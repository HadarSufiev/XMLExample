using System;
using System.Collections.Generic;
using System.Text;

namespace XMLExample
{
    namespace DO
    {
        public struct Student
        {
            public int StudentId { get; set; }
            public string PersonName { get; set; }
            public bool IsMarried { get; set; }
            public DateTime PersonDate { get; set; }
            public Gender StudentGender { get; set; }
            public override string ToString()
            {
                return "Student--> " + StudentId + " " + PersonName +
                    " " + IsMarried + " " + PersonDate + " " + StudentGender;
            }
        }
    }
}
