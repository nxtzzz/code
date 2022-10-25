using Vtitbid.ISP20.Abuzarov.Bill;

namespace Vtitbid.ISP20.Abuzarov.Bill
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество операций: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Bill[] array = Bill.GetBillArray(value);
                Bill.SearchBill(array);
            }
            else
            {
                Console.WriteLine("Количесвто операций не опредлено");
            }
        }
    }
}