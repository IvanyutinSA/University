using System.Collections;
using System.Runtime.CompilerServices;

void display(Hashtable htable, string name)
{
    Console.Write(name + ":");
    foreach (var x in htable.Keys)
    {
        Console.Write("\t({0}, {1})", x, htable[x]);
    }
    Console.WriteLine();
}


var htable = new Hashtable();
var extraHtable = new Hashtable();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine("1. Add\n2. Clear\n3. Contains Key\n4. Contains Value\n" +
        "5. Equals\n6. Remove\n7. GetHashCode\n8. GetType");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Введите элементы в виде ключ:значение");
        var line = Console.ReadLine().Split(":");
        htable.Add(line[0], line[1]);
    }

    else if (method == "2")
    {
        htable.Clear();
    }

    else if (method == "3")
    {
        Console.WriteLine("Укажите ключ");
        Console.WriteLine(htable.ContainsValue(Console.ReadLine()));
    }

    else if (method == "4")
    {
        Console.WriteLine("Введите значение");
        Console.WriteLine(htable.ContainsValue(Console.ReadLine()));
    }

    else if (method == "5")
    {
        Console.WriteLine("Добавьте элементы в дополнительный массив (key:value)");
        for (string inputLine = Console.ReadLine(); inputLine != ""; inputLine = Console.ReadLine())
        {
            string[] line = inputLine.Split(":");
            extraHtable.Add(line[0], line[1]);
        }
        Console.WriteLine(htable.Equals(extraHtable));
        display(extraHtable, "extra htable");
    }

    else if (method == "6")
    {
        Console.WriteLine("Укажите ключ");
        htable.Remove(Console.ReadLine());
    }

    else if (method == "7")
    {
        Console.WriteLine(htable.GetHashCode());
    }

    else if (method == "8")
    {
        Console.WriteLine(htable.GetType());
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(htable, "htable");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
