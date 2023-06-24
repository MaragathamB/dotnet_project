using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Productwebsite.Models
{
    public class tbl_products
    {
        public int id { get; set; }
        public string product_name { get; set; }

        public int quantity { get; set; }
    }
}