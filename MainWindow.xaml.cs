using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s4_oop_6_7_8_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Item> itemsSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда запущена из " + e.Source.ToString());
        }

        //private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //     dataGridMain.UnselectAll();
        //}
    }
}
