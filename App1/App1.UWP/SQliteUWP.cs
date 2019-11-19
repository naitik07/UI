using App1.UWP;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQliteUWP))]
namespace App1.UWP
{
   
        class SQliteUWP : Isqlite
        {
            public SQLiteConnection GetConnection()
            {
                //throw new NotImplementedException();
                var dbase = "Mydatabase";
                var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbase);

                return new SQLiteConnection(path);  

            }
        }
}
