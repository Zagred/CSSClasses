using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Web;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\ppandev\Desktop\bootstrap.css";
            string fileName = System.IO.File.ReadAllText(path);
            MatchCollection mt = Regex.Matches(fileName, @"[^}]?([^{]*{[^}]*})", RegexOptions.Multiline);
            List<string> list = new List<string>();
            List<string> isNotThere = new List<string>();
            bool isThere = false;
            for (int i = 0; i < mt.Count; i++)
            {
                string cls = mt[i].Captures[0].ToString().Trim();
                var className = cls.Substring(1, cls.IndexOf("{") - 1).Trim().Replace(":before", "").Replace(":after", "");

                list.Add(className);

            }
            Console.WriteLine("---------------------------------");
            using (StreamReader reader = new StreamReader(@"C:\Users\ppandev\Desktop\BootstrapClassesInUse.txt"))
            {
                string line;
                foreach (var item in list)
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == item)
                        {
                            isThere = true;
                        }

                    }
                    if (isThere == false)
                    {
                        isNotThere.Add(item);
                    }
                }
            }
            foreach (var item in isNotThere)
            {
                Console.WriteLine(item);
            }
            for (; ; ) { }
        }
    }
}
