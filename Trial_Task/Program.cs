using Trial_Task;
using Trial_Task.Web;

string url = InputHandler.GetInput();

await SitemapChecker.ParseSitemapAsync(url);
Crawler.ExtractHref(url); //https://seoagilitytools.com https://google.com 

List<string> mergedUrls = Crawler.crawlerLinks.Union(SitemapChecker.sitemapLinks).ToList();

if (SitemapChecker.sitemapLinks.Count > 0)
{
    Console.WriteLine("Urls FOUNDED IN SITEMAP.XML but not founded after crawling a web site\nUrl");
    Printer.Print(SitemapChecker.sitemapLinks.Except(Crawler.crawlerLinks).ToList());
} 
else{
    Console.WriteLine("Urls NOT FOUND IN SITEMAP.XML\n");
}

if (Crawler.crawlerLinks.Count > 0)
{
    Console.WriteLine("Urls FOUNDED BY CRAWLING THE WEBSITE but not in sitemap.xml\nUrl");
    Printer.Print(Crawler.crawlerLinks.Except(SitemapChecker.sitemapLinks).ToList());
}
else
{
    Console.WriteLine("Urls NOT FOUND BY CRAWLING THE WEBSITE\n");
}

await ResponseTimeChecker.PrintUrlsResponseTimeAsync(mergedUrls);

Crawler.PrintCount();
SitemapChecker.PrintCount();   