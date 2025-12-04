using System;
using System.ComponentModel.Design;

namespace first_HomeWork
{
    class Programm
    {
        static void Main()
        {
            //!Спросить о возможности рандомного выбора приветствия/взаимодействия с пользователем (выбор из массива?)
            Console.WriteLine("Добро пожаловать в Бот-трекер цен!");

            //Здесь объявляем переменные
            bool progOn = true; // перменная bool при запуске программы

            string userName = null; //изначально имя не установленно
            string userStart = "/start";
            string userHelp = "/help";
            string userInfo = "/info";
            string userExit = "/exit";
            string userEcho = "/echo";


            while (progOn)
            {
                Console.WriteLine("Для продолжения взамодействия введите одну из доступных команд: /start  /help  /info  /exit" + (userName != null ? "  /echo" : "")); //Добавляем /echo в список, если имя установленно
                var enterCom = Console.ReadLine();

                //Проверяем условия ввода команд
                if (enterCom == userStart)
                {
                    do // обробатываем имя до получения корректного имени
                    {
                        Console.WriteLine("Введите свое имя: ");
                        userName = Console.ReadLine()?.Trim(); //Trim() - метод класса string, который удаляет все пробельные символы с начала и конца строки

                        if (string.IsNullOrWhiteSpace(userName)) // isNullorWhiteSpace - метод класса string, который проверяет строку на три условия (null, empty, whiteSpace)
                        {
                            Console.WriteLine("Имя не может быть пустым. Поробуйте снова, вдруг получится?");
                        }
                    } while (string.IsNullOrWhiteSpace(userName));
                    Console.WriteLine($"Я запомнил ваше имя, {userName} -_-");
                }
                else if (enterCom == userHelp)
                {
                    Console.WriteLine("СПРАВОЧНАЯ ИНФОРМАЦИЯ: просто вводить комманды");
                    if (userName != null) //Появляется если пользователь ввел свое имя
                    {
                        Console.WriteLine($"{userName}, внимание! Доступна новая команда: /echo. Введите команду и свой текст");
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
                else
                {
                    Console.WriteLine("Упс...неизвестная команда.");
                }
            }
        }
    }
}