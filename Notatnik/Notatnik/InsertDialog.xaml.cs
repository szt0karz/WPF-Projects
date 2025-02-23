using System;
using System.Windows;

namespace Notatnik
{
    /// <summary>
    /// Logika 
    /// </summary>
    public partial class InsertDialog : Window
    {
        public InsertDialog()
        {
            InitializeComponent();
        }

        // Obsługuje kliknięcie przycisku "Wstaw"
        private void Accept(object sender, RoutedEventArgs e)
        {
            // Ustawienie dialogu jako zakończonego sukcesem
            DialogResult = true;
            // Zamknięcie okna dialogowego
            Close();
        }
    }
}
