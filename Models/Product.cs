using System.ComponentModel.DataAnnotations;

namespace VertechWebApi.Models
{
    public class Product
    {
        [Key]
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
}
