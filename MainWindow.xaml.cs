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
using System.Globalization;

namespace s4_oop_6_7_8_9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();

            Icon = BitmapFrame.Create(new Uri("D:\\OOP\\s4-oop-6-7-8-9\\resources\\icons\\color.ico"));
            //Mouse.OverrideCursor = new Cursor("D:\\OOP\\s4-oop-6-7-8-9\\resources\\icons\\poinrter.cur");

            App.LanguageChanged += LanguageChanged;
            CultureInfo currLang = App.Language;
           
            //Заполняем меню смены языка:
            menuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                menuLanguage.Items.Add(menuLang);
            }

            menuTheme.Items.Clear();
            List<string> themes = new List<string> { "StyleGreen", "StyleOrange" };
            foreach (var theme in themes)
            {
                MenuItem menuItem = new MenuItem();
                menuItem.Header = theme;
                menuItem.Click += ChangeThemeClick;
                menuTheme.Items.Add(menuItem);
            }
            (menuTheme.Items[0] as MenuItem).RaiseEvent(new RoutedEventArgs(MenuItem.ClickEvent));

        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда запущена из " + e.Source.ToString());
        }

        private void OpenElementWindow(object sender, RoutedEventArgs e)
        {
            ElementWindow elementWindow = new ElementWindow() { DataContext = this.DataContext };
            elementWindow.Show();
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in menuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }
        }

        private void ChangeThemeClick(Object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                string style = menuItem.Header as string;
                var uri = new Uri("resources\\" + style + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;

                var olduri = new Uri("resources\\" + (style == "StyleGreen" ? "StyleOrange" : "StyleGreen") + ".xaml", UriKind.Relative);
                ResourceDictionary old = Application.LoadComponent(olduri) as ResourceDictionary;

                Application.Current.Resources.MergedDictionaries.Remove(old);
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                foreach (MenuItem i in menuTheme.Items)
                    i.IsChecked = i.Header.Equals(style);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Lab9Window lab9 = new Lab9Window();
            lab9.Show();
        }

        private void CommandBinding_Executed(object sender, EventArgs e)
        {
            MessageBox.Show("Hi");
        }
    }
}
