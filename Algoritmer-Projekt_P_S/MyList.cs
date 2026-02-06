using System;

public class MyList<T>
{
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

    public T Get(int index)
    {
        return _data[index];
    }
    // Nu lavet som en property (uden parenteser), så din sorterings-kode virker
    public int Count => _antal;

    public T this[int index]
    {
        get => _data[index];
        set => _data[index] = value;
    }
}