using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LearningProject
{
    class DataDownloader
    {
        public void GetData()
        {
            List<RecordThree> recordList = new List<RecordThree>();
            HtmlWeb web = new HtmlWeb();
            for (int i = 1; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    var htmlDoc = web.Load($"https://www.trt.net.tr/televizyon/akis.aspx?kanal=trt-{i}&gun={j}");
                    var node = htmlDoc.DocumentNode.SelectNodes("//div/p/a/span").ToList();
                    for (int k = 0; k < node.Count; k += 2)
                    {
                        RecordThree record = new RecordThree();

                        record.BroadcastDateAndTime = DateTime.Parse($"{DateTime.Today.Day + j}.10.2019 {node[k].InnerHtml.ToString()}");
                        record.Title = node[k + 1].InnerHtml.ToString();


                        recordList.Add(record);
                    }
                }

            }

            string json = JsonConvert.SerializeObject(recordList);
            Console.WriteLine(json);


            XmlSerializer oSerializer = new XmlSerializer(typeof(List<RecordThree>));


            using (StreamWriter oStreamWriter = new StreamWriter("records.xml"))
            {
                oSerializer.Serialize(oStreamWriter, recordList);
            }
        }

    }
}
