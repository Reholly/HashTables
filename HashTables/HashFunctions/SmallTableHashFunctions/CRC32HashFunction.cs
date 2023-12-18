namespace HashTables.HashFunctions.SmallTableHashFunctions;

public class Crc32HashFunction : ISimpleHashFunction
{
    private uint[] _table = null!;

    public Crc32HashFunction()
    {
        GenerateTable();
    }

    public string Title { get; } = "Хэш-функция CRC32";

    public int Hash(int key)
    {
        byte[] data = BitConverter.GetBytes(key);
        var crc = 0xFFFFFFFF;

        foreach (byte b in data)
        {
            var index = (byte)((crc & 0xFF) ^ b);
            crc = (crc >> 8) ^ _table[index];
        }

        return (int)Math.Abs(~crc % 1000); // Final XOR
    }

    private void GenerateTable()
    {
        const uint polynomial = 0xEDB88320;

        _table = new uint[256];

        for (uint i = 0; i < 256; i++)
        {
            uint crc = i;

            for (var j = 0; j < 8; j++)
            {
                if ((crc & 1) == 1)
                {
                    crc = (crc >> 1) ^ polynomial;
                }
                else
                {
                    crc >>= 1;
                }
            }

            _table[i] = crc;
        }
    }
}