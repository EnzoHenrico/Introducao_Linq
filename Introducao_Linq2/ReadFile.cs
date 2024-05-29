using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introducao_Linq2
{
    public class ReadFile
    {
        public List<PenalidadesAplicadas>? GetData(string path)
        { 
            var reader = new StreamReader(path);
            var jsonStr = reader.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<MotoristaHabilitado>(jsonStr, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            return lst?.PenalidadesAplicadas;
        }
    }
}
