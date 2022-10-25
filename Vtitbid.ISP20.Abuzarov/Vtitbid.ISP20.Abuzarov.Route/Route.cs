using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Abuzarov.Route
{
    public class Route : IComparable
    {
        public string RouteFirstPoint { get; set; }
        public string RouteEndPoint { get; set; }
        public int RouteNumber { get; set; }
        public static Route RouteCreate()
        {
            Console.Write("Введите начало маршрута: ");
            string nameStartOfRoute = ChekName(Console.ReadLine(), nameof(RouteFirstPoint));
            Console.Write("Введите конец маршрута: ");
            string nameEndOfRoute = ChekName(Console.ReadLine(), nameof(RouteEndPoint));
            Console.Write("Введите номер маршрута: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                int numberOfRoute = value;
                return new Route(nameStartOfRoute, nameEndOfRoute, numberOfRoute);
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных");
                return null;
            }
        }
        public static Route[] GetRouteArray(int count)
        {
            Route[] routes = new Route[count];

            for (int i = 0; i < routes.Length; i++)
            {
                routes[i] = RouteCreate();
            }
            RouteSort(routes);
            return routes;
        }
        public static Route RouteSort(Route[] routes)
        {
            Array.Sort(routes);
            for (int i = 0; i < routes.Length; i++)
            {
                Console.WriteLine($"\n{routes[i]}");
            }
            return null;

        }
        public static Route RouteSearch(Route[] routes)
        {
            Console.Write("Введите номер вашего маршрута: ");
            if (Int32.TryParse(Console.ReadLine(), out int temp))
            {
                int count = 0;
                int routenum = temp;
                for (int i = 0; i < routes.Length; i++)
                {
                    if (routenum == routes[i].RouteNumber)
                    {
                        count++;
                        Console.WriteLine(routes[i]);
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("информация о данном маршруте отсутсвует");
                }
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
            return null;
        }
        public Route(string nameStartOfRoute, string nameEndOfRoute, int numberOfRoute)
        {
            RouteFirstPoint = nameStartOfRoute;
            RouteEndPoint = nameEndOfRoute;
            RouteNumber = numberOfRoute;
        }
        public override string ToString()
        {
            return $"Начало марщрута: {RouteFirstPoint} \nКонец маршрута: {RouteEndPoint}\nНомер маршрута: {RouteNumber}";
        }
        private static string ChekName(string input, string fieldName = "")
        {
            switch (fieldName)
            {
                case nameof(RouteFirstPoint):
                    if (!string.IsNullOrEmpty(input))
                    { return input; break; }
                    else { return "Начальная точка маршрута не определена"; break; }

                case nameof(RouteEndPoint):
                    if (!string.IsNullOrEmpty(input))
                    { return input; break; }
                    else { return "Конечная точка маршрут не определена"; break; }
            }
            return null;
        }
        public int CompareTo(object? obj)
        {
            if (obj is Route route) return RouteNumber.CompareTo(route.RouteNumber);
            else throw new ArgumentException("Ошибка");
        }
    }
}