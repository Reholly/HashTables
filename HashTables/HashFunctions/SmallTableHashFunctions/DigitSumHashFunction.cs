namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class DigitSumHashFunction : ISimpleHashFunction
{
    public string Title { get; } = "Хэш-функция метода суммирования квадратов разряда и его разряда";

    /// <summary>
    /// Эта хеш-функция умножает каждую цифру числа на её
    /// квадрат и затем прибавляет к результату саму цифру.
    /// Это создает сложную зависимость между цифрами числа.
    /// </summary>
    public int Hash(int key)
    {
        var hash = 0;
        key = Math.Abs(key);
        
        while (key > 0)
        {
            int digit = key % 10;
            hash += digit * digit + digit;
            key /= 10;
        }

        return hash % 1000;
    }
}