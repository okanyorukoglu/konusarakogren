using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KOExam.Web.Models
{
    public static class WiredEx
    {
        
        public static string GetXpath(string title)
        {
            switch (title)
            {
                case "title1":
                    return "//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[1]/div/ul/li[2]/a[2]"; 
                case "title2":
                    return "//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[1]/div[2]/div/ul/li[2]/a[2]";
                case "title3":
                    return "//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[1]/div/ul/li[2]/a[2]";
                case "title4":
                    return "//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[1]/div[2]/div/ul/li[2]/a[2]";
                case "title5":
                    return "//*[@id='app-root']/div/div[3]/div/div/div[2]/div[1]/div/div[1]/div[2]/div[2]/div/ul/li[2]/a[2]";
                default:
                    // Handle bad URL, possibly throw
                    throw new Exception();
            }
        }

    }
}
