namespace tetik
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int x1 = Convert.ToInt32(Console.ReadLine());
                int y1 = Convert.ToInt32(Console.ReadLine());
                int x2 = Convert.ToInt32(Console.ReadLine());
                int y2 = Convert.ToInt32(Console.ReadLine());
                int x3 = Convert.ToInt32(Console.ReadLine());
                int y3 = Convert.ToInt32(Console.ReadLine());

                int u1 = x2 - x1;
                int u2 = y2 - y1;
                int v1 = x3 - x2;
                int v2 = y3 - y2;
                int w1 = x3 - x1;
                int w2 = y3 - y1;
                double u = Math.Sqrt(Math.Pow(u1, 2) + Math.Pow(u2, 2));
                double v = Math.Sqrt(Math.Pow(v1, 2) + Math.Pow(v2, 2));
                double w = Math.Sqrt(Math.Pow(w1, 2) + Math.Pow(w2, 2));
                Console.WriteLine();
                Console.WriteLine(u);
                Console.WriteLine(v);
                Console.WriteLine(w);
                Console.WriteLine();
            }
        }
    }
}
