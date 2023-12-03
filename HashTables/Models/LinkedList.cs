using System.Collections;

namespace HashTables.Models;

public class LinkedList<T> : IEnumerable<Node<T>>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private uint _length;
    
    public uint Length
    {
        get => _length;
    }
    public bool IsEmpty
    {
        get => _length == 0;
    }
    public Node<T> First
    {
        get => _head;
    }
    public Node<T> Last
    {
        get => _tail;
    }

    public Node<T> this[int index]
    {
        get
        {
            if (index >= _length || index < 0)
                throw new InvalidOperationException("Индекс за границами списка!");
            int current = 0;

            foreach (var item in this)
            {
                if (current == index)
                    return item;
                current++;
            }

            throw new InvalidOperationException("Не нашелся элемент с нужным индексом");
        }
    }
    
    public void AppendToEnd(T data)
    {
        if (data is null)
            throw new NullReferenceException("Ошибка! Попытка добавить null");
        var currentNode = new Node<T>(data);
        
        if (_head is null || _tail is null)
        {
            _head = currentNode;
            _tail = currentNode;
            _length++;
            return;
        }

        _tail.Next = currentNode;
        currentNode.Previous = _tail;
        _tail = currentNode;

        _length++;
    }
    
    public void RemoveFirstByValue(T data)
    {
        if (data is null)
            throw new NullReferenceException("Ошибка! Попытка удалить null!");
        Node<T>? currentNode = _head;
        
        while (currentNode is not null)
        {
            if (currentNode.Data!.Equals(data))
                break;
            
            currentNode = currentNode.Next;
        }
        if (currentNode is not null)
        {
            if(currentNode.Next!=null)
                currentNode.Next.Previous = currentNode.Previous;
            else
                _tail = currentNode.Previous;
            
            if(currentNode.Previous!=null)
                currentNode.Previous.Next = currentNode.Next;
            else
                _head = currentNode.Next;
            
            _length--;
        }
    }
        
    public IEnumerator<Node<T>> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }
}