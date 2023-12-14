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
    
    private int[] GenerateUniqueKeys(int count)
    {
        int[] values = new int[count];

        for (int i = 0; i < values.Length; ++i)
            values[i] =  i;

        Random random = new Random();

        for (int i = 0; i < values.Length; ++i)
        {
            int index = random.Next(values.Length);

            if (i == index)
                continue;

            (values[i], values[index]) = (values[index], values[i]);
        }

        return values;
    }
}