using Fitness_Aplikacija.Models;
using Fitness_Aplikacija.Pages;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Fitness_Aplikacija
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Database db = new Database();
        public event PropertyChangedEventHandler PropertyChanged;
        private User user;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            User = new User();
            DataContext = this;
            User.UserName = string.Empty;
            User.Password = string.Empty;
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(User.UserName.Trim()))
            {
                MessageBox.Show("Unesite korisnicko ime");
                return;
            }
            if (string.IsNullOrEmpty(User.Password.Trim()))
            {
                MessageBox.Show("Unesite lozinku");
                return;
            }
            User u = db.getUser(User);
            if ( u.UserName == null && u.Password == null)
            {
                MessageBox.Show($"Ne postoji korisnik {User.UserName}");
                User.UserName = string.Empty;
                return;
            }
            if ( User.Password == u.Password)
            {
                user.Password = string.Empty;
                user.UserName = string.Empty;
                Pocetna_stranica ps = new Pocetna_stranica(u.UserName);
                    this.Content = ps;
                this.Title = "Pocetna stranica";
            }
            else
            {
                MessageBox.Show("Neodgovarajuca lozinka");
                User.Password = string.Empty;
                return;
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            if (User.UserName.Trim() == string.Empty)
            {
                MessageBox.Show("Unesite korisnicko ime!");
                return;
            }
            if (User.Password.Trim() == string.Empty)
            {
                MessageBox.Show("Unesite lozinku!");
                return;
            }
            db.registerUser(User);
        }
    }
}
