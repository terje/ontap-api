using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnTapAPI.Repository;
using OnTapAPI.Models;

namespace OnTapAPI.Controllers
{
    [Route("api/[controller]")]
    public class TapsController : Controller
    {
        private readonly TapRepository tapRepository;

        public TapsController(IConfiguration configuration)
        {
            tapRepository = new TapRepository(configuration);
        }

		// GET api/taps
		[HttpGet]
		public IEnumerable<Tap> Get()
		{
            return tapRepository.GetAll();
			//return new string[] { "tap1", "tap2", "tap3" };
		}

		// GET api/taps/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
            return $"Tap: {id}";
		}

		// POST api/taps
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/taps/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/taps/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
    }
}
