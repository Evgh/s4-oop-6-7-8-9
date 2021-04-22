using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace s4_oop_6_7_8_9
{
    public interface IFilter
    {
        bool IsActive();
        bool IsApropriate(Item item);
    }

    class PriceFilter : INotifyPropertyChanged, IFilter
    {
        string minPrice;
        public string MinPrice
        {
            get => minPrice;
            set
            {
                minPrice = value;
                OnPropertyChanged("MinPrice");
            }
        }

        string maxPrice;
        public string MaxPrice
        {
            get => maxPrice;
            set
            {
                maxPrice = value;
                OnPropertyChanged("MaxPrice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool IsActive()
        {
            int min, max;
            return (int.TryParse(minPrice, out min) || int.TryParse(maxPrice, out max));
        }

        public bool IsApropriate(Item item)
        {
            bool flag = true;
            int min, max;
            int price = item.Price;

            if (int.TryParse(minPrice, out min))
            {
                flag = flag && (price >= min);
            }
            if (int.TryParse(maxPrice, out max))
            {
                flag = flag && (price <= max);
            }
            return flag;
        }
    }

    class HeigthFilter : INotifyPropertyChanged, IFilter
    {
        string minHeight;
        public string MinHeight
        {
            get => minHeight;
            set
            {
                minHeight = value;
                OnPropertyChanged("MinHeight");
            }
        }

        string maxHeight;
        public string MaxHeight
        {
            get => maxHeight;
            set
            {
                maxHeight = value;
                OnPropertyChanged("Maxheight");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool IsActive()
        {
            int min, max;
            return (int.TryParse(minHeight, out min) || int.TryParse(maxHeight, out max));
        }

        public bool IsApropriate(Item item)
        {
            bool flag = true;
            int min, max;
            int height = item.Height;

            if (int.TryParse(minHeight, out min))
            {
                flag = flag && (height >= min);
            }
            if (int.TryParse(maxHeight, out max))
            {
                flag = flag && (height <= max);
            }
            return flag;
        }
    }

    class DiameterFilter : INotifyPropertyChanged, IFilter
    {
        string minDiameter;
        public string MinDiameter
        {
            get => minDiameter;
            set
            {
                minDiameter = value;
                OnPropertyChanged("MinHeight");
            }
        }

        string maxDiameter;
        public string MaxDiameter
        {
            get => maxDiameter;
            set
            {
                maxDiameter = value;
                OnPropertyChanged("Maxheight");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool IsActive()
        {
            int min, max;
            return (int.TryParse(minDiameter, out min) || int.TryParse(maxDiameter, out max));
        }

        public bool IsApropriate(Item item)
        {
            bool flag = true;
            int min, max;
            int height = item.Diameter;

            if (int.TryParse(minDiameter, out min))
            {
                flag = flag && (height >= min);
            }
            if (int.TryParse(maxDiameter, out max))
            {
                flag = flag && (height <= max);
            }
            return flag;
        }
    }
    class AvailabilityFilter : INotifyPropertyChanged, IFilter
    {
        bool available;
        public bool Available
        {
            get => available;
            set
            {
                available = value;
                OnPropertyChanged("Available");
            }
        }

        bool order;
        public bool Order
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool IsActive()
        {
            return available || order;
        }

        public bool IsApropriate(Item item)
        {
            bool flag = false;
            int availability = item.Availability;

            if (available)
            {
                flag = flag || (availability > 0);
            }
            if (order)
            {
                flag = flag || (availability == 0);
            }

            return flag;
        }
    }


    class CategoryFilter : INotifyPropertyChanged, IFilter
    {
        bool blooming;
        public bool Blooming
        {
            get => blooming;
            set
            {
                blooming = value;
                OnPropertyChanged("Blooming");
            }
        }

        bool decidious;
        public bool Decidious
        {
            get => decidious;
            set
            {
                decidious = value;
                OnPropertyChanged("Decidious");
            }
        }

        bool fruit;
        public bool Fruit
        {
            get => fruit;
            set
            {
                fruit = value;
                OnPropertyChanged("Fruit");
            }
        }

        bool predator;
        public bool Predator
        {
            get => predator;
            set
            {
                predator = value;
                OnPropertyChanged("Predator");
            }
        }

        bool bonsai;
        public bool Bonsai
        {
            get => bonsai;
            set
            {
                bonsai = value;
                OnPropertyChanged("Bonsai");
            }
        }
        bool succulent;
        public bool Succulent
        {
            get => succulent;
            set
            {
                succulent = value;
                OnPropertyChanged("Succulent");
            }
        }

        bool primiting;
        public bool Primiting
        {
            get => primiting;
            set
            {
                primiting = value;
                OnPropertyChanged("Primiting");
            }
        }

        bool accessories;
        public bool Accessories
        {
            get => accessories;
            set
            {
                accessories = value;
                OnPropertyChanged("Accessories");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool IsActive() 
        {
            return Blooming || Decidious || Fruit || Predator || Bonsai || Succulent || Primiting || Accessories;    
        }

        public bool IsApropriate(Item item)
        {
            string category = item.Category;
            bool flag = false;

            if (Blooming)
            {
                flag = flag || (category == "Цветущие");
            }
            if (Decidious)
            {
                flag = flag || (category == "Лиственные");
            }
            if (Fruit)
            {
                flag = flag || (category == "Плодовые");
            }
            if (Predator)
            {
                flag = flag || (category == "Насекомоядные");
            }
            if (Bonsai)
            {
                flag = flag || (category == "Бонсай");
            }
            if (Succulent)
            {
                flag = flag || (category == "Суккуленты");
            }
            if (Primiting)
            {
                flag = flag || (category == "Грунт");
            }
            if (Accessories)
            {
                flag = flag || (category == "Аксессуары");
            }
            return flag;
        }

    }
}
