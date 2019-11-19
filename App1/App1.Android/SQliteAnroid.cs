using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQliteAnroid))]
namespace App1.Droid
{
    public class SQliteAnroid : Isqlite
    {
        public SQLiteConnection GetConnection()
        {
            //throw new NotImplementedException();
            var dbase = "Mydatabase";
            var path = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), dbase);

            return new SQLiteConnection(path);

        }


    }
}