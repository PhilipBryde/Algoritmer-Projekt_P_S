using System;
using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
{
    public class DFS
    {
        public void Kør(Forlystelse startNode, string målNavn)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n--- Starter DFS mod '{målNavn}' ---");
            Console.ResetColor();

            Stack<Forlystelse> stak = new Stack<Forlystelse>();
            HashSet<Forlystelse> besøgt = new HashSet<Forlystelse>();
            Dictionary<Forlystelse, Forlystelse> hvorKomViFra = new Dictionary<Forlystelse, Forlystelse>();

            stak.Push(startNode);

            Console.Write("Besøgte noder: ");

            while (stak.Count > 0)
            {
                Forlystelse nuværende = stak.Pop();

                if (!besøgt.Contains(nuværende))
                {
                    besøgt.Add(nuværende);
                    Console.Write(nuværende.Navn + " -> ");

                    if (nuværende.Navn == målNavn)
                    {
                        Console.WriteLine("MÅL FUNDET!");
                        UdskrivSti(nuværende, hvorKomViFra);
                        return;
                    }

                    foreach (var nabo in nuværende.Naboer.AsEnumerable().Reverse())
                    {
                        if (!besøgt.Contains(nabo))
                        {
                            if (!hvorKomViFra.ContainsKey(nabo)) hvorKomViFra[nabo] = nuværende;
                            stak.Push(nabo);
                        }
                    }
                }
            }
            Console.WriteLine("Mål ikke fundet.");
        }

        public void UdskrivSti(Forlystelse målNode, Dictionary<Forlystelse, Forlystelse> rute)
        {
            List<string> sti = new List<string>();
            Forlystelse temp = målNode;

            while (temp != null && rute.ContainsKey(temp))
            {
                sti.Add(temp.Navn);
                temp = rute[temp];
            }
            if (temp != null) sti.Add(temp.Navn);
            sti.Reverse();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Den fundne vej (DFS): " + string.Join(" -> ", sti));
            Console.ResetColor();
        }
    }
}