using System.Collections.Generic;

public class Sort
{
    public int BubbleSort<T>(MyList<T> liste, IComparer<T> comparer)
    {
        int sammenligninger = 0;
        int n = liste.Count;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                sammenligninger++;
                if (comparer.Compare(liste[j], liste[j + 1]) > 0)
                {
                    T temp = liste[j];
                    liste[j] = liste[j + 1];
                    liste[j + 1] = temp;
                }
            }
        }
        return sammenligninger;
    }
}