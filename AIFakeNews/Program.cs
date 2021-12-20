﻿using System;


namespace AIFakeNews
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WebManager.textfromwebsite(@"https:\\de.wikipedia.org"));
            foreach(string s in WebManager.linksfromwebsite(@"https:\\de.wikipedia.org"))
            {
                Console.WriteLine(s);
            }

            TopicalAI.start_AI(true);
            TopicalAI.start_AI(false);
            Console.ReadLine();

        }

       
    }
}
