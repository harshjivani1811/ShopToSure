using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practiceAPI4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practiceAPI4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    CategoryId = 1 ,
                    CategoryName = "Mobiles"
                },

                new Category
                {
                    CategoryId = 2 ,
                    CategoryName = "Fashion"
                },
                new Category
                {
                    CategoryId = 3 ,
                    CategoryName = "Travel"
                },
                new Category
                {
                    CategoryId = 4 ,
                    CategoryName = "Applinces"
                },
            };

            return Ok(categories);
        }




    }
}
