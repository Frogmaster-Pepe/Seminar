namespace nesquicksnort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Co chceš sortnout: ");
            string s = Console.ReadLine();
            string[] cis = s.Split();
            int[] array = new int[cis.Length];
            for (int i = 0; i < cis.Length; i++)
            {
                array[i] = Convert.ToInt32(cis[i]);            
            }
            OuickSnort(array, 0, array.Length - 1);

            Console.WriteLine("Srovnáno: ");
            for (int i = 0; i < array.Length; i++ )
            {
                Console.Write($"{array[i]} ");
            }
        }

        // nakonec sem udělal ten druhej, jelikož se mi nepodařilo vymyslet jak ten první volat na sám sebe
        static void OuickSnort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int p = array[(left + right)/2];

            int i = left;
            int j = right;

            while (i <= j)
            {
                while (array[i] < p)
                {
                    i++;
                }

                while (array[j] > p)
                {
                    j--;
                }

                if (i < j)
                {
                    int t = array[i];
                    array[i] = array[j];
                    array[j] = t;
                }

                if (i <= j)
                {
                    i++;
                    j--;
                }
            }

            OuickSnort(array, left, j);
            OuickSnort(array, i, right);
        }
    }
}

//Bonus č. 4 - pro data ve, kterých se nachází pár extrémě vysokých nebo malých čísel
