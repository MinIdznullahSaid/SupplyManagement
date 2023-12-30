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
public class VendorApprovalController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VendorApprovalController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendorApproval>>> GetVendorApprovals()
    {
        return await _context.VendorApprovals.ToListAsync();
    }

    [HttpGet("{guid}")]
    public async Task<ActionResult<VendorApproval>> GetVendorApproval(Guid guid)
    {
        var vendorApproval = await _context.VendorApprovals.FindAsync(guid);

        if (vendorApproval == null)
        {
            return NotFound();
        }

        return vendorApproval;
    }

    [HttpPost]
    public async Task<ActionResult<VendorApproval>> CreateVendorApproval(VendorApproval vendorApproval)
    {
        _context.VendorApprovals.Add(vendorApproval);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVendorApproval), new { id = vendorApproval.Guid }, vendorApproval);
    }

    [HttpPut("{guid}")]
    public async Task<IActionResult> UpdateVendorApproval(Guid guid, VendorApproval vendorApproval)
    {
        if (guid != vendorApproval.Guid)
        {
            return BadRequest();
        }

        _context.Entry(vendorApproval).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VendorApprovalExists(guid))
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
    public async Task<IActionResult> DeleteVendorApproval(Guid guid)
    {
        var vendorApproval = await _context.VendorApprovals.FindAsync(guid);
        if (vendorApproval == null)
        {
            return NotFound();
        }

        _context.VendorApprovals.Remove(vendorApproval);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VendorApprovalExists(Guid guid)
    {
        return _context.VendorApprovals.Any(e => e.Guid == guid);
    }
}
