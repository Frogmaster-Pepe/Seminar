namespace snort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cisla = {2,6,3,7,9,1,5};
            int l = cisla.Length;
            for(int i = 0; i < l; i++)
            {
                for(int j = 0; i < l - 1; j++)
                {
                    if (cisla[j] > cisla[j+1])
                    {
                        int x = cisla[j];
                        cisla[j] = cisla[j = 1];
                        cisla[j = 1] = x;
                    }
                }
            }
            for (int i = 0; i < l; i++)
            { 
                Console.WriteLine(cisla[i]);
            }
        }
    }
}
