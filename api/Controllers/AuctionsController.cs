using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using AutoMapper;
using api.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuctionsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Auctions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuctionDto>>> GetAuctions()
        {
            var auctions =  await _context.Auctions
                .AsNoTracking()
                .Select(a=> new AuctionDto { Id=a.Id, Name=a.Name,AuctionDate=a.AuctionDate })
                .ToListAsync();
            return Ok(auctions);
        }

        // GET: api/Auctions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDto>> GetAuction(long id)
        {
            var auction = await _context.Auctions
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new AuctionDto { Id = a.Id, Name = a.Name, AuctionDate = a.AuctionDate })
                .FirstOrDefaultAsync();

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(auction);
        }

        // PUT: api/Auctions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuction(long id, AuctionDtoUpdate dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var exists = await _context.Auctions.AnyAsync(a => a.Id == id);
            if (!exists)
                return NotFound();

            var updated = new Auction
            {
                Id = dto.Id,
                Name = dto.Name,
                AuctionDate = dto.AuctionDate
            };
            _context.Auctions.Update(updated);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Auctions
        [HttpPost]
        public async Task<ActionResult<AuctionDtoUpdate>> CreateAuction(AuctionDtoCreate dto)
        {
            var auction = new Auction
            {
                Name = dto.Name,
                AuctionDate = dto.AuctionDate
            };

            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();

            var resultDto = new AuctionDto { Name = auction.Name, AuctionDate = auction.AuctionDate, Id = auction.Id };

            return CreatedAtAction(nameof(GetAuction), new { id = resultDto.Id }, resultDto);
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(long id)
        {

            var exists = await _context.Auctions.AnyAsync(a => a.Id == id);
            if (!exists)
                return NotFound();

            var hasDependencies = await _context.InitialOffers.AnyAsync(io => io.AuctionId == id) ||
                await _context.TradeResults.AnyAsync(tr => tr.AuctionId == id) ||
                await _context.TradeProcesses.AnyAsync(tp => tp.AuctionId == id);
            if (hasDependencies) {
                return Conflict(new
                {
                    message = "Auction cannot be deleted because it has related data (offers, results, or processes)."
                });
            }

            _context.Auctions.Remove(new Auction { Id=id});
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
