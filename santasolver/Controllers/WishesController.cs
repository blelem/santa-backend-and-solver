using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SantaSolver.Models;
using static System.Net.WebRequestMethods;

namespace SantaSolver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishesController : ControllerBase
    {
        private readonly SantaDbContext _dbContext;

        public WishesController (SantaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Wish>> Get()
        {
            return Ok(_dbContext.Whishes.Take(5000).ToList());
        }

       
    }
}
