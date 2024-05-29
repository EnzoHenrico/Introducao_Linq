using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introducao_Linq2
{
    public class MotoristaHabilitado
    {
        /*{ 
            "penalidades_aplicadas": [] 
        }*/
        [JsonProperty("penalidades_aplicadas")]
        public List<PenalidadesAplicadas> PenalidadesAplicadas {  get; set; }    
    }
}