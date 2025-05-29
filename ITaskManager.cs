using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Менеджер_задач
{
    // Интерфейс менеджера задач
    public interface ITaskManager
    {
        void AddTask(string name, string description);   // Добавление задачи
        void RemoveTask(string name);                    // Удаление задачи по имени
        void CompleteTask(string name);                  // Отметить задачу как завершённую
        List<UserTask> GetTasks();                       // Получение списка задач
    }
}
