using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Менеджер_задач
{
    // Пользовательское исключение для TaskManager
    public class TaskManagerException : Exception
    {
        public TaskManagerException(string message) : base(message) { }
    }
}