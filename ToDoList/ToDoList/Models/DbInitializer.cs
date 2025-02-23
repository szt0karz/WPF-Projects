using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    // Klasa statyczna odpowiedzialna za inicjalizację bazy danych
    public static class DbInitializer
    {
        // Metoda inicjalizująca bazę danych
        public static void Initialize(AppDbContext context)
        {
            // Zapewnienie, że baza danych zostanie utworzona, jeśli jeszcze nie istnieje
            context.Database.EnsureCreated();

            // Sprawdzenie, czy tabela Tasks jest pusta
            if (!context.Tasks.Any())
            {
                // Dodanie kilku przykładowych zadań do bazy danych
                context.Tasks.AddRange(
                    new TaskModel { Name = "Kupić mleko", IsCompleted = false },
                    new TaskModel { Name = "Zrobić projekt WPF", IsCompleted = false },
                    new TaskModel { Name = "Poćwiczyć", IsCompleted = false }
                );

                // Zapisanie zmian w bazie danych
                context.SaveChanges();
            }
        }
    }
}
