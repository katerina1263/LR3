using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Менеджер_задач
{
    // Перечисление для обозначения статуса задачи
    public enum TaskStatus
    {
        Pending,    // В ожидании
        Completed   // Завершена
    }

    // Класс, представляющий задачу
    public class UserTask
    {
        public string Name { get; set; }            // Название задачи
        public string Description { get; set; }     // Описание задачи
        public TaskStatus Status { get; set; }      // Статус задачи

        public UserTask(string name, string description)
        {
            Name = name;
            Description = description;
            Status = TaskStatus.Pending;           // По умолчанию — в ожидании
        }

        // Переопределение метода для удобного отображения задачи в интерфейсе
        public override string ToString()
        {
            return $"{Name} - {Description} ({Status})";
        }
    }
}
