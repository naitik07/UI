using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    
        public class Registration
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Userid { get; set; }
            public string Password { get; set; }
            

        }

    
}
