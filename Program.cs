using System;
using System.Net;
using Newtonsoft.Json;

namespace Group_Funds_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Gosty-wosty Group Funds Scraper";
            int roEarned = 0;
            int groupsScraped = 0;

            Console.WriteLine("hey HOTTIE, type in 'sexy' to start the group finder");

            string answer = Console.ReadLine();

            if(answer == "sexy")
            {
                Console.WriteLine("starting you fucking cunt...");
            }
            else
            {
                Console.WriteLine("haha u fucked up, pres a key to exit...");
                Console.ReadKey();
                
            }

            while (true)
            {
                try
                {
                    var thing = new Random();

                    int num = thing.Next(1, 999999);
                    WebClient wc = new WebClient();
                    dynamic json = JsonConvert.DeserializeObject(wc.DownloadString(string.Format("https://groups.roblox.com/v1/groups/{0}", num)));
                    if (json.owner == null)
                    {
                        dynamic json2 = JsonConvert.DeserializeObject(wc.DownloadString(string.Format("https://economy.roblox.com/v1/groups/{0}/currency", num)));
                        if (json2.robux != 0)
                        {
                            groupsScraped = groupsScraped + 1;
                            roEarned = roEarned + json2.robux;
                            Console.Title = ("Gosty-wosty Group Funds Scraper | Groups Scraped: " + groupsScraped + " | Robux Earned: " + roEarned);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Found Robux In Group: " + num);
                            Console.ForegroundColor = ConsoleColor.White;

                            using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(System.AppContext.BaseDirectory + @"Robux.txt"))
                            { 
                                file.WriteLine("\n" + num);
                            }
                        }
                        else
                        {
                                groupsScraped = groupsScraped + 1;
                            Console.Title = ("Gosty-wosty Group Funds Scraper | Groups Scraped: " + groupsScraped + " | Robux Earned: " + roEarned);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No Robux Found In Group: " + num);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (json == null)
                    {
                            groupsScraped = groupsScraped + 1;
                        Console.Title = ("Gosty-wosty Group Funds Scraper | Groups Scraped: " + groupsScraped + " | Robux Earned: " + roEarned);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Robux Found In Group: " + num);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        groupsScraped = groupsScraped + 1;
                        Console.Title = ("Gosty-wosty Group Funds Scraper | Groups Scraped: " + groupsScraped + " | Robux Earned: " + roEarned);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No Robux Found In Group: " + num);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                catch (Exception ex)
                {
                    groupsScraped = groupsScraped + 1;
                    Console.Title = ("Gosty-wosty Group Funds Scraper | Groups Scraped: " + groupsScraped + " | Robux Earned: " + roEarned);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ouch?? | Reason: " + ex);
                }
            }
        }
    }
}
