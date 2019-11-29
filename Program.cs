using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Xml.Serialization;

namespace LearningProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Piotr\Desktop\Regex.txt";
            var text = File.ReadAllText(path);
            Regex regex = new Regex(@"(\w+)");
            var result =regex.Matches(text);
             Console.ReadKey();
        }
       
    }
}
