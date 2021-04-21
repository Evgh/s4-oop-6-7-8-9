using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace s4_oop_6_7_8_9
{
    class ViewModel : INotifyPropertyChanged
    {

        private List<IFilter> filters = new List<IFilter> { 
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
                    (clearFilterCommand = new RelayCommand(
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
                 new Plant { FullName = "Красивый цветок", ShortName = "Цветок", Category="Цветущие", Height=20, Diameter=15, Price=20, Availability="Нет в наличии", Description="Красивый"},
                 new Plant { FullName = "Колючий кактус", ShortName = "Кактус", Category="Суккуленты", Height=15, Diameter=7, Price=9, Availability="5", Description="Колючий"}
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}


