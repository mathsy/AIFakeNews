using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using mshtml;
using HtmlAgilityPack;

namespace AIFakeNews
{
    public class WebManager
    {

       public static string textfromwebsite(string website)
        {

            var client = new WebClient();

            var s = client.DownloadString(website);
            var htmldoc2 = (IHTMLDocument2)new HTMLDocument();
            htmldoc2.write(s);
            var plainText = htmldoc2.body.outerText;
            return plainText;
        }

        public static List<string> linksfromwebsite(string website)
        {
            List<string> hrefTags = new List<string>();
            HtmlDocument htmlSnippet = new HtmlDocument();
            var client = new WebClient();
            var s = client.DownloadString(website);
            htmlSnippet.LoadHtml(s);
            foreach (HtmlNode link in htmlSnippet.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                if (att.Value.StartsWith("http"))
                {
                    hrefTags.Add(att.Value);
                }
            }

            return hrefTags;
        }


    }
}
