// 11. Implement the data structure linked list. Define a class ListItem<T> that has two fields: 
// value (of type T) and Next (of type ListItem<T>). Define additionally a class LinkedList<T> 
// with a single field FirstElement (of type ListItem<T>).

namespace LinkedListDefinition
{
    using System;
    using System.Linq;

    internal class Demo
    {
        private static void Main()
        {
            var list = new CustomLinkedList<int>();

            list.AddItem(1);
            list.AddItem(3);
            list.AddItem(5);

            Console.WriteLine(list);

            list.AddFirst(100);
            Console.WriteLine(list);

            list.RemoveFirst();
            Console.WriteLine(list);

            list.RemoveItem(3);
            Console.WriteLine(list);
        }
    }
}