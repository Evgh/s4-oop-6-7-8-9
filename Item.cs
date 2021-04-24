using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;

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
        string ImagePath { get; set; }
        BitmapImage Image {get;}
        
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

        string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
                OnPropertyChanged("Image");
            }
        }

        //BitmapImage image;
        public BitmapImage Image
        {
            get => new BitmapImage(new Uri(ImagePath));
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
            if (ShortName == null &&
                FullName == null &&
                Description == null &&
                Category == null &&
                Availability == 0 &&
                Price == 0 &&
                Height == 0 &&
                Diameter == 0)
            {
                return true;
            }
            else
            {
                return ShortName == "" &&
                       FullName == "" &&
                       Description == "" &&
                       Category == "" &&
                       Availability == 0 &&
                       Price == 0 &&
                       Height == 0 &&
                       Diameter == 0;
            }

        }
    }

    static class ItemFabric
    {
        public static Item GetEmptyItem()
        {
            return new Plant() { ImagePath = "resources\\add.png" };
        }

        public static ObservableCollection<Item> GetItemsCollection(string path)
        {
            return PlantSerializer.Deserialize(path);
        }

        public static void SaveItemCollection(ObservableCollection<Item> items, string path)
        {
            PlantSerializer.Serialize(items, path);
        }
    }

    static class PlantSerializer 
    {
        static JsonSerializerSettings settings;
        static PlantSerializer()
        {
            settings = new JsonSerializerSettings();
            settings.Converters.Add(new ItemToFlatConverter());
        }

        public static void Serialize(object source, string path)
        {
            using (var sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(JsonConvert.SerializeObject(source));
            }
        }

        public static ObservableCollection<Item> Deserialize(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<ObservableCollection<Item>>(sr.ReadToEnd(), settings);
            }
        }

        private class ItemToFlatConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(Item));
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value, typeof(Plant));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return serializer.Deserialize(reader, typeof(Plant)); ;
            }
        }
    }

}
