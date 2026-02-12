using System;
using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
{
    /// <summary>
    /// Bygger forlystelsesparken med forlystelser (noder) og forbinder dem med edges
    /// </summary>

    public class Forlystelsespark
    {
        public Forlystelse BygOgVisPark()
        {
            // Opretter nye forlystelser
            Forlystelse entrance = new Forlystelse("Entrance");
            Forlystelse carousel = new Forlystelse("Carousel");
            Forlystelse miniTrain = new Forlystelse("Mini Train");
            Forlystelse iceCream = new Forlystelse("Ice Cream");
            Forlystelse rollerCoaster = new Forlystelse("Roller Coaster");
            Forlystelse hauntedHouse = new Forlystelse("Haunted House");
            Forlystelse waterRide = new Forlystelse("Water Ride");
            Forlystelse pirateShip = new Forlystelse("Pirate Ship");
            Forlystelse climbingTower = new Forlystelse("Climbing Tower");
            Forlystelse volcanoRide = new Forlystelse("Volcano Ride");

        
            // Bygger og forbinder Venstre side (Carousel-grenen)
            entrance.Forbind(carousel);
            carousel.Forbind(rollerCoaster);
            carousel.Forbind(hauntedHouse);
            rollerCoaster.Forbind(climbingTower);
            climbingTower.Forbind(volcanoRide);

            // Bygger og forbinder Midten (Toget)
            entrance.Forbind(miniTrain);
            miniTrain.Forbind(waterRide);

            // Bygger og forbinder Højre side (Isen)
            entrance.Forbind(iceCream);
            iceCream.Forbind(pirateShip);

            // Viser forbindelserne
            Console.WriteLine("Parken er bygget! Her er forbindelserne:");

            VisNaboer(entrance);
            VisNaboer(carousel);
            VisNaboer(rollerCoaster);
            VisNaboer(climbingTower);
            VisNaboer(miniTrain);
            VisNaboer(iceCream);

            return entrance;
        }

        // Hjælpe-metode til at udskrive
        private void VisNaboer(Forlystelse sted)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n {sted.Navn} er forbundet til:");
            Console.ResetColor();
            foreach (var nabo in sted.Naboer)
            {
                Console.WriteLine($"   --> {nabo.Navn}");
            }
        }
    }
}