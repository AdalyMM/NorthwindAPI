﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APINorthwind.Models;
using Microsoft.AspNetCore.Identity;

namespace APINorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public RegionsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
          if (_context.Regions == null)
          {
              return NotFound();
          }
            return await _context.Regions.ToListAsync();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
          if (_context.Regions == null)
          {
              return NotFound();
          }
            var region = await _context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/Regions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.RegionId)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Regions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
          if (_context.Regions == null)
          {
              return Problem("Entity set 'NorthwindContext.Regions'  is null.");
          }
            _context.Regions.Add(region);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegionExists(region.RegionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegion", new { id = region.RegionId }, region);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            using (var context = new NorthwindContext()) // Reemplaza YourDbContext con el nombre real de tu DbContext
            {
                var region = await context.Regions.FindAsync(id);
                if (region == null)
                {
                    return NotFound();
                }

                var territories = await context.Territories.Where(t => t.RegionId == id).ToListAsync();
                foreach (var territory in territories) {
                    string deleteOrderDetailsSql = $"SET FOREIGN_KEY_CHECKS=OFF; DELETE FROM territories WHERE TerritoryId = {territory.TerritoryId}; SET FOREIGN_KEY_CHECKS=ON;";
                    await _context.Database.ExecuteSqlRawAsync(deleteOrderDetailsSql);
                }

                context.Regions.Remove(region);
                await context.SaveChangesAsync();
            }

            return NoContent();
        }

        private bool RegionExists(int id)
        {
            return (_context.Regions?.Any(e => e.RegionId == id)).GetValueOrDefault();
        }
    }
}
