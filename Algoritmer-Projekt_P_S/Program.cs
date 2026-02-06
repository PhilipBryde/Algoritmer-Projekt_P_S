using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Klasse der matcher din JSON-fils struktur
public class JsonData
{
    public List<int> values { get; set; }
}

class Program
{
    static void Main()
    {
        // 1. Læs indholdet fra din JSON-fil 
        // Husk at 'notSorted.json' skal have 'Copy to Output Directory' sat til 'Copy if newer'
        string jsonTekst = File.ReadAllText("notSorted.json");

        // 2. Omdan JSON-tekst til en midlertidig liste
        JsonData dataFraFil = JsonSerializer.Deserialize<JsonData>(jsonTekst);

        // 3. Overfør tallene til din egen MyList klasse 
        MyList<int> minListe = new MyList<int>();
        foreach (int tal in dataFraFil.values)
        {
            minListe.Add(tal);
        }

        // 4. Start sortering og tæl sammenligninger 
        Sort algo = new Sort();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Starter sortering af notSorted.json...");

        int antalSammenligninger = algo.BubbleSort(minListe, Comparer<int>.Default);

        // 5. Vis resultatet i konsollen 
        Console.WriteLine("Sortering er færdig!");
        Console.WriteLine("Antal sammenligninger: " + antalSammenligninger);
        Console.ResetColor();
    }
}