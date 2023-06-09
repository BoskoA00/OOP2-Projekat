using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat.Modeli
{
    public class DB
    {
        readonly SqlConnection conn;
        readonly SqlCommand comm;

        public DB()
        {
            //Za bazu sam koristio MicrosoftSQL server pa mi je receno da stavim samo tacku u Connection string
            conn = new SqlConnection(@" . ");
            comm = conn.CreateCommand();
        }
        public void DodajKorisnika(Korisnik  korisnik)
        {
            try
            {
                conn.Open();
                comm.CommandText = $"INSERT INTO [dbo].[Korisnik] ([KorisnickoIme],[Sifra],[Uloga]) VALUES('{korisnik.KorisnickoIme}','{korisnik.Lozinka}','{korisnik.Uloga}')";
                comm.ExecuteNonQuery();
                MessageBox.Show("Uspesno dodavanje nove osobe");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public Korisnik VratiKorisnika(string Ime)
        {
            Korisnik korisnik=new Korisnik();
            try
            {
                conn.Open();
                comm.CommandText = $"SELECT KorisnickoIme,Sifra,Uloga FROM Korisnik  WHERE KorisnickoIme='{Ime}'";
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    korisnik.KorisnickoIme =r["KorisnickoIme"].ToString();
                    korisnik.Lozinka = r["Sifra"].ToString();
                    korisnik.Uloga = r["Uloga"].ToString();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return korisnik;
        }
        public ObservableCollection<Proizvod> GetProizvode()
        {
            ObservableCollection<Proizvod> proizvodi = new ObservableCollection<Proizvod>();
            try
            {
                conn.Open();
                comm.CommandText = $"SELECT * FROM Proizvod";
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    Proizvod p = new Proizvod
                    {
                        BarKod = r["BarKod"].ToString(),
                        Ime = r["ImeP"].ToString()
                    };
                    try
                    {
                        p.Cena = float.Parse(r["Cena"].ToString());
                        p.Kolicina = float.Parse(r["Kolicina"].ToString());
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Neuspesno citanje proizvoda iz baze");
                        MessageBox.Show(e.Message);
                    }
                    proizvodi.Add(p);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return proizvodi;
        }
        public void UnesiProizvod(Proizvod p)
        {
            try
            {
                conn.Open();
                comm.CommandText = $"INSERT INTO [dbo].[Proizvod] ([BarKod],[ImeP],[Cena],[Kolicina]) VALUES('{p.BarKod}','{p.Ime}','{p.Cena}','{p.Kolicina}')";
                comm.ExecuteNonQuery();
                MessageBox.Show("Uspesno dodavanje novog proizvoda");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void IzmeniProizvod(string stariBK,Proizvod p)
        {
            try
            {
                conn.Open();
                comm.CommandText = $"UPDATE [dbo].[Proizvod] SET [BarKod]='{p.BarKod}',[ImeP]='{p.Ime}',[Cena]='{p.Cena}',[Kolicina]='{p.Kolicina}' WHERE [BarKod]='{stariBK}'";
                comm.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void IzbrisiProizvod(string BarKod)
        {
            try
            {
                conn.Open();
                comm.CommandText = $"DELETE FROM [dbo].[Proizvod] WHERE [BarKod]='{BarKod}'";
                comm.ExecuteNonQuery();
                MessageBox.Show("Uspesno brisanje proizvoda");
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

    }
}
