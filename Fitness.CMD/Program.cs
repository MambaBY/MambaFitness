using System;
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

            Console.WriteLine("Введите ваш пол.");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите вашу дату рождения.");
            var birthDate = DateTime.Parse(Console.ReadLine()); //TODO: try parse

            Console.WriteLine("Введите ваш вес.");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите ваш рост.");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name,gender,birthDate, weight,height);
            userController.Save();

        }
    }
}
