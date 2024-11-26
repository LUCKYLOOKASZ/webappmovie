using lab9.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab9.Controllers;
[ApiController]
[Route("/api/companies")]
public class MovieApiController: ControllerBase
{
    private readonly MyDbContext _context;

    public MovieApiController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetFiltered(string fragment)
    {
        return Ok(
            _context.ProductionCompanies.Where(c=>c.CompanyName != null && c.CompanyName
                    .Contains(fragment))
                .AsNoTracking()
                .AsAsyncEnumerable()
            );
    }
}