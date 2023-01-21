using cloudscribe.HtmlAgilityPack;

ExtractHref("https://google.com");
static void ExtractHref(string URL)
{
    List<string> sitemapLinks = new List<string>();
    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = new HtmlDocument();
    doc = web.Load(URL);

    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
    {
        HtmlAttribute att = link.Attributes["href"];


        //Console.WriteLine(att.Value);
        string item = att.Value[0] == '/' ? (URL + att.Value) : att.Value;
        if (att.Value.Contains("/") && !sitemapLinks.Contains(item))
        {
            sitemapLinks.Add(item);
            Console.WriteLine(item);
        }
    }
}