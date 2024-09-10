using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static List<Meccs> meccsek = Beolvasas();
        static void Main(string[] args)
        {
            Feladat2();
        }

        public static List<Meccs> Beolvasas() { 
        
            List<Meccs> meccsek = new List<Meccs>();


            foreach (var lines in File.ReadAllLines("meccs.txt").Skip(1)) { 
            
                var line = lines.Split(' ');
                meccsek.Add(new Meccs(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), Convert.ToInt32(line[4]), line[5], line[6] ));
            }

            return meccsek;

        }

        public static void Feladat2() {

            Console.Write("Adj meg egy mérkőzés számot: ");
            int szam = Convert.ToInt32(Console.ReadLine());
            foreach (var meccs in meccsek)
            {
                if (szam == meccs.fordulo) {
                    Console.WriteLine($"{meccs.hazai}-{meccs.vendeg}: {meccs.hazaiVege}-{meccs.vendegVege} ({meccs.hazaiFel}-{meccs.vendegFel})");
                }
            }
        
        }
    }
}
