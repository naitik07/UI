using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    

    public partial class Feed : TabbedPage

    {
        public SQLiteConnection conn;
        public Post_Data postmodel;
     

        public Feed()
        {


            InitializeComponent();
            
             conn = DependencyService.Get<Isqlite>().GetConnection();
            conn.CreateTable<Post_Data>();
            DisplayDetails();

            BindingContext = new Post_Data();
                
        }
        public  void DisplayDetails()
        {

            var details = (from x in conn.Table<Post_Data>() select x).ToList();
            PostView.ItemsSource = details;
            ArchiveView.ItemsSource = details;
        }
        public async void Post_clicked(object sender, EventArgs e)
        {


            Post_Data pd = new Post_Data();

            pd.Heading = Heading.Text;
            pd.Post_Content = Post_Content.Text;

            int x = 0;
            try
            {
                x = conn.Insert(pd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (x == 1)
            {
                await DisplayAlert("Alert", "Post Submitted", "OK");
                await Navigation.PushAsync(new Feed());

            }
            else
            {
                await DisplayAlert("post Failled!!!", "Please try again", "ERROR");
            }


        }

        public async void PostView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            

            var details = e.Item as Post_Data;

 

            //conn.Table<Post_Data>().Delete(x => x.PostId == details.PostId);



            //await DisplayAlert(details.Heading, details.Post_Content, "Upvote");

            await Navigation.PushAsync(new Viewposts(details.Heading,details.Post_Content));

            //await PopupNavigation.PushAsync(new Demo(details.Heading, details.Post_Content));
        }

        public  async void PostView_ItemTapped_U(object sender, ItemTappedEventArgs e)
        {
            var details_U = e.Item as Post_Data;
            var result = await DisplayAlert("Choose your Action", "", "View Full Post", "Delete Post");
            if (result==true)
            {
                await Navigation.PushAsync(new Viewposts(details_U.Heading, details_U.Post_Content, details_U));
            }
            else if (result ==false)
            {
                conn.Table<Post_Data>().Delete(x => x.PostId == details_U.PostId);
            }
            else
            {
                return;
            }

            

        }
      
    }
 
}
