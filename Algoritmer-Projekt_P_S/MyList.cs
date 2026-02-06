using System;

public class MyList<T>
{
    // Internt array til at gemme data 
    private T[] _data = new T[1000];
    private int _antal = 0;

    // Tilføjer et element til listen
    public void Add(T punkt)
    {
        if (_antal == _data.Length)
        {
            Array.Resize(ref _data, _data.Length * 2);
        }
        _data[_antal] = punkt;
        _antal++;
    }

    // Returnerer antallet af elementer i listen 
    public int Count()
    {
        return _antal;
    }

    // Giver adgang til elementer via indeks, f.eks. liste[0]
    public T this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
}