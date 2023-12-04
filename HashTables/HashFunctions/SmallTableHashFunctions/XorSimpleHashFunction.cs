namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class XorSimpleHashFunction : ISimpleHashFunction
{
    public int Hash(int key)
    {
        int hash = key;
        hash = hash ^ (hash >> 20) ^ (hash >> 12);

        hash = hash ^ (hash >> 7) ^ (hash >> 4);
        return Math.Abs(hash) % 1000;
    }
}