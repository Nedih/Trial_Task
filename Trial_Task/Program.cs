using System.Diagnostics;
using System.Linq;
using System.Net;
using Trial_Task;

string url = "https://seoagilitytools.com";

await SitemapChecker.ParseSitemapAsync(url);
Crawler.ExtractHref(url); //https://seoagilitytools.com https://google.com https://github.com

List<string> mergedUrls = Crawler.crawlerLinks.Union(SitemapChecker.sitemapLinks).ToList();

Console.WriteLine("Urls FOUNDED IN SITEMAP.XML but not founded after crawling a web site\nUrl");
Printer.Print(SitemapChecker.sitemapLinks.Except(Crawler.crawlerLinks).ToList());

Console.WriteLine("Urls FOUNDED BY CRAWLING THE WEBSITE but not in sitemap.xml\nUrl");
Printer.Print(Crawler.crawlerLinks.Except(SitemapChecker.sitemapLinks).ToList());

ResponseTimeChecker.PrintUrlsResponseTime(mergedUrls);

Crawler.PrintCount();
SitemapChecker.PrintCount();   