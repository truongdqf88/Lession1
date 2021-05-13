using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        [HttpGet("aggregate")]
        public async Task<IActionResult> AggregateProduct()
        {
            return Ok("This is Aggregate Product Type");
        }
    }
}
