using FluentApiTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace FluentApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FluentTestController : ControllerBase
    {

        private readonly DatabaseContext _context;

        public FluentTestController(DatabaseContext context)
        {
            context = _context;
        }

        [HttpGet]
        [Route("NewDatabase")]
        public void NewDatabase()
        {


            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("GetBooks")]
        public void GetBooks()
        {

        }

        [HttpGet]
        [Route("GetAuthors")]
        public void GetAuthors()
        {

        }
    }
}