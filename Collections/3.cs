using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_002
{

    public class LinkedList<T>
    {
        private Node head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public void AddFirst(T data)
        {
            Node newNode = new Node(data);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void AddLast(T data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            count++;
        }

        public void Remove(T data)
        {
            if (head == null)
            {
                return;
            }

            if (head.Data.Equals(data))
            {
                head = head.Next;
                count--;
                return;
            }

            Node previous = null;
            Node current = head;

            while (current != null && !current.Data.Equals(data))
            {
                previous = current;
                current = current.Next;
            }

            if (current != null)
            {
                previous.Next = current.Next;
                count--;
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
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }
    }






}
