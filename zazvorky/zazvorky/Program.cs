namespace zazvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpravneZavorky();
        }
       
        static bool SpravneZavorky()
        {
                Console.Write("Pro ukončení programu zadej - k; jinak zadej závorky, které chceš zkontrolovat: ");
                string zavorky = Console.ReadLine();
                Stack<char> seznam = new Stack<char>();
                var páry = new Dictionary<char, char>
                {
                    { ')', '(' },
                    { ']', '[' },
                    { '}', '{' }
                };
                
                foreach (char znak in zavorky)
                {
                    if ("([{".Contains(znak))
                    {
                        seznam.Push(znak);
                    }
                    else if (")]}".Contains(znak))
                    {
                        if (seznam.Count == 0 || seznam.Peek() != páry[znak])
                        {
                            Console.WriteLine("Špatně");
                            return false;
                        }
                        seznam.Pop();
                    }
                }
                Console.WriteLine("Správně");
                return true;
        }
    }
}




