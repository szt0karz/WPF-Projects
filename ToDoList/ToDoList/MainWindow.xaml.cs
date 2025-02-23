using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.Models;

namespace ToDoList
{
    /// <summary>
    /// Logika interakcji dla MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 

            // Inicjalizacja bazy danych przy pierwszym uruchomieniu
            using (var context = new AppDbContext())
            {
                // Wywołanie metody do inicjalizacji bazy danych, np. tworzenie tabel, wstawianie domyślnych danych
                DbInitializer.Initialize(context);
            }
        }
    }
}
