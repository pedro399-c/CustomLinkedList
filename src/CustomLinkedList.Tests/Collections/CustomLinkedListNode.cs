namespace CustomLinkedList.Tests.Collections
{
    public class CustomLinkedListNode<T>
    {
        public T NodeValue { get; set; }

        public CustomLinkedListNode<T>? Previous { get; set; }

        public CustomLinkedListNode<T>? Next { get; set; }

        public CustomLinkedListNode(T nodeValue)
        {
            this.NodeValue = nodeValue;
        }
    }
}
