using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace katselabor.Models
{
    public class SearchModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string length { get; set; }
        public Nullable<decimal> mass { get; set; }
        public string sex { get; set; }
        public Nullable<System.DateTime> entryDate { get; set; }

        public IList<students> resultSet { get; set; }
    }
}