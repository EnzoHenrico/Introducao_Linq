using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Introducao_Linq2
{
    internal class Filters
    {
        public static int GetCountRecords(List<PenalidadesAplicadas> penalties)
        {
            return penalties.Count;
        }
        
        //    Listar registro que tenha o documento do CPF iniciando com o Nº 237
        public static List<PenalidadesAplicadas> FilterByCpf(List<PenalidadesAplicadas> lst, string match)
        {
            return lst.Where(p => p.Cpf.StartsWith(match)).ToList();
        }

        //    Listar regsitros que tem o ano de vigencia igual a 2021
        public static List<PenalidadesAplicadas> FilterYear(List<PenalidadesAplicadas> lst, int year)
        {
            return lst.Where(p => p.VigenciaCadastro.Year == year).ToList();
        }

        //    Quantas empresas tem no seu nome a descrição LTDA
        public static List<PenalidadesAplicadas> FilterComapnyName(List<PenalidadesAplicadas> lst, string match)
        {
            return lst.Where(p => p.RazaoSocial.Contains(match, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        //    Ordenar a lista de registros pela razão social
        public static List<PenalidadesAplicadas> OrderByComapnyName(List<PenalidadesAplicadas> lst)
        {
            return lst.OrderBy(p => p.RazaoSocial).ToList();
        }

        //    Gerar XML baseado nos dados da lista
        public static string? ConvertToXML(List<PenalidadesAplicadas> lst)
        {
            if (lst.Count <= 0)
            {
                return null;
            }

            var penaltieApplied = new XElement("Root",
                    from data in lst
                    select new XElement("motorista",
                        new XElement("razao_social", data.RazaoSocial),
                        new XElement("cnpj", data.Cnpj),
                        new XElement("nome_motorista", data.NomeMotorista),
                        new XElement("cpf", data.Cpf),
                        new XElement("data_de_vigencia", data.VigenciaCadastro)
                        )
                    );
            return penaltieApplied.ToString();
        }
    }
}
