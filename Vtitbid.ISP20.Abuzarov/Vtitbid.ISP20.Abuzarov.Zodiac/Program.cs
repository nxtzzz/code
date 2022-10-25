namespace Vtitbid.ISP20.Abuzarov.Zodiac
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите количество людей: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Zodiac[] array = Zodiac.GetZodiacArray(value);
                Console.WriteLine();
                foreach (Zodiac zodiac in array)
                {
                    Console.WriteLine(zodiac);
                    Console.WriteLine();

                }
            }
            else
            {
                Console.WriteLine("Количесвто людей не опредлено ");
            }

        }
    }
}