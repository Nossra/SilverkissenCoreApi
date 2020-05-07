using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silverkissen.Models;
using System.Linq;
using silverkissen.Models.ViewModels;
using silverkissen.Models.Dtos;

namespace silverkissen.Controllers
{  
    [Route("api/cats")]
    [ApiController] 
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

        [HttpGet("parents")]
        public async Task<ActionResult<Cat>> GetParents()
        {
            var query = from cat in _db.Cats 
                        where cat.Parent == true
                        select cat;

            var result = await query.ToListAsync();
             
            if (result == null)
            {
                return NotFound();
            }

            var returnList = new List<CatViewModel>();
            foreach (Cat cat in result)
            {
                CatViewModel catViewModel = new CatViewModel();

                var imageQuery = from images in _db.Images
                                 join ci in _db.Cat_Image on images.Id equals ci.ImageId
                                 where ci.CatId == cat.Id && images.DisplayPicture == true
                                 select images;

                catViewModel.Images = await imageQuery.ToListAsync();
                catViewModel.Id = cat.Id;
                catViewModel.Name = cat.Name;
                catViewModel.Notes = cat.Notes;
                catViewModel.Parent = cat.Parent;
                catViewModel.Pedigree = cat.Pedigree;
                catViewModel.Sex = cat.Sex;
                catViewModel.Vaccinated = cat.Vaccinated;
                catViewModel.Age = cat.Age;
                catViewModel.BirthDate = cat.BirthDate;
                catViewModel.Breed = cat.Breed;
                catViewModel.CatLitter = cat.CatLitter;
                catViewModel.Chipped = cat.Chipped;
                catViewModel.Color = cat.Color;

                returnList.Add(catViewModel);
            } 

            return Ok(returnList);
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
                var catViewModel = new CatViewModel
                {
                    Id = cat.Id,
                    BirthDate = cat.BirthDate,
                    Notes = cat.Notes,
                    Age = cat.Age,
                    Breed = cat.Breed,
                    Color = cat.Color,
                    Name = cat.Name,
                    Sex = cat.Sex,
                    Parent = cat.Parent,
                    Pedigree = cat.Pedigree,
                    Chipped = cat.Chipped,
                    Vaccinated = cat.Vaccinated,
                    CatLitter = cat.CatLitter
                };

                var imageQuery = from images in _db.Images
                                 join ci in _db.Cat_Image on images.Id equals ci.ImageId
                                 where ci.CatId == id
                                 select images;
                catViewModel.Images = await imageQuery.ToListAsync();
                //List<Image> imgs = await imageQuery.ToListAsync();

                //foreach (Image img in imgs)
                //{
                //    img.Value = img.DecompressImage(img.Value);
                //}
                //catViewModel.Images = imgs;

                return Ok(catViewModel);
            }
        }

        // POST api/values
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<Cat>> PostCat([FromBody] CatDto cat)
        { 
            try
            {
                foreach (Image i in cat.Images) 
                { 
                    _db.Images.Add(i);
                    await _db.SaveChangesAsync();
                }

                Cat newCat = cat;
                for (int i = 0; i < cat.Images.Count; i++)
                {
                    newCat.Images.Add(new Cat_Image(cat.Id, cat.Images[i].Id));
                }

                _db.Cats.Add(newCat);
                await _db.SaveChangesAsync();
                return Ok(newCat);
            } catch (Exception e) {
                return BadRequest(e);
            }

            //return CreatedAtAction(nameof(GetAllCats), new { id = cat.Id }, cat);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //[Authorize]
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<ActionResult<Cat>> Delete(int id)
        {
            Cat CatToDelete = await _db.Cats.FindAsync(id);

            if (CatToDelete == null)
            {
                return NotFound();
            }

            if (CatToDelete.Parent == true)
            {
                var litter_parentsQuery = from p in _db.CatLitter_Parent
                                          where p.CatId == id
                                          select p;
                var litter_parents = await litter_parentsQuery.ToListAsync();

                foreach (CatLitter_Parent p in litter_parents)
                {
                    _db.CatLitter_Parent.Remove(p);
                    await _db.SaveChangesAsync();
                }
            }

            _db.Cats.Remove(CatToDelete);
            await _db.SaveChangesAsync();

            return Ok(CatToDelete);
        }
    }
}