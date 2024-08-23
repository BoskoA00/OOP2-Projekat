using Projekat.Modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat.Stranice
{
    /// <summary>
    /// Interaction logic for Racun.xaml
    /// </summary>
    public partial class Racun : Window, INotifyPropertyChanged
    {
        private readonly ObservableCollection<Proizvod> Proizvodi = new ObservableCollection<Proizvod>();
        private string datum;
        public string Dt
        {
            get { return datum; }
            set { datum = value; OnPropertyChanged(); }
        }
        private float ukupnaCena;

        public float UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; OnPropertyChanged(); }
        }
        private Korisnik korisnik;

        public Korisnik K
        {
            get { return korisnik; }
            set { korisnik = value; OnPropertyChanged(); }
        }
        private float uplata;

        public float Uplata
        {
            get { return uplata; }
            set { uplata = value; OnPropertyChanged(); }
        }
        private float povracaj;

        public float Povracaj
        {
            get { return povracaj; }
            set { povracaj = value; OnPropertyChanged(); }
        }
        private string popust;

        public string Popust
        {
            get { return popust; }
            set { popust = value; OnPropertyChanged(); }
        }
        private string nacinP;

        public string NacinP
        {
            get { return nacinP; }
            set { nacinP = value; OnPropertyChanged();}
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





        public event PropertyChangedEventHandler PropertyChanged;

        public Racun(Korisnik k, ObservableCollection<Proizvod> korpa, string nacinP, float popust, float uplata)
        {
            InitializeComponent();
            K = k;
            Popust = popust.ToString() + "%";
            Uplata = uplata;
            NacinP = nacinP;
            lvProizvodi.ItemsSource = null;
            Proizvodi.Clear();
            foreach (Proizvod Pr in korpa)
            {
                Pr.Cena -= (popust / 100) * Pr.Cena;
                Proizvodi.Add(Pr);
                UkupnaCena += Pr.Cena;
            }
            Povracaj = Uplata - UkupnaCena;
            Dt = DateTime.Now.Day.ToString() + "-" +
               DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + "--" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            lvProizvodi.ItemsSource = Proizvodi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Preuzeli ste racun!");
            this.Close();
        }

        private void Izlaz(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBox.Show("Preuzeli ste racun");
                this.Close();
            }
        }
    }
}
