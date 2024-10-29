using EFCoreAndLinq.Configuration;
using EFCoreAndLinq.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace EFCoreAndLinq
{
    public class ContextClass:DbContext
    {

        public ContextClass(DbContextOptions<ContextClass> options) :base(options)
        {
            
        }



        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Product { get; set; }


        public DbSet<ProductDetails> ProductDetails { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // new ProductConfiguration().Configure(modelBuilder.Entity<Product>());  
            // i can put confguration in file(class) And inject it here




            //modelBuilder.Entity<ProductDetails>().HasQueryFilter(x => x.Id > 12);
            //global filter insted of each query i write it to get oroductDetails i use where clause
            // if i want write query taht i need to preveent filter i use   (IgnoreQueryFilter)



            // modelBuilder.Entity<Category>()  another way to add class And make it domain model
            //  if i make navigtation prop inside calss ike make list of product in category class ef core navigate this class to database even i not put it
            //   in dbcontext class or   protected override void OnModelCreating



            //  modelBuilder.Entity<Category>(x =>
            //  {
            //      x.Property<int>("Id").HasDefaultValue(0);
            //      
            //       can i make object of prop rather than each one
            //      
            //        });





            //  script-migration ===>generate sql script without reflect changes direct in database





            // modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "as" }); i can seed data with this way
            // must i insert primary even if was autogenerate if i want to seed data



            modelBuilder.Entity<Product>(x =>
            {
                x.Property<string>("NameAndPrice")
                    .HasComputedColumnSql("[Name] + ' ' + CAST([Price] AS NVARCHAR(20))");
            });

            //        if i want to make column based of  colums value 
            //         this tequniqe updated old value if i have old value in the table And ADD NEW COLUM 






            // modelBuilder.Entity<Category>().ToTable("table name exisit in database", b => b.ExcludeFromMigrations());
            //ignore Any new change  in the table And not remove if table is exisit from old migration  


        }

    }
}
// if i want to make onDelete SetNull i must make foregin key is nullable