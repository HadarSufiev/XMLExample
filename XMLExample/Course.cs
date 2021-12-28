using System;
using System.Collections.Generic;
using System.Text;

namespace XMLExample
{
    namespace DO
    {
        public struct Course
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public override string ToString()
            {
                return "Course--> "+CourseId + " " + CourseName;
            }

        }
        
    }
}
