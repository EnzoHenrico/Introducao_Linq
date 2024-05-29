using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Introducao_Linq2
{
    public class PenalidadesAplicadas
    {
        /*{
            "razao_social": "",
            "cnpj": "",
            "nome_motorista": "",
            "cpf": "",
            "vigencia_do_cadastro": ""
        }*/

        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }
        
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }
        
        [JsonProperty("nome_motorista")]
        public string NomeMotorista { get; set; }
        
        [JsonProperty("cpf")]
        public string Cpf { get; set; }
        
        [JsonProperty("vigencia_do_cadastro")]
        public DateTime VigenciaCadastro { get; set; }

        public override string ToString()
        {
            return $"Razão social: {RazaoSocial}, CNPJ: {Cnpj}, | Nome: {NomeMotorista}, CPF: {Cpf} Data vigencia: {VigenciaCadastro}";
        }
    }
}
