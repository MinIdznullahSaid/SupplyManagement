using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using SupplyManagement.Models;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompanyController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        return await _context.Companies.ToListAsync();
    }

    [HttpGet("{guid}")]
    public async Task<ActionResult<Company>> GetCompany(Guid guid)
    {
        var company = await _context.Companies.FindAsync(guid);

        if (company == null)
        {
            return NotFound();
        }

        return company;
    }

    [HttpPost]
    public async Task<ActionResult<Company>> CreateCompany(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompany), new { id = company.Guid }, company);
    }

    [HttpPut("{guid}")]
    public async Task<IActionResult> UpdateCompany(Guid guid, Company company)
    {
        if (guid != company.Guid)
        {
            return BadRequest();
        }

        _context.Entry(company).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CompanyExists(guid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{guid}")]
    public async Task<IActionResult> DeleteCompany(Guid guid)
    {
        var company = await _context.Companies.FindAsync(guid);
        if (company == null)
        {
            return NotFound();
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CompanyExists(Guid guid)
    {
        return _context.Companies.Any(e => e.Guid == guid);
    }

}
