using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KOExam.Service.Services
{
    public class WiredService : IWiredService
    {
        public string html;
        public string link;
        public Uri url;
        public async Task<string> getArticleBody(string linkUrl, string linkDevamUrl, string xPath)
        {
            url = new Uri("" + linkUrl + "" + linkDevamUrl);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            html = await client.DownloadStringTaskAsync(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectSingleNode("" + xPath).InnerText;
             
        }

        public async Task<string> getArticleLink(string linkUrl, string xPath, string dip)
        {
            url = new Uri("" + linkUrl);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            html = await client.DownloadStringTaskAsync(url);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectSingleNode("" + xPath).Attributes[dip].Value;
             
        }

        public async Task<string> getArticleTitle(string Url, string XPath)
        {
            url = new Uri(Url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            html = await client.DownloadStringTaskAsync(url);
             
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectSingleNode(XPath).InnerText;

            
        }

        public string titleFix(string title)
        {
            title = title.Replace("&#8212;", "—"); ;
            title = title.Replace("&#39;", "'");
            title = title.Replace("&amp;", "&");

            return title;
        }
    }
}
