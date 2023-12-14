namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class IrrationalSinHash : ISimpleHashFunction
{
    public string Title { get; } = "Хэш-функция метод вычисления хэша с помощью иррациональных чисел и синуса";
    
    /// <summary>
    /// Эта хеш-функция использует произведение различных иррациональных чисел
    /// в сочетании с синусом входного целого числа. Комбинация иррациональных чисел и тригонометрических
    /// функций может создать сложную и непредсказуемую последовательность чисел.
    /// </summary>
    
    public int Hash(int input)
    {
        const double irrationalNumber = Math.PI * Math.E * Math.Tau * 1000;
        double result = irrationalNumber * Math.Sin(input);
        
        var hash = Convert.ToInt32(result);

        return Math.Abs(hash) % 1000;
    }
}