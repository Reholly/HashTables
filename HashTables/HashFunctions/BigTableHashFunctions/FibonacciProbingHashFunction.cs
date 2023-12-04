namespace HashTables.HashFunctions.BigTableHashFunctions;

public class FibonacciProbingHashFunction : IBiHashFunction
{
    private static readonly int Fibonacci = (int)(10000 / ((1 + Math.Sqrt(5)) / 2));
    
    /// <summary>
    /// Фибоначчиево пробирование использует ближайшее к золотому сечению простое число
    /// для расчета смещения. Это может предотвратить кластеризацию и обеспечить хорошее распределение.
    /// </summary>
    public int Hash(int key, int attempt)
    {
        return (key + attempt * Fibonacci) % 10000;
    }
}