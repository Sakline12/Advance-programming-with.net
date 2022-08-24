using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = Student_Services.Get();
            foreach (var item in data)
            {
                Console.WriteLine("{0} -- {1} -- {2} -- {3}",item.Id,item.Name,item.Fname,item.CGPA);
            }
        }
    }
}
