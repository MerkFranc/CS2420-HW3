public class Program
{
    private static DoublyLinkedList BuildList(int[] values)
    {
        DoublyLinkedList list = new DoublyLinkedList(values[0]);
        for (int i = 1; i < values.Length; i++)
        {
            list.Append(values[i]);
        }
        return list;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("===== Problem 1 =====\n");

        Console.WriteLine("=== Empty List ===");
        DoublyLinkedList emptyList = new DoublyLinkedList();
        emptyList.PrintList();
        Console.WriteLine("=== Reverse() ===");
        emptyList.Reverse();
        emptyList.PrintList();

        Console.WriteLine("\n=== One-Node List ===");
        DoublyLinkedList oneNodeList = new DoublyLinkedList(1);
        oneNodeList.PrintList();
        Console.WriteLine("=== Reverse() ===");
        oneNodeList.Reverse();
        oneNodeList.PrintList();

        Console.WriteLine("\n=== Two-Node List ===");
        DoublyLinkedList twoNodeList = BuildList(new int[] { 2, 3 });
        twoNodeList.PrintList();
        Console.WriteLine("=== Reverse() ===");
        twoNodeList.Reverse();
        twoNodeList.PrintList();

        Console.WriteLine("\n===== Problem 2 =====\n");


        Console.WriteLine("=== List ===");
        DoublyLinkedList dll = BuildList(new int[] { 3, 8, 5, 2, 10, 1 });
        dll.PrintList();
        Console.WriteLine("=== Partition ===");
        dll.PartitionList(5);
        dll.PrintList();





        Console.WriteLine("\nDone. Press any key to exit.");
        Console.ReadKey();

    }
}
