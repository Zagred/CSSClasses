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
using HtmlAgilityPack;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\paco\Desktop\Project\CSSClasses\bootstrap.css";
            StreamReader txt = new StreamReader("C:\\Users\\paco\\Desktop\\Project\\CSSClasses\\BootstrapClassesInUse.txt");

            List<string> isThere = new List<string>();

            string txtLine;
            var doc = new HtmlDocument();
            doc.LoadHtml(path);
            try
            {
                txtLine = txt.ReadLine();
                while (txtLine != null)
                {
                    var isExist = doc.DocumentNode.Descendants(txtLine).Any();
                    if (isExist)
                    {
                        isThere.Add(txtLine);
                    }
                    txtLine = txt.ReadLine();
                }
                txt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.WriteLine("These are the classes are used in css file");
            foreach (string s in isThere)
            {
                Console.WriteLine(s);
            }
        }
    }
}
