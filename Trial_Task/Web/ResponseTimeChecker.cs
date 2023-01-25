using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial_Task.Web
{
    static internal class ResponseTimeChecker
    {
        static readonly HttpClient hc = new HttpClient();
        static readonly Stopwatch watch = new Stopwatch();
        static Dictionary<string, long> urlsResponseTime = new Dictionary<string, long>();

        static internal async Task PrintUrlsResponseTimeAsync(List<string> mergedUrls)
        {
            Console.WriteLine("Timing");

            foreach (string link in mergedUrls)
            {
                watch.Start();

                await hc.GetAsync(link);

                watch.Stop();

                urlsResponseTime.Add(link, watch.ElapsedMilliseconds);

                watch.Reset();
            }

            urlsResponseTime = urlsResponseTime.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"{"Url",-75} {"Timing (ms)",8}");

            foreach (var link in urlsResponseTime)
            {
                Console.WriteLine($"{link.Key,-75} {link.Value + " ms",-8}");
            }

            Console.WriteLine();
        }
    }
}
