namespace AbecedniPoradi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadejte vstup: ");
            string[] vztahy = Console.ReadLine().Split();
            List<char> znakyAbecedy = new List<char>(); 

            for (int i = 0; i < vztahy.Length; i++)
            {
                string vztah = vztahy[i];
                if (!znakyAbecedy.Contains(vztah[0]))
                    znakyAbecedy.Add(vztah[0]);
                if (!znakyAbecedy.Contains(vztah[2]))
                    znakyAbecedy.Add(vztah[2]);
            }

            int pocetVrcholu = znakyAbecedy.Count;
            int[,] graf = new int[pocetVrcholu, pocetVrcholu];

            //odkud co kam
            foreach (string vztah in vztahy)
            {
                int indexZ = znakyAbecedy.IndexOf(vztah[0]);
                int indexDo = znakyAbecedy.IndexOf(vztah[2]);

                graf[indexZ, indexDo] = 1;
            }
            VypisGraf(graf, pocetVrcholu);

            //zjišťuje stupeňˇvrcholu pomocí matice sousednosti
            int[] stupneVrcholu = new int[pocetVrcholu];
            for (int i = 0; i < pocetVrcholu; i++) 
            {
                int suma = 0;
                for (int j = 0; j < pocetVrcholu; j++) 
                {
                    suma += graf[j, i];
                }
                stupneVrcholu[i] = suma;
            }
             //kvueue        
            Queue<int> fronta = new Queue<int>();
            for (int i = 0; i < stupneVrcholu.Length; i++)
            {
                if (stupneVrcholu[i] == 0)
                    fronta.Enqueue(i);
            }
            
            List<char> vystup = new List<char>();

            //bere znaky z fronty a dává je správně do výstupu
            while (fronta.Count > 0)
            {
                int vrch = fronta.Dequeue();
                vystup.Add(znakyAbecedy[vrch]);
                                
                for (int i = 0; i < pocetVrcholu; i++)
                {
                    if (graf[vrch, i] == 1)
                    {
                        stupneVrcholu[i]--;
                        if (stupneVrcholu[i] == 0)
                            fronta.Enqueue(i);
                    }
                }
            }
            //vypsání výstupu
            if (vystup.Count != pocetVrcholu)
                Console.WriteLine("Nefunguje to twin");
            else
            {
                foreach (char chr in vystup)
                    Console.Write(chr);
                Console.WriteLine();
            }
        }
        //funkce na vypsani grafu
        static void VypisGraf(int[,] graf, int pocetVrcholu)
        {
            for (int i = 0; i < pocetVrcholu; i++)
            {
                for (int j = 0; j < pocetVrcholu; j++)
                {
                    Console.Write(graf[i, j]);
                }
                Console.WriteLine();
            }
        }   
    }
}
