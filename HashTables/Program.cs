using HashTables.HashFunctions.BigTableHashFunctions;
using HashTables.HashFunctions.SmallTableHashFunctions;
using HashTables.HashTables;
using HashTables.Services;

RandomFiller randomFiller = new RandomFiller();


var keyValuePairs = randomFiller.RandomKeyValuePairs(10000, -10000, 10000);

var divideTable = new SmallTable(new DivideMethodSimpleHashFunction());
var mulTable = new SmallTable(new MultiplyMethodSimpleHashFunction());
var xorTable = new SmallTable(new MultiplyMethodSimpleHashFunction());
divideTable.AddRange(keyValuePairs);
mulTable.AddRange(keyValuePairs);
xorTable.AddRange(keyValuePairs);
var list = new List<SmallTable> { divideTable, mulTable, xorTable };

int count = 0;
foreach (var i in list)
{
    Console.WriteLine(count++);
    Console.WriteLine($"Коэффициент заполнения: {i.GetFillingCoefficient()}. ");
    Console.WriteLine($"Длина самой большой цепочки: {i.GetBiggestChainCount()}. ");
    Console.WriteLine($"Длина самой маленькой цепочки: {i.GetSmallestChainCount()}. ");
}

var bigTableLinear = new BigTable(new LinearMethodHashFunction());
var bigTableQuadratic = new BigTable(new QuadraticMethodHashFunction());
var bigTableDoubleHash = new BigTable(new DoubleHashMethodFunction());

bigTableLinear.AddRange(keyValuePairs);
bigTableQuadratic.AddRange(keyValuePairs);
bigTableDoubleHash.AddRange(keyValuePairs);

var bigTablesList = new List<BigTable> {bigTableLinear, bigTableQuadratic, bigTableDoubleHash};

foreach (var i in bigTablesList)
{
    Console.WriteLine($"Таблица №{count++}");
    Console.WriteLine($"Длина наибольшего кластера: {i.BiggestCluster()}. ");
}