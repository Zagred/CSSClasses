using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\ppandev\Desktop\bootstrap.css";
            StreamReader txt = new StreamReader(@"C:\Users\ppandev\Desktop\BootstrapClassesInUse.txt");

            List<string> cssClases = new List<string>();
            List<string> isThere = new List<string>();

            string txtLine;

            string fileName = System.IO.File.ReadAllText(path);
            MatchCollection css = Regex.Matches(fileName, @"[^{]*{[^}]*}", RegexOptions.Multiline);
            for (int i = 0; i < css.Count; i++)
            {
                string cls = css[i].Captures[0].ToString().Trim();
                var className = cls.Substring(0, cls.IndexOf("{") - 1).Trim().Replace(":before", "").Replace(":after", "");

                cssClases.Add(className);

            }
            try
            {
                txtLine = txt.ReadLine();
                while (txtLine != null)
                {
                    foreach (string str in cssClases)
                    {
                        if (txtLine == str)
                        {
                            isThere.Add(txtLine);
                        }
                    }

                    txtLine = txt.ReadLine();
                }
                txt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.WriteLine("These are the classes used in the css file");
            foreach (string s in isThere)
            {
                Console.WriteLine(s);
            }
        }
    }
}