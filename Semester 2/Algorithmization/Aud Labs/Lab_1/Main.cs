using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casual
{
    class Program
    {
        static void addTeacher(ref List<Teacher> teachers)
        {
            Console.WriteLine("Введите ФИО; Дату рождения; Наименование организации, в которой было получено образование; Наименование предмета");
            Console.WriteLine("Вводим каждую тему в отдельной строке");
            string fullName = Console.ReadLine();
            var birthDay = Console.ReadLine();
            string edName = Console.ReadLine();
            string schoolSubject = Console.ReadLine();

            Console.WriteLine("Вводите данные из трудовой книжки (дата поступления / наименование организации / дата увольнения)");
            Console.WriteLine("Пример: 01/01/2001 Организация 02/02/2002");
            Console.WriteLine("Чтобы прекратить ввод введите пустую строку");

            var empHistory = new List<List<string>>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "")
                    break;
                empHistory.Add(line.Split().ToList());
            }

            teachers.Add(new Teacher(fullName, schoolSubject, birthDay, edName, empHistory));
        }

        static void select(ref List<Teacher> teachers)
        {
            Console.WriteLine("Укажите, что именно вы хотите узнать:");
            Console.WriteLine("1. Наименование предмета\n2. Стаж работы на последнем месте\n3. Общий стаж\n4. Вывод всех сотрудников");

            string input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine("Укажите нужный вам предмет:");
                string subject = Console.ReadLine();
                foreach (Teacher teacher in teachers)
                    if (teacher.SchoolSubject == subject)
                        Console.WriteLine(teacher.FullName);
            }
            else if (input == "2")
            {
                foreach (Teacher teacher in teachers)
                {
                    int[] firstDate = Array.ConvertAll(teacher.EmpHistory[0][0].Split('/'), int.Parse);
                    int[] lastDate = Array.ConvertAll(teacher.EmpHistory[0][2].Split('/'), int.Parse);
                    lastDate[2] -= firstDate[2];
                    firstDate[2] = 0;

                    int firstDays = firstDate[2] * 12 * 30 + firstDate[1] * 30 + firstDate[0];
                    int lastDays = lastDate[2] * 12 * 30 + lastDate[1] * 30 + lastDate[0];
                    string totalExp = (((float)lastDays - firstDays)/360).ToString("#.##");

                    Console.WriteLine($"Общий стаж работы: {totalExp} лет");
                }
            }
            else if (input == "3")
            {
                foreach (Teacher teacher in teachers)
                {
                    double totalExp = 0;
                    foreach (var line in teacher.EmpHistory)
                    {

                        int[] firstDate = Array.ConvertAll(teacher.EmpHistory[0][0].Split('/'), int.Parse);
                        int[] lastDate = Array.ConvertAll(teacher.EmpHistory[0][2].Split('/'), int.Parse);
                        lastDate[2] -= firstDate[2];
                        firstDate[2] = 0;

                        int firstDays = firstDate[2] * 12 * 30 + firstDate[1] * 30 + firstDate[0];
                        int lastDays = lastDate[2] * 12 * 30 + lastDate[1] * 30 + lastDate[0];
                        totalExp += ((double)lastDays - firstDays) / 360;
                    }
                    Console.WriteLine("{0} - Общий стаж {1: #,##} лет", teacher.FullName, totalExp);
                }
            }
            else if (input == "4")
                foreach (var teacher in teachers)
                    Console.WriteLine(teacher.FullName);
            else
                Console.WriteLine("Вы ввели что-то непонятное --- " + input);
        }

        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>();
            while (true)
            {
                Console.WriteLine("Меню\n");
                Console.WriteLine("1. Добавить учителя в базу");
                Console.WriteLine("2. Выборки");
                Console.WriteLine("3. Выйти");

                string input = Console.ReadLine();
                if (input == "1")
                    addTeacher(ref teachers);
                else if (input == "2")
                    select(ref teachers);
                else if (input == "3")
                    break;
                else
                {
                    Console.WriteLine("Вы ввели что-то странное: " + input);
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
    }
}
