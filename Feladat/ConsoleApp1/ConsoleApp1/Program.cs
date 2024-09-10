using System;
using System.Collections;
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
        public static string csapat = "Lelkesek";
        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Console.Write("Adj meg egy csapat nevet: ");
            csapat = Console.ReadLine();
            Feladat5();
            Feladat6();
            Feladat7();
        }

        public static List<Meccs> Beolvasas() {

            List<Meccs> meccsek = new List<Meccs>();


            foreach (var lines in File.ReadAllLines("meccs.txt").Skip(1)) {

                var line = lines.Split(' ');
                meccsek.Add(new Meccs(Convert.ToInt32(line[0]), Convert.ToInt32(line[1]), Convert.ToInt32(line[2]), Convert.ToInt32(line[3]), Convert.ToInt32(line[4]), line[5], line[6]));
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

        public static void Feladat3() {

            //int forditok = meccsek.Count(x => x.Fordito());


            Console.WriteLine($"Fordító csapatok:");
            foreach (var meccs in meccsek) {


                if (meccs.hazaiFel < meccs.vendegFel && meccs.hazaiVege > meccs.vendegVege)
                {
                    Console.WriteLine($"Forduló: {meccs.fordulo}\tGyőztes csapat: {meccs.hazai}");
                }
                else if (meccs.hazaiFel > meccs.vendegFel && meccs.hazaiVege < meccs.vendegVege) {
                    Console.WriteLine($"Forduló: {meccs.fordulo}\tGyőztes csapat: {meccs.vendeg}");
                }
            }

        } 
        public static void Feladat5() {

            int lott = 0;
            int kapott = 0;
            foreach (var meccs in meccsek)
            {

                if (meccs.hazai == csapat)
                {

                    lott += meccs.hazaiVege;
                    kapott += meccs.vendegVege;
                }
                else if (meccs.vendeg == csapat) {

                    lott += meccs.vendegVege;
                    kapott += meccs.hazaiVege;
                
                }
            }

            Console.WriteLine($"Lőtt gólok száma: {lott}\tkapott gólok száma: {kapott}");
        
        }
        public static void Feladat6() {

            Console.WriteLine($"A {csapat} csapat elsőnek otthon kapott ki: ");
            bool egyszersem = true;
            foreach (var meccs in meccsek) { 
            
                if(meccs.hazai == csapat && meccs.hazaiVege<meccs.vendegVege)
                {
                    if(egyszersem) Console.WriteLine($"Forduló: {meccs.fordulo}, {meccs.vendeg} ellen");
                    egyszersem = false;
                    break;
                }
            }

            if (egyszersem) Console.WriteLine("A csapat otthon veretlen maradt.");
        }

        public static void Feladat7() { 
        
        
            Dictionary<string, int> eredmenyek = new Dictionary<string, int>();
            foreach (var meccs in meccsek)
            {
                string ered = meccs.Eredmeny();

                if(!eredmenyek.ContainsKey(ered)) {
                    eredmenyek[ered] = 0;
                }
                eredmenyek[ered] += 1;
                
            }
            //foreach (KeyValuePair<string, int> entry in eredmenyek)
            //{
            //    // do something with entry.Value or entry.Key

            //    Console.WriteLine($"{entry.Key}. {entry.Value}");
            //}
            try
            {

                StreamWriter sw = new StreamWriter("stat.txt");
                sw.Flush();

                foreach (KeyValuePair<string, int> entry in eredmenyek)
                {
                    // do something with entry.Value or entry.Key

                    sw.WriteLine($"{entry.Key}. {entry.Value}");
                }
                sw.Close();
            }
            catch(Exception ex) { 
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
