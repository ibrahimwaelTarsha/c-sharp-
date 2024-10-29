namespace EFCoreAndLinq.Models
{
   
        public class ProductDetails
        {
            public int Id { get; set; }
            public string?   description { get; set; }

         public int? ProductId { get; set; }

        public Product? Products { get; set; }
        }

    

}
