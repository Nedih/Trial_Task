using cloudscribe.HtmlAgilityPack;

namespace Trial_Task.Web
{
    static internal class Crawler
    {
        static internal List<string> crawlerLinks = new List<string>();
        static private List<string> crawlQueue = new List<string>();
        static private readonly HtmlWeb web = new HtmlWeb();

        static internal void ExtractHref(string URL)
        {
            crawlQueue.Add(URL);
            while(crawlQueue.Count > 0)
                Crawl(crawlQueue[0], URL);
            return;
        }

        static private void Crawl(string URL, string domen)
        {
            string item;
            HtmlDocument doc = new HtmlDocument();
            doc = web.Load(URL);

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (string.IsNullOrEmpty(att.Value))
                    continue;

                item = att.Value.First() == '/' ? domen + att.Value : att.Value;
                if (item.IndexOf("?") > 0)
                    item = item.Substring(0, item.IndexOf("?"));
                item = item.TrimEnd(new[] { '/' });

                if (item.Contains("/") && !crawlerLinks.Contains(item) && item.StartsWith(domen))
                {                
                    crawlerLinks.Add(item);
                    crawlQueue.Add(item);
                }
            }
            crawlQueue.Remove(URL);
        }

            static internal void PrintCount()
        {
            Console.WriteLine($"Urls(html documents) found after crawling a website: {crawlerLinks.Count}");
        }
    }
}
