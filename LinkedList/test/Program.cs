using System;

namespace test
{
    class Node<T>
    {
        public T Data;
        public Node<T> Prev;
        public Node<T> Next;
        public Node(T data)
        {
            Data = data;
        }
    }

    class CustomLinkedList<T>
    {
        Node<T> First = null;
        Node<T> Last = null;

        public void logValues()
        {
            Node<T> current = First;

            while(current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
        public void push(T value) {
            Node<T> elem = new Node<T>(value);
            
            if (First == null)
            {
                First = elem;
                Last = elem;
                elem.Prev = null;
            } else
            {
                Last.Next = elem;
                elem.Prev = Last;
                Last = elem;
            }
            elem.Next = null;
        }
        public T pop() {
            if (Last == null) throw new Exception("list is empty");

            Node<T> elem = Last;

            Last = elem.Prev;
            if (Last == null)
            {
                First = null;
            }else
            {
                Last.Next = null;
            }
            elem.Prev = null;

            return elem.Data;
        }
        public T shift() {
            if (First == null) throw new Exception("list is empty");

            Node<T> elem = First;
            First = elem.Next;
            if (First == null)
            {
                Last = null;
            } else
            {
                elem.Next = null;
                First.Prev = null;
            }

            return elem.Data;
        }
        public void unshift(T value) {

            Node<T> elem = new Node<T>(value);

            if (First == null)
            {
                First = elem;
                Last = elem;
                elem.Next = null;
            }
            else
            {
                First.Prev = elem;
                elem.Next = First;
                First = elem;
            }
            elem.Prev = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CustomLinkedList<int> list1 = new CustomLinkedList<int>();

            list1.push(1);
            list1.push(2);
            list1.push(3);
            list1.push(4);
            list1.unshift(0);
            list1.unshift(-1);

            try
            {
                Console.WriteLine(list1.shift());
                Console.WriteLine(list1.shift());
                Console.WriteLine(list1.pop());
                Console.WriteLine(list1.pop());
                list1.logValues();
                Console.WriteLine(list1.shift());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
