using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silverkissen.Models;  

namespace silverkissen.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        private readonly SilverkissenContext _db;

        public ImageController(SilverkissenContext context)
        {
            _db = context;
        }

        /*
        *  Catltter iamges 
        *  reach from api/images/catlitters
        */
        [HttpGet("catlitters/{id}")]
        public async Task<ActionResult<Image>> GetCatLitterImages(int id)
        {
            var query = from i in _db.Images
                        join cli in _db.CatLitter_Image on i.Id equals cli.ImageId
                        where cli.CatLitterId == id
                        select i;

            var litterImages = await query.ToListAsync();

            if (litterImages != null)
            {
                return Ok(litterImages);
            }
            return NotFound();     
        }

        [HttpPost("catlitters/{catlitterid}")]
        public async Task<ActionResult<Image>> PostImageToLitter([FromBody] Image image, int catlitterid)
        {
            _db.Images.Add(image);
            await _db.SaveChangesAsync();

            var litter = await _db.CatLitters.FindAsync(catlitterid);
            litter.Images.Add(new CatLitter_Image(catlitterid, image.Id));
            await _db.SaveChangesAsync();

            return Ok(image);
        }

        [HttpPost("catlitters")]
        public async Task<ActionResult<Image>> PostImageToNewLitter([FromBody] Image image)
        {
            _db.Images.Add(image);
            await _db.SaveChangesAsync();

            var litterQuery = from litter in _db.CatLitters
                              select litter;
            var litterList = await litterQuery.ToListAsync();

            CatLitter latestAddedLitter = litterList[litterList.Count - 1];
            latestAddedLitter.Images.Add(new CatLitter_Image(latestAddedLitter.Id, image.Id));

            await _db.SaveChangesAsync();

            return Ok(image);
        }  

        [HttpDelete("catlitters/{id}")]
        public async Task<ActionResult<Image>> DeleteCatLitterImage(int id)
        {
            var ImageToDelete = await _db.Images.FindAsync(id); 
            if (ImageToDelete != null)
            {
                _db.Images.Remove(ImageToDelete);
                var query = from img in _db.CatLitter_Image
                            where img.ImageId == id
                            select img;
                CatLitter_Image cli = query.FirstOrDefault();
                _db.CatLitter_Image.Remove(cli);
                await _db.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        } 

        /*
         *  Cat iamges
         *  reach by api/images/catimages
         */
        [HttpGet("catimages/{id}")]
        public async Task<ActionResult<Image>> GetCatImages(int id)
        {
            var query = from i in _db.Images
                        join ci in _db.Cat_Image on i.Id equals ci.ImageId
                        where ci.CatId == id
                        select i;

            var litterImages = await query.ToListAsync();

            if (litterImages != null)
            {
                return Ok(litterImages);
            }
            return NotFound();
        }

        [HttpPost("catimages/{id}")]
        public async Task<ActionResult<Image>> PostImageToCat([FromBody] Image image, int id)
        {
            _db.Images.Add(image);
            await _db.SaveChangesAsync();

            var cat = await _db.Cats.FindAsync(id);
            cat.Images.Add(new Cat_Image(id, image.Id));
            await _db.SaveChangesAsync();

            return Ok(image);
        }

        [HttpPost("catimages")]
        public async Task<ActionResult<Image>> PostImageToNewCat([FromBody] Image image)
        {
            _db.Images.Add(image);
            await _db.SaveChangesAsync();

            var catQuery =      from cats in _db.Cats
                                select cats;
            var catList = await catQuery.ToListAsync();

            Cat latestAddedCat = catList[catList.Count - 1];
            latestAddedCat.Images.Add(new Cat_Image(latestAddedCat.Id, image.Id));

            await _db.SaveChangesAsync();

            return Ok(image);
        }

        [HttpDelete("catimages/{id}")]
        public async Task<ActionResult<Image>> DeleteCatImage(int id)
        {
            var ImageToDelete = await _db.Images.FindAsync(id);
            if (ImageToDelete != null)
            {
                _db.Images.Remove(ImageToDelete);
                var query = from img in _db.Cat_Image
                            where img.ImageId == id
                            select img;
                Cat_Image ci = query.FirstOrDefault();
                _db.Cat_Image.Remove(ci);
                await _db.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }
    }
}