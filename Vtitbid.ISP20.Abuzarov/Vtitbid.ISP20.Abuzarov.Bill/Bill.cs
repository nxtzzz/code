using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Bill
{
    public class Bill : IComparable
    {
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

            Console.Write("Введите расчетный счет плательщика: ");
            var payerBill = ChekName(Console.ReadLine(), nameof(PayerAccount));
            Console.Write("Введите расчетный счет получателя: ");
            var recipentBill = ChekName(Console.ReadLine(), nameof(RecipentAccount));
            Console.Write("Введите сумму начисления: ");
            bool CheckOfAmount = int.TryParse(Console.ReadLine(), out int value);
            if (CheckOfAmount)
            {
                int amount = value;
                return new Bill(payerBill, recipentBill, amount);
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных");
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
        private static string ChekName(string input, string fieldName = "")
        {
            switch (fieldName)
            {
                case nameof(PayerAccount):
                    if (!string.IsNullOrEmpty(input))
                    { return input; }
                    else { return "Расчетный счет плательщика не определен"; }
                    break;
                case nameof(RecipentAccount):
                    if (!string.IsNullOrEmpty(input))
                    { return input; }
                    else { return "Расчетный счет получателя не определен"; }
                    break;
            }
            return "Ошибка ввода";
        }
        public static Bill BillSort(Bill[] bills)
        {
            Array.Sort(bills);
            int j = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                j++;
                Console.WriteLine($"\nинформация о {j} человеке ");
                Console.WriteLine(bills[i]);
                Console.WriteLine();
            }
            return null;
        }
        public static int SearchBill(Bill[] bills)
        {
            int count = 0;
            Console.Write("Введите расчетный счет плательщика: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(input))
                return -1;
            for (int i = 0; i < bills.Length; i++)
            {
                if (input == bills[i].PayerAccount)
                {
                    Console.WriteLine(bills[i]);
                }
                {
                    count++;
                }
                if (count == bills.Length) { return -1; }
            }

            return 0;

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