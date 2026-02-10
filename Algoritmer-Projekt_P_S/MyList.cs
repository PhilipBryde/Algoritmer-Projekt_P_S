using System;

/// <summary>
/// En simpel, generisk liste, der fungerer som et dynamisk array.
/// Denne klasse erstatter standard C# List i opgaven.
/// </summary>
public class MyList<T> 
{
    // Det interne array, hvor vi faktisk gemmer dataene.
    // Vi starter med en kapacitet på 1000 for at undgå at resize for tit.
    private T[] _data = new T[1000];
    private int _antal = 0;

    public void Add(T punkt)
    {
        if (_antal == _data.Length)
        {
            Array.Resize(ref _data, _data.Length * 2);
        }
        _data[_antal] = punkt;
        _antal++;
    }

    
    public int Count => _antal;

    public T this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
    public T Get(int index)
    {
        return _data[index];
    }
}