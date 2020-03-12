using System;
using codeSpark_Utility;

namespace codeSpark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter User ID or User Email:");

            Utility my_Utility = new Utility();

            User user = my_Utility.GetUser(Console.ReadLine());

            if (user != null)
            {
                if (!my_Utility.IsHomeUser(user))
                {
                    Console.WriteLine("***** TEACHER INFO ******");

                    user.DisplayInfo();

                    Console.WriteLine("");

                    Teacher teacher = my_Utility.GetTeacherById(user.id);
                    if (teacher != null)
                    {
                        Console.WriteLine("***** SCHOOL INFO ******");

                        teacher.DisplayInfo();

                        Console.WriteLine("");

                        Console.WriteLine("***** STUDENT INFO ******");

                        my_Utility.DisplayAllStudents(teacher);
                    }
                }
            }
        }
    }
}
