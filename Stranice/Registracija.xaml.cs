using Projekat.Modeli;
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

namespace Projekat.Stranice
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Page,INotifyPropertyChanged
    {
        private readonly string adminL = "Administrator1";
        public string uloga;
        public DB db = new DB();
        private Korisnik k;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyChanged = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
        public Korisnik Korisnik
        {
            get { return k; }
            set { k = value; OnPropertyChanged(); }
        }

        public Registracija()
        {
            InitializeComponent();
            Korisnik = new Korisnik();
        }
        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Korisnik.KorisnickoIme.Trim()) || string.IsNullOrWhiteSpace(Korisnik.KorisnickoIme.Trim()))
            {
                MessageBox.Show("Unesite korisnicko ime!");
            }
            else
            {
                if (string.IsNullOrEmpty(txtLozinka.Password) || string.IsNullOrWhiteSpace(txtLozinka.Password))
                {
                    MessageBox.Show("Unesite lozinku");
                }
                else
                {
                    if (string.IsNullOrEmpty(uloga))
                    {
                        MessageBox.Show("Odaberite ulogu novog korisnika");
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Korisnik.KorisnickoIme) && !string.IsNullOrWhiteSpace(Korisnik.KorisnickoIme) && !string.IsNullOrWhiteSpace(txtLozinka.Password)
                                && !string.IsNullOrWhiteSpace(txtLozinka.Password) && !string.IsNullOrEmpty(uloga))
                        {
                            if (adminLozinka.Password.Trim() == adminL)
                            {
                                k.Lozinka = txtLozinka.Password.Trim();
                                k.Uloga = uloga;
                                try
                                {
                                    db.DodajKorisnika(k);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Neuspesno registrovanje!");
                                    MessageBox.Show(ex.Message);
                                }
                                MainWindow mw = new MainWindow();
                                mw.Show();
                                Window win = (Window)this.Parent;
                                win.Close();
                            }
                            else
                            {
                                MessageBox.Show("Netacna lozinka za registrovanje!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Netacno uneti podaci!");
                        }
                    }
                }
            }


        }
        private void CbUloga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbUloga.SelectedIndex == 0)
            {
                uloga = "KASIRKA";
            }
            else if (cbUloga.SelectedIndex == 1)
            {
                uloga = "ADMIN";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Window win = (Window)this.Parent;
            win.Close();

        }
    }
}
