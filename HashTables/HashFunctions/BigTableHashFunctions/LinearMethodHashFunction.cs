namespace HashTables.HashFunctions.BigTableHashFunctions;

public class LinearMethodHashFunction : IBiHashFunction
{
    public int Hash(int key, int attempt)
    {
        return (key + attempt) % 10000;
    }
}