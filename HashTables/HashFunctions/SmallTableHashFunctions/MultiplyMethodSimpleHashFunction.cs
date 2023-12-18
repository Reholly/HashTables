namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class MultiplyMethodSimpleHashFunction : ISimpleHashFunction
{
    public string Title => "Хэш-функция метода умножения";

    public int Hash(int key)
    {
        const double goldenCoefficient = 1.6180339887; //золотое сечение
        double coefficientA = Math.Abs(key) * goldenCoefficient; //значение, чтобы потом дробную часть взять
        
        // 1000 -1 
        return  (int) Math.Round((coefficientA - Math.Truncate(coefficientA)) * 999);
    }
}