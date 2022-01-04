using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopHomepage.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public decimal Price { get; set; }    
        public decimal OldPrice { get; set; }    
        public string Image { get; set; }    
        public string Status { get; set; }    
    }
}