using HashTables.HashFunctions.BigTableHashFunctions;
using HashTables.HashFunctions.SmallTableHashFunctions;
using HashTables.HashTables;
using HashTables.Services;
using KeyValuePair = HashTables.Models.KeyValuePair;

while (true)
{
    Console.WriteLine("Добро пожаловать, это Лабораторная Работа №6 по Теме: Хэш-таблицы.");
    Console.WriteLine("Пользователь вбивает нужное количество генерируемых уникальных пар Ключ-Значение.");
    Console.WriteLine("После этого проводится генерация элементов, которые позже вставляются в малую хэш-таблицу ");
    Console.WriteLine("и в большую. Затем получаются нужные замеры из задания лаборотарной работы.");
    try
    
    {
        Console.WriteLine("Введите число пар для малой хэш-таблицы: (1 <= 100000)");
        int smallCount = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите число пар для большой хэш-таблицы: (1 <= 10000)");
        int bigCount = int.Parse(Console.ReadLine());
        if (smallCount <= 0 || bigCount <= 0 || smallCount > 100000 || bigCount > 10000)
            throw new InvalidOperationException();
        var randomFiller = new RandomFiller();

        var smallPairs = randomFiller.RandomKeyValuePairs(smallCount, int.MinValue, int.MaxValue);
        var bigPairs = randomFiller.RandomKeyValuePairs(bigCount, -10000, 10000);
        
        var bigTables = GetAllBigTables(bigPairs);
        var smallTables = GetAllSmallTables(smallPairs);
        
        PrintSmallTablesData(smallTables);
        PrintBigTablesData(bigTables);
        
        Console.WriteLine(new string('=', 20));
        Console.WriteLine("Нажмите Enter, чтобы вернуться в самое начало.");
        Console.ReadKey();
        Console.Clear();
    }
    catch (Exception)
    {
        Console.Clear();
        Console.WriteLine("Ошибка в преобразовании числа, программа начата заново.");
    }
    

}

List<SmallTable> GetAllSmallTables(KeyValuePair[] pairs)
{
    var divTable = new SmallTable(new DivideMethodSimpleHashFunction());
    var mulTable = new SmallTable(new MultiplyMethodSimpleHashFunction());
    var xorTable = new SmallTable(new XorSimpleHashFunction());
    var quadraticTable = new SmallTable(new QuadraticResidueXorHashFunction());
    var digitSumTable = new SmallTable(new DigitSumHashFunction());
    var irrationalSinTable = new SmallTable(new IrrationalSinHash());

    divTable.AddRange(pairs);
    mulTable.AddRange(pairs);
    xorTable.AddRange(pairs);
    quadraticTable.AddRange(pairs);
    digitSumTable.AddRange(pairs);
    irrationalSinTable.AddRange(pairs);

    return new List<SmallTable>
    {
        divTable, mulTable, xorTable, quadraticTable, digitSumTable, irrationalSinTable
    };
}

List<BigTable> GetAllBigTables(KeyValuePair[] pairs)
{
    var bigTableLinear = new BigTable(new LinearMethodHashFunction());
    var bigTableQuadratic = new BigTable(new QuadraticMethodHashFunction());
    var bigTableDoubleHash = new BigTable(new DoubleHashMethodFunction());
    var bigTableXor = new BigTable(new XorHashFunction());
    var bigTableFibonacci = new BigTable(new FibonacciProbingHashFunction());

    bigTableLinear.AddRange(pairs);
    bigTableQuadratic.AddRange(pairs);
    bigTableDoubleHash.AddRange(pairs);
    bigTableXor.AddRange(pairs);
    bigTableFibonacci.AddRange(pairs);

    return new List<BigTable>
    {
        bigTableLinear, bigTableQuadratic, bigTableDoubleHash, bigTableXor, bigTableFibonacci
    };
}

void PrintSmallTablesData(List<SmallTable> tables)
{
    Console.WriteLine();
    foreach (var i in tables)
    {
        Console.WriteLine($"Таблица. {i.HashFunction.Title}.");
        Console.WriteLine($"Коэффициент заполнения: {i.GetFillingCoefficient()}. ");
        Console.WriteLine($"Длина самой большой цепочки: {i.GetBiggestChainCount()}. ");
        Console.WriteLine($"Длина самой маленькой цепочки: {i.GetSmallestChainCount()}. ");
        Console.WriteLine();
    }
}

void PrintBigTablesData(List<BigTable> tables)
{
    foreach (var i in tables)
    {
        Console.WriteLine($"Таблица. {i.HashFunction.Title}.");
        Console.WriteLine($"Длина наибольшего кластера: {i.BiggestCluster()}. ");
        Console.WriteLine();
    }
    Console.WriteLine();
}