namespace HashTables.HashFunctions.BigTableHashFunctions;

public class QuadraticMethodHashFunction : IBiHashFunction
{
    public int Hash(int key, int attempt)
    {
        key = Math.Abs(key);
        const int helperConst = 13;
        return (key + attempt * attempt * helperConst) % 10000;
    }
}