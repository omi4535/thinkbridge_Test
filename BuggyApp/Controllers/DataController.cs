using BuggyApp.Model;
using BuggyApp.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuggyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly IInvoiceRepository _repo;

        public DataController(IInvoiceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetData()
        {
            Invoice result = _repo.GetInvoiceById(0);
            if (result != null && result.Items.Count > 0) // will throw NullReferenceException
            {
                return Ok(result);
            }
            return BadRequest("No data");
        }

    }
}
