using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Note
{
    public struct DateOfBirth
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateOfBirth(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public static DateOfBirth CreateDateOfBirth()
        {
            Console.WriteLine("Дата рождения:");
            Console.Write("Введите день: ");
            int day = Validate(Console.ReadLine(), nameof(Day));
            Console.Write("Введите месяц: ");
            int month = Validate(Console.ReadLine(), nameof(Month));
            Console.Write("Введите год: ");
            int year = Validate(Console.ReadLine(), nameof(Year));

            return new DateOfBirth(day, month, year);
        }
        private static int Validate(string input, string fieldName = "")
        {
            string[] fields = new string[] { nameof(Day), nameof(Month), nameof(Year) };

            if (!int.TryParse(input, out int value))
                return -1;

            bool isValidFieldName = (fieldName != string.Empty) && fields.Contains(fieldName);

            if (!isValidFieldName)
                return -1;

            switch (fieldName)
            {
                case nameof(Day):
                    if (value <= 31)
                        return value;
                    break;
                case nameof(Month):
                    if (value <= 12)
                        return value;
                    break;

                case nameof(Year):
                    if (value <= DateTime.Now.Year)
                        return value;
                    break;
            }

            return -1;
        }
        public override string ToString()
        {
            string stringDay = Day == -1 ? "День не определен" : Day.ToString();
            string stringMonth = Month == -1 ? "Месяц не определен" : Month.ToString();
            string stringYear = Year == -1 ? "Год не определен" : Year.ToString();

            return $"Дата рождения:\nДень: {stringDay} Месяц: {stringMonth} Год: {stringYear}";
        }
    }
}