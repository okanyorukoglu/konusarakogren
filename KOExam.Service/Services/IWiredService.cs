using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KOExam.Service.Services
{
    public interface IWiredService
    {
        Task<string> getArticleTitle(string Url, string XPath);
        Task<string> getArticleLink(string linkUrl, string xPath, string dip);
        Task<string> getArticleBody(string linkUrl, string linkDevamUrl, string xPath);

        string titleFix(string title);
    }
}
