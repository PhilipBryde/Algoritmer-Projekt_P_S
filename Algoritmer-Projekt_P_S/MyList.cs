using System;

public class MyList<T>
{
    private T[] _items = new T[10000]; // Internt array til lagring 
    private int _count = 0;

    // Tilføjelse af elementer 
    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
        _items[_count] = item;
        _count++;
    }

    // Returnering af antal elementer 
    public int Count => _count;

    // Adgang via indeks (Indexer) 
    public T this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }
}