namespace retizzzzzzzzzzzzekkk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Počet lidí");
            int pocetlidi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vztahy");
            string vztahy = Console.ReadLine();
            int[,] graf = new int[pocetlidi, pocetlidi];
            string[] dvojice = vztahy.Split();

            for (int i = 0; i < dvojice.Length; i++)
            {
                string[] split = dvojice[i].Split("-");
                int x = Convert.ToInt32(split[0]) - 1;
                int y = Convert.ToInt32(split[1]) - 1;

                graf[x, y] = 1;
                graf[y, x] = 1;
            }

            for (int i = 0; i < graf.GetLength(0); i++)
            {
                for (int j = 0; j < graf.GetLength(1); j++)
                {
                    Console.Write(graf[i, j]);
                }
                Console.WriteLine();
            }

            Queue<int> fronta = new Queue<int>();
            bool[] nalezeno = new bool[pocetlidi];
            Console.WriteLine("Kdo s kýmm?");
            string[] startCil = Console.ReadLine().Split();
            int start = Convert.ToInt32(startCil[0]) - 1;
            int cil = Convert.ToInt32(startCil[1]) - 1;
            int[] previous = new int[pocetlidi];  
            for (int i = 0; i < pocetlidi; i++)
                previous[i] = -1;
            nalezeno[start] = true;
            fronta.Enqueue(start);

            while (fronta.Count > 0)
            {
                int vrchol = fronta.Dequeue();
                for (int i = 0; i < pocetlidi; i++)
                {
                    if (graf[vrchol, i] == 1 && nalezeno[i] == false)
                    {
                        nalezeno[i] = true;
                        previous[i] = vrchol;
                        fronta.Enqueue(i);
                    }
                }
            }

            if (!nalezeno[cil])
            {
                Console.WriteLine("Nemáme řetízek přátelstvý ;(");
                return;
            }

            List<int> cesta = new List<int>();
            int temp = cil;

            while (temp != -1)
            {
                cesta.Add(temp + 1); 
                temp = previous[temp];
            }

            cesta.Reverse();
            Console.WriteLine(string.Join(" ", cesta));
        }
    }
}