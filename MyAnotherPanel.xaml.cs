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
    /// Логика взаимодействия для MyAnotherPanel.xaml
    /// </summary>
    /// 

    public partial class MyAnotherPanel : UserControl
    {
        public readonly DependencyProperty SomeTextProperty;

        public MyAnotherPanel()
        {
            InitializeComponent();

            SomeTextProperty = DependencyProperty.Register(
                    "Text",
                    typeof(string),
                    typeof(MyAnotherPanel),
                    new FrameworkPropertyMetadata
                                                ("aaaaaaaaaaa",
                                                FrameworkPropertyMetadataOptions.None,
                                                null, 
                                                new CoerceValueCallback(CoerceValue)),
                    null);
                    //new ValidateValueCallback(ValidateValue));
        }

        public string SomeText
        {
            get { return (string)GetValue(SomeTextProperty); }
            set { SetValue(SomeTextProperty, value); }
        }

        private static bool ValidateValue(object value)
        {
            string currentValue = (string)value;
            if (currentValue.Length > 10)
                return true;
            return false;
        }

        private static object CoerceValue(DependencyObject d, object value)
        {
            if (((string)value).Length < 10)
            {
                return "Антон солнышко";
            }
            return value;
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // MessageBox.Show(SomeText);

            someTextBlock.Text = someTextBlock.Text + "\n" + $"{SomeText} sender {sender.GetType()}";
        }
    }
}
