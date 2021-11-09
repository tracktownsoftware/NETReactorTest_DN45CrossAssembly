using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ConsoleAppTest...");
            Library2.PublicClass class1 = new Library2.PublicClass();
            Console.WriteLine(class1.Library1PublicClass_SaySomething());
            Console.WriteLine(class1.Library1InternalClass_SaySomething());
        }
    }
}
