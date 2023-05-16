using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Shared.Models
{
    public class Product
    {
        [Key]
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
