using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using SupplyManagement.Models;

[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VendorController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
    {
        return await _context.Vendors.ToListAsync();
    }

    [HttpGet("{guid}")]
    public async Task<ActionResult<Vendor>> GetVendor(Guid guid)
    {
        var vendor = await _context.Vendors.FindAsync(guid);

        if (vendor == null)
        {
            return NotFound();
        }

        return vendor;
    }

    [HttpPost]
    public async Task<ActionResult<Vendor>> CreateVendor(Vendor vendor)
    {
        _context.Vendors.Add(vendor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVendor), new { guid = vendor.Guid }, vendor);
    }

    [HttpPut("{guid}")]
    public async Task<IActionResult> UpdateVendor(Guid guid, Vendor vendor)
    {
        if (guid != vendor.Guid)
        {
            return BadRequest();
        }

        _context.Entry(vendor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendorExists(guid))
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
    public async Task<IActionResult> DeleteVendor(Guid guid)
    {
        var vendor = await _context.Vendors.FindAsync(guid);
        if (vendor == null)
        {
            return NotFound();
        }

        _context.Vendors.Remove(vendor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VendorExists(Guid guid)
    {
        return _context.Vendors.Any(e => e.Guid == guid);
    }
}
