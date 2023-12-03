namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class DivideMethodSimpleHashFunction : ISimpleHashFunction
{
    public int Hash(int key)
    {
        return Math.Abs(key) % 1000;
    }
}