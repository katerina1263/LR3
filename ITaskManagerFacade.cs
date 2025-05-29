using System.Collections.Generic;

namespace Менеджер_задач
{
    // Интерфейс фасада для работы с задачами
    public interface ITaskManagerFacade
    {
        void CreateTask(string name, string description);    // Создать задачу
        void DeleteTask(string name);                        // Удалить задачу
        void MarkTaskCompleted(string name);                 // Завершить задачу
        List<UserTask> ShowAllTasks();                       // Показать все задачи
    }
}