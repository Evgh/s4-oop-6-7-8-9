using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace s4_oop_6_7_8_9
{
    public class MyCommands
    {
        // Создание команды requery
        private static RoutedUICommand hiCommand;

        static MyCommands()
        {
            // Инициализация команды
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.H, ModifierKeys.Control, "Ctrl + H"));

            hiCommand = new RoutedUICommand("Hi", "Hi", typeof(MyCommands), inputs);
        }

        public static RoutedUICommand Hi
        {
            get { return hiCommand; }
        }
    }
}
