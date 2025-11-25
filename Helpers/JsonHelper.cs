using InventoryTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

namespace InventoryTracker.Helpers
{
    public class JsonHelper
    {
        public static void WriteJson(string path, object obj)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented));
        }

        public static T ReadConfiguration<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
