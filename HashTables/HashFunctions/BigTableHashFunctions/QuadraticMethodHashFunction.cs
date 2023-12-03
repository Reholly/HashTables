namespace HashTables.HashFunctions.BigTableHashFunctions;

public class QuadraticMethodHashFunction : IBiHashFunction
{
    public int Hash(int key, int attempt)
    {
        return (key + attempt * attempt) % 10000;
    }
}