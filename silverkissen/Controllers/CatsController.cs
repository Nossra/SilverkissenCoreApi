using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silverkissen.Models;

namespace silverkissen.Controllers
{  
    [Route("api/cats")]
    [ApiController]
    [Authorize]
    public class CatsController : ControllerBase
    {
        private readonly SilverkissenContext _db;

        public CatsController(SilverkissenContext context)
        {
            _db = context;
        }
   
        // GET api/cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetAllCats()
        {
            return await _db.Cats.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            var cat = await _db.Cats.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            } else
            {
                return cat;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat([FromBody] Cat cat)
        {
            _db.Cats.Add(cat);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllCats), new { id = cat.Id }, cat);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Cat>> Put(int id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }
            _db.Entry(cat).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Cat>> Patch(int id, [FromBody] JsonPatchDocument<Cat> cat)
        {
            Cat CatToUpdate = await _db.Cats.FindAsync(id);
            if (cat != null)
            {
                cat.ApplyTo(CatToUpdate, ModelState);
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                } else
                {
                    return new ObjectResult(CatToUpdate);
                }
            } else
            {
                return BadRequest();
            }
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cat>> Delete(int id)
        {
            Cat CatToDelete = await _db.Cats.FindAsync(id);

            if (CatToDelete == null)
            {
                return NotFound();
            }

            _db.Cats.Remove(CatToDelete);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}