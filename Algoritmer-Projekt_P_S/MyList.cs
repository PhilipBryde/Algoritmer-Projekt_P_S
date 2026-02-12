using System;

/// <summary>
/// En simpel, generisk liste, der fungerer som et dynamisk array.
/// Denne klasse erstatter standard C# List i opgaven.
/// </summary>
/// /// <typeparam name="T">Datatypen som listen skal indehole, kan være alt dog i dette tilfælde er det int</typeparam>
public class MyList<T> 
{
    // Det interne array, hvor vi faktisk gemmer dataene.
    // Vi starter med en kapacitet på 1000 for at undgå at resize for tit.
    private T[] data = new T[1000];
    private int antal = 0; //Holder styr på hvor mange elementer er tilføjet

    /// <summary>
    /// Tilføjer nyt element til listen
    /// hvis array'et er fuldt fordobles kapaciteteten ved brug af Array.Resize()
    /// </summary>
    /// <param name="punkt">Element der skal tilføjes</param>
    public void Add(T punkt)
    {
        if (antal == data.Length) //Hvis arrayet er fyldt op, fordobles kapaciteteten
        {
            Array.Resize(ref data, data.Length * 2);
        }
        data[antal] = punkt;
        antal++;
    }

    
    public int Count => antal; //Returnerer antallet af elementer i listen

    public T this[int index] //Sætter ny værdi til det givene index
    {
        get => data[index];
        set => data[index] = value;
    }
    public T Get(int index) //Henter et element på et specifikt index
    {
        return data[index];
    }
}