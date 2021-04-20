using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace s4_oop_6_7_8_9
{
    class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> Items { get; set; }
        public IFilter Category { get; set; }
        public IFilter Price { get; set; }
        public IFilter Height { get; set; }
        public IFilter Diameter { get; set; }
        public IFilter Availability { get; set; }


        private Item selectedItem;
        public Item SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
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
                            MessageBox.Show($"{Category.IsApropriate(selectedItem)}");
                        },
                        obj =>
                        {
                            return Items.Count > 0;
                        }));
            }
        }


        public ViewModel()
        {
            Items = new ObservableCollection<Item>
            {
                 new Plant { FullName = "Красивый цветок", ShortName = "Цветок", Category="Цветущие", Height=20, Diameter=15, Price=20, Availability="Нет в наличии", Description="Красивый"},
                 new Plant { FullName = "Колючий кактус", ShortName = "Кактус", Category="Суккуленты", Height=15, Diameter=7, Price=9, Availability="5", Description="Колючий"}
            };

            // инициализируем фильтры 
            Category = new CategoryFilter();
            Price = new PriceFilter();
            Height = new HeigthFilter();
            Diameter = new DiameterFilter();
            Availability = new AvailabilityFilter();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}


