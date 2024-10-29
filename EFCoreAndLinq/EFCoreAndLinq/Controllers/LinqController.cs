using EFCoreAndLinq.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.Intrinsics.X86;
using System;
using System.Reflection.Metadata;

namespace EFCoreAndLinq.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly ContextClass _contextClass;
        public LinqController(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }




        [HttpGet]
        public async Task<IActionResult> getAllProduct()
        {
            IEnumerable<Product> products = await _contextClass.Product.AsNoTracking().ToListAsync();

            return Ok(products);
        }








        [HttpGet]
        public async Task<IActionResult> whereWithSelect()
        {
            //Always prefer Where before Select when working with large datasets in EF Core.
            //This reduces the amount of data being retrieved from the database, leading to better performance.
            var result = _contextClass.Product
                   .Where(p => p.Price > 50)
                   .Select(p => new { p.Name, p.Price }) ;
                  
            return Ok(await result.ToListAsync());

        }



       





        [HttpGet]
        public async Task<IActionResult> SelectWithWhere()
        {

            //The SQL query retrieves all the rows first, and then EF Core applies the filter in memory (WHERE Price > 50).
            //This means more data may be transferred from the database and filtered in-memory.
            var result = await _contextClass.Product
                       .Select(p => new { p.Name, p.Price })
                       .Where(p => p.Price > 50)
                       .ToListAsync();

            return Ok(result);

        }




        [HttpGet]
        public async Task<IActionResult> SingleOrDefault()
        {   // this teqnigue is more effecent if i want to ensure that  i have just one result in database without check All rows no 
            // i filter firstone use where And i use single to check the result that come from where not direct from table on database
            Product products = await _contextClass.Product.Where(x => x.Name == "any").SingleOrDefaultAsync();

            products.Name = "value";
            _contextClass.SaveChanges();
            /// this teqige make me update 1 value for specific column
            return Ok(products);
        }






        [HttpGet]
        public async Task<IActionResult> Avarage()
        {   //avarage not take expresssion inside it And i use where if i want avarage based on expression
            var x = await _contextClass.Product.Where(x => x.Name == "any").AverageAsync(x => x.Price);

            return Ok(x);
        }








        [HttpGet]
        public async Task<IActionResult> Sum()
        {   //Sum not take expresssion inside it And i use where if i want Sum based on expression
            var x = await _contextClass.Product.Where(x => x.Name == "any").SumAsync(x => x.Price);

            return Ok(x);
        }






        [HttpGet]
        public async Task<IActionResult> LongCount()
        {   //return number that count cannot store in int dataType 
            var x = await _contextClass.Product.LongCountAsync(x => x.Price > 400);

            return Ok(x);
        }






        [HttpGet]
        public async Task<IActionResult> any()
        {   // return flase if table has at least 1 record And return flase i table is empty
            // i can add x=>X.  to any like Any linq extention method
            bool x = await _contextClass.Product.AnyAsync();


            return Ok(x);
        }














        [HttpGet]
        public async Task<IActionResult> Pagination(int pageNum, int pageSize)
        {
            var x = await _contextClass.Product.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(x);
        }







        [HttpGet]
        public async Task<IActionResult> GroupBy()
        {
            var x = await _contextClass.Product.GroupBy(x => new { x.Name, x.NameAndPrice }).Select(x => new { Name = x.Key, count = x.Count() }).ToListAsync();
            // key is the prop i choese it in groupBy and must use aggrigate function with it to group result baesd on key that i choese it
            // i need more training 
            return Ok(x);
        }












        //[HttpGet]
        //public async Task<IActionResult> All()
        //{   // i cant write All without expression inside it 
        //    bool x = await _contextClass.Product.AllAsync();

        //    return Ok(x);
        //}












        [HttpGet]
        public async Task<IActionResult> Last()
        {
            var x = await _contextClass.Product.OrderBy(x => x.Id).LastAsync();
            // if i want to use last i must order rows by any column 

            return Ok(x);
        }













        [HttpGet]
        public async Task<IActionResult> orderByWithThenBy()
        {
            var x = await _contextClass.Product.OrderBy(x => x.Id).ThenBy(x => x.Price).ToListAsync();
            // if i want to order by column And i want second order 

            return Ok(x);
        }












        [HttpGet]
        public async Task<IActionResult> orderByWithThenByDesinding()
        {
            var x = await _contextClass.Product.OrderBy(x => x.Id).ThenByDescending(x => x.Price).ToListAsync();
            // if i want to order by column And i want second order to order desinding 

            return Ok(x);
        }















        [HttpGet]
        public async Task<IActionResult> Distsict()
        {
            var x = await _contextClass.Product.Select(x => x.Name).Distinct().ToListAsync();
            // distinct work with all column i retrive it from database And deal with it
            // As a single block and retrive result that different from all colums i select it 

            return Ok(x);
        }















        [HttpGet]
        public async Task<IActionResult> LastOrDefault()
        {
            var x = await _contextClass.Product.OrderBy(x => x.Id).LastOrDefaultAsync(x => x.Id > 2);
            // similar of first or default but not return first element return last element
            // can i use last with expression like first And return exeption if not return Any result

            return Ok(x);
        }














        [HttpPost]
        public async Task<IActionResult> AddRange()
        {
            // add many rows at same time in entity
            var cat = new List<Category>{

               new Category { Name = "sdf" },
               new Category { Name = "asdasd" } };

            await _contextClass.Categories.AddRangeAsync(cat);
            await _contextClass.SaveChangesAsync();

            return Ok(true);
        }








        [HttpPost]
        public async Task<IActionResult> AddRelatedDateWhenAddParentAtSameTime()
        {
            // if i want at sametime add products to category that not created yet and i want to assign this product to category i want created it 
            // at same time that  i create product  i use this tequniq  to use navigate prop <related>  and when i create category i create list of product

            var cat = new List<Category>{

               new Category { Name = "test1",Products=new List<Product>{ new Product{ Name="prdForTes1" ,Price=12} } },


               new Category { Name = "test2",Products=new List<Product>{ new Product{ Name="prdForTes2" ,Price=14} } },
            };

            await _contextClass.Categories.AddRangeAsync(cat);
            await _contextClass.SaveChangesAsync();

            return Ok(true);
        }

















        [HttpGet]
        public async Task<IActionResult> UpdateProductName()
        {   // if i search by id or select byId  findAsync is most suitable  for this
            Product products = await _contextClass.Product.FindAsync(1);
            products.Name = "value";
            _contextClass.SaveChanges();
            return Ok(products);
        }









        [HttpPut]
        public async Task<IActionResult> updateInEfcore()
        {
            // this wany i use it if i want to update some column (maby 1 col or 2 or 3) now all record 
            var row = await _contextClass.Product.FindAsync(2);

            row.Name = "updated name";
            row.Price = 10;
            await _contextClass.SaveChangesAsync();

            return Ok(true);
        }





        [HttpPut]
        public async Task<IActionResult> updateInEfcore2()
        {
            // this wany updated record based on type of object (ef core can know based on obj type whch table want be modified)
            // and i must send id to the ojc to tell ef core whch record in specific table i want update it with values in obj
            var obj = new Product { Id = 4, Name = "update " };

            //  _contextClass.Update(obj);

            // each prop in table set null if i not send it eith obj==> example (var obj = new Product { Id = 2, Name = "update " };) price i not send it mean not saved with old data
            // in the table efcore know this prop null because i not send it with obj





            // if i want to keep each column with saved data And not be A null if i not send it with obj i make this after _context.update
            _contextClass.Update(obj);
            _contextClass.Entry(obj).Property(x => x.Price).IsModified = false;
            _contextClass.Entry(obj).Property(x => x.CategoryId).IsModified = false;
            
            await _contextClass.SaveChangesAsync();

            return Ok(true);
        }





















        [HttpGet]
        public async Task<IActionResult> AsNoTracking()
        {    // i can change query behavior like this 
            _contextClass.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var x = await _contextClass.Product.ToListAsync();

            // i need more training 
            return Ok(x);
        }












        [HttpGet]
        public async Task<IActionResult> EagerLoading()
        {
            var xx = await _contextClass.Categories.Include(x => x.Products).ToListAsync();
            // if i not include product then in my qeury i not load Any referance or navigate or related data 

            // يوثر علي الاداء لانه يقوم بتحميل الجدول مع البيانات المرتبطه به 
            var product = xx.Select(x => new { category = x.Name, products = x.Products.Select(x => x.Name) }).ToList();
            return Ok(product);
        }















        [HttpGet]
        public async Task<IActionResult> explisitLoading(bool a)
        {


            if (a)
            {
                // can i after query make select or where or Any operation for related daa taht return 
                var xx = await _contextClass.Product.FirstOrDefaultAsync(x => x.Id == 1);
                await _contextClass.Entry(xx).Reference(x => x.Category).Query().Select(x => x.Name).LoadAsync();

                return Ok(xx);

            }
            else
            {
                var xx = await _contextClass.Product.FirstOrDefaultAsync(x => x.Id == 1);

                return Ok(xx);

            }

        }















        [HttpGet]
        public async Task<IActionResult> LazyLoading()
        {
            // i use packageLazyLoadingProxies (EntityFremework.Core.Proxies) And i make all navigation prp as a virtual 
            // And i load data lazy that mean when i select data without include data that load 
            // and if i want to display navigatinon data or related i not use include i can  acces to related data without using include 

            var xx = await _contextClass.Product.FirstOrDefaultAsync(x => x.Id == 1);

            return Ok(xx.Category.Name);// load this category without need to use include if i use lazyLoading package And in program.cs before useSql i use lazyLoadingProxies

        }













        [HttpGet]
        public async Task<IActionResult> SqlQuery()
        {


            //Ensure Product Exists: The SQL query (SELECT * FROM product) should return results that can be mapped to the Product entity.
            //The columns returned from the SQL query must match the
            // each prop not exist or in different name in mapped model  that be null 
            var products = await _contextClass.Product
                .FromSqlRaw("SELECT * FROM product")
                .ToListAsync();

            return Ok(products);

        }















        [HttpGet]
        public async Task<IActionResult> SqlQueryWithAvoidSqlInjection()
        {

            //If you need to include parameters in your query, you can use SQL parameters to ensure safe handling of inputs:



            var productName = "ExampleProduct";
            var products = await _contextClass.Product
                .FromSqlRaw("SELECT * FROM product WHERE Name = {0}", productName)
                .ToListAsync();
            return Ok(products);


           // The { 0} is a placeholder for the first argument(productName),
           // and Entity Framework Core will safely pass this as a parameter to prevent SQL injection.



        }








        [HttpGet]
        public async Task<IActionResult> AsSplit()
        {
            //AsSplitQuery: This method tells EF Core to execute multiple SQL queries instead of a single query when
            //  loading related data.It breaks down the original query into separate queries for
            //  the main entity and each of its related collections.This approach helps reduce 
            //  the overhead of large joins and the "Cartesian product problem" that occurs when querying multiple collections.


            //  You would use AsSplitQuery when querying entities that have
            //   multiple related collections, and you want to avoid the performance degradation caused by large joins.


            //Benefits of AsSplitQuery:
            //Improves performance in cases where large joins cause inefficiencies or a Cartesian explosion of results.
            //Reduces memory pressure and avoids over-fetching of redundant data.



        var xx = await _contextClass.Product.Include(x => x.Category).Include(x => x.ProductDetails).AsSplitQuery().FirstOrDefaultAsync(x => x.Id == 2);
            return Ok(xx.Category);
        }








        [HttpGet]
        public async Task<IActionResult> transaction1()
        {
            
            // must i use try And catch i i want deal with transactions
            using var transaction=await _contextClass.Database.BeginTransactionAsync();


            try
            {
                await  _contextClass.Categories.AddAsync(new Category { Name = "test33" });
                await  _contextClass.Categories.AddAsync(new Category { Id=3,Name = "test2" });

               

                await _contextClass.SaveChangesAsync();


                await  transaction.CommitAsync();

                return Ok(true);
            }
            catch
            {
               await transaction.RollbackAsync();
                return BadRequest(false);

            }

        }











        [HttpGet]
        public async Task<IActionResult> transaction2()
        {

            // must i use try And catch i i want deal with transactions
            using var transaction = await _contextClass.Database.BeginTransactionAsync();


            try
            {
                await _contextClass.Categories.AddAsync(new Category { Name = "fdfddfd" });
                await _contextClass.Categories.AddAsync(new Category { Name = "fdfdfdfdfdf" });

              
                await transaction.CreateSavepointAsync("point1");///  execute code if exeption happend And return 
                //to point that i choese it in catch And execite logic before same point in try block
                await _contextClass.Categories.AddAsync(new Category { Name = "test33" });
                await _contextClass.Categories.AddAsync(new Category { Id = 3, Name = "test2" });



                await _contextClass.SaveChangesAsync();


                await transaction.CommitAsync();

                return Ok(true);
            }
            catch
            {
                await transaction.RollbackToSavepointAsync("point1");
                await transaction.RollbackAsync();
                return BadRequest(false);

            }

        }






        public async Task<IActionResult> BulkUpdate()
        {
            // bulk update impreove pefrformace And more efficient if i want update multiple rows
            // because it direct deal with database by create sql command to hanle update 
            // i not need saveChages for bulk
            await _contextClass.Categories.Where(x => x.Id > 3).ExecuteUpdateAsync(x => x.SetProperty(x=>x.Name,"sdsdsd"));
            // i i not use filter changes reflect for All rows
            return Ok(true);    
        }






        public async Task<IActionResult> Bulkdelete()
        {
            // bulk update impreove pefrformace And more efficient if i want delete multiple rows
            // because it direct deal with database by create sql command to hanle update 
            // i not need saveChages for bulk
            await _contextClass.Categories.Where(x => x.Id > 3).ExecuteDeleteAsync();
            return Ok(true);
            // i i not use filter changes reflect for All rows

        }









        [HttpGet]
        public async Task<IActionResult> ProcedureInEfCore()
        {
            // to be continue 



            // var productSummaries = await _contextClass.Database.



            return Ok();//productSummaries);
        }






    }
}