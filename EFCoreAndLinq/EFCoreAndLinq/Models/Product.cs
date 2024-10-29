using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCoreAndLinq.Models
{
    [Index(nameof(Name))]  // create index to product table
    [Index(nameof(Name),nameof(Price))]  // create composed index to product table

    public class Product
{
    [Key]
      public int Id { get; set; }


        public string Name { get; set; } = string.Empty;         
        public decimal Price { get; set; }      
        
        public string NameAndPrice { get; set; }
        public int? CategoryId { get; set; }        
        public Category? Category { get; set; }
      
        public ProductDetails?  ProductDetails { get; set; }
    }

}
