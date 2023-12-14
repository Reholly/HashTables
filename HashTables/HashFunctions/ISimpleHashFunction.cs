namespace HashTables.HashFunctions;

public interface ISimpleHashFunction
{
    string Title { get; }
    int Hash(int key);
}