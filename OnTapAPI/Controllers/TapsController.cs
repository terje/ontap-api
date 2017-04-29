using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnTapAPI.Controllers
{
    [Route("api/[controller]")]
    public class TapsController : Controller
    {
		[HttpGet] // GET api/values
		public IEnumerable<string> Get()
		{
			return new string[] { "tap1", "tap2" };
		}
    }
}
