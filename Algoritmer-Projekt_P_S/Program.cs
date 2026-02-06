using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

// Klasser til JSON struktur
public class JsonData { public List<int> values { get; set; } }

public class SortResult
{
    public string algorithm { get; set; }
    public string dataset { get; set; }
    public int comparisons { get; set; }
    public long time_ms { get; set; }
    public List<int> sorted { get; set; }
}

class Program
{
    static void Main()
    {
        // Navnene på dine tre JSON-filer
        string[] filer = { "sorted.json", "reverseSorted.json", "notSorted.json" };

        Sort algo = new Sort();

        // Opretter en mappe til resultaterne, hvis den ikke findes
        if (!Directory.Exists("output"))
        {
            Directory.CreateDirectory("output");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--- Starter BubbleSort på alle filer ---");
        Console.ResetColor();

        foreach (string filNavn in filer)
        {
            Console.WriteLine($"\nBehandler: {filNavn}...");

            try
            {
                // 1. Læs data
                string jsonTekst = File.ReadAllText(filNavn);
                JsonData indhold = JsonSerializer.Deserialize<JsonData>(jsonTekst);

                MyList<int> minListe = new MyList<int>();
                foreach (int tal in indhold.values) minListe.Add(tal);

                // 2. Sorter og mål tid
                Stopwatch sw = Stopwatch.StartNew();
                int sammenligninger = algo.BubbleSort(minListe, Comparer<int>.Default);
                sw.Stop();

                // 3. Forbered data til output-filen
                List<int> resultatListe = new List<int>();
                for (int i = 0; i < minListe.Count; i++) resultatListe.Add(minListe[i]);

                var outputData = new SortResult
                {
                    algorithm = "BubbleSort",
                    dataset = filNavn,
                    comparisons = sammenligninger,
                    time_ms = sw.ElapsedMilliseconds,
                    sorted = resultatListe
                };

                // 4. Gem output filer i 'output' mappen
                string baseNavn = Path.GetFileNameWithoutExtension(filNavn);

                // Gem JSON
                string jsonOutput = JsonSerializer.Serialize(outputData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText($"output/BubbleSort_{baseNavn}.json", jsonOutput);

                // Gem TXT (Performance)
                string txtOutput = $"Algoritme: BubbleSort\nFil: {filNavn}\nSammenligninger: {sammenligninger}\nTid: {sw.ElapsedMilliseconds} ms";
                File.WriteAllText($"output/performance_BubbleSort_{baseNavn}.txt", txtOutput);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"færdig! ({sammenligninger} sammenligninger, {sw.ElapsedMilliseconds} ms)");
                Console.ResetColor();
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FEJL: Kunne ikke finde filen '{filNavn}'. Husk 'Copy to Output Directory'!");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\nAlle filer er behandlet. Tjek mappen 'output' for resultater.");
    }
}