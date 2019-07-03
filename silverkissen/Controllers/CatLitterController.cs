using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silverkissen.Models;

namespace silverkissen.Controllers
{
    [Route("api/catlitters")]
    [ApiController]
    [Authorize]
    public class CatLitterController : ControllerBase
    {

        private readonly SilverkissenContext _db;

        public CatLitterController(SilverkissenContext context)
        {
            _db = context;
        }
        // GET: api/CatLitter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatLitter>>> GetAllCatLitters()
        {
            return await _db.CatLitters.ToListAsync();
        }

        // GET: api/CatLitter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatLitter>> GetCatLitter(int id)
        {
            var litter = await _db.CatLitters.FindAsync(id);
            if (litter == null)
            {
                return NotFound();
            } else
            {
                return litter;
            }
        }

        [HttpPost]
        public async Task<ActionResult<CatLitter>> PostCat([FromBody] CatLitter Litter)
        {
            _db.CatLitters.Add(Litter);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllCatLitters), new { id = Litter.Id }, Litter);
        }

        // PUT: api/CatLitter/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Cat>> Put(int id, CatLitter litter)
        {
            if (id != litter.Id)
            {
                return BadRequest();
            }
            _db.Entry(litter).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }
         
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatLitter>> Delete(int id)
        {
            CatLitter Litter = await _db.CatLitters.FindAsync(id);

            if (Litter == null)
            {
                return NotFound();
            } else
            {
                _db.CatLitters.Remove(Litter);
                await _db.SaveChangesAsync();

                return NoContent();
            }


        }
    }
}
