namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class RjXorSimpleHashFunction : ISimpleHashFunction
{
    public int Hash(int key)
    {
        int hash = key;
        hash = hash ^ (hash >> 20) ^ (hash >> 12);
        
        return hash ^ (hash >> 7) ^ (hash >> 4);
    }
}