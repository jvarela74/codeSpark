using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace codeSpark_Utility
{
    public class Teacher
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }

        public string id
        {
            get;
            set;
        }

        public string userId
        {
            get;
            set;
        }

        public string schoolDistrict
        {
            get;
            set;
        }

        public string students
        {
            get;
            set;
        }

        public List<string> GetStudentIDsList()
        {
            List<string> result = new List<string>();
            var student_ids = students.Split(',');

            foreach(string s in student_ids)
            {
                if(s.Trim() != "")
                {
                    result.Add(s.Trim());
                }
            }

            return result;
        }

        // **********************************************************************************************
        // DisplayInfo
        //
        // Displays all values for this object in console.
        // **********************************************************************************************
        public void DisplayInfo()
        {
            Console.WriteLine(@"_id: {0}", Id);
            Console.WriteLine(@"id: {0}", id);
            Console.WriteLine(@"userId: {0}", userId);
            Console.WriteLine(@"schoolDistrict: {0}", schoolDistrict);
            Console.WriteLine(@"students: {0}", students);
            Console.WriteLine("");
        }

    }
}
