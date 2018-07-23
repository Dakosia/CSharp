using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    public class CircularQueue
    {
        private int[] elements;
        private int head;
        private int tail;
        private int max;
        private int cnt;
        
        public void Enqueue(int item)
        {
            if (cnt == max)
                throw new Exception("Queue Overflow");
            else
            {
                tail = (tail + 1) % max;
                elements[tail] = item;
                cnt++;
            }
        }

        public void Dequeue()
        {
            if (cnt == 0)
                throw new Exception("Queue is Empty");
            else
            {
                head = (head + 1) % max;
                cnt--;
            }
        }

        public void PrintQueue()
        {
            if (cnt == 0)
                throw new Exception("Queue is Empty");
            else
            {
                for (int j = 0; j < cnt; j++)
                {
                    Console.WriteLine("Element[" + (head + 1) + "]: " + elements[head]);

                    head = (head + 1) % max;
                }
            }
        }

        public CircularQueue(int size)
        {
            elements = new int[size];
            head = 0;
            tail = -1;
            max = size;
            cnt = 0;
        }
    }
}
