using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Менеджер_задач
{
    // Фасад для упрощения взаимодействия с TaskManager
    public class TaskManagerFacade : ITaskManagerFacade
    {
        private readonly ITaskManager taskManager;

        public TaskManagerFacade()
        {
            taskManager = TaskManager.Instance;  // Получение Singleton-экземпляра
        }

        //Создание задачи
        public void CreateTask(string name, string description)
        {
            taskManager.AddTask(name, description);
        }

        //Удаление задачи
        public void DeleteTask(string name)
        {
            taskManager.RemoveTask(name);
        }

        //Отметить задачу как завершенную
        public void MarkTaskCompleted(string name)
        {
            taskManager.CompleteTask(name);
        }

        //Показать все задачи
        public List<UserTask> ShowAllTasks()
        {
            return taskManager.GetTasks();
        }
    }
}
