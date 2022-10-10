using System;

namespace Assignment_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter cpr (10 digits): ");
            string? cpr = Console.ReadLine();

            DateTime birthdate = GetBirthdateFromCpr(cpr);
            Console.WriteLine("Birthdate: " + birthdate);
            Console.WriteLine("Age: " + GetAge(birthdate));

            List<Person> persons = new()
            {
                new Person("0101223999", "E"),  // 01.01.1922
                new Person("0101224000", "M"),  // 01.01.2022
                new Person("0101374999", "F"),  // 01.01.1937
                new Person("0101015000", "I"),  // 01.01.2001
                new Person("0101995999", "D"),  // 01.01.1899
                new Person("0101006000", "H"),  // 01.01.2000
                new Person("0101986999", "C"),  // 01.01.1898
                new Person("0101207000", "L"),  // 01.01.2020
                new Person("0101977999", "B"),  // 01.01.1897
                new Person("0101108000", "K"),  // 01.01.2010
                new Person("0101968999", "A"),  // 01.01.1896
                new Person("0101029000", "J"),  // 01.01.2002
                new Person("0101999999", "G")   // 01.01.1999
            };

            persons.Sort(new Comparison<Person>((a, b) =>
            {
                return GetBirthdateFromCpr(a.Cpr).CompareTo(GetBirthdateFromCpr(b.Cpr));
            }));

            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Cpr}: {person.Name}");
            }
        }

        static DateTime GetBirthdateFromCpr(string? cpr)
        {
            if (cpr == null || cpr.Length != 10)
            {
                throw new ArgumentException("Not a cpr-number");
            }
            if (!(int.TryParse(cpr.Substring(0, 2), out int birthDay)
                && int.TryParse(cpr.Substring(2, 2), out int birthMonth)
                && int.TryParse(cpr.Substring(4, 2), out int birthYear)
                && int.TryParse(cpr.Substring(6, 4), out int serial)))
                throw new ArgumentException("Not a cpr-number");

            return new DateTime(GetTrueYearFromCpr(birthYear, serial), birthMonth, birthDay);
        }

        private static int GetTrueYearFromCpr(int year, int serial)
        {
            if ((serial >= 4000 && serial <= 4999) || (serial >= 9000 && serial <= 9999))
            {
                return year + (year < 37 ? 2000 : 1900);
            }
            else if (serial >= 5000 && serial <= 8999)
            {
                return year + (year < 58 ? 2000 : 1800);
            }
            else
            {
                return year + 1900;
            }
        }

        private static int GetAge(DateTime birthdate)
        {
            DateTime today = DateTime.Now;

            int age = today.Year - birthdate.Year;
            if (today < birthdate.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
