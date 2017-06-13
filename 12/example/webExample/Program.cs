using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace webExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string Word = "internet";
            Console.WriteLine("Getting Definition for " + Word + "...");
            Console.WriteLine(getDefinition_DictionaryCom_PageCrawl(Word));

            Console.WriteLine();


            string City = "Beersheba";
            Console.WriteLine("Getting Current Temperature for " + City + "...");
            Console.WriteLine(getTemperature_OWM_API(City, "metric"));
            Console.WriteLine();


            Console.WriteLine("Done.");
            Console.ReadLine();

        }


        public static string getDefinition_DictionaryCom_PageCrawl(string word)
        {
            try
            {
                //start web client and load page HTML
                WebClient myClient = new WebClient();
                string result = myClient.DownloadString("http://dictionary.reference.com/browse/" + word + "?s=ts");

                //search for content of our tags using a REGEX
                string startTag = "meta name=\"description\" content=\"";
                string endTag = " See More";
                string definition = ParseBetween(result, startTag, endTag);
                definition = definition.Substring(0, definition.Length - endTag.Length);//remove the ending "See more"

                return definition;
            }
            catch (Exception e1)
            {
                Console.WriteLine("could not get the definition");
                return "";
            }

        }

        //returns all content between two strings
        public static string ParseBetween(string Subject, string Start, string End)
        {
            return Regex.Match(Subject, Regex.Replace(Start, @"[][{}()*+?.\\^$|]", @"\$0") + @"\s*(((?!" + Regex.Replace(Start, @"[][{}()*+?.\\^$|]", @"\$0") + @"|" + Regex.Replace(End, @"[][{}()*+?.\\^$|]", @"\$0") + @").)+)\s*" + Regex.Replace(End, @"[][{}()*+?.\\^$|]", @"\$0"), RegexOptions.IgnoreCase).Value.Replace(Start, "").Replace(End, "");
        }


        public static string getTemperature_OWM_API(string city, string unit)
        {
            try
            {
                string m_strFilePath = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&units=" + unit + "&APPID=bd5e378503939ddaee76f12ad7a97608";//URL to API (including request)
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(m_strFilePath); // load the web service's reply -XML

                XmlNode node = myXmlDocument.DocumentElement.ChildNodes[1];// //look for sub node <temperature/>
                if (node != null)
                    if (node.Attributes != null)
                        return node.Attributes["value"].Value + " " + node.Attributes["unit"].InnerText;//get node's value for the tempurature

                return "";// if failed

            }
            catch (Exception e2)
            {
                Console.WriteLine("could not get the weather");
                return "";
            }
        }
    }
}
