using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;
using Microsoft.Win32;

namespace s4_oop_6_7_8_9
{
    partial class ViewModel : INotifyPropertyChanged
    {
        private Stack<ObservableCollection<Item>> mementoStack;
        private Stack<ObservableCollection<Item>> redoStack;

        private event Action listChanges;


        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        private Item buffItem = ItemFabric.GetEmptyItem(); 

        private Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem ?? (selectedItem = buffItem);
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private readonly List<IFilter> filters = new List<IFilter> {
                                                            new CategoryFilter(),
                                                            new PriceFilter(),
                                                            new HeigthFilter(),
                                                            new DiameterFilter(),
                                                            new AvailabilityFilter() };
        public IFilter Category { get => filters[0]; }
        public IFilter Price { get => filters[1]; }
        public IFilter Height { get => filters[2]; }
        public IFilter Diameter { get => filters[3]; }
        public IFilter Availability { get => filters[4]; }

        private RelayCommand filterCommand;
        public RelayCommand FilterCommand
        {
            get
            {
                return filterCommand ??
                    (filterCommand = new RelayCommand(
                        obj =>
                        {
                            foreach (Item item in items)
                            {
                                bool isVisible = true;

                                foreach (IFilter filter in filters)
                                {
                                    if (filter.IsActive())
                                    {
                                        isVisible = isVisible && filter.IsApropriate(item);
                                    }
                                }

                                item.ItemVisibility = isVisible;
                            }
                        }
                        ));
            }
        }

        private RelayCommand clearFilterCommand;
        public RelayCommand ClearFilterCommand
        {
            get
            {
                return clearFilterCommand ??
                    (clearFilterCommand = new RelayCommand(
                        obj =>
                        {
                            foreach (Item item in Items)
                            {
                                item.ItemVisibility = true;
                            }
                        }
                        ));
            }
        }


        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(
                        obj =>
                        {
                            Item item = obj as Item;
                            if (item != null)
                            {
                                Items.Remove(item);
                            }

                            listChanges?.Invoke();
                        },
                        obj =>
                        {
                            return !SelectedItem.IsNull() && SelectedItem.ItemVisibility;
                        }
                        ));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(
                        obj =>
                        {
                            items.Add(buffItem);
                            
                            buffItem = ItemFabric.GetEmptyItem();
                            SelectedItem = buffItem; 

                            listChanges?.Invoke();
                        },
                        obj =>
                        {
                            return !buffItem.IsNull();
                        }
                        ));
            }
        }

        private RelayCommand resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ??
                    (resetCommand = new RelayCommand(
                        obj =>
                        {
                            if (InAddMode())
                            {
                                buffItem = ItemFabric.GetEmptyItem();
                                SelectedItem = buffItem;
                            }
                            else if (InEditMode())
                            {
                                SelectedItem.SetCopy(buffItem);
                            }
                        }
                        ));
            }

        }

        private RelayCommand clearAllCommand;
        public RelayCommand ClearAllCommand
        {
            get
            {
                return clearAllCommand ??
                    (clearAllCommand = new RelayCommand(
                        obj =>
                        {
                            Items.Clear();
                            listChanges?.Invoke();
                        },
                        obj =>
                        {
                            return Items.Count > 0;
                        }
                        ));
            }

        }

        private RelayCommand saveFileCommand;
        public RelayCommand SaveFileCommand
        {
            get
            {
                return saveFileCommand ??
                    (saveFileCommand = new RelayCommand(
                        obj =>
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Filter = "JSON files (*.json)|*.json";
                            if (saveFileDialog.ShowDialog() == true)
                            {
                                ItemFabric.SaveItemCollection(Items, saveFileDialog.FileName);
                            }
                        }
                        ));
            }
        }

        private RelayCommand openFileCommand;
        public RelayCommand OpenFileCommand
        {
            get
            {
                return openFileCommand ??
                    (openFileCommand = new RelayCommand(
                        obj =>
                        {
                            // по-хорошему для грамотного mvvm стоит переделать это и saveFileDialog, но пока на это нет времени
                            // также можно добавить обработку исключений
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "JSON files (*.json)|*.json";
                            if (openFileDialog.ShowDialog() == true)
                            {
                                Items = ItemFabric.GetItemsCollection(openFileDialog.FileName);
                            }
                        }
                        ));
            }
        }

        private RelayCommand openImageCommand;
        public RelayCommand OpenImageCommand
        {
            get
            {
                return openImageCommand ??
                    (openImageCommand = new RelayCommand(
                        obj =>
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.Filter = "PNG image (*.png)|*.png|Jpeg image(*.jpg)|*.jpg";
                            if (openFileDialog.ShowDialog() == true)
                            {
                                SelectedItem.ImagePath = openFileDialog.FileName;
                            }
                        }
                        ));
            }
        }



        private RelayCommand undoCommand;
        public RelayCommand UndoCommand
        {
            get
            {
                return undoCommand ??
                    (undoCommand = new RelayCommand(
                        obj =>
                        {
                            if(mementoStack.Count != 0)
                            {
                                //redoStack.Push(mementoStack.Pop());
                                //Items = redoStack.Peek();

                                Items = mementoStack.Pop();
                            }
                        }
                        ));
            }
        }

        private RelayCommand redoCommand;
        public RelayCommand RedoCommand
        {
            get
            {
                return redoCommand ??
                    (redoCommand = new RelayCommand(
                        redoCommand =>
                        {
                            if (redoStack.Count != 0)
                            {
                                //Items = redoStack.Pop();
                            }
                        }
                        ));
            }
        }


        public ViewModel()
        {
            Items = new ObservableCollection<Item> { };
            mementoStack = new Stack<ObservableCollection<Item>>();
            redoStack = new Stack<ObservableCollection<Item>>();

            listChanges += OnListChanges;
            ToEditMode();
            
            listChanges?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void OnListChanges()
        {
            var memento = new ObservableCollection<Item>();
            foreach(var item in Items)
            {
                memento.Add(item);
            }

            mementoStack.Push(memento);
            redoStack.Clear();
        }
    }

    public class CategoryToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string category = ((string)value);
            switch (category)
            {
                case "Цветущие": return 0;
                case "Лиственные": return 1;
                case "Плодовые": return 2;
                case "Насекомоядные": return 3;
                case "Бонсай": return 4;
                case "Суккуленты": return 5;
                case "Грунт": return 6;
                case "Аксессуары": return 7;
                default: return -1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int category = (int)value;
            switch (category)
            {
                case 0: return "Цветущие";
                case 1: return "Лиственные";
                case 2: return "Плодовые";
                case 3: return "Насекомоядные";
                case 4: return "Бонсай";
                case 5: return "Суккуленты";
                case 6: return "Грунт";
                case 7: return "Аксессуары";
                default: return "";
            }
        }
    }
}


