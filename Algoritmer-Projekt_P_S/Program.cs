using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using Algoritmer_Projekt_P_S;

// Klasser til JSON struktur
public class JsonData { public List<int> values { get; set; } }

public class SortResult
{
    public string algorithm { get; set; }
    public string dataset { get; set; }
    public int comparisons { get; set; }
    public double time_ms { get; set; }
    public List<int> sorted { get; set; }
}

class Program
{
    static void Main()
    {
        // Navnene på dine tre JSON-filer
        string[] filer = { "sorted.json", "reverseSorted.json", "notSorted.json" };

        Sort algo = new Sort();
        Insertion ins = new Insertion();

        // Opretter en mappe til resultaterne, hvis den ikke findes
        if (!Directory.Exists("output"))
        {
            Directory.CreateDirectory("output");
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--- Starter Sorteringer på alle filer ---");
        Console.ResetColor();

        foreach (string filNavn in filer)
        {
            Console.WriteLine($"\nBehandler: {filNavn}...");

            try
            {
                // 1. Læs data
                string jsonTekst = File.ReadAllText(filNavn);
                JsonData indhold = JsonSerializer.Deserialize<JsonData>(jsonTekst);

                MyList<int> bubbleList = new MyList<int>();
                foreach (int tal in indhold.values) bubbleList.Add(tal);

                // 2. Sorter og mål tid
                Stopwatch bubbleSW = Stopwatch.StartNew();
                int sammenligninger = algo.BubbleSort(bubbleList, Comparer<int>.Default);
                bubbleSW.Stop();

                // 3. Forbered data til output-filen
                List<int> resultatListe = new List<int>();
                for (int i = 0; i < bubbleList.Count; i++) resultatListe.Add(bubbleList[i]);

                GemResultat("Bubble Sort", filNavn, bubbleList, sammenligninger, bubbleSW.Elapsed.TotalMilliseconds);

                MyList<int> insertionList = new MyList<int>();
                foreach (int tal in indhold.values) insertionList.Add(tal);

                Stopwatch insertionSW = Stopwatch.StartNew();
                int sammenligninger1 = ins.InsertionSort(insertionList, Comparer<int>.Default);
                insertionSW.Stop();

                GemResultat("Insertion Sort", filNavn, insertionList, sammenligninger1, insertionSW.Elapsed.TotalMilliseconds);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"færdig! ({sammenligninger} sammenligninger, {bubbleSW.ElapsedMilliseconds} ms)");
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


        //DELOPGAVE 2
        Console.WriteLine("\nTryk enter for at starte Delopgave 2...");
        Console.ReadLine();
        KørDelopgave2();

        Console.WriteLine("\nProgrammet er færdigt. Tryk enter for at lukke.");
        Console.ReadLine();
    }


    static void GemResultat(string algoritme, string filNavn, MyList<int> liste, int sammenligninger, double tidMs)
    {
        List<int> resultatsListe = new List<int>();
        for (int i = 0; i < liste.Count; i++)
        {
            resultatsListe.Add(liste[i]);
        }

        var outputData = new SortResult
        {
            algorithm = algoritme,
            dataset = filNavn,
            comparisons = sammenligninger,
            time_ms = tidMs,
            sorted = resultatsListe,
        };

        string baseNavn = Path.GetFileNameWithoutExtension(filNavn);

        string jsonOutput = JsonSerializer.Serialize(outputData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($"output/{algoritme}_{baseNavn}.json", jsonOutput);

        string txtOutput = $"Algoritme: {algoritme}\nFil: {filNavn}\nSammenligninger: {sammenligninger}\nTid: {tidMs} ms";
        File.WriteAllText($"output/performance_{algoritme}_{baseNavn}.txt", txtOutput);
    }

    static void KørDelopgave2()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("--- Bygger Forlystelsespark (Delopgave 2) ---");
        Console.ResetColor();

        // 1. Byg parken
        Forlystelsespark tivoli = new Forlystelsespark();
        Forlystelse startSted = tivoli.BygOgVisPark();

        Console.WriteLine("\nTryk på ENTER for at starte søgninger...");
        Console.ReadLine();

        // 2. Kør BFS (Breadth-First Search)
        BFS bfsAlgo = new BFS(); // Opretter BFS klassen
        bfsAlgo.Kør(startSted, "Water Ride");
        bfsAlgo.Kør(startSted, "Volcano Ride");

        Console.WriteLine("\n--------------------------------");

        // 3. Kør DFS (Depth-First Search)
        DFS dfsAlgo = new DFS(); // Opretter DFS klassen
        dfsAlgo.Kør(startSted, "Water Ride");
        dfsAlgo.Kør(startSted, "Volcano Ride");
    }
} 