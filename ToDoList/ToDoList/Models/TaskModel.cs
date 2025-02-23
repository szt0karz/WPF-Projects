using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class TaskModel
    {
        // Identyfikator zadania - klucz główny w bazie danych
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Wartość tego pola jest generowana automatycznie
        public int Id { get; set; }

        // Nazwa zadania
        public string Name { get; set; }

        // Określa, czy zadanie zostało ukończone
        public bool IsCompleted { get; set; }
    }
}
