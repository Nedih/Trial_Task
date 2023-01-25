﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;

namespace Trial_Task.Web
{
    static internal class SitemapChecker
    {
        static internal List<string> sitemapLinks = new List<string>();
        static private HttpClient hc = new HttpClient();
        static readonly List<string> sitemapAddresses = new List<string> { "/sitemap.xml", "/sitemap_index.xml", "/sitemapindex.xml", "/sitemap/index.xml", "/sitemap1.xml" };

        static internal async Task ParseSitemapAsync(string URL)
        {
            string sitemapString, sitemapURL = "";
            XmlDocument urldoc = new XmlDocument();

            sitemapLinks.Clear();

            foreach (string link in sitemapAddresses)
            {
                try
                {
                    sitemapURL = URL + link;
                    sitemapString = await hc.GetStringAsync(sitemapURL);
                    urldoc.LoadXml(sitemapString);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{sitemapURL} - {e.Message}");
                }

            }

            XmlNodeList xmlSitemapList = urldoc.GetElementsByTagName("url");

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