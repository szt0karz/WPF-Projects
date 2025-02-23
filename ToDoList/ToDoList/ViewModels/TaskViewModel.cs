using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public partial class TaskViewModel : ObservableObject
    {
        private readonly AppDbContext _context; // Kontekst bazy danych
        public ObservableCollection<TaskModel> Tasks { get; } = new(); // Kolekcja zadań

        [ObservableProperty]
        private string newTaskName = string.Empty; // Nowa nazwa zadania

        public TaskViewModel()
        {
            _context = new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>());
            DbInitializer.Initialize(_context);
            LoadTasks(); // Ładowanie zadań z bazy
        }

        // Ładowanie zadań z bazy danych do kolekcji
        private void LoadTasks()
        {
            Tasks.Clear();
            foreach (var task in _context.Tasks.ToList())
            {
                Tasks.Add(task);
            }
        }

        // Komenda dodawania nowego zadania
        [RelayCommand]
        private void AddTask()
        {
            if (string.IsNullOrWhiteSpace(NewTaskName)) return;

            var task = new TaskModel { Name = NewTaskName, IsCompleted = false };
            _context.Tasks.Add(task);
            _context.SaveChanges();
            Tasks.Add(task);
            NewTaskName = string.Empty; // Resetowanie pola
        }

        // Komenda zmiany statusu ukończenia zadania
        [RelayCommand]
        private void ToggleTaskCompletion(TaskModel task)
        {
            task.IsCompleted = !task.IsCompleted;
            _context.SaveChanges();
            LoadTasks();
        }

        // Komenda usuwania zadania
        [RelayCommand]
        private void DeleteTask(TaskModel task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            Tasks.Remove(task);
        }
    }
}
