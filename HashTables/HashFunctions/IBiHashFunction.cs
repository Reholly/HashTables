namespace HashTables.HashFunctions;

public interface IBiHashFunction
{
    string Title { get; }
    int Hash(int key, int attempt);
}