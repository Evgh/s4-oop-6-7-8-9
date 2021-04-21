using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Controls;
namespace s4_oop_6_7_8_9
{
    public interface Item : INotifyPropertyChanged
    {
        bool ItemVisibility { get; set; }

        string ShortName { get; set; }
        string FullName { get; set; }
        string Category { get; set; }
        int Price { get; set; }
        string Availability { get; set; }
        int Height { get; set; }
        int Diameter { get; set; }
        string Description { get; set; }
    }

    class Plant : Item
    {
        bool itemVisibility = true;
        public bool ItemVisibility
        {
            get => itemVisibility;
            set
            {
                itemVisibility = value;
                OnPropertyChanged("ItemVisibility");
            }
        }

        string shortName;
        public string ShortName 
        {
            get => shortName; 
            set
            {
                shortName = value;
                OnPropertyChanged("ShortName");
            } 
        }

        string fullName;
        public string FullName 
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        string category;
        public string Category 
        {
            get => category; 
            set
            {
                category = value;
                OnPropertyChanged("Category");
            } 
        }

        int price;
        public int Price 
        {
            get => price; 
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        string availability;
        public string Availability 
        {
            get => availability; 
            set
            {
                availability = value;
                OnPropertyChanged("Availability");
            } 
        }

        int height;
        public int Height 
        {
            get => height; 
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }

        int diameter;
        public int Diameter 
        {
            get => diameter; 
            set
            {
                diameter = value;
                OnPropertyChanged("Diameter");
            } 
        }

        string description;
        public string Description 
        {
            get => description; 
            set
            {
                description = value;
                OnPropertyChanged("Description");
            } 
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
