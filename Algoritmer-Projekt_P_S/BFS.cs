using System;
using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
{
    public class BFS
    {
        public void Kør(Forlystelse startNode, string målNavn)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- Starter BFS mod '{målNavn}' ---");
            Console.ResetColor();

            Queue<Forlystelse> kø = new Queue<Forlystelse>();
            HashSet<Forlystelse> besøgt = new HashSet<Forlystelse>();
            Dictionary<Forlystelse, Forlystelse> hvorKomViFra = new Dictionary<Forlystelse, Forlystelse>();

            kø.Enqueue(startNode);
            besøgt.Add(startNode);

            Console.Write("Besøgte noder: ");

            while (kø.Count > 0)
            {
                Forlystelse nuværende = kø.Dequeue();
                Console.Write(nuværende.Navn + " -> ");

                if (nuværende.Navn == målNavn)
                {
                    Console.WriteLine("MÅL FUNDET!");
                    UdskrivSti(nuværende, hvorKomViFra);
                    return;
                }

                foreach (var nabo in nuværende.Naboer)
                {
                    if (!besøgt.Contains(nabo))
                    {
                        besøgt.Add(nabo);
                        hvorKomViFra[nabo] = nuværende;
                        kø.Enqueue(nabo);
                    }
                }
            }
            Console.WriteLine("Mål ikke fundet.");
        }

        private void UdskrivSti(Forlystelse målNode, Dictionary<Forlystelse, Forlystelse> rute)
        {
            List<string> sti = new List<string>();
            Forlystelse temp = målNode;

            while (temp != null && rute.ContainsKey(temp))
            {
                sti.Add(temp.Navn);
                temp = rute[temp];
            }
            if (temp != null) sti.Add(temp.Navn); // Få startnoden med
            sti.Reverse();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Den fundne vej (BFS): " + string.Join(" -> ", sti));
            Console.ResetColor();
        }
    }
}