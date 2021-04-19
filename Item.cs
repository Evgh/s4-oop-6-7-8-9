using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace s4_oop_6_7_8_9
{
    public interface Item : INotifyPropertyChanged
    {
        string ShortName { get; set; }
        string FullName { get; set; }
        string Category { get; set; }
        string Price { get; set; }
        string Availability { get; set; }
        string Height { get; set; }
        string Diameter { get; set; }
        string Description { get; set; }
    }

    class Plant : Item
    {
        string shortName;
        string fullName;
        string category;
        string price;
        string availability;
        string height;
        string diameter;
        string description;

        public string ShortName 
        {
            get => shortName; 
            set
            {
                shortName = value;
                OnPropertyChanged("ShortName");
            } 
        }
        public string FullName 
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }
        public string Category 
        {
            get => category; 
            set
            {
                category = value;
                OnPropertyChanged("Category");
            } 
        }
        public string Price 
        {
            get => price; 
            set
            {
                price = value;
                OnPropertyChanged("Price");
            } 
        }
        public string Availability 
        {
            get => availability; 
            set
            {
                availability = value;
                OnPropertyChanged("Availability");
            } 
        }
        public string Height 
        {
            get => height; 
            set
            {
                height = value;
                OnPropertyChanged("Height");
            }
        }
        public string Diameter 
        {
            get => diameter; 
            set
            {
                diameter = value;
                OnPropertyChanged("Diameter");
            } 
        }
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
