using Trial_Task;

string url = "https://github.com";

SitemapChecker.ParseSitemap(url);
SitemapChecker.Print();
Crawler.ExtractHref(url); //https://seoagilitytools.com https://google.com
Crawler.Print();