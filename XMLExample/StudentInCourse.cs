using System;
using System.Collections.Generic;
using System.Text;

namespace XMLExample
{
    namespace DO
    {
        public struct StudentInCourse
        {
            public int CourseId { get; set; }
            public int StudentId { get; set; }
            public float Grade { get; set; }
            public override string ToString()
            {
                return "StudentInCourse--> " + CourseId + " " + StudentId + " " + Grade;
            }
        }
    }
}
