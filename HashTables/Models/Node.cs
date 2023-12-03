namespace HashTables.Models;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Previous { get; set; }

    public Node(T nodeData) => Data = nodeData;
}