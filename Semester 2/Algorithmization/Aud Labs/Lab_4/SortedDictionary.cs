using System.Collections;

void display(SortedDictionary<string, string> sortedDict, string name)
{
    Console.Write(name + ":");
    foreach (var x in sortedDict.Keys)
    {
        Console.Write("\t({0} : {1})", x, sortedDict[x]);
    }
    Console.WriteLine();
}


var sortedDict = new SortedDictionary<string, string>();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine(
        "1. Add\n" +
        "2. Remove\n" +
        "3. Try Add\n" +
        "4. Try Get Value\n" +
        "5. Contains Key\n" +
        "6. Contains Value\n" +
        "7. Clear\n" +
        "8. Get Type\n" +
        "9. To String");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Введите ключ:значение");
        var item = Console.ReadLine().Split(":");
        sortedDict.Add(item[0], item[1]);
    }

    else if (method == "2")
    {
        Console.WriteLine("Укажите ключ");
        sortedDict.Remove(Console.ReadLine());
    }

    else if (method == "3")
    {
        Console.WriteLine("Укажите ключ:значение");
        var pair = Console.ReadLine().Split(":");
        if (!sortedDict.TryAdd(pair[0], pair[1]))
            Console.WriteLine("Пара с указанным ключом уже существует");
    }

    else if (method == "4")
    {
        Console.WriteLine("Укажите ключ");
        if (sortedDict.TryGetValue(Console.ReadLine(), out string value))
            Console.WriteLine("value: {0}", value);
        else
            Console.WriteLine("Пары с данным ключём не существует");
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите ключ");
        Console.WriteLine(sortedDict.ContainsKey(Console.ReadLine()));
    }

    else if (method == "6")
    {
        Console.WriteLine("Укажите значение");
        Console.WriteLine(sortedDict.ContainsValue(Console.ReadLine()));
    }

    else if (method == "7")
    {
        sortedDict.Clear();
    }

    else if (method == "8")
    {
        Console.WriteLine(sortedDict.GetType);
    }

    else if (method == "9")
    {
        Console.WriteLine(sortedDict.ToString());
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(sortedDict, "Sorted Dictionary");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
