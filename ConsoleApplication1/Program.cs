using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            String []arr = SerialPort.GetPortNames();
            foreach (String s in arr)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
