using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace codeSpark_Utility
{
    public class Student
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

        public string first_name
        {
            get;
            set;
        }

        public string last_name
        {
            get;
            set;
        }

        public string gender
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
            Console.WriteLine(@"first_name: {0}", first_name);
            Console.WriteLine(@"last_name: {0}", last_name);
            Console.WriteLine(@"gender: {0}", gender);
            Console.WriteLine("");
        }
    }
}
