using System;
using XMLExample.DO;

namespace XMLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example for XML files");

            IDaL dl = FactoryDal.getDal("xml");
            #region StudentFunctions
            dl.AddStudent(new Student() { StudentId = 555, IsMarried = false,
                                            PersonDate = DateTime.ParseExact("02.06.95", "dd.MM.yy", null),
                                            PersonName = "jojo", StudentGender = DO.Gender.male });

            foreach (var item in dl.GetAllStudents())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("deleteing student 555...");
            dl.DeleteStudent(555);

            foreach (var item in dl.GetAllStudents())
            {
                Console.WriteLine(item);
            }

            #endregion

            #region TestFunctions
            //dl.DeleteStudent(1); try to delete students with courses 
            Console.WriteLine("-------------tests----------------------");
            foreach (var item in dl.getAllTests())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("test 4 : " + dl.GetTestById(4));

            dl.AddTest(new Test() { IdTest = 999, CourseName = "newone", TestDate = DateTime.ParseExact("23.05.96", "dd.MM.yy", null) });
            Console.WriteLine("-------------after adding test 999 -------------");
            foreach (var item in dl.getAllTests())
            {
                Console.WriteLine(item);
            }

            bool succeed = dl.RemoveTest(4);
            if (succeed == true)
            {
                Console.WriteLine("-------------after remove test 4 -------------");
                foreach (var item in dl.getAllTests())
                {
                    Console.WriteLine(item);
                }
            }
            else Console.WriteLine("cannot delete test 4, it is not found..");

            dl.UpdateTest(new Test() { IdTest = 999, CourseName = "oldone", TestDate = DateTime.ParseExact("24.05.96", "dd.MM.yy", null) });
            Console.WriteLine("-------------after updating test 999 -------------");
            foreach (var item in dl.getAllTests())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            #endregion
        }
    }
}
