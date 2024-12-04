class MyProgram
{
    public static void Main()
    {
        /* --------------- ADD ---------------- */

        MyList<int> list1 = new MyList<int> {37, 45, 78, 99};
        int number = 119;

        Console.WriteLine("Действие Add: ");
        Console.Write("\tНачальный список: " + string.Join(", ", list1));
        Console.WriteLine();
        Console.WriteLine($"\tНеобходимо добавить: {number}");

        list1.Add(number);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\tИзмененный список: " + string.Join(", ", list1));
        Console.ResetColor();





        /* --------------- COUNT ---------------- */

        MyList<int> list2 = new MyList<int> {37, 45, 78, 99, 578};

        Console.WriteLine("Действие Count: ");
        Console.Write("\tCписок: " + string.Join(", ", list2));
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\tКоличество элементов в списке: " + list2.Count);
        Console.ResetColor();




        /* --------------- REMOVE ---------------- */

        MyList<int> list3 = new MyList<int> {37, 45, 135, 999, 0};
        number = 999;

        Console.WriteLine("Действие Remove: ");
        Console.Write("\tНачальный список: " + string.Join(", ", list3));
        Console.WriteLine();
        Console.WriteLine($"\tНеобходимо удалить: {number}");

        list3.Remove(number);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\tИзмененный список: " + string.Join(", ", list3));
        Console.ResetColor();
    }
}