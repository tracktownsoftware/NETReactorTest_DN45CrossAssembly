using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library2
{
    public class PublicClass
    {
        public string Library1InternalClass_SaySomething()
        {
            var internalClass = new Library1.InternalClass();
            return internalClass.SaySomething();
        }

        public string Library1PublicClass_SaySomething()
        {
            var publicClass = new Library1.PublicClass();
            return publicClass.SaySomething();
        }
    }
}
