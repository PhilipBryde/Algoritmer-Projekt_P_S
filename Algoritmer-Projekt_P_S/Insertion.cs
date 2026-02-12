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
        public int InsertionSort<T>(MyList<T> liste, IComparer<T> comparer)
        {
            int sammenligninger = 0;

            for (int i = 1; i < liste.Count; i++)
            {
                T value = liste.Get(i);
                int pointer = i;

                while (pointer > 0 && comparer.Compare(value, liste.Get(pointer - 1)) < 0)
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