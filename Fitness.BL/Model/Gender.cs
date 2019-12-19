using System;


namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// название
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// создать новый пол
        /// </summary>
        /// <param name="name">Имя пола</param>
        public Gender (string name)
        {
            //проверяем входные условия на предмет ошибок и некорректного ввода
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Пол не может быть пустым или NULL", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
