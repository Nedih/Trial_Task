using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_Task
{
    internal static class Printer
    {
        internal static void Print(IEnumerable<string> list)
        {
            foreach(var item in list) 
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
