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
	public partial class Viewposts : ContentPage
	{
        public SQLiteConnection conn;
        public Post_Data postmodel;
        public Viewposts(string Heading1, string Post_Content1)
        {
            InitializeComponent();
            Heading.Text = Heading1;
            Post_Contents.Text = Post_Content1;
        }

        public void UpvoteClicked(object sender, EventArgs e)
        {
            DisplayAlert("", "Post upvotes", "OK");
            Upvote.IsVisible = false;
 
        }
    }
}