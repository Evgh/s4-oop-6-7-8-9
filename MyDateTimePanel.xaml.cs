using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для DateTimePanel.xaml
    /// </summary>
    public partial class MyDateTimePanel : UserControl
    {
        public readonly DependencyProperty DateTimeProperty;

        public MyDateTimePanel()
        {
            InitializeComponent();
            DateTimeProperty = DependencyProperty.Register(
                           "DateTime",
                           typeof(DateTime),
                           typeof(MyDateTimePanel),
                           new FrameworkPropertyMetadata(DateTime.Now));
        }

        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show($"{DateTime} sender: {sender.GetType()}");

            dateBlock.Text = dateBlock.Text + '\n' + $"{DateTime} sender: {sender.GetType()}";
        }
    }
}
