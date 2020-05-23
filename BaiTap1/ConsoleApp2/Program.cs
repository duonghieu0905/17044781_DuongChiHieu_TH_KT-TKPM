using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = new ConvertXML<eBenhNhan>().O2XML(new eBenhNhan { DIACHI = "123", HOTEN = "123", MSBN = "123", SOCMND = "123" });
            eBenhNhan e = new ConvertXML<eBenhNhan>().XML2O(x);
            Console.WriteLine(x);
            Console.WriteLine(e.SOCMND);
            Console.ReadKey();
        }
    }
}
