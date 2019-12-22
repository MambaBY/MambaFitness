using System;
using System.Runtime.InteropServices;
using Fitness.BL.Controller;


namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветсвует приложение MambaFitness!");
            
            Console.WriteLine("Введите имя пользователя.");
            var name = Console.ReadLine();


            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
               Console.WriteLine("Введите ваш пол ");
               var gender = Console.ReadLine();
               var birthDate = ParseDataTime(); ;
               var weight = ParseDouble("Вес.");
               var height = ParseDouble("Рост.");
                
               userController.SetNewUserData(gender, birthDate, weight,height);

            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDataTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.mm.yyyy) ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты.");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name} ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}.");
                }
            }
        }
    }
}
