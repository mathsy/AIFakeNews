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

            var s = client.DownloadString(@"https://stackoverflow.com/questions/7264659/read-text-from-web-page");
            var htmldoc2 = (IHTMLDocument2)new HTMLDocument();
            htmldoc2.write(s);
            var plainText = htmldoc2.body.outerText;
            return plainText;
        }


    }
}
