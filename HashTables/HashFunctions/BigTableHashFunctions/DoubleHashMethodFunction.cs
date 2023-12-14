namespace HashTables.HashFunctions.BigTableHashFunctions;

public class DoubleHashMethodFunction : IBiHashFunction
{
    public string Title { get; } = "Хэш-функция метод двойного хэширования";

    public int Hash(int key, int attempt)
    {
        //h(k,i)=(h1(k)+i⋅h2(k))mod10000
        //Первая хэш функция метода деления, потом прибавляем к ее результату хэш-функцию
        // линейного метода исследования.
        key = Math.Abs(key);
        return (key % 10000 + attempt * (key + attempt) % 10000) % 10000;
    }
}