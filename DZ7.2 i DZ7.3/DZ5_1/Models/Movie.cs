using System;
using System.Collections.Generic;

#nullable disable

namespace DZ5_1.Models
{
    public partial class Movie
    {
        public int movie_id { get; set; }
        public string title { get; set; }
        public string  budget { get; set; }
        public string homepage { get; set; }
        public string overview { get; set; }
        public string popularity { get; set; }
        public string release_date { get; set; }
        public string  revenue { get; set; }
        public string runtime { get; set; }
        public string movie_status { get; set; }
        public string tagline { get; set; }
        public string vote_average { get; set; }
        public int? vote_count { get; set; }        
    }
}
