using System;

namespace practical_task6
{
    public class Program
    {
        // Вывод меню
        static void PrintMenu(string[] menuItems, int choice, string info)
        {
            Console.Clear();
            Console.WriteLine(info);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == choice) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        // Выбор пункта из меню
        static int MenuChoice(string[] menuItems, string info = "")
        {
            Console.CursorVisible = false;
            int choice = 0;
            while (true)
            {
                PrintMenu(menuItems, choice, info);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choice == 0) choice = menuItems.Length;
                        choice--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == menuItems.Length - 1) choice = -1;
                        choice++;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        return choice;
                }
            }
        }

        // Ввод целого числа
        public static int IntInput(int lBound = int.MinValue, int uBound = int.MaxValue, string info = "")
        {
            bool exit;
            int result;
            Console.Write(info);
            do
            {
                exit = int.TryParse(Console.ReadLine(), out result);
                if (!exit) Console.Write("Введено нецелое число! Повторите ввод: ");
                else if (result <= lBound || result >= uBound)
                {
                    exit = false;
                    Console.Write("Введено недопустимое значение! Повторите ввод: ");
                }
            } while (!exit);
            return result;
        }

        // Получение элемента последовательности
        public static int SenquenceElement(int index, int a1, int a2, int a3)
        {
            if (index == 1) return a1;
            if (index == 2) return a2;
            if (index == 3) return a3;
            return SenquenceElement(index - 1, a1, a2, a3) + SenquenceElement(index - 2, a1, a2, a3) * SenquenceElement(index - 3, a1, a2, a3) / 2;
        }

        // Создание последовательности с выводом и подсчёт элементов, которые >= m
        public static void CreateSequence(int a1, int a2, int a3, int n, int m, out int superior)
        {
            superior = 0;
            Console.Write(" " + a1);
            if (a1 >= m) superior++;
            Console.Write(" " + a2);
            if (a2 >= m) superior++;
            Console.Write(" " + a3);
            if (a3 >= m) superior++;

            int index = 4;
            
            while (n != 0)
            {
                int el = SenquenceElement(index++, a1, a2, a3);
                if (el % 2 == 0) n--;
                if (el >= m) superior++;
                Console.Write(" " + el);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Пункты меню
            string[] MENU_ITEMS = { "Создать последовательность", "Выйти из программы" };

            // Индекс пункта - выход из программы
            const int EXIT_CHOICE = 1;

            // Индекс пункта меню, который выбрал пользователь
            int userChoice;

            while (true)
            {
                // Пользователь выбирает действие (выйти или задать матрицу)
                userChoice = MenuChoice(MENU_ITEMS, "Программа для построения последовательности чисел\nA(к) = A(к–1) + (A(к-2)*A(к–3))/2\nВыберите действие:");
                if (userChoice == EXIT_CHOICE) break;
                Console.Clear();

                // Ввод а1, а2, а3
                int a1 = IntInput(info: "Введите первый элемент последовательности: ");
                int a2 = IntInput(info: "Введите второй элемент последовательности: ");
                int a3 = IntInput(info: "Введите третий элемент последовательности: ");

                // Ввод n, m
                int n = IntInput(lBound: 0, info: "Введите количество чётных чисел, которое нужно добавить в поледовательность: ");
                int m = IntInput(info: "Введите число m, чтобы подсчитать элементы последовательности, которые >= m: ");


                // Вывод последовательности
                Console.Write("Созданная последовательность:");
                CreateSequence(a1, a2, a3, n, m, out int notLessM);

                // Вывод кол-ва элементов последовательности >= m
                Console.WriteLine($"Кол-во элементов последовательности, которые >= {m}: {notLessM}");

                Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
                Console.ReadLine();
            }    
        }
    }
}
