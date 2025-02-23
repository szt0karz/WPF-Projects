using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Notatnik
{
    /// <summary>
    /// Logika
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openDialog = new OpenFileDialog();  // Dialog do otwierania pliku
        SaveFileDialog saveDialog = new SaveFileDialog();  // Dialog do zapisywania pliku

        public MainWindow()
        {
            InitializeComponent();  
        }

        // Obsługuje kliknięcie przycisku "Nowa notatka"
        private void NewNote(object sender, RoutedEventArgs e)
        {
            // Pokazuje komunikat z pytaniem, czy użytkownik chce rozpocząć nową notatkę
            if (MessageBox.Show("Czy nowa notatka?", "Nowa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Notepad.Clear();  // Czyści zawartość TextBox
            }
        }

        // Obsługuje kliknięcie przycisku "Zapisz notatkę"
        private void SaveNote(object sender, RoutedEventArgs e)
        {
            // Pokazuje dialog zapisu pliku
            if (saveDialog.ShowDialog() == true)
            {
                // Zapisuje tekst z TextBoxa do wybranego pliku
                File.WriteAllText(saveDialog.FileName, Notepad.Text);
            }
        }

        // Obsługuje kliknięcie przycisku "Otwórz notatkę"
        private void OpenNote(object sender, RoutedEventArgs e)
        {
            // Pokazuje dialog otwierania pliku
            if (openDialog.ShowDialog() == true)
            {
                // Wczytuje zawartość wybranego pliku do TextBoxa
                Notepad.Text = File.ReadAllText(openDialog.FileName);
            }
        }

        // Obsługuje kliknięcie przycisku "Wstaw symbol"
        private void InsertSymbol(object sender, RoutedEventArgs e)
        {
            InsertDialog insertDialog = new InsertDialog();  // Tworzy nowe okno dialogowe

            // Modalne: czeka na akcję użytkownika w oknie dialogowym
            if (insertDialog.ShowDialog() == true)
            {
                // Wstawia wybrany symbol do aktualnie wybranego tekstu
                Notepad.SelectedText = insertDialog.Symbol.Text;
            }

        }
    }
}
