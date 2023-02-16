using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_002
{

    public class DoublyLinkedList<T>
    {
        private Node head;
        private Node tail;
        private int count;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddFirst(T data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

            count++;
        }

        public void AddLast(T data)
        {
            Node newNode = new Node(data);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        public void Remove(T data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Prev == null)
                    {
                        head = current.Next;
                        if (head != null)
                        {
                            head.Prev = null;
                        }
                    }
                    else if (current.Next == null)
                    {
                        tail = current.Prev;
                        if (tail != null)
                        {
                            tail.Next = null;
                        }
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    count--;
                    break;
                }

                current = current.Next;
            }
        }

        public bool Contains(T data)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public int Count
        {
            get { return count; }
        }

        private class Node
        {
            public T Data { get; private set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Prev = null;
                Next = null;
            }
        }
    }






}
