using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introducao_Linq
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return 
                $"ID: {Id} Name: {Name} Idade: {Age} Telefone: {Telephone}";
        }
    }
}
