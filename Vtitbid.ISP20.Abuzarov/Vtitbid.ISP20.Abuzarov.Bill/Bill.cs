using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Bill
{
    public class Bill : IComparable
    {
        static readonly Action<string> writer = Console.WriteLine;
        static readonly Func<string> reader = Console.ReadLine;
        public string PayerAccount { get; set; }
        public string RecipentAccount { get; set; }
        public int Amount { get; set; }

        public Bill(string payerAccaunt, string recipentAccount, int amount)
        {
            PayerAccount = payerAccaunt;
            RecipentAccount = recipentAccount;
            Amount = amount;
        }

        public static Bill CreateBill()
        {
            writer("Введите расчетный счет плательщика: ");
            string payerBill = CheckField(reader(), nameof(PayerAccount));
            writer("Введите расчетный счет получателя: ");
            string recipentBill = CheckField(reader(), nameof(RecipentAccount));
            writer("Введите сумму начисления: ");
            bool CheckOfAmount = int.TryParse(reader(), out int value);
            if (CheckOfAmount)
            {
                int amount = value;
                return new Bill(payerBill, recipentBill, amount);
            }
            else
            {
                writer("Ошибка ввода данных");
                Environment.Exit(0);
            }
            return null;
        }
        public static Bill[] GetBillArray(int count)
        {
            Bill[] bills = new Bill[count];

            for (int i = 0; i < bills.Length; i++)
            {
                bills[i] = CreateBill();
            }
            BillSort(bills);
            return bills;
        }
        public static Bill BillSort(Bill[] bills)
        {
            Array.Sort(bills);
            int j = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                j++;
                writer($"\nинформация о {j} человеке ");
                writer(bills[i].ToString());
                writer("");
            }
            return null;
        }
        public static int SearchBill(Bill[] bills)
        {
            int count = 0;
            writer("Введите расчетный счет плательщика: ");
            string input = reader();
            writer("");
            if (string.IsNullOrEmpty(input))
                return -1;
            for (int i = 0; i < bills.Length; i++)
            {
                if (input == bills[i].PayerAccount)
                {
                    writer(bills[i].ToString());
                }
                {
                    count++;
                }
                if (count == bills.Length) { return -1; }
            }

            return 0;

        }
        private static string CheckField(string input, string fieldName = "")
        {
            switch (fieldName)
            {
                case nameof(PayerAccount):
                    if (!string.IsNullOrEmpty(input))
                    {
                        return input;
                        break;
                    }
                    else
                    {
                        return "Расчетный счет плательщика не определен";
                        break;
                    }

                case nameof(RecipentAccount):
                    if (!string.IsNullOrEmpty(input))
                    {
                        return input;
                        break;
                    }
                    else
                    {
                        return "Расчетный счет получателя не определен";
                        break;
                    }
            }
            return "Ошибка ввода";
        }
        public int CompareTo(object? o)
        {
            if (o is Bill route) return Amount.CompareTo(route.Amount);
            else throw new ArgumentException("Некорректное значение параметра");
        }
        public override string ToString()
        {

            return $"\nРасчетный счет плательщика: {PayerAccount} \nРасчетный счет получателя: {RecipentAccount}\nСумма начисления: {Amount}";
        }

    }
}