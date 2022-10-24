using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Note
{
    class Note : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateOfBirth DateOfBirth { get; set; }
        public static Note[] GetNote(int count)
        {
            Note[] notes = new Note[count];
            for (int i = 0; i < notes.Length; i++)
            {
                notes[i] = NoteCreate();
            }
            NoteSort(notes);
            return notes;
        }
        public static Note NoteCreate()
        {
            Console.Write("Введите Ваше имя: ");
            string firstName = ChekName(Console.ReadLine(), nameof(FirstName));
            Console.Write("Введите Вашу фамилию: ");
            string lastName = ChekName(Console.ReadLine(), nameof(LastName));

            Console.WriteLine("введите номер телефона: ");
            string phoneNumber = ChekName(Console.ReadLine(), nameof(PhoneNumber));

            DateOfBirth dateOfBirth = DateOfBirth.CreateDateOfBirth();
            if (dateOfBirth.Day > 28 && dateOfBirth.Month == 2)
            {
                Console.WriteLine($"В феврале не может быть: {dateOfBirth.Day} дней");
                Environment.Exit(0);
            }
            return new Note(firstName, lastName, phoneNumber, dateOfBirth);
        }
        public static Note NoteSort(Note[] notes)
        {
            Array.Sort(notes);
            int j = 0;
            for (int i = 0; i < notes.Length; i++)
            {
                j++;
                Console.WriteLine($"информация о {j} человеке ");
                Console.WriteLine(notes[i]);
                Console.WriteLine();
            }
            return null;
        }
        public static Note NoteSearch(Note[] notes)
        {
            Console.WriteLine("введите месяц рождения человека или людей, которых вы хотите найти");
            int monthname = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < notes.Length; i++)
            {
                if (monthname == notes[i].DateOfBirth.Month)
                {
                    Console.WriteLine(notes[i]);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("данные о таком человеке отсутствуют");

            }
            return null;
        }
        public Note() { }
        public Note(string firstName, string lastName, string phoneNumber, DateOfBirth birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            DateOfBirth = birthday;
        }

        public override string ToString()
        {
            return $"\n{FirstName}\n{LastName}\n{PhoneNumber}\n{DateOfBirth.Day}.{DateOfBirth.Month}.{DateOfBirth.Year}";
        }
        private static string ChekName(string input, string fieldName = "")
        {

            switch (fieldName)
            {
                case nameof(FirstName):
                    if (!string.IsNullOrEmpty(input))
                    { return input; break; }
                    else { return "Название товара не определено"; break; }

                case nameof(LastName):
                    if (!string.IsNullOrEmpty(input))
                    { return input; break; }
                    else { return "Названия магазина не определена"; break; }

            }
            return null;

        }
        public int CompareTo(object? obj)
        {
            if (obj is Note person) return DateOfBirth.Day.CompareTo(person.DateOfBirth.Day);
            else throw new ArgumentException("Ошибка");
        }

    }
}