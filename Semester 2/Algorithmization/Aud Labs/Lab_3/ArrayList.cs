using System.Collections;

void display(ArrayList arrList, string name)
{
    Console.Write(name + ":");
    foreach(var x in arrList)
    {
        Console.Write("\t{0}", x);
    }
    Console.WriteLine();
}


var arrList = new ArrayList();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine("1. Add\n2. AddRange\n3. Clear\n4. Contains\n5. IndexOf\n" +
        "6. Remove\n7. Sort\n8. Insert\n9. Reverse");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Введите элемент");
        arrList.Add(Console.ReadLine());
    }

    else if (method == "2")
    {
        Console.WriteLine("Введите элементы, которые хотите добавить в коллекцию (чтобы прекратить ввод - введите пустую строку)");
        var extraArrList = new ArrayList();
        for (string x = Console.ReadLine(); x != ""; x = Console.ReadLine())
        {
            extraArrList.Add(x);
        }
        arrList.AddRange(extraArrList);
    }

    else if (method == "3")
    {
        arrList.Clear();
    }

    else if (method == "4")
    {
        Console.WriteLine("Укажите элемент");
        Console.WriteLine(arrList.Contains(Console.ReadLine()));
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите индекс");
        Console.WriteLine(arrList.IndexOf(Console.ReadLine()));
    }

    else if (method == "6")
    {
        Console.WriteLine("Укажите элемент");
        arrList.Remove(Console.ReadLine());
    }

    else if (method == "7")
    {
        arrList.Sort();
    }

    else if (method == "8")
    {
        Console.WriteLine("Укажите индекс");
        int index = int.Parse(Console.ReadLine());
        Console.WriteLine("Укажите элемент");
        arrList.Insert(index, Console.ReadLine());
    }

    else if (method == "9")
    {
        arrList.Reverse();
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(arrList, "arrayList");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
