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

namespace api.Controllers
{
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
            var actions =  await _context.Auctions.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<AuctionDto>>(actions));
        }

        // GET: api/Auctions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuctionDto>> GetAuction(long id)
        {
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuctionDto>(auction));
        }

        // PUT: api/Auctions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuction(long id, AuctionDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
                return NotFound();

            _mapper.Map(dto, auction);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuctionExists(id))
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

        // POST: api/Auctions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuctionDto>> CreateAuction(AuctionDto dto)
        {
            var auction = _mapper.Map<Auction>(dto);

            _context.Auctions.Add(auction);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<AuctionDto>(auction);

            return CreatedAtAction(nameof(GetAuction), new { id = resultDto.Id }, resultDto);
        }

        // DELETE: api/Auctions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuction(long id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }

            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuctionExists(long id)
        {
            return _context.Auctions.Any(e => e.Id == id);
        }
    }
}
