using System;
using System.Collections.Generic;

#nullable disable

namespace DZ5_1.Models
{
    public partial class MovieCast
    {
        public int movie_id { get; set; }
        public int person_id { get; set; }
        public string character_name { get; set; }
        public int gender_id { get; set; }
        public int cast_order { get; set; }

        public virtual Movie MovieIDNavigation { get; set; }
        public virtual Person PersonIDNavigation { get; set; }
    }
}
