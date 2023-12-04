namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class QuadraticResidueXorHashFunction : ISimpleHashFunction
{
    /// <summary>
    /// Эта хеш-функция использует квадратичную резидуацию
    /// (возвод числа в квадрат по модулю простого числа)
    /// в сочетании с операцией XOR. Квадратичная резидуация вносит
    /// дополнительную нелинейность, что может повысить уровень сложности хеш-функции.
    /// </summary>
    public int Hash(int key)
    {
        int hash = key;
        
        const int prime = 997;
        hash = hash * hash % prime;
        
        hash ^= key;

        return hash % 1000;
    }
}