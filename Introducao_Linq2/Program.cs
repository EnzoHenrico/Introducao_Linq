namespace Introducao_Linq2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dir = @"C:\Code\CodeData\";
            var file = "motoristas_habilitados.json";
            var penalties = new ReadFile().GetData(dir + file);

            int option = 0;
            Console.WriteLine("[ 1 ] Listar registro que tenha o documento do CPF iniciando com o Nº 237");
            Console.WriteLine("[ 2 ] Listar regsitros que tem o ano de vigencia igual a 2021");
            Console.WriteLine("[ 3 ] Quantas empresas tem no seu nome a descrição LTDA");
            Console.WriteLine("[ 4 ] Ordenar a lista de registros pela razão social");
            Console.WriteLine("[ 5 ] Inserir todos registros no SQL Server ");
            Console.WriteLine("[ 6 ] Converter aquivo para XML e exibir ");

            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    PrintRecords(Filters.FilterByCpf(penalties, "237"));
                    break;
                case 2:
                    PrintRecords(Filters.FilterYear(penalties, 2021));
                    break;
                case 3:
                    PrintRecords(Filters.FilterComapnyName(penalties, "LTDA"));
                    break;
                case 4:
                    PrintRecords(Filters.OrderByComapnyName(penalties));
                    break;
                case 5:
                    var database = new Database();
                    database.InsertPenalties(penalties);
                    break;
                case 6:
                    Console.WriteLine(Filters.ConvertToXML(penalties));
                    break;
                default:
                    Console.WriteLine("ERROR");
                    break;
            }
            Console.WriteLine("Quantidade de linhas registradas: " + Filters.GetCountRecords(penalties));
        }

        static void PrintRecords(List<PenalidadesAplicadas> penalties)
        {
            foreach (var penalt in penalties)
            {
                Console.WriteLine(penalt);
            }
        }
    }
}
