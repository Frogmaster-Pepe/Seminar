using PololetniUloha;
using System.Text;

namespace PololetniUloha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] pocty = new int[5];

            // (20b) 1. Seřaďte známky ze souboru znamky.txt od 1 do 5 algoritmem s lineární časovou složitostí vzhledem k počtu známek.
            // Vypište je na řádek a pak vypište i četnosti jednotlivých známek.
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky.txt")) // otevření souboru pro čtení
            {


                while (!sr.EndOfStream) // dokud jsme nedošli na konec souboru
                {
                    int znamky = Convert.ToInt16(sr.ReadLine()); // čteme známky po řádcích a převádíme je na číslo
                    pocty[znamky - 1]++;
                }



            }
            // => to, co jste pravděpodobně stvořili se nazývá Counting Sort
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                while ((pocty[i]) > 0)
                {
                    output.Append(i + 1);
                    pocty[i]--;
                }
                Console.WriteLine(output);
            }



            // (40b) 2. Ze souboru znamky_prezdivky.csv vytvořte objekty typu Student se správně přiřazenou známkou a přezdívkou.
            // Seřaďte je podle známek (stabilně = dodržte pořadí v souboru) a vypište seřazené dvojice (znamka: přezdívka) - na každý řádek jednu.
            using (StreamReader sr = new StreamReader(@"..\..\..\..\..\znamky_prezdivky.csv"))
            {
                Console.WriteLine();
                List<Student>[] znamkyStudentu = new List<Student>[5];
                for (int i = 0; i < 5; i++) znamkyStudentu[i] = new List<Student>();

                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(";");
                    int znamka = Convert.ToInt16(line[1]);
                    string prezdivka = line[0];
                    Student S = new Student(prezdivka, znamka);

                    if (znamka >= 0 || znamka <= 5)
                    {
                        znamkyStudentu[znamka - 1].Add(S);
                    }
                }
                StringBuilder vystup = new StringBuilder();
                for (int i = 0; i < 5; i++)
                {
                    foreach (Student s in znamkyStudentu[i])
                    {
                        vystup.Append($"{s.Znamka}: {s.Prezdivka}\n");
                    }
                }
                Console.WriteLine(vystup);
                // => to, co jste pravděpodobně stvořili se nazývá Bucket Sort (přihrádkové řazení)




                // (10b) 3. Určete časovou a prostorovou složitost algoritmu z 2. úkolu




                // (+60b) 4. BONUS: Napište kód, který bude řadit lexikograficky velká čísla v lineárním čase. Využijte dat ze souboru velka_cisla.txt

            }
        }
    }

    class Student
    {
        public string Prezdivka { get; } // tím, že je zde pouze get říkáme, že tato vlastnost třídy Student jde mimo třídu pouze číst, nikoli upravovat
        public int Znamka { get; }
        public Student(string prezdivka, int znamka) // konstruktor třídy
        {
            // použitím samotného { get; } také říkáme, že tyto vlastnosti jdou nastavit nejpozději v konstruktoru - tedy v této metodě
            Prezdivka = prezdivka;
            Znamka = znamka;
        }
    }
}
    



          
