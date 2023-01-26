using cloudscribe.HtmlAgilityPack;

namespace Trial_Task.Web
{
    static internal class Crawler
    {
        static internal List<string> crawlerLinks = new List<string>();
        static private readonly HtmlWeb web = new HtmlWeb();
        static private HtmlDocument doc = new HtmlDocument();

        static internal void ExtractHref(string URL)
        {
            doc = web.Load(URL);
            string item;

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (string.IsNullOrEmpty(att.Value))
                    continue;

                item = att.Value.First() == '/' ? URL + att.Value : att.Value;

                if (item.Contains("/") && !crawlerLinks.Contains(item))
                    crawlerLinks.Add(item);
            }
        }

        static internal void PrintCount()
        {
            Console.WriteLine($"Urls(html documents) found after crawling a website: {crawlerLinks.Count}");
        }
    }
}
