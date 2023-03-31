using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domino
{
    class domino
    {
        public int bal;
        public int jobb;

        public domino(int bal, int jobb)
        {
            this.bal = bal;
            this.jobb = jobb;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<domino> dominolista = new List<domino>();
            StreamReader sr = new StreamReader("domino.txt", Encoding.Default);

            while (!sr.EndOfStream)
            {
                string[] darabok = sr.ReadLine().Split(' ');
                dominolista.Add(new domino(Convert.ToInt32(darabok[0]), Convert.ToInt32(darabok[1])));
            }
            sr.Close();

            foreach (var item in dominolista)
            {
                Console.WriteLine(" " + item.bal + " | " + item.jobb);

            }

            Console.Write(" 3.feladat: ");
            Console.WriteLine(" Dominók száma:" + dominolista.Count + "db");

            Console.Write(" Kérek egy számot 1-13-ig! ");
            int sorszam = Convert.ToInt32(Console.ReadLine());
            Console.Write(" 4.feladat: ");
            Console.WriteLine(" A(z) " + sorszam + ". sorszámnak megfelelő dominó: " + dominolista[sorszam - 1].bal + " " + dominolista[sorszam - 1].jobb);

            Console.Write(" 5.feladat: ");
            int duplakszama = 0;
            foreach (var item in dominolista)
            {
                if (item.bal == item.jobb)
                {
                    duplakszama++;
                }
            }
            Console.WriteLine(" Dupla dominók száma: " + duplakszama + "db");

            Console.Write(" 6.feladat: ");
            
            domino elozo_domino = dominolista[0];
            int szamlalo = 0;
            bool szabalyose = true;
            foreach (var item in dominolista)
            {
                if (szamlalo > 0)
                {
                    if (item.bal != elozo_domino.jobb)
                    {
                        szabalyose = false;
                    }
                }
                szamlalo++;
                elozo_domino = item;

            }
            if (szabalyose == true)
            {
                Console.WriteLine(" Szabályosak az illesztések");
            }
            else
            {
                Console.WriteLine(" Nem szabályosak az illesztések");
            }
            Console.WriteLine();
            Console.WriteLine(" Vége a proginak sajnos. Indítsd újra, ha akarod! :) ");
            Console.ReadKey();
        }
    }
}
