using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Менеджер_задач
{
    // Реализация менеджера задач (Singleton)
    public class TaskManager : ITaskManager
    {
        private static TaskManager instance; // Единственный экземпляр класса (Singleton)

        // Свойство доступа к экземпляру
        public static TaskManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new TaskManager();  // Создаётся при первом обращении
                return instance;
            }
        }

        private readonly List<UserTask> tasks;   // Внутренний список задач

        private TaskManager() // Приватный конструктор предотвращает создание извне
        {
            tasks = new List<UserTask>();
        }

        // Добавление новой задачи
        public void AddTask(string name, string description)
        {
            if (!string.IsNullOrWhiteSpace(name))
                tasks.Add(new UserTask(name, description));
            else
                throw new TaskManagerException("Task name cannot be empty.");
        }

        // Удаление задачи по имени
        public void RemoveTask(string name)
        {
            var task = tasks.FirstOrDefault(t => t.Name == name);
            if (task != null)
                tasks.Remove(task);
            else
                throw new TaskManagerException("Task not found.");
        }

        // Отметить задачу как завершённую
        public void CompleteTask(string name)
        {
            var task = tasks.FirstOrDefault(t => t.Name == name);
            if (task != null)
                task.Status = TaskStatus.Completed;
            else
                throw new TaskManagerException("Task not found.");
        }

        // Получить копию списка задач
        public List<UserTask> GetTasks()
        {
            return new List<UserTask>(tasks);
        }
    }
}
