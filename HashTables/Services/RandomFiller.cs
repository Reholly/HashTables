using KeyValuePair = HashTables.Models.KeyValuePair;

namespace HashTables.Services;

public class RandomFiller
{
    public KeyValuePair[] RandomKeyValuePairs(int count, int from, int to)
    {
        KeyValuePair[] keyValuePairs = new KeyValuePair[count];
        Random random = new Random();
        
        for (int i = 0; i < count; i++)
            keyValuePairs[i] = new KeyValuePair(random.Next(from, to), random.Next(from, to));

        return keyValuePairs;
    }
}