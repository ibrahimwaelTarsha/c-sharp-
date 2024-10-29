﻿using System.ComponentModel.DataAnnotations;

namespace EFCoreAndLinq.Models
{
  public class Category
{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;     
        public ICollection<Product>? Products { get; set; }
}

}
