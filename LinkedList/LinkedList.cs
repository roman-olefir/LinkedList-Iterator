using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList : IEnumerable<int>
    {
        private Node head; // голова
        private Node tail; // хвіст
        private int count; // кількість елементів у списку

        public int Count => count;

        public void Add(int data)
        {
            Node node = new Node(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        public void Remove(int data)
        {
            Node pointer = head;
            Node last = null;

            while (pointer != null)
            {
                if (pointer.Data.Equals(data))
                {
                    if (last != null)
                    {
                        last.Next = pointer.Next;

                        if (pointer.Next == null)
                            tail = last;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                }
                last = pointer;
                pointer = pointer.Next;
            }
        }

        public bool Contains(int data)
        {
            Node pointer = head;

            while (pointer != null)
            {
                if (pointer.Data.Equals(data))
                {
                    return true;
                }
                pointer = pointer.Next;
            }
            return false;
        }

        public int GetByIndex(int inputIndex)
        {
            if (inputIndex < 0 || inputIndex >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node pointer = head;

            for (int i = 0; i < inputIndex; i++)
            {
                pointer = pointer.Next;
            }
            return pointer.Data;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LinkedListIEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LinkedListIEnumerator(this);
        }

        class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        class LinkedListIEnumerator : IEnumerator<int>
        {
            private LinkedList linkedList;

            public LinkedListIEnumerator(LinkedList linkedList)
            {
                this.linkedList = linkedList;
            }

            public int Current => current;

            object IEnumerator.Current => current;

            private int pointer;
            private int current;

            public bool MoveNext()
            {
                if (++pointer < linkedList.Count)
                {
                    current = linkedList.GetByIndex(pointer);
                    return true;
                }
                else return false;
            }

            public void Reset()
            {
                pointer = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
