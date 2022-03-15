using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList.Tests.Collections
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private CustomLinkedListNode<T>? firstElement;

        public int Count => this.GetTotalRecords();

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public CustomLinkedListNode<T> AddFirst(T value)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(value)
            {
                Next = firstElement
            };

            firstElement = node;

            if (node.Next != null)
            {
                node.Next.Previous = node;
            }

            return node;
        }

        public CustomLinkedListNode<T> AddLast(T value)
        {
            CustomLinkedListNode<T> node = new CustomLinkedListNode<T>(value);

            if (firstElement == null)
            {
                firstElement = node;
            }
            else
            {
                var current = firstElement;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
                node.Previous = current;
            }

            return node;
        }

        public bool Remove(CustomLinkedListNode<T> node)
        {
            return this.RemoveNode(this.Find(node, false));
        }

        public bool Remove(T value)
        {
            return this.RemoveNode(this.Find(value, false));
        }

        public CustomLinkedListNode<T> AddAfter(CustomLinkedListNode<T> node, T value)
        {
            var nodeToFind = this.Find(node);

            if (nodeToFind == null)
            {
                throw new Exception();
            }

            CustomLinkedListNode<T> nodeToInsert = new CustomLinkedListNode<T>(value)
            {
                Previous = nodeToFind,
                Next = nodeToFind.Next
            };

            nodeToFind.Next = nodeToInsert;
            return nodeToInsert;
        }

        public CustomLinkedListNode<T>? Find(T value)
        {
            return this.Find(value, true);
        }

        public CustomLinkedListNode<T>? Find(CustomLinkedListNode<T> node)
        {
            return this.Find(node, true);
        }

        private int GetTotalRecords()
        {
            if (firstElement == null)
            {
                return 0;
            }

            var totalRecords = 1;

            var current = firstElement;

            while (current?.Next != null)
            {
                totalRecords++;
                current = current.Next;
            }

            return totalRecords;
        }

        private CustomLinkedListNode<T>? Find(T value, bool throwException)
        {
            if (firstElement == null)
            {
                if (throwException)
                {
                    throw new Exception();
                }

                return null;
            }

            var current = firstElement;
            CustomLinkedListNode<T>? elementToReturn = null;

            while (current != null && elementToReturn == null)
            {
                if (current.NodeValue.Equals(value))
                {
                    elementToReturn = current;
                }

                current = current.Next;
            }

            if (elementToReturn == null && throwException)
            {
                throw new Exception();
            }

            return elementToReturn;
        }

        private CustomLinkedListNode<T>? Find(CustomLinkedListNode<T> node, bool throwException)
        {
            if (firstElement == null)
            {
                if (throwException)
                {
                    throw new Exception();
                }

                return null;
            }

            var current = firstElement;
            CustomLinkedListNode<T>? elementToReturn = null;

            while (current != null && elementToReturn == null)
            {
                if (current.Equals(node))
                {
                    elementToReturn = current;
                }

                current = current.Next;
            }

            if (elementToReturn == null && throwException)
            {
                throw new Exception();
            }

            return elementToReturn;
        }

        private bool RemoveNode(CustomLinkedListNode<T>? node)
        {
            if (node == null)
            {
                return false;
            }

            var newFirstElement = node.Next;

            if (newFirstElement != null)
            {
                if (node.Previous == null)
                {
                    firstElement = newFirstElement;
                }
                else
                {
                    node.Previous.Next = node.Next;
                }
            }
            else
            {
                firstElement = null;
            }

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = firstElement;

            while (current != null)
            {
                yield return current.NodeValue;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var current = firstElement;

            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}
