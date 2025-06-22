using Microsoft.AspNetCore.Mvc;
using VlammendVarkenBackend.Data;

namespace VlammendVarkenBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("check")]
        public IActionResult CheckDatabaseConnection()
        {
            try
            {
                // Probeer een simpele query
                var aantalTafels = _context.Tafels.Count();
                return Ok($"Verbinding succesvol. Aantal tafels: {aantalTafels}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Databasefout: {ex.Message}");
            }
        }
    }
}