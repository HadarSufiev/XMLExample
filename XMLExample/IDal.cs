using System;
using System.Collections.Generic;
using System.Text;
using XMLExample.DO;

namespace XMLExample
{
    interface IDaL
    {
        #region Student
        void AddStudent(DO.Student stu);
        void DeleteStudent(int id);
        void UpdateStudent(DO.Student stu);
        DO.Student GetStudent(int id);
        IEnumerable<DO.Student> GetAllStudents(Func<DO.Student, bool> predicat = null);

        #endregion

        #region Test
        IEnumerable<DO.Test> getAllTests();
        DO.Test GetTestById(int id);
        void AddTest(DO.Test test);
        bool RemoveTest(int id);
        void UpdateTest(DO.Test test);

        #endregion
    }
}
