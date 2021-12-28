using System;
using System.Collections.Generic;
using System.Text;
using XMLExample.DO;

namespace XMLExample
{
    class DalObject : IDaL
    {
        public void AddStudent(Student stu)
        {
            throw new NotImplementedException();
        }

        public void AddTest(Test test)
        {
            throw new NotImplementedException();
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents(Func<Student, bool> predicat = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> getAllTests()
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Test GetTestById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTest(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student stu)
        {
            throw new NotImplementedException();
        }

        public void UpdateTest(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
