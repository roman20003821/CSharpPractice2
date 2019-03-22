using System;
using System.Collections.Generic;
using RomanProject.Model;

namespace RomanProject.Tools
{
    internal static class UserGenerator
    {
        private static Random random = new Random();

        internal static List<Person> GenerateUsers(int n)
        {
            List<Person> res = new List<Person>(n);
            for (int i = 0; i < n; i++)
            {
                string name = GetRandomName(5);
                string surnName = GetRandomName(6);
                string email = GetRandomName(8) + "@gmail.com";
                DateTime birthdayDate = GetRandomDate();
                Person user = new Person(name, surnName, email, birthdayDate);
                res.Add(user);
            }
            return res;
        }

        private static string GetRandomName(int lenght)
        {
            char[] res = new char[lenght];
            for (int i = 0; i < lenght; i++)
            {
                res[i] = GetRandomChar();
            }
            return new String(res);
        }

        private static char GetRandomChar()
        {
            int num = random.Next(0, 26);
            return (char) ('a' + num);
        }

        private static DateTime GetRandomDate()
        {
            int year = GetRandomYear();
            int month = GetRandomMonth();
            int day = GetRandomDay(month, year);
            return new DateTime(year,month,day);
        }

        private static int GetRandomYear()
        {
            return random.Next(DateTime.Now.Year - 134, DateTime.Now.Year);
        }

        private static int GetRandomMonth()
        {
            return random.Next(1, 12);
        }

        private static int GetRandomDay(int month, int year)
        {
            int daysInMonth = GetDaysInMonth(month, year);
            return random.Next(1, daysInMonth + 1);
        }

        private static int GetDaysInMonth(int month, int year)
        {
            return DateTime.DaysInMonth(year, month);
        }
    }
}
