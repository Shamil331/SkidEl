using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using Npgsql;
namespace SkidEl.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/discounts")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private SkidElContext? _context;
        //public DiscountsController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public DiscountsController(SkidElContext skidElContext)
        {
            _context=skidElContext;
        }
        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<Discount>>> GetAll()
        {
            return await _context.Discounts.ToListAsync();
        }
        [HttpGet("{DiscountId}")]
        [ActionName("GetById")]
        public async Task<ActionResult<Discount>> GetById(int DiscountId)
        {
            Discount discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == DiscountId);
            if (discount == null)
                return NotFound();
            return new ObjectResult(discount);
        }
        [HttpGet("{DiscountSubcategory}")]
        [ActionName("GetBySubcategory")]
        public async Task<ActionResult<IEnumerable<Discount>>> GetBySubcategory(string DiscountSubcategory)
        {
            return await _context.Discounts.Where(x => x.Subcategory.Name == DiscountSubcategory).ToListAsync();
        }
        [HttpGet("{DiscountName}")]
        [ActionName("GetByName")]
        public async Task<ActionResult<IEnumerable<Discount>>> GetByName(string DiscountName)
        {
            string enteredName = DiscountName.ToLower();
            List<Discount> discounts = new List<Discount>();
            await foreach (var i in _context.Discounts)
            {
                string iName = i.Name.ToLower();
                if (iName.Contains(enteredName))
                    discounts.Add(i);
            }
            return new ObjectResult(discounts);
        }
        //GET: api/<DiscountsController>
        //[HttpGet]
        //public JsonResult Get()
        //{
        //    string query = @"Select * from Discounts";
        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("SkidElCon");
        //    NpgsqlDataReader myReader;
        //    using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }
        //    return new JsonResult(table);
        //}


    }
}
