using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;


namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }


        /// <summary>
        /// Создание нового контролера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthData, double weight, double height)
        {
            //TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthData, weight, height); 
           
        }

        /// <summary>
        /// получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: Что делать, если пользователя не прочитали?

            }
        }

        /// <summary>
        /// сщхранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        
       
    }
}
