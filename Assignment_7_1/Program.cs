using System;

namespace Assignment_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter cpr (10 digits): ");
            string? cpr = Console.ReadLine();

            Console.WriteLine("Age = " + GetAgeFromCpr(cpr));
        }

        static int GetAgeFromCpr(string? cpr)
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

            return GetAge(birthDay, birthMonth, GetTrueYearFromCpr(birthYear, serial));
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

        private static int GetAge(int birthDay, int birthMonth, int birthYear)
        {
            DateTime today = DateTime.Now;

            int age = today.Year - birthYear;
            if ((today.Month < birthMonth) || (today.Month == birthMonth && today.Day < birthDay))
            {
                age--;
            }
            return age;
        }
    }
}
