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


            //itemsSource = new ObservableCollection<Item> {
            //    new Plant { FullName = "Красивый цветок", ShortName = "Цветок", Category="Цветы", Height="20", Diameter="15", Price="20", Availability="Нет в наличии", Description="Красивый"}, 
            //    new Plant { FullName = "Колючий кактус", ShortName = "Кактус", Category="Кактусы", Height="15", Diameter="7", Price="9", Availability="5", Description="Колючий"}
            //};
            //dataGridMain.ItemsSource = itemsSource;

        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда запущена из " + e.Source.ToString());
        }

        private void dataGridMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(dataGridMain.SelectedItem != null)
            //{
            //    gridItemButtons.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    gridItemButtons.Visibility = Visibility.Hidden;
            //}
        }


        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
             dataGridMain.UnselectAll();
        }

        private void dataGridMain_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //if (dataGridMain.SelectedItem != null)
            //{
            //    gridItemButtons.Visibility = Visibility.Visible;  
            //}
            //else
            //{
            //    gridItemButtons.Visibility = Visibility.Hidden;
            //}
        }
    }
}
