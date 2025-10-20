namespace pole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 4, 7, 67, 6, 9, 18, 21 };

            int max = FindMax(num);

            Console.Write("Pole: ");
            Console.WriteLine(string.Join(" ", num));
            Console.WriteLine($"Nejvetsi cislo v poli je: {max}");
            int[] sort = MergeSort(num);
            Console.Write("SortArray: ");
            Console.WriteLine(string.Join(" ", sort));
            int SearchNumber = 9;
            int numberPosition = BinarySearch(sort, SearchNumber);
            Console.Write("BinarySearch: ");
            if (numberPosition == -1)
            {
                Console.WriteLine("Cislo neni v poli");
            }
            else
            {
                Console.WriteLine($"{SearchNumber} je na pozici {numberPosition}");
            }
        }

        static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }
        static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int mid = array.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }

            for (int i = mid; i < array.Length; i++)
            {
                right[i - mid] = array[i];
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0;
            int r = 0;
            int l = 0;

            while (l < left.Length && r < right.Length)
            {
                if (left[l] >= right[r])
                {
                    result[i++] = left[l++];
                }
                else
                {
                    result[i++] = right[r++];
                }
            }

            while (l < left.Length)
            {
                result[i++] = left[l++];
            }

            while (r < right.Length)
            {
                result[i++] = right[r++];
            }

            return result;
        }


        static int BinarySearch(int[] num, int searchNumber)
        {
            int lowest = 0;
            int highest = num.Length - 1;
            while (lowest <= highest)
            {
                int k = lowest + (highest - lowest) / 2;
                if (num[k] == searchNumber)
                {
                    return k;
                }
                if (num[k] > searchNumber)
                {
                    lowest = k + 1;
                }
                else
                {
                    highest = k - 1;
                }
            }

            return -1;
        }
    }
}


