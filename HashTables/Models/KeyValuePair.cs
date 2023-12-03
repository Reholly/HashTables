namespace HashTables.Models;

public class KeyValuePair
{
    public int Key { get; set; }
    public int Value { get; set; }

    public KeyValuePair(int key, int value)
    {
        Key = key;
        Value = value;
    }
}