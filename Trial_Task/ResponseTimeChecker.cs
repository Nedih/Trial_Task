using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_Task
{
    static internal class ResponseTimeChecker
    {
        static HttpClient hc = new HttpClient();
        static Stopwatch watch = new Stopwatch();
        static Dictionary<string, long> urlsResponseTime = new Dictionary<string, long>();

        static internal void PrintUrlsResponseTime(List<string> mergedUrls)
        {
            Console.WriteLine("Timing");

            foreach (string link in mergedUrls)
            {

                watch.Start();

                var request = hc.GetAsync(link);
                using (HttpResponseMessage response = request.Result)
                {
                    watch.Stop();
                    urlsResponseTime.Add(link, watch.ElapsedMilliseconds);
                }

                watch.Reset();
            }

            urlsResponseTime = urlsResponseTime.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{"Url", -75} {"Timing (ms)", 8}");

            foreach (var link in urlsResponseTime)
            {
                Console.WriteLine($"{link.Key, -75} {link.Value + " ms", -8}");
            }

            Console.WriteLine();
        }
    }
}
