using Vtitbid.ISP20.Abuzarov.Bill;

namespace Vtitbid.ISP20.Abuzarov.Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int n = 3;
            ListAccounts[] listAccounts = new ListAccounts[n];
            ListAccounts bill = new ListAccounts();

            ListAccounts.Conclusion(n, listAccounts);
        }
    }
}