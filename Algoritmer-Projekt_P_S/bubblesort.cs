using System.Collections.Generic;

/// <summary>
/// Implementerer Bubble Sort algoritmen
/// Looper igennem hele listen indtil den er sorteret
/// </summary>
public class Bubble
{
    /// <summary>
    /// Sorterer en generisk liste.
    /// Hvis 2 naboer er i en forkert rækkefølge bytter de pladser
    /// Dette gentager indtil hele listen er sorteret
    /// Tæller antal sammenligninger undervejs
    /// </summary>
    /// <typeparam name="T">Datatypen der skal sorteres (i dette tilfælde er det int)</typeparam>
    /// <param name="liste">Listen der skal sorteres</param>
    /// <param name="comparer">Sammenligner elementer</param>
    /// <returns>Returnerer antal sammenligner</returns>
    public int BubbleSort<T>(MyList<T> liste, IComparer<T> comparer)
    {
        int sammenligninger = 0;
        int n = liste.Count;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                sammenligninger++; //Tæller én op hver loop
                if (comparer.Compare(liste[j], liste[j + 1]) > 0) //Hvis venstre index er højre, byttes de
                {
                    T temp = liste[j];
                    liste[j] = liste[j + 1];
                    liste[j + 1] = temp;
                }
            }
        }
        return sammenligninger; //Returnerer sammenligninger
    }
}