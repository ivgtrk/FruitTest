using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FruitTest
{
    internal class DataGridModel : INotifyPropertyChanged
    {
        private DateTime date;
        private string trader;
        private string good;
        private double weight;
        private double price;
        private double cost;


        public DateTime Date
        {
            get => date;
            set { date = value; OnPropertyChanged(); }
        }

        public string Trader
        {
            get => trader;
            set { trader = value; OnPropertyChanged(); }
        }

        public string Good
        {
            get => good;
            set { good = value; OnPropertyChanged(); }
        }

        public double Weight
        {
            get => weight;
            set { weight = value; OnPropertyChanged(); }
        }

        public double Price
        {
            get => price;
            set { price = value; OnPropertyChanged(); }
        }

        public double Cost
        {
            get => cost;
            set { cost = value; OnPropertyChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}
