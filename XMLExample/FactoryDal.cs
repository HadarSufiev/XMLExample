using System;
using System.Collections.Generic;
using System.Text;

namespace XMLExample
{
    class FactoryDal
    {
        public static IDaL getDal(string type)
        {
            switch (type)
            {
                case "xml":
                    return new DLXML();   
                case "list":
                    return new DalObject();
                default: throw new Exception();
            }
        }
    }
}
