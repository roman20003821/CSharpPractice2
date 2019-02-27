using System;

namespace RomanProject.Model
{
   internal class Person
    {
        #region constans
        static readonly string[] ChineaseSigns= { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey", "Rooster", "Dog", "Pig" };
        #endregion

        #region fields
        private string _name;
        private string _surname;
        private string _eMail;
        private DateTime _birthdayDate;
        #endregion

        #region properties
       internal string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        internal string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        internal string EMail
        {
            get { return _eMail; }
            set
            {
                _eMail = value;
            }
        }

        internal DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
            }
        }

        internal bool IsAdult
        {
            get { return IsOlderThan(18); }
        }

        internal string SunSign
        {
            get { return GetSunSign(); }
        }

        internal string ChineaseSign
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
            _name = name;
            _surname = surname;
            _eMail = eMail;
            _birthdayDate = birthdayDate;
        }

        internal Person(string name, string surname, string eMail)
        {
            _name = name;
            _surname = surname;
            _eMail = eMail;
        }

        internal Person(string name, string surname, DateTime birthdayDate)
        {
            _name = name;
            _surname = surname;
            _birthdayDate = birthdayDate;
        }

        private bool IsOlderThan(int age)
        {
            if (DateTime.Today.Year - _birthdayDate.Year < age) return false;
            else if (DateTime.Today.Year - _birthdayDate.Year == age)
            {
                if (DateTime.Today.Month < _birthdayDate.Month) return false;
                else if (DateTime.Today.Month == _birthdayDate.Month)
                {
                    if (DateTime.Today.Day < _birthdayDate.Day) return false;
                }

            }
            return true;
        }

        private string GetSunSign()
        {
            return GetSunSign(_birthdayDate.Month, _birthdayDate.Day);
        }


        private string GetSunSign(int month, int day)
        {
            if (((month == 3) && (day >= 21)) || ((month == 4) && (day <= 20)))
            {
                return "Aires";
            }
            else if (((month == 4) && (day >= 21)) || ((month == 5) && ( day <= 21)))
            {
                return "Taurus";
            }
            else if (((month == 5) && (day >= 21 )) || ((month == 6) && ( day <= 21)))
            {
                return "Gemini";
            }
            else if (((month == 6) && (day >= 22 )) || ((month == 7) && ( day <= 22)))
            {
                return "Cancer";
            }
            else if (((month == 7) && (day >= 23 ) )|| ((month == 8) && ( day <= 22)))
            {
                return "Leo";
            }
            else if (((month == 8) && (day >= 23 )) || ((month == 9) && (day <= 21)))
            {
                return "Virgo";
            }
            else if (((month == 9) && (day >= 23)) || ((month == 10) && ( day <= 21)))
            {
                return "Libra";
            }
            else if (((month == 10) && (day >= 23 )) || ((month == 11) && (day <= 21)))
            {
                return "Scorpio";
            }
            else if (((month == 11) && (day >= 22)) || ((month == 12) && (day <= 21)))
            {
                return "Sagittarius";
            }
            else if (((month == 12) && (day >= 22)) || ((month == 1) && ( day <= 20)))
            {
                return "Capricorn";
            }
            else if (((month == 1) && (day >= 21)) || ((month == 2) && ( day <= 19)))
            {
                return "Aquarius";
            }
            else if (((month == 2) && (day >= 20)) || ((month == 3) && ( day <= 20)))
            {
                return "Pisces";
            }
            throw new AccessViolationException();
        }

        private string GetChineaseSign()
        {
            return GetChineaseSign(_birthdayDate.Year);
        }

        private string GetChineaseSign(int year)
        {
            return ChineaseSigns[(year - 4) % 12];
        }

        private bool IsBirthdayToday()
        {
            return _birthdayDate.Month == DateTime.Today.Month && _birthdayDate.Day == DateTime.Today.Day;
        }

        public override string ToString()
        {
            return $"Name: {_name}\nSurname: {_surname}\nEmail: {_eMail}\nBirthday: {_birthdayDate.ToShortDateString()}\n" +
                   $"Is Adult: {IsAdult}\nIs Birthday: {IsBirthday}\nChinease Sign: {ChineaseSign}\nSun Sign: {SunSign}";
        }  
    }
}
