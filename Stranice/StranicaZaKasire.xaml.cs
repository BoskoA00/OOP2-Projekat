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
    /// Interaction logic for StranicaZaKasire.xaml
    /// </summary>
    public partial class StranicaZaKasire : Page, INotifyPropertyChanged
    {
        public float UkupnaCena;
        public Korisnik K;
        public string nacinP;
        public DB db = new DB();
        private Proizvod proizvod;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Proizvod> PonudjeniProizvodi { set; get; }
        public ObservableCollection<Proizvod> Korpa { set; get; }
        public Proizvod TrProizvod
        {
            get { return proizvod; }
            set { proizvod = value; OnPropertyChanged(); }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private float uplata;
        public float Uplata
        {
            get { return uplata; }
            set { uplata = value; OnPropertyChanged(); }
        }

        private float popust;
        public float Popust
        {
            get { return popust; }
            set { popust = value; OnPropertyChanged(); }
        }
        public void Ocitaj_proizvode()
        {
            PonudjeniProizvodi = db.GetProizvode();
            lvPonudjeniProizvodi.ItemsSource = null;
            lvPonudjeniProizvodi.ItemsSource = PonudjeniProizvodi;
        }

        public StranicaZaKasire(Korisnik k)
        {
            InitializeComponent();
            TrProizvod = new Proizvod();
            K = k;
            Korpa = new ObservableCollection<Proizvod>();
            txtKorisnik.Text = "Korisnik:" + K.KorisnickoIme;
            Ocitaj_proizvode();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            var win = (Window)this.Parent;
            MessageBox.Show("Uspesno odjavljivanje");
            win.Close();
            mw.Show();
        }

        private void LvPonudjeniProizvodi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvPonudjeniProizvodi.SelectedIndex > -1)
            {
                TrProizvod.Ime = (lvPonudjeniProizvodi.SelectedItem as Proizvod).Ime;
                TrProizvod.BarKod = (lvPonudjeniProizvodi.SelectedItem as Proizvod).BarKod;
                TrProizvod.Cena = (lvPonudjeniProizvodi.SelectedItem as Proizvod).Cena;
                TrProizvod.Kolicina = 0;
                trText.Text = TrProizvod.Ime + "(" + TrProizvod.BarKod + ")";
            }
            else
            {
                MessageBox.Show("Niste odabrali proizvod");
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (string.Equals(rb.Content, "Gotovina"))
            {
                nacinP = "Gotovina";
            }
            else if (string.Equals(rb.Content, "Kreditna kartica"))
            {
                nacinP = "Kreditna kartica";
            }
            else if (string.Equals(rb.Content, "Debitna kartica"))
            {
                nacinP = "Debitna kartica";
            }
            else if (string.Equals(rb.Content, "Digitalni novcanik"))
            {
                nacinP = "Digitalni novcanik";
            }
            else
            {
                nacinP = "Neodabran";
            }
        }

        private void BtnUKorpu_Click(object sender, RoutedEventArgs e)
        {
            if (float.IsNaN(TrProizvod.Kolicina) || TrProizvod.Kolicina <= 0) { MessageBox.Show("Nevazeca vrednost za kolicinu"); }
            else
            {
                if (lvPonudjeniProizvodi.SelectedIndex > -1)
                {
                    float kolicina = (lvPonudjeniProizvodi.SelectedItem as Proizvod).Kolicina;

                    if (TrProizvod.Kolicina != 0 && kolicina >= TrProizvod.Kolicina && kolicina > 0)
                    {
                        Proizvod p = new Proizvod
                        {
                            BarKod = TrProizvod.BarKod,
                            Ime = TrProizvod.Ime,
                            Kolicina = TrProizvod.Kolicina
                        };
                        p.Cena = TrProizvod.Cena * p.Kolicina;
                        PonudjeniProizvodi[lvPonudjeniProizvodi.SelectedIndex].Kolicina = PonudjeniProizvodi[lvPonudjeniProizvodi.SelectedIndex].Kolicina - p.Kolicina;
                        UkupnaCena += p.Cena;
                        lvPonudjeniProizvodi.ItemsSource = null;
                        lvPonudjeniProizvodi.ItemsSource = PonudjeniProizvodi;
                        Korpa.Add(p);
                        lvKorpa.ItemsSource = null;
                        lvKorpa.ItemsSource = Korpa;
                        TrProizvod.BarKod = string.Empty;
                        TrProizvod.Ime = string.Empty;
                        TrProizvod.Kolicina = 0;
                        TrProizvod.Cena = 0;
                        trText.Text = string.Empty;
                    }
                    else if (kolicina == 0)
                    {
                        MessageBox.Show("Nema dovoljno proizvoda na stanju!");

                    }
                    else if (TrProizvod.Kolicina > kolicina)
                    {
                        MessageBox.Show("Nema dovoljno proizvoda na stanju!");
                    }
                    else if (TrProizvod.Kolicina == 0)
                    {
                        MessageBox.Show("Morate uneti zeljenu kolicinu");
                    }
                }
                else
                {
                    MessageBox.Show("Niste odabrali prizvod");
                }
            }
        }

        private void BtnNaplati_Click(object sender, RoutedEventArgs e)
        {
            if (Uplata == 0 || float.IsNaN(Uplata)) { MessageBox.Show("Uplata mora biti veca od 0"); }
            else if (Popust < 0) { MessageBox.Show("Nije moguce da popust bude manji od 0 "); }
            else if (Popust > 100) { MessageBox.Show("Nije moguce da popust bude veci od 100%"); }
            else if (float.IsNaN(Popust)) { MessageBox.Show("Neispravna vrednost za popust"); }
            else if (Uplata < UkupnaCena - (UkupnaCena * Popust)) { MessageBox.Show("Nedovoljna uplata!"); }
            else if (!string.IsNullOrEmpty(nacinP))
            {
                MessageBoxResult odgovor = MessageBox.Show("Isplata kupovine?", "Potvrda", MessageBoxButton.YesNo);
                if (odgovor == MessageBoxResult.Yes)
                {
                    foreach (Proizvod pr in PonudjeniProizvodi)
                    {
                        db.IzmeniProizvod(pr.BarKod, pr);
                    }
                    Racun r = new Racun(K, Korpa, nacinP, Popust, Uplata);
                    r.Show();
                    Korpa.Clear();
                    Popust = 0;
                    Uplata = 0;
                    UkupnaCena = 0;
                    Ocitaj_proizvode();
                }
                else
                {
                    odgovor = MessageBox.Show("Ponistiti kupovinu?", "Pitnaje", MessageBoxButton.YesNo);
                    if (odgovor == MessageBoxResult.Yes)
                    {
                        Ocitaj_proizvode();
                        lvKorpa.ItemsSource = null;
                        Korpa.Clear();
                        lvKorpa.ItemsSource = Korpa;
                        UkupnaCena = 0;
                        Popust = 0;
                        Uplata = 0;
                        UkupnaCena = 0;
                    }
                }
            }
            else if (string.IsNullOrEmpty(nacinP) || nacinP == "Neodabran")
            {
                MessageBox.Show("Niste odabrali nacin placanja");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            string stariTxt = "";
            if (e.Key == Key.Enter)
            {
                foreach (Proizvod item in PonudjeniProizvodi)
                {
                    if (item.BarKod == trText.Text.Trim())
                    {
                        TrProizvod.BarKod = item.BarKod;
                        TrProizvod.Cena = item.Cena;
                        TrProizvod.Kolicina = 0;
                        TrProizvod.Ime = item.Ime;
                        lvPonudjeniProizvodi.SelectedIndex = PonudjeniProizvodi.IndexOf(item);
                        stariTxt = trText.Text.Trim();
                        trText.Text = TrProizvod.Ime + "(" + TrProizvod.BarKod + ")";
                    }
                }
                if (TrProizvod.BarKod != stariTxt.Trim())
                {
                    MessageBox.Show("Ne postoji proizvod sa datim bar kodom");
                }
            }
        }

        
    }
}
