using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LearningProject
{
    class SerializeClass
    {
        public static void Serialize()
        {
            Product product = new Product();
            product.ExpiryDate = new DateTime(2008, 12, 28);

            JsonSerializer serializer = new JsonSerializer();
            
            serializer.NullValueHandling = NullValueHandling.Ignore;

            
            using(StreamWriter sw = new StreamWriter(@"C:\Users\Piotr\Desktop\Newtosoft.txt"))
            {
                using(JsonWriter jw = new JsonTextWriter(sw))
                {
                    serializer.Serialize(jw, product);
                }
            }


            
        }
        

       

    }

    class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }

        public decimal Price { get; set; }

        public string[] Sizes { get; set; }

    }
}
