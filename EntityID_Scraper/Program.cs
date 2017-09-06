using System;
using System.Collections.Generic;
using System.IO;

namespace EntityID_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Path:");
            string filePath = Console.ReadLine();

            //Print(ScrapeID(filePath));
            Print(ScrapeElements(filePath));
            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        static List<string> ScrapeID(string filePath)
        {
            List<string> entityIDs = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] line;
                 
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(':');

                    if (line[0].Equals("- id"))
                    {
                        string id = line[1].Trim();
                        if (entityIDs.Contains(id) == false)
                            entityIDs.Add(id);
                    }
                }
            }

            return entityIDs;
        }
        static List<string> ScrapeElements(string filePath)
        {
            List<string> elements = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] line;

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Split(':');

                    if (line[0].Equals("- element"))
                    {
                        string id = line[1].Trim();
                        if (elements.Contains(id) == false)
                            elements.Add(id);
                    }
                }
            }

            return elements;
        }

        static void Print(List<string> data)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Odin\Desktop\" + DateTime.Today.Hour + "ONIData.txt"))
            {
                foreach (string s in data)
                    writer.WriteLine(s + ",");
            }
        }
    }
}
