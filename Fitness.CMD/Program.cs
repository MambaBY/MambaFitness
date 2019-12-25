using System;
using System.Runtime.InteropServices;
using Fitness.BL.Controller;
using Fitness.BL.Model;


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
            var eatingController = new EatingController(userController.CurrentUser);

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
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи");
          
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            
            var callories = ParseDouble("Количество каллорий");
            var prots = ParseDouble("Количество белка");
            var fats = ParseDouble("Количество жиров");
            var carbs = ParseDouble("Количество углеводов");

            var weight = ParseDouble("Вес порции");


            var product = new Food(food, callories, prots,fats, carbs);

            return (Food: product, Weight: weight);

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
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}
