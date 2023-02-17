using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktikal2
{

    internal class MyConverter
    {
        public static void MySerealize(List<notes> notes)
        {
            string json = JsonConvert.SerializeObject( notes);
            File.WriteAllText("C:\\Рабочий Стол\\MYjsom",json);
        }
        public static List<notes> MyDeSerealize()
        {
            string json = File.ReadAllText("C:\\Рабочий Стол\\MYjsom");
            List<notes> notes = JsonConvert.DeserializeObject<List<notes>>(json);
            return notes;
        }
    }
}
