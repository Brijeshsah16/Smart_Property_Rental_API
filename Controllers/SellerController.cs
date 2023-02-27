using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using propertyapi.Models;

namespace propertyapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ACE42023Context db;

        public SellerController(ACE42023Context _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("showProperties/seller_id={id:int}")]
         public async Task<ActionResult<List<BrijeshProperty>>> ShowProperties(int id)
        {
            var result=db.BrijeshProperties.Where(x => x.SellerpId==id).Select(x=>x).ToList();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddProperty/seller_id={id:int}")]

        public async Task<ActionResult> AddProperty(int id,BrijeshProperty p)
        {

            if(p.SellerpId!= id) return BadRequest();
            
            db.BrijeshProperties.Add(p);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropertyExists(p.PropertyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

         private bool PropertyExists(int id)
        {
            return db.BrijeshProperties.Any(e => e.PropertyId == id);
        }

        [HttpPut]
        [Route("EditProperty/prop_id={id:int}")]
        public async Task<IActionResult> EditProperty(int id, BrijeshProperty p)
        {
            if(id!=p.PropertyId) return BadRequest();
             

            db.BrijeshProperties.Update(p);
              await db.SaveChangesAsync();
            return Ok(p);
        }

        [Route("DeleteYourProperty/prop_id={id:int}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProperty(int? id)
        {
                if(id==null) return BadRequest();

                BrijeshProperty p= await db.BrijeshProperties.FindAsync(id);

                if(p!=null){
                     db.BrijeshProperties.Remove(p);
                    await db.SaveChangesAsync();
                    
                }
                else {
                    return NotFound();
                }

                return Ok();       

        }

         [HttpGet]
       [Route("Details/prop_id={id:int}")]
        public  async Task<IActionResult> GetEmployeeById(int id)
        {
            BrijeshProperty p= await db.BrijeshProperties.FindAsync(id);

            if(p!=null) return Ok(p);
            else return NotFound();
        }

        [HttpGet]
        [Route("Search/keyword={keyword}&sellerId={sId}")]
        public async Task<ActionResult<List<BrijeshProperty>>> SearchYourProp(string keyword,int sId)
       {
          
        var result=await db.BrijeshProperties.Where(x=>x.PName.Contains(keyword)).Select(x=>x).ToListAsync();
        result= result.Where(x=>x.SellerpId==sId).Select(x=>x).ToList();
        return Ok(result);

     }

        }

        
    }

