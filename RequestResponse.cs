using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LearningProject
{
    class RequestResponse
    {
        async static void GetRequest(string url)
        {

            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    using (var content = response.Content)
                    {

                        var myContent = await content.ReadAsByteArrayAsync();


                    }


                }

            }

        }
        public static void DownloadFile(string url)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(url, "MyDownloadedImage.jpg");
        }
        static void WriteToFile(string content)
        {
            using (FileStream stream = new FileStream(@"C:\Users\Piotr\Desktop\google.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (BinaryWriter binary = new BinaryWriter(stream))
                {
                    binary.Write(content);
                }
            }
        }

        static void GetRequestWeb(string url)
        {
            WebRequest web = WebRequest.Create(url);
            web.Proxy = null;
            using (WebResponse res = web.GetResponse())
            {
                using (Stream rs = res.GetResponseStream())
                {
                    using (FileStream stream = File.Create("code.html"))
                    {
                        rs.CopyTo(stream);
                    }
                }
            }



        }
    }
}
