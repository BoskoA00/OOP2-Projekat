using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Modeli
{
    public class Proizvod : INotifyPropertyChanged
    {
        private string barKod;
            
        public string BarKod
        {
            get { return barKod; }
            set { barKod = value; OnPropertyChanged(); }
        }
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged(); }
        }
        private float cena;

        public float Cena
        {
            get { return cena; }
            set { cena = value; OnPropertyChanged(); }
        }
        private float kolicina;

        public float Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
