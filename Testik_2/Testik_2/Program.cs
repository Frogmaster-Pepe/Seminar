namespace Testik_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int vstup = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i<vstup;i++)
            {
                string[] vstupy = Console.ReadLine().Split();
                int[] cisla = new int[vstupy.Length];
                for (int j = 0; j < vstupy.Length; j++)
                {
                    cisla[j] = Convert.ToInt32(vstupy[j]);
                }
            }
            }
            
            static void vypisGrafu()
            {
                for (int i = 0; i < cisla.Length; i++)
                {
                    for (int j = 0; i < cisla.Length; i++)
                    {

                    }
                }
            }






                  
        
    }
}
