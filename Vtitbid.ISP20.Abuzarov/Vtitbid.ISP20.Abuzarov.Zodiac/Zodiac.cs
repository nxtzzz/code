using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Zodiac
{
    public class Zodiac
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enum ZodiacSign
        {
            None,
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }
        public DateOfBirth DateOfBirth { get; set; }
        public ZodiacSign ZodiacSigns { get; private set; }


        public Zodiac(string firstName, string lastName, DateOfBirth dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;

            ZodiacSigns = SignDate(dateOfBirth);
        }
        
        public static Zodiac[] GetZodiacArray(int count)
        {
            Zodiac[] zodiacs = new Zodiac[count];

            for (int i = 0; i < zodiacs.Length; i++)
            {
                zodiacs[i] = CreateZodiac();
            }

            return zodiacs;
        }

        public static Zodiac CreateZodiac()
        {
            Console.Write("Введите Ваше имя: ");
            string firstName = ChekName(Console.ReadLine(),nameof(FirstName));
            Console.Write("Введите Вашу фамилию: ");
            string lastName = ChekName(Console.ReadLine(),nameof(LastName));
            DateOfBirth dateOfBirth = DateOfBirth.CreateDateOfBirth();
            if (dateOfBirth.Day > 28 && dateOfBirth.Month == 2)
            {
                Console.WriteLine($"В феврале не может быть: {dateOfBirth.Day} дней");
                Environment.Exit(0);
            }
            
            return new Zodiac(firstName, lastName, dateOfBirth);
        }

        private ZodiacSign SignDate(DateOfBirth dateOfBirth)
        {
            var day = dateOfBirth.Day;
            var month = dateOfBirth.Month;

            if ((day >= 21 && month == 3) || (day <= 20 && month == 4))
                return ZodiacSign.Aries;

            if ((day >= 21 && month == 4) || (day <= 20 && month == 5))
                return ZodiacSign.Taurus;

            if ((day >= 21 && month == 5) || (day <= 21 && month == 6))
                return ZodiacSign.Gemini;

            if ((day >= 22 && month == 6) || (day <= 22 && month == 7))
                return ZodiacSign.Cancer;

            if ((day >= 23 && month == 7) || (day <= 22 && month == 8))
                return ZodiacSign.Leo;

            if ((day >= 23 && month == 8) || (day <= 23 && month == 9))
                return ZodiacSign.Virgo;

            if ((day >= 24 && month == 9) || (day <= 23 && month == 10))
                return ZodiacSign.Libra;

            if ((day >= 24 && month == 10) || (day <= 22 && month == 11))
                return ZodiacSign.Scorpio;

            if ((day >= 23 && month == 11) || (day <= 21 && month == 12))
                return ZodiacSign.Sagittarius;

            if ((day >= 22 && month == 12) || (day <= 20 && month == 1))
                return ZodiacSign.Capricorn;

            if ((day >= 21 && month == 1) || (day <= 18 && month == 2))
                return ZodiacSign.Aquarius;
            if ((day >= 18 && month == 2) || (day <= 19 && month == 3))
                return ZodiacSign.Pisces;
            else
                return ZodiacSign.None;

        }
        public string ZodiacSignToString(ZodiacSign sign)
        {
            switch (sign)
            {
                case ZodiacSign.Aries: return "Овен";
                case ZodiacSign.Taurus: return "Телец";
                case ZodiacSign.Gemini: return "Близнецы";
                case ZodiacSign.Cancer: return "Рак";
                case ZodiacSign.Leo: return "Лев";
                case ZodiacSign.Virgo: return "Дева";
                case ZodiacSign.Libra: return "Весы";
                case ZodiacSign.Scorpio: return "Скорпион";
                case ZodiacSign.Sagittarius: return "Стрелец";
                case ZodiacSign.Capricorn: return "Козерог";
                case ZodiacSign.Aquarius: return "Водолей";
                case ZodiacSign.Pisces: return "Рыбы";
                case ZodiacSign.None: return "ЗЗ не определен";
                default: return "Знак зодиака не определен";
            }

        }
        public override string ToString()
        {
            var firstName = FirstName == null ? "Имя не определено": FirstName.ToString();
            var lastName = LastName == null ? "Фамилия не опрделена": LastName.ToString();
            return $"{FirstName} {LastName}\n{DateOfBirth}\nЗнак зодиака: {ZodiacSignToString(ZodiacSigns)}";
        }

        private static string ChekName(string input,string fieldName = "")
        {
            
                switch (fieldName)
                {
                    case nameof(FirstName):
                        if (!string.IsNullOrEmpty(input))
                        { return input; break; }
                        else { return "Имя не определено"; break; }
                    
                    case nameof(LastName):
                        if (!string.IsNullOrEmpty(input))
                        { return input; break; }
                        else { return "Фамилия не определена"; break; }
                        
                    
                }
            return null;
            
        }
    }
}