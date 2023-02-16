using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babichevskyi_002
{

    public class CircularQueue<T>
    {
        private T[] data;
        private int front;
        private int rear;
        private int size;

        public CircularQueue(int size)
        {
            data = new T[size];
            front = rear = -1;
            this.size = size;
        }

        public void Enqueue(T item)
        {
            if ((front == 0 && rear == size - 1) || (rear == (front - 1) % (size - 1)))
            {
                throw new Exception("Queue is full");
            }
            else if (front == -1) // queue is empty
            {
                front = rear = 0;
                data[rear] = item;
            }
            else if (rear == size - 1 && front != 0)
            {
                rear = 0;
                data[rear] = item;
            }
            else
            {
                rear++;
                data[rear] = item;
            }
        }

        public T Dequeue()
        {
            if (front == -1)
            {
                throw new Exception("Queue is empty");
            }

            T item = data[front];
            data[front] = default(T);

            if (front == rear)
            {
                front = rear = -1;
            }
            else if (front == size - 1)
            {
                front = 0;
            }
            else
            {
                front++;
            }

            return item;
        }

        public T Peek()
        {
            if (front == -1)
            {
                throw new Exception("Queue is empty");
            }

            return data[front];
        }

        public bool IsEmpty()
        {
            return front == -1;
        }

        public bool IsFull()
        {
            return (front == 0 && rear == size - 1) || (rear == (front - 1) % (size - 1));
        }
    }






}
