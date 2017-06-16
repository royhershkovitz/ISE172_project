using System;


public class Node<T>
{
    private T _info;
    private Node<T> _next;
       
    /*Constructor*/
    public Node(T info)
    {
        _info = info;
        _next = null;
    }

    /*Constructor*/
    public Node(T info, Node<T> next)
    {
        _info = info;
        _next = next;
    }

    /*Return current node data */
    public T GetInfo()
    {
        return _info;
    }

    /*Return current node next node */
    public Node<T> GetNext()
    {
        return _next;
    }
    /*set current node data */
    public void SetInfo(T info)
    {
        _info = info;
    }
    /*set current node next node */
    public void SetNext(Node<T> next)
    {
        _next = next;
    }
}

