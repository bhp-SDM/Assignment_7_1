using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7_1
{
    public class Person
    {
        public string Cpr { get; set; }
        public string Name { get; set; }

        public Person(string cpr, string name)
        {
            Cpr = cpr;
            Name = name;
        }
    }
}
