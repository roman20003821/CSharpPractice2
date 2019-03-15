using RomanProject.Tools;
using System;
using System.Linq;
using RomanProject.Tools.Exceptions;

namespace RomanProject.Model
{
    internal class Person
    {
        #region constans
        static readonly string[] ChineaseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey", "Rooster", "Dog", "Pig" };
        private static readonly int MaxPersonAge = 135;
        #endregion

        #region fields
        private string _name;
        private string _surname;
        private string _eMail;
        private DateTime _birthdayDate;
        #endregion

        #region properties
        private string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        private string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        private string EMail
        {
            get { return _eMail; }
            set
            {
                _eMail = value;
            }
        }

        private DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
            }
        }

        private bool IsAdult
        {
            get { return IsOlderThan(18); }
        }

        private string SunSign
        {
            get { return GetSunSign(); }
        }

        private string ChineaseSign
        {
            get { return GetChineaseSign(); }
        }

        internal bool IsBirthday
        {
            get { return IsBirthdayToday(); }
        }

        #endregion

        internal Person(string name, string surname, string eMail, DateTime birthdayDate)
        {
            ConstructAndValidate(name, surname, eMail, birthdayDate);
        }

        internal Person(string name, string surname, string eMail)
        {
            ConstructAndValidate(name, surname, eMail, default(DateTime));
        }

        internal Person(string name, string surname, DateTime birthdayDate)
        {
            ConstructAndValidate(name, surname, default(string), birthdayDate);
        }

        private void ConstructAndValidate(string name, string surname, string eMail, DateTime birthdayDate)
        {
            _name = name;
            _surname = surname;
            _eMail = eMail;
            _birthdayDate = birthdayDate;
            CheckName(name);
            CheckName(surname);
            ValidateEmail(eMail);
            CheckBirthdayDate(birthdayDate);
        }

        private void ValidateEmail(string eMail)
        {
            if (eMail == default(string))
            {
                return;
            }
            if (!RegexUtilities.IsValidEmail(eMail))
            {
                throw new WrongEmailException($"Email is incorrect: {eMail}");
            }
        }

        private void CheckBirthdayDate(DateTime birthdayDate)
        {
            if (birthdayDate == default(DateTime))
            {
                return;
            }
            if (IsOlderThan(MaxPersonAge))
            {
                throw new OldBirthdayException($"Person is too old, birthday date: {birthdayDate.ToShortDateString()}");
            }
            else if (!IsOlderThan(0))
            {
                throw new LateBirthdayException($"Person haven't born yet, birthday date: {birthdayDate.ToShortDateString()}");
            }
        }

        private void CheckName(string name)
        {
            if (!name.All(char.IsLetter))
            {
                throw new WrongNameException($"This name is bad {name}");
            }
        }

        private bool IsOlderThan(int age)
        {
            if (DateTime.Today.Year - BirthdayDate.Year < age) return false;
            else if (DateTime.Today.Year - BirthdayDate.Year == age)
            {
                if (DateTime.Today.Month < BirthdayDate.Month) return false;
                else if (DateTime.Today.Month == BirthdayDate.Month)
                {
                    if (DateTime.Today.Day < BirthdayDate.Day) return false;
                }

            }
            return true;
        }

        private string GetSunSign()
        {
            return GetSunSign(BirthdayDate.Day, BirthdayDate.Month, BirthdayDate.Year);
        }


        private string GetSunSign(int day, int month, int year)
        {
            if (((month == 3) && (day >= 21)) || ((month == 4) && (day <= 20)))
            {
                return "Aires";
            }
            else if (((month == 4) && (day >= 21)) || ((month == 5) && (day <= 21)))
            {
                return "Taurus";
            }
            else if (((month == 5) && (day >= 21)) || ((month == 6) && (day <= 21)))
            {
                return "Gemini";
            }
            else if (((month == 6) && (day >= 22)) || ((month == 7) && (day <= 22)))
            {
                return "Cancer";
            }
            else if (((month == 7) && (day >= 23)) || ((month == 8) && (day <= 22)))
            {
                return "Leo";
            }
            else if (((month == 8) && (day >= 23)) || ((month == 9) && (day <= 21)))
            {
                return "Virgo";
            }
            else if (((month == 9) && (day >= 23)) || ((month == 10) && (day <= 21)))
            {
                return "Libra";
            }
            else if (((month == 10) && (day >= 23)) || ((month == 11) && (day <= 21)))
            {
                return "Scorpio";
            }
            else if (((month == 11) && (day >= 22)) || ((month == 12) && (day <= 21)))
            {
                return "Sagittarius";
            }
            else if (((month == 12) && (day >= 22)) || ((month == 1) && (day <= 20)))
            {
                return "Capricorn";
            }
            else if (((month == 1) && (day >= 21)) || ((month == 2) && (day <= 19)))
            {
                return "Aquarius";
            }
            else if (((month == 2) && (day >= 20)) || ((month == 3) && (day <= 20)))
            {
                return "Pisces";
            }
            throw new AccessViolationException();
        }

        private string GetChineaseSign()
        {
            return GetChineaseSign(BirthdayDate.Year);
        }

        private string GetChineaseSign(int year)
        {
            return ChineaseSigns[(year - 4) % 12];
        }

        private bool IsBirthdayToday()
        {
            return BirthdayDate.Month == DateTime.Today.Month && BirthdayDate.Day == DateTime.Today.Day;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {EMail}\nBirthday: {BirthdayDate.ToShortDateString()}\n" +
                   $"Is Adult: {IsAdult}\nIs Birthday: {IsBirthday}\nChinease Sign: {ChineaseSign}\nSun Sign: {SunSign}";
        }
    }
}
