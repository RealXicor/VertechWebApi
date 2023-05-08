using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VertechWebApi.Database;
using VertechWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VertechWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetProduct/{product_name}")]
        public IActionResult Get(string product_name)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer("Data Source=DESKTOP-SB4HEO9;Initial Catalog=VertechWebApiDB;Trusted_Connection=true;").Options;
            var _context = new DatabaseContext(options);

            var searchedProduct = _context.Product.FirstOrDefault(p => p.title.Contains(product_name));

            if(searchedProduct == null)
            {
                return NotFound("Product Not Found");
            }

            return Ok(searchedProduct);
        }

        [HttpPut("SaveInDatabase/{product_name}/{product_price}/{description}")]
        public IActionResult Put(string product_name, double product_price, string description)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer("Data Source=DESKTOP-SB4HEO9;Initial Catalog=VertechWebApiDB;Trusted_Connection=true;").Options;
            var _context = new DatabaseContext(options);

            if(_context.Product.FirstOrDefault(p => p.title.Equals(product_name)) != null){
                return BadRequest("Product with that name already exists in database!");
            }
            else
            {
                var product = new Product
                {
                    title = product_name,
                    price = product_price,
                    description = description

                };

                _context.Product.Add(product);
                _context.SaveChanges();

                var JSON_Result = new
                {
                    server_response = "Product successfully added to database!",
                    product_name = product_name,
                    product_price = product_price,
                    product_description = description,
                };

                return Ok(JSON_Result);
            }
        }
    }
}
