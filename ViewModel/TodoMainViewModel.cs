using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using BasicTodoList.Model;

namespace BasicTodoList.ViewModel
{
    public class TodoMainViewModel : ViewModelBase 
    {
        private List<TodoTask> _taskList = new();
        public List<TodoTask> TaskList
        {
            get => _taskList;
            set => Set(ref _taskList, value);
        }

        public TodoTask? SelectedTask { get; set; }

        private string? _taskTextBox;
        public string? TaskTextBox
        {
            get => _taskTextBox;
            set => Set(ref _taskTextBox, value);
        }

        private RelayCommand? _addTaskCommand;
        public RelayCommand? AddTaskCommand
        {
            get => _addTaskCommand ??= new RelayCommand(
                () =>
                {
                    if (TaskTextBox != "")
                    {
                        _taskList.Add(new(TaskTextBox, false));
                        TaskList = new(TaskList);
                        TaskTextBox = "";
                    }
                    else
                    {
                        MessageBox.Show("Task cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }

        private RelayCommand? _deleteTaskCommand;
        public RelayCommand? DeleteTaskCommand
        {
            get => _deleteTaskCommand ??= new RelayCommand(
                () =>
                {
                    if (SelectedTask != null)
                    {
                        TaskList.Remove(SelectedTask);
                        TaskList = new(TaskList);
                    }
                    else
                    {
                        MessageBox.Show("You didn't select a task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }

        private RelayCommand? _completedTaskCommand;
        public RelayCommand? CompletedTaskCommand
        {
            get => _completedTaskCommand ??= new RelayCommand(
                () =>
                {
                    if (SelectedTask != null)
                    {
                        TaskList.Find(new Predicate<TodoTask>(x => x.GetHashCode() == SelectedTask.GetHashCode())).IsCompleted = true;
                        TaskList = new(TaskList);
                    }
                    else
                    {
                        MessageBox.Show("You didn't select a task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
