using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _10zachto
{
    internal class Soxran
    {
        public static T Deserializer<T>(string path)
        {
            string json = File.ReadAllText(path);
            T List = JsonConvert.DeserializeObject<T>(json);
            return List;
        }
        public static void Serializer<T>(string path, T list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }
    }
}
