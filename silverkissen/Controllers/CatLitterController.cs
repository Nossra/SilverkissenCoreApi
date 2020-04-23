using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using silverkissen.Models;
using silverkissen.Models.Dtos;
using silverkissen.Models.ViewModels;
using silverkissen.Utilities;

namespace silverkissen.Controllers
{
    [Route("api/catlitters")]
    [ApiController]
    public class CatLitterController : ControllerBase
    {

        private readonly SilverkissenContext _db; 

        public CatLitterController(SilverkissenContext context)
        {
            _db = context; 
        } 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatLitter>>> GetAllCatLitters()
        {
            var returnList = new List<CatLitterViewModel>();
            var litters = await _db.CatLitters.ToListAsync();

            foreach (CatLitter litter in litters)
            {
                var LitterViewModel = new CatLitterViewModel();
                var parentsQuery = from cats in _db.Cats
                                   join parents in _db.CatLitter_Parent on cats.Id equals parents.CatId
                                   where parents.CatLitterId == litter.Id
                                   select cats;

                var imageQuery = from images in _db.Images
                                 join cli in _db.CatLitter_Image on images.Id equals cli.ImageId
                                 where cli.CatLitterId == litter.Id && images.DisplayPicture == true
                                 select images;

                LitterViewModel.Parents = await parentsQuery.ToListAsync();
                LitterViewModel.Images = await imageQuery.Take(1).ToListAsync();
                LitterViewModel.Id = litter.Id;
                LitterViewModel.Notes = litter.Notes;
                LitterViewModel.Pedigree = litter.Pedigree;
                LitterViewModel.PedigreeName = litter.PedigreeName;
                LitterViewModel.ReadyDate = litter.ReadyDate;
                LitterViewModel.Status = litter.Status;
                LitterViewModel.SVERAK = litter.SVERAK;
                LitterViewModel.Vaccinated = litter.Vaccinated;
                LitterViewModel.Chipped = litter.Chipped;
                LitterViewModel.BirthDate = litter.BirthDate;
                LitterViewModel.AmountOfKids = litter.AmountOfKids;
                returnList.Add(LitterViewModel);
            } 

            if (returnList == null)
            {
                return NotFound();
            }
            return Ok(returnList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CatLitter>> GetCatLitter(int id)
        {
            var fromDb = await _db.CatLitters.FindAsync(id);

            if (fromDb == null)
            {
                return NotFound();
            }
            else
            {
                var litterViewModel = new CatLitterViewModel();
                litterViewModel = await GetLitterData(fromDb);

                if (litterViewModel == null)
                {
                    return NotFound();
                } 
                return Ok(litterViewModel);
            }
        }

        [HttpGet("active")]
        public async Task<ActionResult<CatLitter>> GetActiveLitters()
        {
            var returnList = new List<CatLitterViewModel>();
            var litters = from litter in _db.CatLitters
                        where litter.Status == Litter.LitterStatus.ACTIVE
                        select litter;

            foreach (CatLitter litter in litters)
            {
                var LitterViewModel = await GetLitterData(litter);

                returnList.Add(LitterViewModel);
            }

            if (returnList == null)
            {
                return NotFound();
            }
            return Ok(returnList);
        }



        [HttpGet("archived")]
        public async Task<ActionResult<CatLitter>> GetArchivedLitters()
        {
            var query = from litter in _db.CatLitters
                        where litter.Status == Litter.LitterStatus.ARCHIVED
                        select litter;

            var litters = await query.ToListAsync();

            var returnList = new List<CatLitterViewModel>();

            foreach (CatLitter litter in litters)
            {
                var LitterViewModel = await GetLitterData(litter);

                returnList.Add(LitterViewModel);
            }

            if (returnList == null)
            {
                return NotFound();
            }

            return Ok(returnList);
        }

        [HttpGet("earlier")]
        public async Task<ActionResult<CatLitter>> GetEarlierLitters()
        {
            var query = from litter in _db.CatLitters
                        where litter.Status == Litter.LitterStatus.EARLIER_LITTER
                        select litter;

            var litters = await query.ToListAsync();

            var returnList = new List<CatLitterViewModel>();

            foreach (CatLitter litter in litters)
            {
                var LitterViewModel = await GetLitterData(litter);

                returnList.Add(LitterViewModel);
            }

            if (returnList == null)
            {
                return NotFound();
            }

            return Ok(returnList);
        }

        public async Task<CatLitterViewModel> GetLitterData(CatLitter litter)
        {
            var LitterViewModel = new CatLitterViewModel();
            var parentsQuery = from cats in _db.Cats
                               join parents in _db.CatLitter_Parent on cats.Id equals parents.CatId
                               where parents.CatLitterId == litter.Id
                               select cats;

            var imageQuery = from images in _db.Images
                             join cli in _db.CatLitter_Image on images.Id equals cli.ImageId
                             where cli.CatLitterId == litter.Id && images.DisplayPicture == true
                             select images;

            var kittensQuery = from cats in _db.Cats
                               where cats.CatLitter.Id == litter.Id
                               select cats;

            LitterViewModel.Kittens = await kittensQuery.ToListAsync();
            LitterViewModel.Parents = await parentsQuery.ToListAsync();
            LitterViewModel.Images = await imageQuery.ToListAsync();
            LitterViewModel.Id = litter.Id;
            LitterViewModel.Notes = litter.Notes;
            LitterViewModel.Pedigree = litter.Pedigree;
            LitterViewModel.PedigreeName = litter.PedigreeName;
            LitterViewModel.ReadyDate = litter.ReadyDate;
            LitterViewModel.Status = litter.Status;
            LitterViewModel.SVERAK = litter.SVERAK;
            LitterViewModel.Vaccinated = litter.Vaccinated;
            LitterViewModel.Chipped = litter.Chipped;
            LitterViewModel.BirthDate = litter.BirthDate;
            LitterViewModel.AmountOfKids = litter.AmountOfKids;

            return LitterViewModel;
        }

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<CatLitter>> PostCatLitter([FromBody] CatLitterDto Litter)
        {
            try
            {
                foreach (Image i in Litter.Images)
                {
                    _db.Images.Add(i);
                    await _db.SaveChangesAsync();
                }

                CatLitter newLitter = Litter;
                for (int i = 0; i < Litter.Images.Count; i++)
                {
                    newLitter.Images.Add(new CatLitter_Image(Litter.Id, Litter.Images[i].Id));
                }
                

                for (int i = 0; i < Litter.AmountOfKids; i++)
                {
                    newLitter.Kittens.Add(new Cat(Litter.BirthDate));
                }
                int thirteenWeeksInDays = 91;
                newLitter.ReadyDate = Litter.BirthDate.AddDays(thirteenWeeksInDays);
                  
                _db.CatLitters.Add(newLitter);

                await _db.SaveChangesAsync();
                return Ok(newLitter);
            } catch (Exception e)
            {
                return BadRequest(e);
            } 
        }

        // PUT: api/CatLitter/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<ActionResult<Cat>> Put([FromBody] CatLitter litter)
        {
           try
            {
                _db.Entry(litter).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return NoContent();
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
         
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<ActionResult<CatLitter>> Delete(int id)
        {
            CatLitter Litter = await _db.CatLitters.FindAsync(id);

            if (Litter == null)
            {
                return NotFound();
            } else
            {

                var kittensQuery = from cats in _db.Cats
                                   where cats.CatLitter.Id == id
                                   select cats;

                var kittens = await kittensQuery.ToListAsync();


                _db.CatLitters.Remove(Litter);
                await _db.SaveChangesAsync();

                return NoContent();
            }


        }

        //[HttpPatch("images")]
        //public async Task<ActionResult<CatLitter>> AddImageToCatLitter([FromBody] Image image)
        //{
        //    _db.Images.Add(image);

        //    var litterQuery = from litter in _db.CatLitters
        //                      select litter;

        //    List<CatLitter> litterList = await litterQuery.ToListAsync();
        //    CatLitter latestAddedLitter = litterList[litterList.Count - 1];

        //    _db.
            
        //}
    }
}
