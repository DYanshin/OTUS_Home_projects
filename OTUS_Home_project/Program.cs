using System;
using System.ComponentModel.Design;

namespace first_HomeWork
{
    class Programm
    {
        static void Main()
        {
            //Здесь объявляем переменные
            bool progOn = true; // перменная bool при запуске программы

            string userName = null; //изначально имя не установленно
            List<string> userList = new List<string>(); // добавляем список

            string userStart = "/start";
            string userHelp = "/help";
            string userInfo = "/info";
            string userExit = "/exit";
            string userEcho = "/echo";
            string userAddtask = "/addtask"; // Пользователь сможет добавлять задачи в список
            string userShowtask = "/showtask"; // Пользователь сможет просматривать задачи
            string userRemovetask = "/removetask"; // пользователь сможет удалить задачи


            //!Спросить о возможности рандомного выбора приветствия/взаимодействия с пользователем (выбор из массива?)
            Console.WriteLine("Добро пожаловать в Бот-трекер цен!");


            while (progOn)
            {
                Console.WriteLine("Для продолжения взаимодействия введите одну из доступных команд: /start  /help  /info  /addtask  /showtask  /removetask  /exit" + (userName != null ? "  /echo" : "")); //Добавляем /echo в список, если имя установленно
                var enterCom = Console.ReadLine();

                //Проверяем условия ввода команд
                if (enterCom == userStart)
                {
                    do // обработка имени пользователя до получения корректного имени
                    {
                        Console.WriteLine("Введите свое имя: ");
                        userName = Console.ReadLine()?.Trim(); //Trim() - метод класса string, который удаляет все пробельные символы с начала и конца строки

                        if (string.IsNullOrWhiteSpace(userName)) // isNullorWhiteSpace - метод класса string, который проверяет строку на три условия (null, empty, whiteSpace)
                        {
                            Console.WriteLine("Имя не может быть пустым. Попробуйте снова, вдруг получится?");
                        }
                    } while (string.IsNullOrWhiteSpace(userName));
                    Console.WriteLine($"Я запомнил ваше имя, {userName} -_-");
                }
                else if (enterCom == userHelp)
                {
                    Console.WriteLine("СПРАВОЧНАЯ ИНФОРМАЦИЯ: просто вводить комманды из списка");
                    if (userName != null) //Появляется если пользователь ввел свое имя
                    {
                        Console.WriteLine($"{userName}, внимание! Доступна новая команда: /echo. Введите команду и свой текст. Доступны команды /addtask - добавление задачи, /showtasks - показать добавленные задачи и /removetask - удаление задач.");
                    }
                }
                else if (enterCom == userInfo)
                {
                    Console.WriteLine($"Привет, {userName}! Текущая информация по программе:");
                    Console.WriteLine("Телеграм-Бот-трекер цен. Версия 1.0");
                }
                else if (enterCom == userExit)
                {
                    Console.WriteLine($"{userName} выходит из программы...");
                    progOn = false;
                }

                //Обработка команды /echo

                else if (enterCom != null && enterCom.StartsWith(userEcho))
                {
                    if (userName == null)
                    {
                        Console.WriteLine($"{userName}, внимание! Доступна новая команда: /echo. Введите команду и свой текст");
                    }
                    else
                    {
                        //извлекаем текст после команды /echo
                        string echoText = enterCom.Substring(userEcho.Length).Trim();
                        if (string.IsNullOrWhiteSpace(echoText))
                        {
                            Console.WriteLine($"{userName}, вы ввели пустоту. Пожалуйста введите текст после команды /echo");
                        }
                        else
                        {
                            Console.WriteLine(echoText);
                        }
                    }
                }

                // обработка команды /addtask от пользователя
                else if (enterCom == userAddtask)
                {
                    if (userName == null)
                    {
                        Console.WriteLine("Неизвестный пользователь, сначала введите команду /start");
                    }
                    else
                    {
                        Console.WriteLine($"{userName}, введите задачу для добавления в список");
                        string userTask = Console.ReadLine(); // добавляем задачу от пользователя
                        if (string.IsNullOrWhiteSpace(userTask))
                        {
                            Console.WriteLine("Задача не может быть пустой. Введите задачу.");
                        }
                        else
                        {
                            userList.Add(userTask);
                            Console.WriteLine($"{userName}, задача добавлена! Всего задач: {userList.Count}");
                        }
                    }
                }
                // обрабтка команды /showtask 
                else if (enterCom == userShowtask)
                {
                    if (userName == null)
                    {
                        Console.WriteLine("Неизвестный пользователь, сначала введите команду /start");
                    }
                    else if (userList.Count == 0)
                    {
                        Console.WriteLine($"{userName}, у вас нет задач в списке, увы!");
                    }
                    else
                    {
                        Console.WriteLine($"{userName}, вот список ваших задач: ");
                        int counter = 1;
                        foreach (var userTask in userList)
                        {
                            Console.WriteLine($"{counter++}. {userTask}");
                        }
                    }
                }
                // обработка команды /removetask
                else if (enterCom == userRemovetask)
                {
                    if (userName == null)
                    {
                        Console.WriteLine("Неизвестный пользователь, сначала введите команду /start");
                    }
                    else if (userList.Count == 0)
                    {
                        Console.WriteLine($"{userName}, у вас нет задач для удаления");
                    }
                    else
                    {
                        Console.WriteLine($"{userName}, вот список ваших задач: ");
                        int counter = 1;
                        foreach (var task in userList)
                        {
                            Console.WriteLine($"{counter++}. {task}");
                        }
                        Console.WriteLine($"{userName}, введите порядковый номер задачи д~ля удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= userList.Count)
                        {
                            userList.RemoveAt(num - 1);
                            Console.WriteLine($"Успешное удаление задачи {num}!");
                        }
                        else
                        {
                            Console.WriteLine($"{userName}, неверный номер задачи на удаление! Введите команду /removetask и попробуйте снова.");
                        }

                    }
                }

                else
                {
                    Console.WriteLine("Упс...неизвестная команда.");
                }
            }
        }
    }
}
