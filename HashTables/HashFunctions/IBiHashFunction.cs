namespace HashTables.HashFunctions;

public interface IBiHashFunction
{
    int Hash(int key, int attempt);
}