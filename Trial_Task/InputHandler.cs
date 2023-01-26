using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Trial_Task
{
    internal static class InputHandler
    {
        internal static string GetInput()
        {      
            Console.WriteLine("Please, enter a web-site address you want to check (http://example.com or https://example.com):");     
            while (true) { 
                
                string? url = Console.ReadLine();
                Console.WriteLine();

                if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))                   
                    return url.TrimEnd(new[] { '/' });
                Console.WriteLine("Input is not correct, your address must be in the format http://example.com or https://example.com:");
            }           
        }
    }
}
