namespace HashTables.HashFunctions.BigTableHashFunctions;

public class XxHashFunction(uint seed = 0) : IBiHashFunction
{
    private const uint Prime1 = 2654435761U;
    private const uint Prime2 = 2246822519U;
    private const uint Prime3 = 3266489917U;
    private const uint Prime4 = 668265263U;
    private const uint Prime5 = 374761393U;

    public string Title => "Хэш-функция xxHash";

    public int Hash(int key, int attempt)
    {
        byte[] data = new byte[8];
        Buffer.BlockCopy(BitConverter.GetBytes(key), 0, data, 0, 4);
        Buffer.BlockCopy(BitConverter.GetBytes(attempt), 0, data, 4, 4);

        uint hash = seed + Prime5;

        int len = data.Length;
        int index = 0;

        if (len >= 4)
        {
            int limit = len - 4;
            uint v1 = seed + Prime1 + Prime2;
            uint v2 = seed + Prime2;
            uint v3 = seed;
            uint v4 = seed - Prime1;

            do
            {
                v1 = Round(v1, BitConverter.ToUInt32(data, index));
                index += 4;
                v2 = Round(v2, BitConverter.ToUInt32(data, index));
                index += 4;

                if (index <= limit)
                {
                    v3 = Round(v3, BitConverter.ToUInt32(data, index));
                    index += 4;
                }

                if (index <= limit)
                {
                    v4 = Round(v4, BitConverter.ToUInt32(data, index));
                    index += 4;
                }
            } while (index <= limit);

            hash = RotateLeft(v1, 1) + RotateLeft(v2, 7) + RotateLeft(v3, 12) + RotateLeft(v4, 18);
        }

        hash += (uint)len;

        while (index <= len - 4)
        {
            hash += BitConverter.ToUInt32(data, index) * Prime3;
            hash = RotateLeft(hash, 17) * Prime4;
            index += 4;
        }

        while (index < len)
        {
            hash += data[index] * Prime5;
            hash = RotateLeft(hash, 11) * Prime1;
            index++;
        }

        hash ^= hash >> 15;
        hash *= Prime2;
        hash ^= hash >> 13;
        hash *= Prime3;
        hash ^= hash >> 16;

        return (int)(hash % 10000);
    }

    private static uint RotateLeft(uint value, int count)
    {
        return (value << count) | (value >> (32 - count));
    }

    private static uint Round(uint acc, uint input)
    {
        acc += input * Prime2;
        acc = RotateLeft(acc, 13);
        acc *= Prime1;
        return acc;
    }
}