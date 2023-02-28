using Microsoft.AspNetCore.Mvc;

namespace TBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SudokuController : ControllerBase
    {
        [HttpGet]
        public void Get(){
            var test = 2;
        }
    }
}
