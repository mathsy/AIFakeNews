using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using mshtml;

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

        public static IEnumerator<IHTMLElement> linksfromwebsite(string website)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument doc = hw.Load(/* url */);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {

            }

        }


    }
}
