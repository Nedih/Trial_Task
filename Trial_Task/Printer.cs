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
            if(list.Count() == 0)
            {
                Console.WriteLine("No URLs");
            }

            foreach(var item in list) 
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
