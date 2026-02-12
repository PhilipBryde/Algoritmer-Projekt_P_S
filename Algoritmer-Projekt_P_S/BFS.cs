using System;
using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
{
    /// <summary>
    /// Implementerr BFS algoritmen til grafen. Kører bredt og i gennem alle naboer på samme nivaeu
    /// </summary>
    public class BFS
    {
        /// <summary>
        /// Kører BFS fra en startnode til et speciferet mål
        /// Bruger en Queue (first in, first out) til at håndtere noder der skal besøges
        /// printer både besøgte noder og den endelige vej til målet
        /// </summary>
        /// <param name="startNode">Noden der startes ved</param>
        /// <param name="målNavn">Navnet på noden der skal findes</param>
        public void Kør(Forlystelse startNode, string målNavn)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n--- Starter BFS mod '{målNavn}' ---");
            Console.ResetColor();

            Queue<Forlystelse> kø = new Queue<Forlystelse>(); //Opretter en ny kø
            HashSet<Forlystelse> besøgt = new HashSet<Forlystelse>(); //Holder styr på hvilke noder der er blevet besøgt
            Dictionary<Forlystelse, Forlystelse> hvorKomViFra = new Dictionary<Forlystelse, Forlystelse>(); //Dictionary der gemmer vejen

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

        /// <summary>
        /// Printer den fundne vej fra start noden til målet.
        /// </summary>
        /// <param name="målNode">Noden vi endte med</param>
        /// <param name="rute">Dictionary der mapper hver node til den forrige node i vejen</param>
        private void UdskrivSti(Forlystelse målNode, Dictionary<Forlystelse, Forlystelse> rute)
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
            Console.WriteLine("Den fundne vej (BFS): " + string.Join(" -> ", sti));
            Console.ResetColor();
        }
    }
}