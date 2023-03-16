using System.Collections;
using System.Runtime.CompilerServices;

void display(SortedList sortedList, string name)
{
    Console.Write(name + ":");
    for (int i = 0; i < sortedList.Count; i++)
    {
        Console.Write("\t({0} : {1})", sortedList.GetKey(i), sortedList.GetByIndex(i));
    }
    Console.WriteLine();
}


var sortedList = new SortedList();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine("1. Add\n2. Clear\n3. Contains Key\n4. Contains Value\n5. GetKey\n" +
        "6. GetKeyList\n7. GetValueList\n8. Remove\n9. SetByIndex");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Введите ключ:значение");
        var line = Console.ReadLine().Split(":");
        sortedList.Add(line[0], line[1]);
    }

    else if (method == "2")
    {
        sortedList.Clear();
    }

    else if (method == "3")
    {
        Console.WriteLine("Укажите ключ");
        Console.WriteLine("Результат: " + sortedList.ContainsKey(Console.ReadLine()));
    }

    else if (method == "4")
    {
        Console.WriteLine("Укажите значение");
        Console.WriteLine("Результат: " + sortedList.ContainsValue(Console.ReadLine()));
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите индекс");
        int index = int.Parse(Console.ReadLine());
        if (sortedList.Count < index)
            Console.WriteLine("Результат: ошибка");
        Console.WriteLine("Результат: " + sortedList.GetKey(index));
    }

    else if (method == "6")
    {
        Console.Write("Key list:");
        foreach (var key in sortedList.GetKeyList())
        {
            Console.Write("\t{0}", key);
        }
        Console.WriteLine();
    }

    else if (method == "7")
    {
        Console.Write("Value list:");
        foreach (var value in sortedList.GetValueList())
        {
            Console.Write("\t{0}", value);
        }
        Console.WriteLine();
    }

    else if (method == "8")
    {
        Console.WriteLine("Укажите ключ");
        sortedList.Remove(Console.ReadLine());
    }

    else if (method == "9")
    {
        Console.WriteLine("Укажите индекс");
        var index = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите значение");
        sortedList.SetByIndex(index, Console.ReadLine());
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(sortedList, "sortedList");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
