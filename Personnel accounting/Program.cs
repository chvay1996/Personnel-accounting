using System;

namespace Home1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dossier = { "Петров Роман Анатольевич", "Федотов Виктор Сергеевич", "Черний Иван Сергеевич" };
            string[] post = { "Слесарь", "Грамист", "Программист" };
            string[] menu = { "Добавить", "Удалить", "Посмотреть все досье", "Поиск по фамилии", "Выход" };
            int index = 0;
            bool launchingTheProgram = true;

            while (launchingTheProgram)
            {
                Console.SetCursorPosition(0, 0);
                Console.ResetColor();
                Console.WriteLine("\t\tМеню");

                for (int i = 0; i < menu.Length; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index != 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index != menu.Length - 1) index++;
                        break;
                    case ConsoleKey.Enter:

                        switch (index)
                        {
                            case 0:
                                AddADossier(ref dossier, ref post);
                                break;
                            case 1:
                                DeleteDossier(ref dossier, ref post);
                                break;
                            case 2:
                                Case2(dossier, post);
                                break;
                            case 3:
                                SearchByLastName(ref dossier,ref post);
                                break;
                            case 4:
                                Exit(launchingTheProgram);
                                break;
                        }
                        break;
                }
            }
        }
        private static void Case2(string[] dossier, string[] post)
        {

            ViewTheDossierOfAll(dossier, post);
            Console.ReadKey();
            Cler();
        
        }
        static void SearchByLastName(ref string[] arrayDosier,ref string[] arrayPost)
        {
            string name;
            int indexArray = -1;
            Console.WriteLine("Чтобы найти досье, напишите полностью фамилию");
            name = Console.ReadLine();

            for (int i = 0; i < arrayDosier.Length; i++)
            {
                if (arrayDosier[i].StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    indexArray = i;
                    break;
                }
            }

            if (indexArray == -1)
            {
                Console.WriteLine("Такое досье не было найдено!");
            }

            else
            {
                Console.WriteLine("Досье найдено!");
                Console.WriteLine((indexArray + 1) + "-" + arrayDosier[indexArray] + "-" + arrayPost[indexArray]);
            }

            Console.ReadKey();
            Cler();
        }
        static void Exit(bool launchingTheProgram)
        {
            Console.Clear();
            launchingTheProgram = false;
            Environment.Exit(0);
        }
        static void AddADossier(ref string[] arrayDossier, ref string[] arrayPost)
        {
            Console.SetCursorPosition(0, 7);
            string[] copiDossier = new string[arrayDossier.Length + 1];
            string[] copiPost = new string[arrayPost.Length + 1];

            ForArrayLenght(0, 0, arrayDossier.Length, arrayDossier, arrayPost, copiDossier, copiPost);

            arrayDossier = copiDossier;
            arrayPost = copiPost;
            Text("Введите Фамилию Имя Отчество", ConsoleColor.Magenta);
            copiDossier[arrayDossier.Length - 1] = Console.ReadLine();
            Text("Введите должность", ConsoleColor.Magenta);
            copiPost[arrayPost.Length - 1] = Console.ReadLine();

            Text(("Вы добавели " + (arrayDossier.Length) + ") " + arrayDossier[arrayDossier.Length - 1] + " - " + arrayPost[arrayPost.Length - 1]), ConsoleColor.Cyan);
            Console.ReadKey();
            Cler();
        }
        static void ForArrayLenght(int namberArray, int namberI, int arrayFor, string[] arrayDossier, string[] arrayPost, string[] copiDossier, string[] copiPost)
        {
            for (int i = namberI; i < arrayFor; i++)
            {
                copiDossier[i - namberArray] = arrayDossier[i];
                copiPost[i - namberArray] = arrayPost[i];
            }

        }
        static string[] DeleteDossier(ref string[] arrayDossier, ref string[] arrayPost) // удаление
        {
            string[] copiDossier = new string[arrayDossier.Length - 1];
            string[] copiPost = new string[arrayPost.Length - 1];
            ViewTheDossierOfAll(arrayDossier, arrayPost);
            Console.Write("Введите номер сотрудника, которого вы хотите удалить: ");
            int deleteIndex = Convert.ToInt32(Console.ReadLine());
            Text($"Вы удалили {arrayDossier[deleteIndex - 1]} - {arrayPost[deleteIndex - 1]}", ConsoleColor.Blue);

            ForArrayLenght(0, 0, deleteIndex - 1, arrayDossier, arrayPost, copiDossier, copiPost);

            ForArrayLenght(1, deleteIndex, arrayDossier.Length, arrayDossier, arrayPost, copiDossier, copiPost);

            arrayDossier = copiDossier;
            arrayPost = copiPost;
            Console.ReadKey();
            Cler();
            return arrayDossier;
        }
        static void ViewTheDossierOfAll(string[] arrayDossier, string[] arrayPost)
        {
            Console.WriteLine("Список сотрудников");

            for (int i = 0; i < arrayDossier.Length; i++)
            {
                Console.WriteLine((i + 1) + "." + arrayDossier[i] + " - " + arrayPost[i]);
            }
        }
        static void Text(string message, ConsoleColor color = ConsoleColor.Red)
        {
            Cler();
            Console.SetCursorPosition(0, 6);
            Console.ForegroundColor = color;
            Console.WriteLine(message + "\t\t\t\t\t");
            Console.ResetColor();
        }
        static void Cler(int x = 0, int y = 6)
        {
            Console.SetCursorPosition(x, y);
         
            for (int i = 0; i < 15; i++)
            {
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t\t\t\t\t");
            }

            Console.SetCursorPosition(x, y);
        }

    }
}
// Задача:
// Будет 2 массива: 1) фио 2) должность.
// Описать функцию заполнения массивов – досье, функцию форматированного вывода, функцию поиска по фамилии и функцию удаления досье.
// Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
// Программа должна быть с меню, которое содержит пункты:
// 1) добавить досье.
// 2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)
// 3) удалить досье
// 4) поиск по фамилии
// 5) выход
