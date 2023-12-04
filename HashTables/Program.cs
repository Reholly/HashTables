using HashTables.HashFunctions.BigTableHashFunctions;
using HashTables.HashFunctions.SmallTableHashFunctions;
using HashTables.HashTables;
using HashTables.Services;

var randomFiller = new RandomFiller();

var keyValuePairs = randomFiller.RandomKeyValuePairs(10000, -10000, 10000);

var divideTable = new SmallTable(new DivideMethodSimpleHashFunction());
var mulTable = new SmallTable(new MultiplyMethodSimpleHashFunction());
var xorTable = new SmallTable(new XorSimpleHashFunction());
var quadraticTable = new SmallTable(new QuadraticResidueXorHashFunction());
var digitSumTable = new SmallTable(new DigitSumHashFunction());

divideTable.AddRange(keyValuePairs);
mulTable.AddRange(keyValuePairs);
xorTable.AddRange(keyValuePairs);
quadraticTable.AddRange(keyValuePairs);
digitSumTable.AddRange(keyValuePairs);

var list = new List<SmallTable>
{
    divideTable, mulTable, xorTable, quadraticTable, digitSumTable
};

var count = 0;
foreach (SmallTable i in list)
{
    Console.WriteLine($"Таблица №{++count}");
    Console.WriteLine($"Коэффициент заполнения: {i.GetFillingCoefficient()}. ");
    Console.WriteLine($"Длина самой большой цепочки: {i.GetBiggestChainCount()}. ");
    Console.WriteLine($"Длина самой маленькой цепочки: {i.GetSmallestChainCount()}. ");
}

var bigTableLinear = new BigTable(new LinearMethodHashFunction());
var bigTableQuadratic = new BigTable(new QuadraticMethodHashFunction());
var bigTableDoubleHash = new BigTable(new DoubleHashMethodFunction());
var bigTableXor = new BigTable(new XorHashFunction());
var bigTableFibonacci = new BigTable(new FibonacciProbingHashFunction());

bigTableLinear.AddRange(keyValuePairs);
bigTableQuadratic.AddRange(keyValuePairs);
bigTableDoubleHash.AddRange(keyValuePairs);
bigTableXor.AddRange(keyValuePairs);
bigTableFibonacci.AddRange(keyValuePairs);

var bigTablesList = new List<BigTable>
{
    bigTableLinear, bigTableQuadratic, bigTableDoubleHash, bigTableXor, bigTableFibonacci
};

foreach (BigTable i in bigTablesList)
{
    Console.WriteLine($"Таблица №{++count}");
    Console.WriteLine($"Длина наибольшего кластера: {i.BiggestCluster()}. ");
}