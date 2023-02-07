using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Npgsql;
namespace SkidEl.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/discounts")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SkidElContext _context;
        //public DiscountsController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        public DiscountsController(SkidElContext skidElContext)
        {
            _context=skidElContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> Get()
        {
            return await _context.Discounts.ToListAsync();
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
