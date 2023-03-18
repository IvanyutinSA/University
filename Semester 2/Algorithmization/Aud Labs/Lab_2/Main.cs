using Labs;
using System.Runtime.CompilerServices;

DateTime goToDateTime(string stringName)
{
    int[] date = Array.ConvertAll(stringName.Split('.'), int.Parse);
    return new DateTime(date[2], date[1], date[0]);
}


var employeers = new List<Employee>();

while (true)
{
    Console.WriteLine("Меню.");

    Console.WriteLine("\n" +
        "1. Добавить работника\n" +
        "2. Общий стаж работников\n" +
        "3. Количество экземпляров, отпечатанных работником за диапозон дат\n" +
        "4. Работы, выполненные вспомогательным составом\n" +
        "5. Приказы и распоряжения, которые были выданы определённым лицом"
        );

    string message = Console.ReadLine();
    Console.WriteLine();

    if (message == "1")
    {
        Console.WriteLine("Укажите ФИО");
        string fullName = Console.ReadLine();
        Console.WriteLine("\nУкажите должность");
        string jobTitle = Console.ReadLine();
        Console.WriteLine("\nДалее везде, чтобы прекратить ввод, нужно ввести null");
        Console.WriteLine("\n" +
            "Далее заполните трудовую книжку\n" +
            "Вводите в виде дата_поступления наименование_организации дата_увольнения\n" +
            "Пример: 01.01.2001 Политех 05.05.2005"
            );

        var empHistory = new List<List<object>>();

        for (string inputLine = Console.ReadLine(); inputLine != null; inputLine = Console.ReadLine())
        {
            string[] line = inputLine.Split(' ');
            var startDate = goToDateTime(line[0]);
            var endDate = goToDateTime(line[2]);
            empHistory.Add(new List<object>() { startDate, line[1], endDate });
        }

        Console.WriteLine("\n" +
            "Укажите категорию, к которой относится данный работник\n" +
            "1. Управленец\n" +
            "2. Основной работник\n" +
            "3. Вспомогательный персонал"
            );

        string employeeCategory = Console.ReadLine();

        if (employeeCategory == "1")
        {
            Console.WriteLine("\nУкажите приказы и распоряжения, которые выдавал этот работник");
            var orderList = new List<string>();
            for (string order = Console.ReadLine(); order != null; order = Console.ReadLine())
                orderList.Add(order);
            employeers.Add(new Manager(orderList, fullName, jobTitle, empHistory));
        }

        else if (employeeCategory == "2")
        {
            Console.WriteLine("\n" +
                "Укажите количество отмечатанных экземпляров за определённый день: дата:количество_экземпляров\n" +
                "Пример: 20.12.2023:1027"
                );

            var copies = new Dictionary<DateTime, int>();
            for (string inputLine = Console.ReadLine(); inputLine != null; inputLine = Console.ReadLine())
            {
                List<string> lineList = inputLine.Split(':').ToList();
                var date = goToDateTime(lineList[0]);
                int amount = int.Parse(lineList[1]);
                copies.Add(date, amount);
            }
            employeers.Add(new Ordinary(copies, fullName, jobTitle, empHistory));
        }

        else if (employeeCategory == "3")
        {
            Console.WriteLine("\n" +
                "Укажите дни, в которые была выполненная работа\n" +
                "Пример: 18.03.2023"
                );

            var completedWork = new List<DateTime>();
            for (string line = Console.ReadLine(); line != null; line = Console.ReadLine())
                completedWork.Add(goToDateTime(line));

            employeers.Add(new Support(completedWork, fullName, jobTitle, empHistory));
        }

        else
            Console.WriteLine("\nПолучен некорректный запрос");



    }
    else if (message == "2")
    {
        Console.WriteLine("Общий стаж работы (в годах)");
        foreach (var employee in employeers)
        {
            double totalDays = 0;
            foreach (var line in employee.EmpHistory)
            {
                DateTime startDay = (DateTime)line[0];
                DateTime endDay = (DateTime)line[2];
                totalDays += (endDay - startDay).Days;
            }
            Console.WriteLine("{0}:\t{1:F2}", employee.FullName, totalDays / 365);
        }
    }
    else if (message == "3")
    {
        Console.WriteLine("\n" +
            "Укажите сотрудника"
            );
        string employeeName = Console.ReadLine();

        Console.WriteLine("\n" +
            "Укажите диапозон дат\n" +
            "Пример 01.01.2001 05.05.2005"
            );
        List<DateTime> dates = Array.ConvertAll(Console.ReadLine().Split(), goToDateTime).ToList();

        foreach (var employee in employeers)
            if (employee.FullName == employeeName)
            {
                Ordinary orEmp = (Ordinary)(employee);
                int totalCopies = 0;
                foreach (DateTime date in orEmp.Copies.Keys)
                {
                    if (date <= dates[1] && dates[0] <= date)
                        totalCopies += orEmp.Copies[date];
                }
                Console.WriteLine("\nВсего копий: {0}", totalCopies);
                break;
            }
    }
    else if (message == "4")
    {
        var allDates = new List<DateTime>();
        foreach (var employee in employeers)
        {
            if (employee is Support)
            {
                var support = (Support)(employee);
                allDates.AddRange(support.CompletedWork);
            }

        }
        foreach (var date in allDates)
            Console.WriteLine(date.ToShortDateString());
    }
    else if (message == "5")
    {
        Console.WriteLine("Укажите сотрудника");
        string employeeName = Console.ReadLine();
        Console.WriteLine();
        foreach (var employee in employeers)
            if (employee is Manager && employee.FullName == employeeName)
            {
                var manager = (Manager)(employee);
                foreach (var order in manager.Orders)
                    Console.WriteLine(order);
            }
    }
    else
        Console.WriteLine("Вы ввели что-то непонятное.");


    Console.WriteLine("\nУспешно выполненно.\nНажмите любую клавишу для продолжения...");
    Console.ReadKey();
    Console.Clear();
}
