using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Bill
{
    class ListAccounts : IComparable
    {
        public string PayerAccount { get; set; }
        public string RcipientAccount { get; set; }
        public double AMountTransferred { get; set; }

        private static void MakingPayment(int n, ListAccounts[] user)
        {
            for (int i = 0; i < n; i++)
            {
                user[i] = new ListAccounts();
                Console.WriteLine("введите расчетный счет плательщика");
                PayerAccountInput(user, i);

                Console.WriteLine("введите расчетный счет получателя");
                RcipientAccountInput(user, i);

                Console.WriteLine("введите  перечисляемую сумму");
                FullAMountTransferredInput(user, i);

                Console.Clear();
            }
            SortMakingPayment(n, user);
        }
        private static void SortMakingPayment(int n, ListAccounts[] user)
        {
            Array.Sort(user);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"информация о {i + 1} операцией ");

                Console.WriteLine(user[i]);

                Console.WriteLine();
            }

            InformationTransfers(n, user);
        }

        private static void InformationTransfers(int n, ListAccounts[] user)
        {
            Console.WriteLine("введите расчетный счет плательщика, чтобы узнать информацию о платеже");
            string score = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (score == user[i].PayerAccount)
                {

                    Console.WriteLine("расчетный счет плательщика:" + user[i].PayerAccount);
                    Console.WriteLine("сумма перевода: " + user[i].AMountTransferred);
                    Console.WriteLine("расчетный счет получателя: " + user[i].RcipientAccount);
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("информация о данном платеже отсутствует");
            }
        }

        public static void Conclusion(int n, ListAccounts[] listAccounts)
        {
            while (true)
            {
                MakingPayment(n, listAccounts);

                Console.WriteLine("продолжить?(да, нет)");
                string b = Console.ReadLine();

                switch (b)
                {
                    case "да":
                        Console.Clear();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public override string ToString()
        {
            return $"\nрасчетный счет плательщика: {PayerAccount}\nрасчетный счет получателя: {RcipientAccount}\nперечисляемая сумма: {AMountTransferred}\n";
        }

        public int CompareTo(object? obj)
        {
            if (obj is ListAccounts person) return PayerAccount.CompareTo(person.PayerAccount);
            else throw new ArgumentException("Ошибка");
        }
        private static string PayerAccountInput(ListAccounts[] user, int i)
        {
            bool prov;
            do
            {
                user[i].PayerAccount = Console.ReadLine();
                if (string.IsNullOrEmpty(user[i].PayerAccount) || string.IsNullOrWhiteSpace(user[i].PayerAccount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите расчетный счет ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return user[i].PayerAccount;
        }
        private static string RcipientAccountInput(ListAccounts[] user, int i)
        {
            bool prov;
            do
            {
                user[i].RcipientAccount = Console.ReadLine();
                if (string.IsNullOrEmpty(user[i].RcipientAccount) || string.IsNullOrWhiteSpace(user[i].RcipientAccount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите расчетный счет ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);
            return user[i].RcipientAccount;
        }
        private static double FullAMountTransferredInput(ListAccounts[] user, int i)
        {
            bool prov;
            do
            {
                user[i].AMountTransferred = InputAMountTransferred();
                if (!(user[i].AMountTransferred > 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ОШИБКА ввода введите перечисляемую сумму ещё раз ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    prov = false;
                }
                else
                {
                    prov = true;
                }

            } while (!prov);

            return user[i].AMountTransferred;
        }
        private static double InputAMountTransferred()
        {
            while (true)
            {
                double i;
                if (double.TryParse(Console.ReadLine(), out i))
                    return (int)i;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Ошибка ввода! Введите перечисляемую сумму еще раз: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
    }
}
