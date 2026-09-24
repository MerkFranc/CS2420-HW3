using System;

// ============================================================
// Node class — kept OUTSIDE the DoublyLinkedList class.
// A DLL node carries TWO links: next (forward) and prev (backward).
// ============================================================
public class Node
{
    public int value;
    public Node? next;
    public Node? prev;

    public Node(int value)
    {
        this.value = value;
    }
}

// ============================================================
// DoublyLinkedList class — head/tail/length plus every method.
// ============================================================
public class DoublyLinkedList
{
    private Node? head;
    private Node? tail;
    private int length;

    // Creates an empty list
    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        length = 0;
    }

    // Creates a list with one node
    public DoublyLinkedList(int value)
    {
        Node newNode = new Node(value);
        head = newNode;
        tail = newNode;
        length = 1;
    }

    public void PrintList()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        Node? temp = head;

        Console.Write("head -> ");

        while (temp != null)
        {
            Console.Write(temp.value);

            if (temp.next != null)
            {
                Console.Write(" <-> ");
            }

            temp = temp.next;
        }

        Console.Write(" <- tail");


        Console.WriteLine();
    }

    public void GetHead()
    {
        Console.WriteLine(head == null ? "Head: null" : "Head: " + head.value);
    }

    public void GetTail()
    {
        Console.WriteLine(tail == null ? "Tail: null" : "Tail: " + tail.value);
    }

    public void GetLength()
    {
        Console.WriteLine("Length: " + length);
    }

    // ========================================================
    // Append — add to the end.
    // newNode.prev = old tail, then tail moves forward. O(1).
    // ========================================================
    public void Append(int value)
    {
        Node newNode = new Node(value);

        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        length++;
    }

    // ========================================================
    // Prepend — add to the front.
    // newNode.next = old head, old head.prev = newNode. O(1).
    // ========================================================
    public void Prepend(int value)
    {
        Node newNode = new Node(value);

        if (length == 0)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.next = head;
            head!.prev = newNode;
            head = newNode;
        }

        length++;
    }

    // ========================================================
    // Reverse - swap next/prev at every node, then swap head/tail.
    // current.prev temporarily holds the ORIGINAL next node, so
    // "current = current.prev" still walks forward through the list.
    // ========================================================
    public void Reverse()
    {
        if (length == 0 || length == 1) return;

        Node? current = head;
        Node? temp;
        while (current != null)
        {
            temp = current.prev;
            current.prev = current.next;
            current.next = temp;
            current = current.prev;
        }

        temp = head;
        head = tail;
        tail = temp;
    }
    // ===================================
    // Time Complexity - O(n)
    // The loop visits each node exactly once and swaps its prev and next. 
    // ==================================

    // ========================================================
    // Partition - Dummy chains are used to collect values < x and >= x
    // current node is used to traverse list
    // prev1 and prev 2 serve as end pointers for each of the dummy chains
    // The end of the < chain is connected to the start of the >= chain
    // ========================================================
    public void PartitionList(int x)
    {
        Console.WriteLine($"Partitioning around: {x}");

        if (head == null)
        {
            return;
        }

        // Dummy nodes for the two partitions
        Node dummy1 = new Node(0); // values < x
        Node dummy2 = new Node(0); // values >= x

        Node prev1 = dummy1;
        Node prev2 = dummy2;

        Node? current = head;

        while (current != null)
        {
            Node? next = current.next;

            if (current.value < x)
            {
                prev1.next = current;
                prev1 = current;
            }
            else
            {
                prev2.next = current;
                prev2 = current;
            }
            current = current.next;
        }
        
        // Terminate the greter-or-equal chain
        prev2.next = null;

        // Conncect the two chains (skip the dumies)
        prev1.next = dummy2.next;

        // Update head
        head = dummy1.next;

        // Update tail
        if (dummy2.next != null)
            tail = prev2;
        else 
            tail = prev1;
    }
    // =========================================
    // Time Complexity - O(n)
    // This only passes through the list a single time
    // ==========================================

    

}