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
    public partial class DisplayPage : ContentPage
    {
        public SQLiteConnection conn;
        public Registration regmodel;
       
        public DisplayPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Registration>();
            DisplayDetails();


        }
        public void DisplayDetails()
        {

            var details = (from x in conn.Table<Registration>() select x).ToList();
            myListView.ItemsSource = details;
        }
    }
}