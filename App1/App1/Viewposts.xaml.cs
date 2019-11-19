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
        public Viewposts(string Heading1, string Post_Content1, App1.Post_Data postID_)
        {
            InitializeComponent();
            Heading.Text = Heading1;
            Post_Contents.Text = Post_Content1;
            Upvote.IsVisible = false;

            Upvote.Clicked +=  (sender, args) => DisplayAlert(" ", "Post upvoted", "OK");
              

    }
      
        //public void deletepost(App1.Post_Data postid)
        //{
          
        //}

      
        //Upvote.IsVisible = false;

        //conn.Table<Post_Data>().Upvot

    }

    
}