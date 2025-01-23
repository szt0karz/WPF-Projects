using System.IO;
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
using Microsoft.Win32;

namespace Notatnik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openDialog = new OpenFileDialog();
        SaveFileDialog saveDialog = new SaveFileDialog();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewNote(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy nowa notatka?", "Nowa", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Notepad.Clear();
            }
        }

        private void SaveNote(object sender, RoutedEventArgs e)
        {
            if(saveDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveDialog.FileName, Notepad.Text);
            }
        }

        private void OpenNote(object sender, RoutedEventArgs e)
        {
            if (openDialog.ShowDialog() == true)
            {
                Notepad.Text = File.ReadAllText(openDialog.FileName);
            }
        }

        private void InsertSymbol(object sender, RoutedEventArgs e)
        {
            InsertDialog insertDialog = new InsertDialog();
            //Modalne
            if (insertDialog.ShowDialog() == true)
            {
                Notepad.SelectedText = insertDialog.Symbol.Text;
            }

            //Niemodalne
        }
    }
}