using System.Collections;
using System.Runtime.CompilerServices;

void display(string[] stack, string name)
{
    Console.Write(name + ":");
    for (int i = 0; i < stack.Length; i++)
    {
        Console.Write("\t{0}", stack[i]);
    }
    Console.WriteLine();
}


var stack = new Stack<string>();
while (true)
{
    Console.WriteLine("Меню.\n");
    Console.WriteLine(
        "1. Push\n" +
        "2. Pop\n" +
        "3. Peek\n" +
        "4. Clear\n" +
        "5. Contains\n" +
        "6. ToArray\n" +
        "7. TryPeek\n" +
        "8. TryPop\n" +
        "9. Задача"
        );

    string method = Console.ReadLine();

    if (method == "1")
    {
        Console.WriteLine("Укажите элемент");
        stack.Push(Console.ReadLine());
    }

    else if (method == "2")
    {
        if (stack.Count != 0)
            stack.Pop();
        else
            Console.WriteLine("Стэк пустой");
    }

    else if (method == "3")
    {
        if (stack.Count != 0)
            Console.WriteLine("Peek: {0}", stack.Peek());
        else
            Console.WriteLine("Стэк пустой");
    }

    else if (method == "4")
    {
        stack.Clear();
    }

    else if (method == "5")
    {
        Console.WriteLine("Укажите элемент");
        Console.WriteLine(stack.Contains(Console.ReadLine()));
    }

    else if (method == "6")
    {
        Console.WriteLine("Тип полученного объекта: {0}", stack.ToArray().GetType());
    }

    else if (method == "7")
    {
        Console.WriteLine(stack.TryPeek(out var result));
        Console.WriteLine("Результат: {0}", result);
    }

    else if (method == "8")
    {
        Console.WriteLine(stack.TryPop(out var result));
        Console.WriteLine("Результат: {0}", result);
    }

    else if (method == "9")
    {

        var brackets = new Stack<char>();
        char[] allBrackets = { '(', '[', '{', '}', ']', ')' };
        char[] openBrackets = { '(', '[', '{' };
        var pairBrackets = new Dictionary<char, char>();
        pairBrackets[')'] = '(';
        pairBrackets[']'] = '[';
        pairBrackets['}'] = '{';
        try
        {
            foreach (char symbol in Console.ReadLine())
            {
                if (pairBrackets.ContainsValue(symbol))
                    brackets.Push(symbol);
                else if (pairBrackets.ContainsKey(symbol))
                {
                    if (brackets.Peek() == pairBrackets[symbol])
                        brackets.Pop();
                    else
                        throw new Exception();
                }
            }
            if (brackets.Count != 0)
                throw new Exception();
            Console.WriteLine("Всё окей");
        }
        catch
        {
            Console.WriteLine("Нарушен порядок открытия/закрытия скобок");
        }
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    else
    {
        Console.WriteLine("Что-то непонятное.");
    }

    display(stack.ToArray(), "stack");
    Console.WriteLine("Нажмите любую кнопку");
    Console.ReadKey();
    Console.Clear();
}
