using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer_Projekt_P_S
{
    //Implementerer Insertion Sort algoritmen
    public class Insertion
    {
        /// <summary>
        /// Sorterer en generisk liste, går i gennem hele listen én gang og sammenligner den nuværende index med den forrige
        /// og flytter dem.
        /// Tæller antal sammenligninger undervejs
        /// </summary>
        /// <typeparam name="T">Datatypen der skal sorteres (i dette tilfælde er det int)</typeparam>
        /// <param name="liste">Navnet på vores listen der skal sorteres</param>
        /// <param name="comparer">Tilat sammenligne elementer</param>
        /// <returns>Returnerer antal sammenligninger</returns>

        public int InsertionSort<T>(MyList<T> liste, IComparer<T> comparer)
        {
            int sammenligninger = 0;

            for (int i = 1; i < liste.Count; i++) //Starter ved 1 da element 0 allerede er "sorteret"
            {
                T value = liste.Get(i);
                int pointer = i;

                while (pointer > 0 && comparer.Compare(value, liste.Get(pointer - 1)) < 0) //Hvis pointer er mindre end indexet til venstre, bliver de flyttet
                {
                    sammenligninger++; //Tæller hver sammenligning
                    liste[pointer] = liste[pointer - 1];
                    pointer = pointer - 1;
                }
                liste[pointer] = value;
            }
            return sammenligninger;
        }
    }
}