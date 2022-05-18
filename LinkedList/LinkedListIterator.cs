using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedListIterator : IEnumerator<int>
    {
        private LinkedList linkedList;

        public LinkedListIterator(LinkedList linkedList)
        {
            this.linkedList = linkedList;
        }

        public int Current => current;

        object IEnumerator.Current => throw new NotImplementedException();

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
