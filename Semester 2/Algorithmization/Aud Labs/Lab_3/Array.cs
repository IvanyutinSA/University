void displayArray(Array arr, string name)
{
    Console.Write(name + ":");
    foreach (var x in arr)
    {
        Console.Write("\t{0}", x);
    }
    Console.WriteLine();
}


var arr = Array.CreateInstance(typeof(int), 5);
for (int i = 1; i < 6; i++)
    arr.SetValue(i, i-1);
var extraArray = Array.CreateInstance(typeof(int), 5);
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine("1. Binary Search\n2. Clear\n3. Copy\n4. Sort\n5. GetValue\n"
                    + "6. GetLength\n7. GetType\n8. IndexOf\n9. Reverse");

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Укажите элемент");
        Console.WriteLine(Array.BinarySearch(arr, Int32.Parse(Console.ReadLine())));
    }

    else if (method == "2")
        Array.Clear(arr);

    else if (method == "3")
    {
        Console.WriteLine("Сколько элементов вы хотите скопировать? (максимум 5)");
        Array.Copy(arr, extraArray, Int32.Parse(Console.ReadLine()));
        displayArray(extraArray, "extraArray");
    }

    else if (method == "4")
        Array.Sort(arr);

    else if (method == "5")
    {
        Console.WriteLine("Укажите индекс");
        Console.WriteLine(arr.GetValue(int.Parse(Console.ReadLine())));
    }

    else if (method == "6")
    {
        Console.WriteLine(arr.GetLength(0));
    }

    else if (method == "7")
    {
        Console.WriteLine(arr.GetType());
    }

    else if (method == "8")
    {
        Console.WriteLine("Укажите индекс");
        Console.WriteLine(Array.IndexOf(arr, int.Parse(Console.ReadLine())));
    }

    else if (method == "9")
    {
        Array.Reverse(arr);
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    Console.WriteLine();
    displayArray(arr, "array");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
