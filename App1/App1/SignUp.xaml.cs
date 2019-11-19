using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
        public SQLiteConnection conn;
        public Registration regmodel;
        public SignUp ()
		{
			InitializeComponent ();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Registration>();
        }


        public async void Ok_clicked(object sender, EventArgs e)
        { 
            
            Registration reg = new Registration();

            reg.Userid = Userid.Text;
            reg.Password = Password.Text;
            
            int x = 0;
            try
            {
                x = conn.Insert(reg);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (x == 1)
            {
                await DisplayAlert("Alert", "You are Now Registered", "OK");
                await Navigation.PushAsync(new Feed());

            }
            else
            {
                await DisplayAlert("Registration Failled!!!", "Please try again", "ERROR");
            }

        }

        private void Show_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new DisplayPage()); //DisplayPage
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}