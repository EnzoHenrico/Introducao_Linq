using System.Threading.Channels;

namespace Introducao_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var people = Adm.LoadData();

            Console.WriteLine(">> Todos: \n");
            Adm.PrintData(people);

            Console.WriteLine(">> Sem maiores de idade: \n");
            var filteredMajors = Adm.FilterByAgeLinq(people);
            Adm.PrintData(filteredMajors);

            Console.WriteLine(">> Inicial com A: \n");
            var filteredByChar = Adm.FilterByInitialCharacterLinq(people, "a");
            Adm.PrintData(filteredByChar);

            Console.WriteLine(">> Ordem Alfabetica Ascendente: \n");
            var orderedByName = Adm.OrderedByNameAscLinq(people);
            Adm.PrintData(orderedByName); 
            
            Console.WriteLine(">> Ordem Alfabetica Descendente: \n");
            orderedByName = Adm.OrderedByNameDescLinq(people);
            Adm.PrintData(orderedByName);

            Console.WriteLine(">> Possui A mais de 3 chars no Nome: \n");
            var filteredByName = Adm.FilterByCharAndLengthLinq(people, 'a', 3);
            Adm.PrintData(filteredByName);
        }
    }
}