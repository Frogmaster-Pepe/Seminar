
namespace kino_reserve
{
    //Abych mohl všude používat stejné základní hodnoty tak sem jim udělal třídu Values     
    public class Values
    {
        public static int Rows = 0;
        public static int SeatsPerRow = 0;
        public static int DefaultPrice = 0;
        public static int VIPFee = 0;
        public static bool[,] Cinema;
        public static List<int> VIPRows;
        

        public static void SetValue()
        {
            Rows = 8;
            SeatsPerRow = 10;
            DefaultPrice = 180;
            VIPFee = 70;
            Cinema = new bool[Rows, SeatsPerRow];
            VIPRows = new List<int> { 7, 8 };
             
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {   
            // tady setneme ty hodnoty z classy Values, v ostatních  funkcích to neděláme aby si to pamatovalo změni a správně spočítalo cenu a vytisklo pole 
            Values.SetValue();
            Usage();
        }
        static void Reserve()
        {
            Console.Write("Řada: ");
            string rowInput = Console.ReadLine();
            int targetRow;
            // kontroluje jestli je vstup int a jesti je v rosahu
            if (!int.TryParse(rowInput, out targetRow))
            {
                Console.WriteLine("Neplatný vstup pro řadu.");
                return;
            }
            if (targetRow < 1 || targetRow > Values.Rows)
            {
                Console.WriteLine($"Neplatná řada. Zadejte číslo mezi 1 a {Values.Rows}.");
                return;
            }

            Console.Write("Číslo sedadla: ");
            string seatInput = Console.ReadLine();
            int targetSeat;
            // kontroluje jestli je vstup int a jesti je v rosahu
            if (!int.TryParse(seatInput, out targetSeat))
            {
                Console.WriteLine("Neplatný vstup pro číslo sedadla.");
                return;
            }
            if (targetSeat < 1 || targetSeat > Values.SeatsPerRow)
            {
                Console.WriteLine($"Neplatné sedadlo. Zadejte číslo mezi 1 a {Values.SeatsPerRow}.");
                return;
            }
            // zjišťuje jestli je sedadlo rezervované 
            if (Values.Cinema[targetRow - 1, targetSeat - 1] == true)
            {
                Console.WriteLine("Sedadlo již je rezervované.");
                return;
            }

            Console.Write("Potvrdit rezervaci? -> a/A (jinak bude zrušena): ");
            string confirm = Console.ReadLine();
            if (confirm == null)
            {
                Console.WriteLine("Rezervace zrušena.");
                return;
            }

            if (confirm.Length > 0 && (confirm[0] == 'a' || confirm[0] == 'A'))
            {
                Values.Cinema[targetRow - 1, targetSeat - 1] = true;
                Console.WriteLine("Rezervace úspěšná.");
            }
            else
            {
                Console.WriteLine("Rezervace zrušena.");
            }
            Console.WriteLine();
        }

        static void Calculate()
        {

            int price = 0;
            for (int i = 0; i < Values.Rows; i++)
            {
                for (int j = 0; j < Values.SeatsPerRow; j++)
                {
                    if (Values.Cinema[i, j])
                    {
                        if (Values.VIPRows.Contains(i + 1))
                        {
                            price += Values.DefaultPrice + Values.VIPFee;
                        }
                        else
                        {
                            price += Values.DefaultPrice;
                        }
                    }
                }
            }
            Console.WriteLine($"Aktuální cena: {price} Kč");
            Console.WriteLine();
        }
        static void PrintCinema()
        {
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10");
            for (int i = 0; i < Values.Rows; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < Values.SeatsPerRow; j++)
                {
                    string ch = Values.Cinema[i, j] ? "X " : "S ";
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($" S = volné, X = rezervované. VIP řady: {string.Join(", ", Values.VIPRows)} (příplatek {Values.VIPFee} Kč)");
            Console.WriteLine();
        }

        static void Usage()
        {

            while (true)
            {
                Console.WriteLine("Co chcete udělat: \nz - Zobrazit sedadla v kinosále\nr - Rezervovat sedadlo\ns - spočítat finální cenu\nk - ukončit program");
                string action = Console.ReadLine();
                if (action.Contains("z"))
                {
                    PrintCinema();
                }
                else if (action.Contains("s"))
                {
                    Calculate();
                }
                else if (action.Contains("r"))
                {
                    Reserve();
                }
                else if (action.Contains("k"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Co tam píšeš za nesmysly. Instrukce jsou snad jasné, ne?");
                }
            }
        }

    }
}
