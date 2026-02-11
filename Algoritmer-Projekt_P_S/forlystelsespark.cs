using System;
using System.Collections.Generic;

namespace Algoritmer_Projekt_P_S
{

    public class Forlystelsespark
    {
        public Forlystelse BygOgVisPark()
        {
            // --- 1. OPRET FORLYSTELSER ---
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

        
            // Venstre side (Carousel-grenen)
            entrance.Forbind(carousel);
            carousel.Forbind(rollerCoaster);
            carousel.Forbind(hauntedHouse);
            rollerCoaster.Forbind(climbingTower);
            climbingTower.Forbind(volcanoRide);

            // Midten (Toget)
            entrance.Forbind(miniTrain);
            miniTrain.Forbind(waterRide);

            // Højre side (Isen)
            entrance.Forbind(iceCream);
            iceCream.Forbind(pirateShip);

            // --- 3. VIS RESULTATET ---
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