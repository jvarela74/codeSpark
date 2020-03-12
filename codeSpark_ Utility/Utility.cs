using System;
using System.Text.RegularExpressions;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace codeSpark_Utility
{
    public class Utility
    {
        private MongoClient client;
        private IMongoDatabase db;
        private const bool enable_logging = false;

        #region MongoDB
        private const string CONNECTION_STRING = "mongodb://localhost:27017";
        private const string DATABASE = "codespark";
        private const string USER_COLLECTION = "user";
        private const string TEACHER_COLLECTION = "teacher";
        private const string STUDENT_COLLECTION = "student";
        #endregion

        #region ACCOUNT_TYPE
        private const string HOME_ACCOUNT_TYPE = "home";
        private const string TEACHER_ACCOUNT_TYPE = "teacher";
        #endregion

        #region MESSAGES
        private const string MESSAGE_IS_HOME_USER = "Sorry, this user is not a teacher";
        private const string MESSAGE_IS_TEACHER = "This user is a teacher";
        private const string MESSAGE_ACCOUNT_TYPE_UNKNOWN = "Sorry, account type unknown";
        private const string MESSAGE_USER_NOT_IN_COLLECTION = "Sorry, cannot find user in collection";
        private const string MESSAGE_TEACHER_NOT_IN_COLLECTION = "Sorry, cannot find teacher in collection";
        private const string MESSAGE_STUDENT_NOT_IN_COLLECTION = "Sorry, cannot find student in collection";
        private const string MESSAGE_USER_IS_NULL = "Sorry, user is NULL";
        private const string MESSAGE_TEACHER_IS_NULL = "Sorry, teacher is NULL";
        private const string MESSAGE_STUDENT_IS_NULL = "Sorry, student is NULL";
        #endregion

        public Utility()
        {
            Logger.Log("Initializing Utility...", enable_logging);
            client = new MongoClient(CONNECTION_STRING);
            db = client.GetDatabase(DATABASE);
        }


        #region USER
        // **********************************************************************************************
        // GetUser
        //
        // Returns User based on the string argument 'user_search_identifier'
        // user_search_identifier format is examined based on basic RegEx match
        // Once the format has been determined a filter is created.
        // The filter is used to find the first User that matches the criteria.
        // **********************************************************************************************
        public User GetUser(string user_search_identifier)
        {
            User user = null;
            FilterDefinition<User> filter = Builders<User>.Filter.Empty;

            IMongoCollection<User> collection = db.GetCollection<User>(USER_COLLECTION);

            if (Regex.IsMatch(user_search_identifier, @"^\d+$"))
            {
                Logger.Log(String.Format("Searching by user ID: {0}", user_search_identifier), enable_logging);
                filter = Builders<User>.Filter.Eq("id", user_search_identifier);
            }
            else if(Regex.IsMatch(user_search_identifier, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                Logger.Log(String.Format("Searching by user Email: {0}", user_search_identifier), enable_logging);
                filter = Builders<User>.Filter.Eq("email", user_search_identifier);
            }
            else
            {
                Logger.Log(String.Format(@"{0} not user ID or user Email format!", user_search_identifier), enable_logging);
            }

            if (filter != Builders<User>.Filter.Empty)
            {
                user = collection.Find(filter).FirstOrDefault();
            }

            if(user == null)
            {
                Logger.Log(MESSAGE_USER_NOT_IN_COLLECTION);
            }


            return user;
        }

        // **********************************************************************************************
        // IsHomeUser
        //
        // Determines if the passed User is a Home account type or a Teacher account type.
        // Account type is pulled from user accountType field.
        // The account type is displayed in the console.
        // **********************************************************************************************
        public bool IsHomeUser(User user)
        {
            bool result = false;
            if (user != null)
            {
                if (user.accountType.ToLower() == HOME_ACCOUNT_TYPE.ToLower())
                {
                    Logger.Log(MESSAGE_IS_HOME_USER, true);
                    result = true;
                }
                else if (user.accountType.ToLower() == TEACHER_ACCOUNT_TYPE.ToLower())
                {
                    Logger.Log(MESSAGE_IS_TEACHER, enable_logging);
                }
                else
                {
                    Logger.Log(MESSAGE_ACCOUNT_TYPE_UNKNOWN, enable_logging);
                }
            }
            else
            {
                Logger.Log(MESSAGE_USER_IS_NULL, enable_logging);
            }

            return result;
        }
        #endregion

        #region TEACHER
        // **********************************************************************************************
        // GetTeacherById
        //
        // Returns Teacher based on userId NOT id!!!
        // **********************************************************************************************
        public Teacher GetTeacherById(string id)
        {
            Teacher teacher = null;
 
            var filter = Builders<Teacher>.Filter.Eq("userId", id);

            IMongoCollection<Teacher> collection = db.GetCollection<Teacher>(TEACHER_COLLECTION);
            teacher = collection.Find(filter).FirstOrDefault();

            if (teacher == null)
            {
                Logger.Log(MESSAGE_TEACHER_NOT_IN_COLLECTION);
            }

            return teacher;
        }

        // **********************************************************************************************
        // DisplayAllStudents
        //
        // This displays the fields for each Student associated with the Teacher 
        // The list of student ids is pulled from the students field for the passed teacher parameter
        // The list of student ids is then used as a filter in the function GetStudentsByIds
        // **********************************************************************************************
        public void DisplayAllStudents(Teacher teacher)
        {
            List<Student> student_list = GetStudentsByIds(teacher.GetStudentIDsList());

            foreach (Student s in student_list)
            {
                s.DisplayInfo();
            }
        }
        #endregion

        #region STUDENT
        // **********************************************************************************************
        // GetStudentById
        //
        // Returns single Student from the student collection whose id matches the passed id parameter.
        // This function makes one call to the collection.
        // **********************************************************************************************
        public Student GetStudentById(string id)
        {
            Student student = null;
         
            var filter = Builders<Student>.Filter.Eq("id", id);

            IMongoCollection<Student> collection = db.GetCollection<Student>(STUDENT_COLLECTION);
            student = collection.Find(filter).FirstOrDefault();
            
            if (student == null)
            {
                Logger.Log(MESSAGE_STUDENT_NOT_IN_COLLECTION);
            }

            return student;
        }

        // **********************************************************************************************
        // GetStudentsByIds
        //
        // Returns all Students from the student collection whose id is contained in the passed ids list.
        // This function makes one call to the collection.
        // **********************************************************************************************
        public List<Student> GetStudentsByIds(List<String> ids)
        {
            var filter = Builders<Student>.Filter.In(x => x.id, ids);

            IMongoCollection<Student> collection = db.GetCollection<Student>(STUDENT_COLLECTION);
            var students = collection.Find(filter).ToList();

            return students;
        }
        #endregion
    }
}
