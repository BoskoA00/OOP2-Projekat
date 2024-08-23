using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Modeli
{
    public class Korisnik:INotifyPropertyChanged
    {
        private string korisnickoIme;
        private string lozinka;
        private string uloga;

        public string Uloga
        {
            get { return uloga; }
            set { uloga = value; OnPropertyChanged(); }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; OnPropertyChanged(); }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
