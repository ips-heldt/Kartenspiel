using System;
using System.Linq;

namespace KartenMischen
{
    class Program
    {
        static void Main(string[] args)
        {
            int anzahlKarten = 32;
            string[] farben = { "eichel", "gruen", "herz", "schellen" };
            object[,] stapel = ErstelleStapel(anzahlKarten, farben);

            do
            {
                Console.WriteLine("\nKartenstapel mit {0} wird gemischt", anzahlKarten);
                stapel = MischeStapel(stapel);

                for (int i = 0; i < stapel.GetLength(0); i++)
                {
                    Console.WriteLine("Karte {0} = {1}:Wertigkeit={2}", i+1, stapel[i, 0], stapel[i, 2]);
                }

                Console.WriteLine("{0} Karten im Stapel", stapel.GetLength(0));
                Console.Write("\nStapel neu mischen? (j)");
            } while (Console.ReadKey().KeyChar.ToString() == "j");

        }

        static object[,] ErstelleStapel(int anzahlKarten, string[] farben)
        {
            object[,] stapel = new object[anzahlKarten, 3];

            for (int x = 0, i=0; x < farben.Length; x++)
            {
                for (int y = 7; y <= 12; y++)
                {
                    switch (y)
                    {
                        case 12:
                            stapel[i, 0] = farben[x] + "_bube";
                            stapel[i, 1] = farben[x];
                            stapel[i, 2] = 10;
                            i++;
                            stapel[i, 0] = farben[x] + "_dame";
                            stapel[i, 1] = farben[x];
                            stapel[i, 2] = 10;
                            i++;
                            stapel[i, 0] = farben[x] + "_koenig";
                            stapel[i, 1] = farben[x];
                            stapel[i, 2] = 10;
                            break;
                        case 11:
                            stapel[i, 0] = farben[x] + "_as";
                            stapel[i, 1] = farben[x];
                            stapel[i, 2] = 11;
                            break;
                        default:
                            stapel[i, 0] = farben[x] + "_" + y.ToString();
                            stapel[i, 1] = farben[x];
                            stapel[i, 2] = y;
                            break;
                    }
                    i++;
                }

            }

            return stapel;
        }

        static object[,] MischeStapel(object[,] stapel)
        {
            Random rand = new Random(0);
            int[] tmp = new int[stapel.GetLength(0)];
            int i = 0;
            object[,] oStapel = new object[stapel.GetLength(0), 3];

            while (i < stapel.GetLength(0) - 1)
            {
                int randValue = rand.Next(0, stapel.GetLength(0));
                if (!tmp.Contains(randValue))
                {
                    tmp.SetValue(randValue, i);
                    i++;
                }
            }

            for (int x = 0; x < tmp.Length; x++)
            {
                oStapel[x, 0] = stapel[tmp[x], 0];
                oStapel[x, 1] = stapel[tmp[x], 1];
                oStapel[x, 2] = stapel[tmp[x], 2];
            }

            return oStapel;
        }
    }
}
