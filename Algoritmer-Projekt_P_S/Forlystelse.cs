using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
/// <summary>
/// en forlystelse klasse for sig selv 
/// for at definere forlystelserne og skabe forbindelserne imellem dem
/// </summary>

{
    public class Forlystelse
    {
        public string Navn { get; set; } //property til forlystelsens navn
        public List<Forlystelse> Naboer { get; set; } = new List<Forlystelse>();

        public Forlystelse(string navn)
        {
            Navn = navn; //Opretter en forlystelse med det givne navn
        }

        //Opretter undirceted edge 
        public void Forbind(Forlystelse anden) 
        {
            Naboer.Add(anden);
            anden.Naboer.Add(this); // Forbinder begge veje
        }
    }
}