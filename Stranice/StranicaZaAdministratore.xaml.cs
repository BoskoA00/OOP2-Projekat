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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekat.Stranice
{
    /// <summary>
    /// Interaction logic for StranicaZaAdministratore.xaml
    /// </summary>
    public partial class StranicaZaAdministratore : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Proizvod> Proizvodi { set; get; }
        public DB db = new DB();
        public string ImeK;
        private Proizvod proizvod;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Proizvod Proiz
        {
            get { return proizvod; }
            set { proizvod = value; OnPropertyChanged(); }
        }

        public StranicaZaAdministratore(string ImeKorisnika)
        {
            InitializeComponent();
            dobodosliText.Text = "Korisnik: " + ImeKorisnika;
            Proiz = new Proizvod();
            Ocitaj_proizvode();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if( string.IsNullOrEmpty(Proiz.Ime) || string.IsNullOrWhiteSpace(Proiz.Ime)) { MessageBox.Show("Unesite ime proizvoda"); }
            else if (string.IsNullOrWhiteSpace(Proiz.BarKod) || string.IsNullOrEmpty(Proiz.BarKod)) { MessageBox.Show("Unesite bar kod proizvoda"); }
            else if (float.IsNaN(Proiz.Cena) || Proiz.Cena <= 0) { MessageBox.Show(" Unesite cenu proizvoda"); }
            else if (float.IsNaN(Proiz.Kolicina) || Proiz.Kolicina <= 0) { MessageBox.Show("Unesite kolicinu proizvoda"); }
            else
            {
                db.UnesiProizvod(Proiz);
                Ocitaj_proizvode();
                Proiz.Ime = string.Empty;
                Proiz.BarKod = string.Empty;
                Proiz.Cena = 0;
                Proiz.Kolicina = 0;
            }

        }
        private void Ocitaj_proizvode()
        {
            Proizvodi = db.GetProizvode();
            lvProizvodi.ItemsSource = null;
            lvProizvodi.ItemsSource = Proizvodi;
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            var temp = Proiz.BarKod;
            txtBK.IsReadOnly = false;
            db.IzmeniProizvod(temp, Proiz);
            MessageBox.Show("Uspesna izmena proizvoda");
            lvProizvodi.SelectedItem = null;
            Proiz = null;
            Proiz = new Proizvod();
        }

        private void LvProizvodi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvProizvodi.SelectedIndex > -1)
            {
                btnIzmeni.IsEnabled = true;
                btnIzbrisi.IsEnabled = true;
                txtBK.IsReadOnly = true;
                Proiz = (Proizvod)lvProizvodi.SelectedItem;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            var win = (Window)this.Parent;
            MessageBox.Show("Uspesno odjavljivanje");
            win.Close();
            mw.Show();
        }

        private void BtnIzbrisi_Click(object sender, RoutedEventArgs e)
        {
            if (lvProizvodi.SelectedItem != null)
            {
                db.IzbrisiProizvod((lvProizvodi.SelectedItem as Proizvod).BarKod);
                Ocitaj_proizvode();
                lvProizvodi.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Odaberite proizvod za brisanje");
            }
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Proizvod Pr in Proizvodi)
            {
                if (Pr.Kolicina < 50)
                {
                    MessageBox.Show("Artikla " + Pr.Ime + "(" + Pr.BarKod + ")" + " je manje od 50 kg na stanju");
                }
            }
        }

        private void TxtBK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                foreach (Proizvod item in Proizvodi)
                {
                    if(item.BarKod==txtBK.Text)
                    {
                        Proiz.BarKod = item.BarKod;
                        Proiz.Cena = item.Cena;
                        Proiz.Ime = item.Ime;
                        Proiz.Kolicina = item.Kolicina;
                        lvProizvodi.SelectedIndex = Proizvodi.IndexOf(item);
                    }
                }
                if (Proiz.BarKod != txtBK.Text)
                {
                    MessageBox.Show("Ne postoji proizvod sa datim bar kodom!");
                }
            }

        }

    }
}
