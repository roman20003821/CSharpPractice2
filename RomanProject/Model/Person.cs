using RomanProject.Tools;
using System;
using System.Linq;
using RomanProject.Tools.Exceptions;

namespace RomanProject.Model
{
    [Serializable]
    internal class Person
    {
        #region constans
        static readonly string[] ChineaseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey", "Rooster", "Dog", "Pig" };
        static readonly string[] SunSigns = { "Aquarius", "Pisces", "Aires", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn" };
        private static readonly int MaxPersonAge = 135;
        #endregion

        #region fields
        private string _name;
        private string _surname;
        private string _eMail;
        private DateTime _birthdayDate;
        private bool? _isAdult;
        private string _sunSign;
        private string _chineaseSign;
        #endregion

        #region properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
            }
        }

        public string EMail
        {
            get { return _eMail; }
            set
            {
                _eMail = value;
            }
        }

        public DateTime BirthdayDate
        {
            get { return _birthdayDate; }
            set
            {
                _birthdayDate = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                if (_isAdult == null)
                {
                    _isAdult = IsOlderThan(18);
                }
                return _isAdult.Value;
            }
        }

        public string SunSign
        {
            get
            {
                if (_sunSign == null)
                {
                    _sunSign = GetSunSign();
                }

                return _sunSign;
            }
        }

        public string ChineaseSign
        {
            get
            {
                if (_chineaseSign == null)
                {
                    _chineaseSign = GetChineaseSign();
                }
                return _chineaseSign;
            }
        }

        public bool IsBirthday
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
            CheckName(name);
            CheckName(surname);
            ValidateEmail(eMail);
            CheckBirthdayDate(birthdayDate);
        }

        internal Person(string name, string surname, string eMail):this(name, surname, eMail, default(DateTime))
        {
        }

        internal Person(string name, string surname, DateTime birthdayDate):this(name, surname, default(string), birthdayDate)
        {  
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
                return SunSigns[2];
            }
            else if (((month == 4) && (day >= 21)) || ((month == 5) && (day <= 21)))
            {
                return SunSigns[3];
            }
            else if (((month == 5) && (day >= 21)) || ((month == 6) && (day <= 21)))
            {
                return SunSigns[4];
            }
            else if (((month == 6) && (day >= 22)) || ((month == 7) && (day <= 22)))
            {
                return SunSigns[5];
            }
            else if (((month == 7) && (day >= 23)) || ((month == 8) && (day <= 22)))
            {
                return SunSigns[6];
            }
            else if (((month == 8) && (day >= 23)) || ((month == 9) && (day <= 21)))
            {
                return SunSigns[7];
            }
            else if (((month == 9) && (day >= 23)) || ((month == 10) && (day <= 21)))
            {
                return SunSigns[8];
            }
            else if (((month == 10) && (day >= 23)) || ((month == 11) && (day <= 21)))
            {
                return SunSigns[9];
            }
            else if (((month == 11) && (day >= 22)) || ((month == 12) && (day <= 21)))
            {
                return SunSigns[10];
            }
            else if (((month == 12) && (day >= 22)) || ((month == 1) && (day <= 20)))
            {
                return SunSigns[11];
            }
            else if (((month == 1) && (day >= 21)) || ((month == 2) && (day <= 19)))
            {
                return SunSigns[0];
            }
            else if (((month == 2) && (day >= 20)) || ((month == 3) && (day <= 20)))
            {
                return SunSigns[1];
            }
            throw new AccessViolationException();
        }

        private string GetChineaseSign()
        {
            return GetChineaseSign(BirthdayDate.Year);
        }

        private string GetChineaseSign(int year)
        {
            if (year<4)
            {
              return ChineaseSigns[year];
            }
            return ChineaseSigns[(year - 4) % ChineaseSigns.Length];
        }

        private bool IsBirthdayToday()
        {
            return BirthdayDate.Month == DateTime.Today.Month && BirthdayDate.Day == DateTime.Today.Day;
        }

        public static int CompareSunSigns(string sign1, string sign2)
        {
            int index1 = IndexOfSign(sign1, SunSigns);
            int index2 = IndexOfSign(sign2, SunSigns);
            return CompareIndexes(index1, index2);
        }

        public static int CompareChineaseSigns(string sign1, string sign2)
        {
            int index1 = IndexOfSign(sign1, ChineaseSigns);
            int index2 = IndexOfSign(sign2, ChineaseSigns);
            return CompareIndexes(index1, index2);
        }

        private static int IndexOfSign(string sign, string[] signArray)
        {
            for (int i = 0; i < signArray.Length; i++)
            {
                if (sign == signArray[i])
                {
                    return i;
                }
            }

            return -1;
        }

        private static int CompareIndexes(int index1, int index2)
        {
            if (index1 == index2)
            {
                return 0;
            }
            else if (index1 < index2) { return 1; }
            else
            {
                return -1;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType()) return false;

            Person p = (Person)obj;
            return (this.Name == p.Name) && (this.Surname == p.Surname) && (this.EMail == p.EMail)&& (this.BirthdayDate == p.BirthdayDate);
        }
        public override string ToString()
        {
            return $"Name: {Name}\nSurname: {Surname}\nEmail: {EMail}\nBirthday: {BirthdayDate.ToShortDateString()}\n" +
                   $"Is Adult: {IsAdult}\nIs Birthday: {IsBirthday}\nChinease Sign: {ChineaseSign}\nSun Sign: {SunSign}";
        }
    }
}
