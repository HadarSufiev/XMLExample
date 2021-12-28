using System;
using System.Collections.Generic;
using System.Text;

namespace XMLExample
{
    namespace DO
    {
        public struct Test
        {
            public int IdTest { get; set; }
            public string CourseName { get; set; }
            public DateTime TestDate { get; set; }
            

            public override string ToString()
            {
                return "Test--> " + IdTest + " " + CourseName +
                    " " + TestDate ;
            }

        }
    }
}
