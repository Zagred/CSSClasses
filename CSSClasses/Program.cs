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
        public static Dictionary<string, string>  GetCSSClases(string pathCSS)
        {
            Dictionary<string, string> classes = new Dictionary<string, string>();

            string fileName = System.IO.File.ReadAllText(pathCSS);
            MatchCollection css = Regex.Matches(fileName, @"[^{]*{[^}]*}", RegexOptions.Multiline);
            for (int i = 0; i < css.Count; i++)
            {
                string cls = css[i].Captures[0].ToString().Trim();
                var className = cls.Substring(0, cls.IndexOf("{") - 1).Trim().Replace(":before", "").Replace(":after", "");

                try { classes.Add(className, className); } catch { }

            }
            return classes;
        }
        public static void HTMLCLassesUsingCSSFile(Dictionary<string, string> classes, string pathTXT)
        {

            List<string> isThere = new List<string>();
            string txtLine;

            StreamReader txt = new StreamReader(pathTXT);
            try
            {
                txtLine = txt.ReadLine();
                while (txtLine != null)
                {
                    try
                    {
                        classes.Add(txtLine, txtLine);
                    }
                    catch
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

            Console.WriteLine("These are the classes used in the css file");
            foreach (string s in isThere)
            {
                Console.WriteLine(s);
            }
        }
        static void Main(string[] args)
        {
            var pathCSS = @"C:\Users\paco\Desktop\Project\CSSClasses\bootstrap.css";
            var pathTXT = @"C:\Users\paco\Desktop\Project\CSSClasses\BootstrapClassesInUse.txt";

            HTMLCLassesUsingCSSFile(GetCSSClases(pathCSS), pathTXT);

        }
    }
}