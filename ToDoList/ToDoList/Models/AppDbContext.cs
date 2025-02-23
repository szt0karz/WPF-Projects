using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class AppDbContext : DbContext
    {
        // DbSet reprezentujący tabelę z zadaniami w bazie danych
        public DbSet<TaskModel> Tasks { get; set; }

        // Konstruktor z opcjami dla DbContext, używany w przypadku wstrzykiwania zależności
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Konstruktor domyślny, wykorzystywany przez Entity Framework
        public AppDbContext() { }

        // Konfiguracja bazy danych i połączenia
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Jeśli opcje nie zostały wcześniej skonfigurowane, ustawiamy połączenie z bazą danych
            if (!options.IsConfigured)
            {
                // Ustawienie źródła danych na SQLite, baza danych będzie zapisywana w pliku "todo.db"
                options.UseSqlite("Data Source=todo.db");
            }
        }
    }
}
