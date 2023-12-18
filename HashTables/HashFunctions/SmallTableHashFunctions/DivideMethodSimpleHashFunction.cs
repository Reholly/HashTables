namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class DivideMethodSimpleHashFunction : ISimpleHashFunction
{
    public string Title => "Хэш-функция метода деления";

    public int Hash(int key)
    {
        return Math.Abs(key) % 1000;
    }
}