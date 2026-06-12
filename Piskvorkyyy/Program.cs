namespace Piskvorkyyy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        static List<List<string>> pole = new List<List<string>>();
        static int vys;
        static int sir;
        static string pl1;
        static string pl2;
        //už nikdy nebudu přepisovat kod z pythonu do c# =))
        //jako reálně kdybych tohle nedělal loni a neměel ten python kod tak bych to si nedal
        //bohužel nevim jak tam dát taky tak hezký barevný čtverečky takže tam sou ty závorky ze kterejch mě už bolí oči ::(
        static void Main()
        {
            Console.WriteLine("Ahoj! Pojďte si zahrát hru");
            Console.Write("Jak široké chcete pole(nejlíp větší než pět když se hraje na pět, ale you do you): ");
            sir = int.Parse(Console.ReadLine());
            Console.Write("Jak vysoké chcete pole(nejlíp větší než pět když se hraje na pět, ale you do you): ");
            vys = int.Parse(Console.ReadLine());
            Console.Write("Jak se jmenuje hráč číslo jedna: ");
            pl1 = Console.ReadLine();
            Console.Write("Jak se jmenuje hráč číslo dva: ");
            pl2 = Console.ReadLine();

            for (int i = 0; i < vys; i++)
            {
                var row = new List<string>();
                for (int j = 0; j < sir; j++)
                {
                    row.Add("[]");
                }
                pole.Add(row);
            }
            VypisPole();
            while (true)
            {
                Tah(pl1);
                if (Vyhra())
                {
                    VypisPole();
                    Console.WriteLine($"\x1bGG Vítězem je:\n{pl1}");
                    return;
                }
                Remiza();
                VypisPole();

                Tah(pl2);
                if (Vyhra())
                {
                    VypisPole();
                    Console.WriteLine($"\x1bGG Vítězem je:\n{pl2}");
                    return;
                }
                Remiza();
                VypisPole();
            }
        }
        static void VypisPole()
        {
            for (int i = 0; i < vys; i++)
            {
                Console.WriteLine(string.Join(" ", pole[i]));
            }
        }

        static void Tah(string hrac)
        {
            int sloupec;
            while (true)
            {
                Console.Write($"{hrac} do jakého sloupce chcete vhodit svůj žeton (z leva do prava začíná se od 1 do {sir}): ");
                if (!int.TryParse(Console.ReadLine(), out sloupec) || sloupec < 1 || sloupec > sir)
                {
                    Console.WriteLine("Neplatný vstup, zkus to znovu.");
                    continue;
                }
                if (pole[0][sloupec - 1] != "[]")
                {
                    Console.Write("\x1bTY TY TY, tento sloupec je plný zkus jiný: ");
                    continue;
                }
                break;
            }
            for (int j = 0; j < vys; j++)
            {
                if (pole[j][sloupec - 1] != "[]")
                {
                    if (hrac == pl1)
                        pole[j - 1][sloupec - 1] = "()";
                    else if (hrac == pl2)
                        pole[j - 1][sloupec - 1] = "{}";
                    return;
                }
                else if (j == vys - 1)
                {
                    if (hrac == pl1)
                        pole[j][sloupec - 1] = "()";
                    else if (hrac == pl2)
                        pole[j][sloupec - 1] = "{}";
                    return;
                }
            }
        }
        static void Remiza()
        {
            int x = 0;
            for (int i = 0; i < sir; i++)
            {
                if (pole[0][i] == "[]")
                    break;
                else
                    x++;
            }
            if (x == sir)
            {
                VypisPole();
                Console.WriteLine("\x1bREMÍZA!!!!! \nVšechna pole jsou už plná. gg.");
                Environment.Exit(0);
            }
        }
        static bool Vyhra()
        {
            for (int i = 0; i < vys; i++)
            {
                for (int j = 0; j <= sir - 5; j++)
                {
                    if (Enumerable.Range(0, 5).All(k => pole[i][j + k] == "()"))
                        return true;
                    if (Enumerable.Range(0, 5).All(k => i - k >= 0 && j + k < sir && pole[i - k][j + k] == "{}"))
                        return true;
                }
            }
            for (int i = 0; i <= vys - 5; i++)
            {
                for (int j = 0; j < sir; j++)
                {
                    if (Enumerable.Range(0, 5).All(k => pole[i + k][j] == "()"))
                        return true;
                    if (Enumerable.Range(0, 5).All(k => i - k >= 0 && j + k < sir && pole[i - k][j + k] == "{}"))
                        return true;
                }
            }
            for (int i = 0; i <= vys - 5; i++)
            {
                for (int j = 0; j <= sir - 5; j++)
                {
                    if (Enumerable.Range(0, 5).All(k => pole[i + k][j + k] == "()"))
                        return true;
                    if (Enumerable.Range(0, 5).All(k => i - k >= 0 && j + k < sir && pole[i - k][j + k] == "{}"))
                        return true;
                }
            }
            for (int i = 4; i < vys; i++)
            {
                for (int j = 0; j <= sir - 5; j++)
                {
                    if (Enumerable.Range(0, 5).All(k => pole[i - k][j + k] == "()"))
                        return true;
                    if (Enumerable.Range(0, 5).All(k => pole[i - k][j + k] == "{}"))
                        return true;
                }
            }
            return false;
        }
    }
}
