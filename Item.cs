using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
namespace s4_oop_6_7_8_9
{
    public interface Item : INotifyPropertyChanged
    {
        bool ItemVisibility { get; set; }

        string ShortName { get; set; }
        string FullName { get; set; }
        string Description { get; set; }
        string Category { get; set; }
        int Availability { get; set; }
        int Price { get; set; }
        int Height { get; set; }
        int Diameter { get; set; }

        Item GetCopy();
        void SetCopy(Item item);
        bool IsNull();
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

        int availability;
        public int Availability
        {
            get => availability;
            set
            {
                availability = value;
                OnPropertyChanged("Availability");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Item GetCopy()
        {
            return (Item)this.MemberwiseClone();
        }

        public void SetCopy(Item buffItem)
        {
            this.ShortName = buffItem.ShortName;
            this.FullName = buffItem.FullName;
            this.Description = buffItem.Description;
            this.Category = buffItem.Category;
            this.Availability = buffItem.Availability;
            this.Price = buffItem.Price;
            this.Height = buffItem.Height;
            this.Diameter = buffItem.Diameter;
        }

        public bool IsNull()
        {
            return ShortName == null &&
                   FullName == null &&
                   Description == null &&
                   Category == null &&
                   Availability == 0 &&
                   Price == 0 &&
                   Height == 0 &&
                   Diameter == 0;
        }
    }
}
