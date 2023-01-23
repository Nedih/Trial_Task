using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;

namespace Trial_Task
{
    static internal class SitemapChecker
    {
        static internal List<string> sitemapLinks = new List<string>();
        static private WebClient wc = new WebClient();

        static internal void ParseSitemap(string URL)
        {
            string sitemapURL = URL + "/sitemap.xml";
            wc.Encoding = System.Text.Encoding.UTF8;
            XmlDocument urldoc = new XmlDocument();
            try {
                string sitemapString = wc.DownloadString(sitemapURL);
                urldoc.LoadXml(sitemapString);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            XmlNodeList xmlSitemapList = urldoc.GetElementsByTagName("url");

            sitemapLinks.Clear();

            foreach (XmlNode node in xmlSitemapList)
            {
                if (node["loc"] != null && !sitemapLinks.Contains(node["loc"].InnerText))
                {
                    sitemapLinks.Add(node["loc"].InnerText);
                }
            }
        }

        static internal void PrintCount()
        {
            Console.WriteLine($"Urls found in sitemap: {sitemapLinks.Count}");
        }
    }
}
