using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// 1. Læs JSON filen
string filePath = Path.Combine(
            AppContext.BaseDirectory,
            "JSON_Data",
            "sorted.json"
            ); string jsonTekst = File.ReadAllText("notSorted.json");
List<int> midlertidig = JsonSerializer.Deserialize<List<int>>(jsonTekst);

// 2. Overfør til din egen MyList
MyList<int> minListe = new MyList<int>();
foreach (var tal in midlertidig)
{
    minListe.Add(tal);
}

// 3. Kør sortering og tæl sammenligninger 
Sort algo = new Sort();
int antal = algo.BubbleSort(minListe, Comparer<int>.Default);

Console.WriteLine($"Færdig! Brugte {antal} sammenligninger.");