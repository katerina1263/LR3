using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Менеджер_задач
{
    // Основная форма приложения
    public partial class Form1 : Form
    {
        private readonly ITaskManagerFacade facade;   // Фасад для взаимодействия с логикой

        public Form1()
        {
            InitializeComponent();
            facade = new TaskManagerFacade();
        }

        // Обработка кнопки "Добавить задачу"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                facade.CreateTask(txtTaskName.Text.Trim(), txtTaskDescription.Text.Trim());
                ClearInputs();        // Очистить поля ввода
                RefreshTaskList();    // Обновить список
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}");
            }
        }

        // Обработка кнопки "Удалить задачу"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxTasks.SelectedItem is UserTask selectedTask)
                {
                    facade.DeleteTask(selectedTask.Name);
                    RefreshTaskList();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите задачу из списка для удаления.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting task: {ex.Message}");
            }
        }

        // Обработка кнопки "Завершить задачу"
        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxTasks.SelectedItem is UserTask selectedTask)
                {
                    facade.MarkTaskCompleted(selectedTask.Name);
                    RefreshTaskList();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите задачу из списка для завершения.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing task: {ex.Message}");
            }
        }

        // Обработка кнопки "Обновить список"
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        // Метод обновления списка задач в ListBox
        private void RefreshTaskList()
        {
            listBoxTasks.Items.Clear();
            foreach (var t in facade.ShowAllTasks())
            {
                listBoxTasks.Items.Add(t);
            }
        }

        // Метод очистки полей ввода
        private void ClearInputs()
        {
            txtTaskName.Clear();
            txtTaskDescription.Clear();
        }
    }
}
