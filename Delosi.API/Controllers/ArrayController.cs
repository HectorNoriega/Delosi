using Delosi.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Delosi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrayController : ControllerBase 
    {
        private IArrayApp _app;

        public ArrayController(IArrayApp app)
        {
            _app = app;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int[][]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RotateArray([FromBody] int[][] request)
        {
            try {
                var arrayResponse = _app.rotateArray(request);
                return Ok(arrayResponse); 
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest(); 
            }
        }
    }
}