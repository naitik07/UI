using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        
            public SQLiteConnection conn;
            public Registration regmodel;

            public MainPage()
            {
                InitializeComponent();
                conn = DependencyService.Get<Isqlite>().GetConnection();
                conn.CreateTable<Registration>();
            }


     
            //public async void  Login_clicked(string Userid, string Password)
            //{
            //    var data = conn.Table<Registration>();
            //    var d1 = data.Where(x => x.Userid == Userid && x.Password == Password).FirstOrDefault();
            //    if (d1 != null)
            //    {
            //    await Navigation.PushAsync(new Feed());
            //}
            //    else
            //        return ;
            //}

        



        private async void SignUp_clicked(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new SignUp());
        }

        public async void Login_clicked(object sender, EventArgs e)
        {

            var Username_Val = Userid.Text;
            var Pasword_Val = Password.Text;
            conn = DependencyService.Get<Isqlite>().GetConnection();
            var data = conn.Table<Registration>();
            var d1 = data.Where(x => Username_Val == x.Userid && Pasword_Val == x.Password).FirstOrDefault();
            if (d1 != null)
            {
                await Navigation.PushAsync(new Feed());
            }
            else
              await  DisplayAlert("Incorrect Details", "Please try again", "ERROR");
        }

      
    }

    
}
