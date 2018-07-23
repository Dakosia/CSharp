using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularQueue
{
    //FIFO - First In First Out
    class Program
    {
        static void Main(string[] args)
        {
            CircularQueue q = new CircularQueue(5);
            Random r = new Random();
            q.Enqueue(r.Next(1, 101));
            q.Enqueue(r.Next(1, 101));
            q.Enqueue(r.Next(1, 101));
            q.Enqueue(r.Next(1, 101));
            q.Enqueue(r.Next(1, 101));

            Console.WriteLine("Elements in the circular queue:");
            q.PrintQueue();

            q.Dequeue();
            q.Dequeue();

            q.Enqueue(r.Next(1, 101));
            q.Enqueue(r.Next(1, 101));

            Console.WriteLine("Elements in the circular queue:");
            q.PrintQueue();
        }
    }
}
