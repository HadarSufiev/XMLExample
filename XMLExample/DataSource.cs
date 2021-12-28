using System;
using System.Collections.Generic;
using System.Text;

namespace XMLExample
{
    namespace DS
    {
        static class DataSource
        {
            public static List<DO.Test> testList;
            public static List<DO.Student> studentList;
            public static List<DO.Course> courseList;
            public static List<DO.StudentInCourse> studentInCourseList;

            static DataSource()
            {
                initLists();

            }
            private static void initLists()
            {
                courseList = new List<DO.Course>();

                string[] courseNameArray = new string[] { "c#", "java", "computerEngeneering", "c++", "infi", "bdida", "programming" };
                for (int i = 0; i < courseNameArray.Length; i++)
                    courseList.Add(new DO.Course { CourseId = i, CourseName = courseNameArray[i] });

                string[] studentNameArray = new string[] { "Avraham", "David", "Shlomi", "Sara", "Orit" };

                int id = -1;

                studentList = new List<DO.Student>()
                { 
                        new DO.Student(){StudentId = ++id ,IsMarried = true ,
                                            PersonDate = DateTime.ParseExact("24.03.85", "dd.MM.yy", null),
                                            PersonName = studentNameArray[id],
                                            StudentGender =  DO.Gender.male },
                        
                    
                        new DO.Student(){ StudentId = ++id ,IsMarried = false ,
                                            PersonDate = DateTime.ParseExact("20.04.95", "dd.MM.yy", null),
                                            PersonName = studentNameArray[id],
                                            StudentGender = DO.Gender.male },
                        new DO.Student {StudentId = ++id ,IsMarried = true ,
                                            PersonDate = DateTime.ParseExact("02.12.77", "dd.MM.yy", null),
                                            PersonName = studentNameArray[id],
                                             StudentGender = DO.Gender.male },
                        new DO.Student {StudentId = ++id ,IsMarried = false ,
                                             PersonDate = DateTime.ParseExact("03.11.87", "dd.MM.yy", null),
                                            PersonName = studentNameArray[id],
                                            StudentGender = DO.Gender.female },
                        new DO.Student {StudentId = ++id ,IsMarried = true ,
                                            PersonDate = DateTime.ParseExact("04.03.67", "dd.MM.yy", null),
                                             PersonName = studentNameArray[id],
                                            StudentGender = DO.Gender.female }
                };

                studentInCourseList = new List<DO.StudentInCourse>();

                var rand = new Random();
                for (int i = 0; i < studentList.Count; i++)
                    studentInCourseList.Add(new DO.StudentInCourse() { StudentId = i, CourseId = rand.Next(0, courseNameArray.Length), Grade = rand.Next(0, 100) });

                //init testList
                testList = new List<DO.Test>()
                {
                  new DO.Test(){ CourseName="aaa", IdTest=1,  TestDate=DateTime.ParseExact("24.03.85", "dd.MM.yy", null) },
                  new DO.Test(){ CourseName="bbb", IdTest=2,  TestDate=DateTime.ParseExact("20.04.85", "dd.MM.yy", null) },
                  new DO.Test(){ CourseName="ccc", IdTest=3,  TestDate=DateTime.ParseExact("17.03.85", "dd.MM.yy", null) },
                  new DO.Test(){ CourseName="ddd", IdTest=4,  TestDate=DateTime.ParseExact("15.08.85", "dd.MM.yy", null) },
                  new DO.Test(){ CourseName="eee", IdTest=5, TestDate=DateTime.ParseExact("22.10.85", "dd.MM.yy", null) }
                };
            }


        }
    }

}
