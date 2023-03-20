using System.Collections;

void display(HashSet<string> someSet, string name)
{
    Console.Write(name + ":");
    foreach (var x in someSet)
    {
        Console.Write("\t{0}", x);
    }
    Console.WriteLine();
}


var someSet = new HashSet<string>();

while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine(
        "1. Add\n" +
        "2. Remove\n" +
        "3. Contains\n" +
        "4. Try Get Value\n" +
        "5. Union With\n" +
        "6. Intersect With\n" +
        "7. Is Subset Of\n" +
        "8. Is Superset of\n" +
        "9. Clear");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Введите элемент");
        someSet.Add(Console.ReadLine());
    }

    else if (method == "2")
    {
        Console.WriteLine("Укажите элемент");
        someSet.Remove(Console.ReadLine());
    }

    else if (method == "3")
    {
        Console.WriteLine("Укажите элемент");
        Console.WriteLine("Contains?: {0}", someSet.Contains(Console.ReadLine()));
    }

    else if (method == "4")
    {
        Console.WriteLine("Укажите элемент");
        if (someSet.TryGetValue(Console.ReadLine(), out string value))
            Console.WriteLine("Значение: {0}", value);
        else
            Console.WriteLine("Такого значения нет");
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите значения дополнительного множества");
        var extraSet = new HashSet<string>();
        for (string value = Console.ReadLine(); value != null; value = Console.ReadLine())
            extraSet.Add(value);
        someSet.UnionWith(extraSet);
    }

    else if (method == "6")
    {
        Console.WriteLine("Укажите значения дополнительного множества");
        var extraSet = new HashSet<string>();
        for (string value = Console.ReadLine(); value != null; value = Console.ReadLine())
            extraSet.Add(value);
        someSet.IntersectWith(extraSet);
    }

    else if (method == "7")
    {
        Console.WriteLine("Укажите значения дополнительного множества");
        var extraSet = new HashSet<string>();
        for (string value = Console.ReadLine(); value != null; value = Console.ReadLine())
            extraSet.Add(value);
        Console.WriteLine(someSet.IsSubsetOf(extraSet));
    }

    else if (method == "8")
    {
        Console.WriteLine("Укажите значения дополнительного множества");
        var extraSet = new HashSet<string>();
        for (string value = Console.ReadLine(); value != null; value = Console.ReadLine())
            extraSet.Add(value);
        Console.WriteLine(someSet.IsSupersetOf(extraSet));
    }

    else if (method == "9")
    {
        someSet.Clear();
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(someSet, "Hash Set");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
