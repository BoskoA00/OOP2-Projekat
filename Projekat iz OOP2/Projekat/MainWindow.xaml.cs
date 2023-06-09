using Projekat.Modeli;
using Projekat.Stranice;
using System;
using System.Collections.Generic;
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

namespace Projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public DB db = new DB();
        private Korisnik korisnik;

        public Korisnik K
        {
            get { return korisnik; }
            set { korisnik = value; OnPropertyChanged(); }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainWindow()
        {
            InitializeComponent();
            K = new Korisnik();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(K.KorisnickoIme) || !string.IsNullOrWhiteSpace(K.KorisnickoIme))
            {
                K = db.VratiKorisnika(K.KorisnickoIme);
                if (string.IsNullOrEmpty(K.KorisnickoIme))
                {
                    MessageBox.Show("Ne postoji korisnik sa takvim korisnickim imenom");
                    K.KorisnickoIme = string.Empty;
                    txtLozinka.Password = string.Empty;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtLozinka.Password) || !string.IsNullOrEmpty(txtLozinka.Password))
                    {
                        if (txtLozinka.Password.Trim() == K.Lozinka)
                        {
                            if (K.Uloga == "KASIRKA")
                            {
                                StranicaZaKasire szk = new StranicaZaKasire(K);
                                main.Content = szk;
                                main.Title = "Kasa";
                            }
                            else
                            {
                                StranicaZaAdministratore sza = new StranicaZaAdministratore(K.KorisnickoIme);
                                main.Content = sza;
                                main.Title = "Prozor za administratore";
                            }

                        }
                        else
                        {
                            MessageBox.Show("Pogresna lozinka");
                            txtLozinka.Password = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unesite lozinku");
                    }
                }
            }
            else
            {
                MessageBox.Show("Unesite korisnicko ime");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registracija r = new Registracija();
            main.Content = r;
            main.Title = "Registracija";
        }

        private void Izlaz(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
