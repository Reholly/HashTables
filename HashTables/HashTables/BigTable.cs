using HashTables.HashFunctions;
using KeyValuePair = HashTables.Models.KeyValuePair;

namespace HashTables.HashTables;

public class BigTable
{
    public IBiHashFunction HashFunction => _simpleHashFunction;
    
    private readonly IBiHashFunction _simpleHashFunction;
    private readonly KeyValuePair?[] _items;
    
    private readonly int _attempts = 13;

    public BigTable(IBiHashFunction simpleHashFunction)
    {
        _simpleHashFunction = simpleHashFunction;
        _items = new KeyValuePair[10000];
    }

    public void Add(int key, int value)
    {
        int index = _simpleHashFunction.Hash(key, 0);
        int attempt = 0;

        if (_items[index]?.Key == key)
        {
            return;
        }
        
        while (_items[index] is not null && attempt < _attempts)
        {
            index = _simpleHashFunction.Hash(index, ++attempt); //(index + 1) % 10000;
        }

        _items[index] = new KeyValuePair(key, value);
    }

    public int? Get(int key)
    {
        int index = _simpleHashFunction.Hash(key, 0);
        int attempt = 0;

        while (_items[index] is not null)
        {
            if (_items[index]!.Key == key)
            {
                return _items[index]!.Value;
            }

            index = _simpleHashFunction.Hash(key, ++attempt);
        }

        return null;
    }

    public void Remove(int key)
    {
        int index = _simpleHashFunction.Hash(key, 0);
        int attempt = 0;

        while (_items[index] is not null && attempt < _attempts)
        {
            if (_items[index]?.Key.Equals(key) == true)
            {
                _items[index] = null;
                return;
            }
            
            index = _simpleHashFunction.Hash(index, ++attempt);
        }
    }

    public void Print()
    {
        foreach (var i in _items)
        {
            if (i is not null)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }
        }
    }

    public void AddRange(KeyValuePair[] pairs)
    {
        for (int i = 0; i < pairs.Length; i++)
        {
            Add(pairs[i].Key, pairs[i].Value);
        }
    }

    public int BiggestCluster()
    {
        int maxCluster = 0;
        int currentCluster = 0;

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] is not null)
            {
                currentCluster++;
            }
            else
            {
                maxCluster = Math.Max(maxCluster, currentCluster);
                currentCluster = 0;
            }
        }

        return Math.Max(maxCluster, currentCluster);
    }
}