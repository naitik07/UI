using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App1
{
    public class Post_Data
    {

        [PrimaryKey, AutoIncrement]
        public int PostId { get; set; }
        public string Heading { get; set; }
        public string Post_Content { get; set; }

        public int Upvotes { get; set; }
        


    }
}

    
    