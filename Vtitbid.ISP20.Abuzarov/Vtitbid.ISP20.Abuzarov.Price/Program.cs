using Vtitbid.ISP20.Abuzarov.Price;

namespace Vtitbid.ISP20.Abuzarov.Price
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество магазинов: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Price[] array = Price.GetPrice(value);
                Console.WriteLine();
                Console.WriteLine(Price.PriceSearch(array));
            }
            else
            {
                Console.WriteLine("\nОшибка");
            }
        }
    }
}