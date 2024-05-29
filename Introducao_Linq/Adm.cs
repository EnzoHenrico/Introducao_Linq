using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introducao_Linq
{
    internal class Adm
    {
        public static List<Person> LoadData()
        {
            return new List<Person>()
            {
                new() { Id = 1, Name = "Enzo", Age = 24, Telephone = "16988165084" },
                new() { Id = 2, Name = "Murilo", Age = 15, Telephone = "169881653234" },
                new() { Id = 3, Name = "Ana", Age = 20, Telephone = "169822343443" },
                new() { Id = 4, Name = "Paulo", Age = 10, Telephone = "16998787344" },
                new() { Id = 5, Name = "Arnaldo", Age = 80, Telephone = "16989000898" }
            };
        }

        public static void PrintData(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person + "\n");
            }
        }

        public static List<Person> FilterByAge(List<Person> people)
        {
            var filtered = new List<Person>();
            foreach (var person in people)
            {
                if (person.Age >= 18)
                {
                    filtered.Add(person);
                }
            }
            return filtered;
        }

        public static List<Person> FilterByAgeLinq(List<Person> people)
        {
            return people.Where(p => p.Age >= 18).ToList();
        }

        public static List<Person> FilterByInitialCharacterLinq(List<Person> people, string initial)
        {
            return people.Where(p => p.Name.StartsWith(initial, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Person> FilterByCharAndLengthLinq(List<Person> people, char character, int minLen)
        {
            return people.Where(p => p.Name.Contains(character, StringComparison.OrdinalIgnoreCase) && p.Name.Length > minLen).ToList();
        }

        public static List<Person> OrderedByNameAscLinq(List<Person> people)
        {
            return people.OrderBy(p => p.Name).ToList();
        }

        public static List<Person> OrderedByNameDescLinq(List<Person> people)
        {
            return people.OrderByDescending(p => p.Name).ToList();
        }
    }
}
