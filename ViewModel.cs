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

namespace s4_oop_6_7_8_9
{
    partial class ViewModel : INotifyPropertyChanged
    {
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

        private Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem ?? new Plant();
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
                        },
                        obj =>
                        {
                            return Items.Count > 0;
                        }));
            }
        }

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
                        }));
            }
        }

        private RelayCommand clearFilterCommand;
        public RelayCommand ClearFilterCommand
        {
            get
            {
                return clearFilterCommand ??
                    (clearFilterCommand = new RelayCommand (
                        obj =>
                        {
                            foreach (Item item in Items)
                            {
                                item.ItemVisibility = true;
                            }
                        }));
            }
        }

        public ViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                 new Plant { FullName = "Красивый цветок", ShortName = "Цветок", Category="Цветущие", Height=20, Diameter=15, Price=20, Availability=0, Description="Красивый"},
                 new Plant { FullName = "Колючий кактус", ShortName = "Кактус", Category="Суккуленты", Height=15, Diameter=7, Price=9, Availability=5, Description="Колючий"}
            };

            ToEditMode();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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


