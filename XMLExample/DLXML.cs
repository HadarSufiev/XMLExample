using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace XMLExample
{
    class DLXML : IDaL
    {
        //dir need to be up from bin
        static string dir = @"..\..\..\..\xmlData\";
        static DLXML()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }
      
        string testFilePath = @"TestList.xml";
        string studentFilePath = @"StudentsList.xml";
        string courseFilePath = @"CoursesList.xml";
        string studentInCourseFilePath = @"StudentInCourseList.xml";

        public DLXML()
        {
            if (!File.Exists(dir + studentFilePath))
                DL.XMLTools.SaveListToXMLSerializer<DO.Student>(DS.DataSource.studentList, dir + studentFilePath);

            if (!File.Exists(dir + courseFilePath))
                DL.XMLTools.SaveListToXMLSerializer<DO.Course>(DS.DataSource.courseList, dir + courseFilePath);

            if (!File.Exists(dir + studentInCourseFilePath))
                DL.XMLTools.SaveListToXMLSerializer<DO.StudentInCourse>(DS.DataSource.studentInCourseList, dir + studentInCourseFilePath);

            if (!File.Exists(dir + testFilePath))
                DL.XMLTools.SaveListToXMLSerializer<DO.Test>(DS.DataSource.testList, dir + testFilePath);

          
        }
      

        

        #region Student
        public void AddStudent(DO.Student stu)
        {
            List<DO.Student> studentList = DL.XMLTools.LoadListFromXMLSerializer<DO.Student>(dir + studentFilePath);
            if(studentList.Exists(t => t.StudentId == stu.StudentId))
            {
                 throw new Exception("DL: Student with the same id already exists...");
                //throw new SomeException("DL: Student with the same id already exists...");
            }

            DO.Student stu1 = studentList.Find(t => t.StudentId == stu.StudentId);            
            studentList.Add(stu);

            DL.XMLTools.SaveListToXMLSerializer<DO.Student>(studentList, dir + studentFilePath);
        }
        public void DeleteStudent(int id)
        {
            List<DO.Student> studentList = DL.XMLTools.LoadListFromXMLSerializer<DO.Student>(dir + studentFilePath);
            if (!studentList.Exists(t => t.StudentId == id))
            {
                throw new Exception("DL: Student with the same id not found...");
                //throw new SomeException("DL: Student with the same id not found...");
            }

            DO.Student stu1 = GetStudent(id);

            List<DO.StudentInCourse> studentInCourseList = DL.XMLTools.LoadListFromXMLSerializer<DO.StudentInCourse>(dir + studentInCourseFilePath);

            if (studentInCourseList.Exists(s => s.StudentId == id))
            {
                throw new Exception("DL: cannot delete student, courses for this student still exist !!!");
                //    throw new SomeException("DL: cannot delete student, courses for this student still exist !!!");
            }

            studentList.Remove(stu1);

            DL.XMLTools.SaveListToXMLSerializer<DO.Student>(studentList, dir + studentFilePath);
        }
        public void UpdateStudent(DO.Student stu)
        {
            List<DO.Student> studentList = DL.XMLTools.LoadListFromXMLSerializer<DO.Student>(dir + studentFilePath);

            int index = studentList.FindIndex(t => t.StudentId == stu.StudentId);

            if (index == -1)
                throw new Exception("DAL: Student with the same id not found...");

            studentList[index] = stu;

            DL.XMLTools.SaveListToXMLSerializer<DO.Student>(studentList, dir + studentFilePath);
        }
        public DO.Student GetStudent(int id)
        {
            List<DO.Student> studentList = DL.XMLTools.LoadListFromXMLSerializer<DO.Student>(dir + studentFilePath);
            int index = studentList.FindIndex(t => t.StudentId == id);
            if (index == -1)
                throw new Exception("DAL: Student with the same id not found...");
            return studentList.Find(t => t.StudentId == id);
        }
        public IEnumerable<DO.Student> GetAllStudents(Func<DO.Student, bool> predicat = null)
        {
            List<DO.Student> studentList = DL.XMLTools.LoadListFromXMLSerializer<DO.Student>(dir + studentFilePath);
            
            var v = from item in studentList
                    select item; 

            if (predicat == null)
                return v.AsEnumerable().OrderByDescending(s => s.StudentId);

            return v.Where(predicat).OrderByDescending(s => s.StudentId);
        }


        #endregion

        #region Test
        public IEnumerable<DO.Test> getAllTests()
        {
            
                XElement testRoot = DL.XMLTools.LoadData(dir + testFilePath);
                List<DO.Test> allTests;
                try
                {
                    allTests = (from p in testRoot.Elements()
                                select new DO.Test()
                                {
                                    IdTest = Convert.ToInt32(p.Element("IdTest").Value),
                                    CourseName = p.Element("CourseName").Value,
                                    TestDate = Convert.ToDateTime(p.Element("TestDate").Value)      
                                }).ToList();
                }
                catch
                {
                    allTests = null;
                }
            return allTests;
        }

        public DO.Test GetTestById(int id)
        {
            XElement testRoot = DL.XMLTools.LoadData(dir + testFilePath);
            DO.Test t = new DO.Test();
            try
            {
                t = (from p in testRoot.Elements()
                           where Convert.ToInt32(p.Element("IdTest").Value) == id
                           select new DO.Test()
                           {
                               IdTest = Convert.ToInt32(p.Element("IdTest").Value),
                               CourseName = p.Element("CourseName").Value,
                               TestDate = Convert.ToDateTime(p.Element("TestDate").Value)           
                           }).FirstOrDefault();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return t;
        }

        public void AddTest(DO.Test test)
        {
            XElement testRoot = DL.XMLTools.LoadData(dir + testFilePath);
            XElement testElement;
            testElement = (from p in testRoot.Elements()
                           where Convert.ToInt32(p.Element("IdTest").Value) == test.IdTest
                           select p).FirstOrDefault();
            if (testElement==null)
            {
                XElement IdTest = new XElement("IdTest", test.IdTest);
                XElement CourseName = new XElement("CourseName", test.CourseName);
                XElement TestDate = new XElement("TestDate", test.TestDate.ToString("O"));
                testRoot.Add(new XElement("test", IdTest, CourseName, TestDate));
                testRoot.Save(dir + testFilePath);
            }
            else
            {
                Console.WriteLine("cannot adding test with id " + test.IdTest +  "...");
            }
        }

        public bool RemoveTest(int id)
        {
            XElement testRoot = DL.XMLTools.LoadData(dir + testFilePath);
            XElement testElement;
            try
            {
                testElement = (from p in testRoot.Elements()
                                  where Convert.ToInt32(p.Element("IdTest").Value) == id
                                  select p).FirstOrDefault();
                if (testElement != null)
                {
                    testElement.Remove();
                    testRoot.Save(dir + testFilePath);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateTest(DO.Test test)
        {
            XElement testRoot = DL.XMLTools.LoadData(dir + testFilePath);
            XElement testElement = (from p in testRoot.Elements()
                                       where Convert.ToInt32(p.Element("IdTest").Value) == test.IdTest
                                       select p).FirstOrDefault();
            testElement.Element("CourseName").Value = test.CourseName;
            testElement.Element("TestDate").Value = test.TestDate.ToString();
            testRoot.Save(dir + testFilePath);
        }

    }
    #endregion
}
