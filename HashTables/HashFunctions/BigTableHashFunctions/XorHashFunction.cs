﻿namespace HashTables.HashFunctions.BigTableHashFunctions;

public class XorHashFunction : IBiHashFunction
{
    public string Title => "Хэш-функция метод XOR";

    /// <summary>
    /// Эта хеш-функция использует операцию XOR между ключом и номером попытки.
    /// XOR обеспечивает быстродействие, а также дополнительную случайность
    /// в распределении, что может быть полезным для избегания кластеризации.
    /// </summary>
    public int Hash(int key, int attempt)
    {
        return Math.Abs(key ^ attempt) % 10000;
    }
}