using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace codeSpark_Utility
{
    public class User
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

        public string firstName
        {
            get;
            set;
        }

        public string lastName
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string username
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public string city
        {
            get;
            set;
        }

        public string state
        {
            get;
            set;
        }

        public string country
        {
            get;
            set;
        }

        public string accountType
        {
            get;
            set;
        }

        public bool isAdmin
        {
            get;
            set;
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
            Console.WriteLine(@"firstName: {0}", firstName);
            Console.WriteLine(@"lastName: {0}", lastName);
            Console.WriteLine(@"email: {0}", email);
            Console.WriteLine(@"username: {0}", username);
            Console.WriteLine(@"password: {0}", password);
            Console.WriteLine(@"city: {0}", city);
            Console.WriteLine(@"state: {0}", state);
            Console.WriteLine(@"country: {0}", country);
            Console.WriteLine(@"accountType: {0}", accountType);
            Console.WriteLine(@"isAdmin: {0}", isAdmin);
            Console.WriteLine("");
        }
    }
}
