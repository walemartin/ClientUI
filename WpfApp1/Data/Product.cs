using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp1.Data
{
    public class Product: INotifyPropertyChanged
    {
        private string name;
        private string description;
        private double price;
        private int unit;
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        public Product()
        {
        }

        public Product(string name,string description,double price,int unit)
        {
            this.Name = name;
            this.Unit = unit;
            this.description = description;
            this.Price = price;
        }

       

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public int Id { get; set; }
        public string Name {
            get { return name; }
            set
            {
                name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public string Description {
            get { return description; }
            set
            {
                description = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public double Price {
            get { return price; }
            set
            {
                price = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
        public int Unit {
            get { return unit; }
            set
            {
                unit = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }
    }
}
