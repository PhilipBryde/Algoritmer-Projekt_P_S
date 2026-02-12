using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using Algoritmer_Projekt_P_S;

// Klasser til JSON struktur
public class JsonData { public List<int> values { get; set; } } //json 

/// <summary>
/// Sorteringsresultat properties der gemmes til output filerne
/// inkluderer algoritmenavnet, dataset, antal sammenligninger, tid og det sorteret data
/// </summary>
public class SortResult
{
    public string Algorithm { get; set; }
    public string Dataset { get; set; }
    public int Comparisons { get; set; }
    public double Time_ms { get; set; } //Double da vi skal have den mest nøjagtige tid
    public List<int> Sorted { get; set; }
}

class Program
{
    /// <summary>
    /// Hovedprogrammet kører først delopgave 1 og derefter delopgave 2
    /// Læser 3 json filer og sorterer dens data med insertion og bubble sort algoritmer, måler derefter performance
    /// De endelige resultater bliver gemt i en output mappe, derefter køres delopgave 2 med DFS OG BFS
    /// </summary>
    static void Main()
    {
        // Navnene på de tre JSON-filer der skal sorteres
        string[] filer = { "sorted.json", "reverseSorted.json", "notSorted.json" };

        Bubble bub = new Bubble();
        Insertion ins = new Insertion();

        // Opretter en mappe til resultaterne, hvis den ikke findes
        if (!Directory.Exists("output"))
        {
            Directory.CreateDirectory("output");
        }

        foreach (string filNavn in filer) //Går igennem hver fil og sorterer med begge algoritmer
        {
            Console.WriteLine($"\nBehandler: {filNavn}...");

            try
            {
                //Læs data
                string jsonTekst = File.ReadAllText(filNavn);
                JsonData indhold = JsonSerializer.Deserialize<JsonData>(jsonTekst);

                //Kopier data til en ny liste
                MyList<int> bubbleList = new MyList<int>();
                foreach (int tal in indhold.values) bubbleList.Add(tal);

                // Måler tid og antal sammenligninger
                Stopwatch bubbleSW = Stopwatch.StartNew();
                int sammenligninger = bub.BubbleSort(bubbleList, Comparer<int>.Default);
                bubbleSW.Stop();

                // 3. Forbered data til output-filen
                List<int> resultatListe = new List<int>();
                for (int i = 0; i < bubbleList.Count; i++) resultatListe.Add(bubbleList[i]);

                GemResultat("Bubble Sort", filNavn, bubbleList, sammenligninger, bubbleSW.Elapsed.TotalMilliseconds); //Gemmer resultater med GemResultat metoden

                //Gentager det samme med Insertion Sort
                MyList<int> insertionList = new MyList<int>();
                foreach (int tal in indhold.values) insertionList.Add(tal); 

                Stopwatch insertionSW = Stopwatch.StartNew(); //Sorterer og måler tid
                int sammenligninger1 = ins.InsertionSort(insertionList, Comparer<int>.Default);
                insertionSW.Stop();

                GemResultat("Insertion Sort", filNavn, insertionList, sammenligninger1, insertionSW.Elapsed.TotalMilliseconds);

            }
            catch (FileNotFoundException) //Hvis de originale json filer ikke kan findes kommer denne fejlbesked
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FEJL: Kunne ikke finde filen '{filNavn}'");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\nFiler er blevet sorteret/opdateret, tjek 'output' mappen");


        //DELOPGAVE 2
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nTryk enter for at starte Delopgave 2...");
        Console.ReadLine();
        KørDelopgave2();
    }

    /// <summary>
    /// Gemmer de endelige resultater som json og txt filer i output mappen
    /// json filerne indeholder den fulde sorteringsdata mens txt filerne vider performance stats
    /// </summary>
    /// <param name="algoritme">Navnet på algoritmen</param>
    /// <param name="filNavn">Navnet på den originale fil</param>
    /// <param name="liste">Den sorteret liste</param>
    /// <param name="sammenligninger">Antal sammenligninger</param>
    /// <param name="tidMs">Tid i millisekunder</param>
    static void GemResultat(string algoritme, string filNavn, MyList<int> liste, int sammenligninger, double tidMs) //Metode der gemmer resultater i json og txt filer
    {
        
        List<int> resultatsListe = new List<int>();
        for (int i = 0; i < liste.Count; i++)
        {
            resultatsListe.Add(liste[i]);
        }

        var outputData = new SortResult
        {
            Algorithm = algoritme,
            Dataset = filNavn,
            Comparisons = sammenligninger,
            Time_ms = tidMs,
            Sorted = resultatsListe,
        };

        string baseNavn = Path.GetFileNameWithoutExtension(filNavn);

        string jsonOutput = JsonSerializer.Serialize(outputData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText($"output/{algoritme}_{baseNavn}.json", jsonOutput);

        string txtOutput = $"Algoritme: {algoritme}\nFil: {filNavn}\nSammenligninger: {sammenligninger}\nTid: {tidMs} ms";
        File.WriteAllText($"output/performance_{algoritme}_{baseNavn}.txt", txtOutput); //json og txt fil oprettes med de korrekte navne og info
    }

    static void KørDelopgave2() //Kører Delopgave 2
    {
        Console.Clear();

        // 1. Byg parken
        Forlystelsespark tivoli = new Forlystelsespark();
        Forlystelse startSted = tivoli.BygOgVisPark();

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