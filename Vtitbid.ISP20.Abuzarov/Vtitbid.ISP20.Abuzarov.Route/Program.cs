using Vtitbid.ISP20.Abuzarov.Route;

namespace Vtitbid.ISP20.Abuzarov.Route
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите количество маршрутов: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Route[] array = Route.GetRoute(value);
                Console.WriteLine();
                Console.WriteLine(Route.RouteSearch(array));
            }
            else
            {
                Console.WriteLine("\nКоличесвто маршрутов не опредлено");
            }
        }
    }
}