using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Week04
{
    // Node class
    public class Node
    {
        public int Value;
        public Node Next;

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }

    // LinkedList class
    public class LinkedList : IEnumerable<int>
    {
        public Node Head;

        public LinkedList()
        {
            Head = null;
        }

        // Insert at the head
        public void InsertHead(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
        }

        // TODO: Problem 1 - Insert Tail
        public void InsertTail(int value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                return;
            }
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        // TODO: Problem 2 - Remove Tail
        public void RemoveTail()
        {
            if (Head == null) return;
            if (Head.Next == null)
            {
                Head = null;
                return;
            }
            Node current = Head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }

        // TODO: Problem 3 - Remove by value
        public void Remove(int value)
        {
            if (Head == null) return;
            if (Head.Value == value)
            {
                Head = Head.Next;
                return;
            }

            Node current = Head;
            while (current.Next != null)
            {
                if (current.Next.Value == value)
                {
                    current.Next = current.Next.Next;
                    break;
                }
                current = current.Next;
            }
        }

        // TODO: Problem 4 - Replace oldValue with newValue
        public void Replace(int oldValue, int newValue)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Value == oldValue)
                {
                    current.Value = newValue;
                }
                current = current.Next;
            }
        }

        // TODO: Problem 5 - Forward iterator
        public IEnumerator<int> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        // Reverse iterator
        public IEnumerable<int> Reverse()
        {
            Stack<int> stack = new Stack<int>();
            Node current = Head;
            while (current != null)
            {
                stack.Push(current.Value);
                current = current.Next;
            }
            while (stack.Count > 0)
            {
                yield return stack.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}