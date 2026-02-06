using System.Collections.Generic;

public class Sort
{
    // Metoden skal være generisk og bruge IComparer 
    public int BubbleSort<T>(MyList<T> list, IComparer<T> comparer)
    {
        int comparisons = 0; // Tæl antal sammenligninger 
        int n = list.Count;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                comparisons++; // Registrer sammenligningen 

                if (comparer.Compare(list[j], list[j + 1]) > 0)
                {
                    // Swap
                    T temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
        return comparisons; // Returner resultatet til performance-filen 
    }
}