using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
{
    public class Forlystelse
    {
        public string Navn { get; set; }
        public List<Forlystelse> Naboer { get; set; } = new List<Forlystelse>();

        public Forlystelse(string navn)
        {
            Navn = navn;
        }

        public void Forbind(Forlystelse anden)
        {
            Naboer.Add(anden);
            anden.Naboer.Add(this); // Forbinder begge veje
        }
    }
}