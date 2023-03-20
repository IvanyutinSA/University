using System.Collections;
using System.Runtime.CompilerServices;

void display(string[] queue, string name)
{
    Console.Write(name + ":");
    for (int i = 0; i < queue.Length; i++)
    {
        Console.Write("\t{0}", queue[i]);
    }
    Console.WriteLine();
}


var queue = new Queue<string>();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine(
        "1. Enqueue\n" +
        "2. Dequeue\n" +
        "3. Peek\n" +
        "4. Clear\n" +
        "5. Contains\n" +
        "6. ToArray\n" +
        "7. TryPeek\n" +
        "8. TryDequeue\n" +
        "9. Equals"
        );

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Укажите элемент");
        queue.Enqueue(Console.ReadLine());
    }

    else if (method == "2")
    {
        if (queue.Count != 0)
            queue.Dequeue();
        else
            Console.WriteLine("Стэк пустой");
    }

    else if (method == "3")
    {
        if (queue.Count != 0)
            Console.WriteLine("Peek: {0}", queue.Peek());
        else
            Console.WriteLine("Стэк пустой");
    }

    else if (method == "4")
    {
        queue.Clear();
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите элемент");
        Console.WriteLine(queue.Contains(Console.ReadLine()));
    }

    else if (method == "6")
    {
        Console.WriteLine("Тип полученного объекта: {0}", queue.ToArray().GetType());
    }

    else if (method == "7")
    {
        Console.WriteLine(queue.TryPeek(out var result));
        Console.WriteLine("Результат: {0}", result);
    }

    else if (method == "8")
    {
        Console.WriteLine(queue.TryDequeue(out var result));
        Console.WriteLine("Результат: {0}", result);
    }

    else if (method == "9")
    {
        var newQueue = new Queue();
        Console.WriteLine("Укажите элементы новой очереди");
        for (string element = Console.ReadLine(); element != null; element = Console.ReadLine())
            newQueue.Enqueue(element);
        Console.WriteLine(queue.Equals(newQueue));

    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(queue.ToArray(), "queue");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
