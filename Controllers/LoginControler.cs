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
    public class LoginController : ControllerBase
    {
       
         private readonly ACE42023Context db;

        public LoginController(ACE42023Context _db)
        {
            db = _db;
        }



        [HttpGet]
        [Route("LoginAsBuyer/id={id:int}&password={pass}")]
         public   ActionResult LoginBuyer(int id,string pass)
        {
                   
                     var result=(from i in db.BrijeshBuyers
                      where i.BuyerId==id && i.BuyerPassword == pass
                      select i).SingleOrDefault();
                 
             if(result!=null)
            {   
                return Ok(result);
            }
            else
            {
                return NotFound();
            }    
                    
        }

        [HttpGet]
        [Route("LoginAsSeller/id={id:int}&password={pass}")]
         public   ActionResult LoginSeller(int id,string pass)
        {
            var result=(from i in db.BrijeshSellers 
                      where i.SellerId==id && i.SellerPassword == pass
                      select i).SingleOrDefault();
            
            if(result!=null)

            {   
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        
        }

       [HttpPost]
       [Route("RegisterAsBuyer")]
        public async Task<ActionResult<BrijeshBuyer>> PostBrijeshBuyer(BrijeshBuyer brijeshBuyer)
        {
            db.BrijeshBuyers.Add(brijeshBuyer);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BrijeshBuyerExists(brijeshBuyer.BuyerId))
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

        private bool BrijeshBuyerExists(int id)
        {
            return db.BrijeshBuyers.Any(e => e.BuyerId == id);
        }


        [HttpPost]
        [Route("RegisterAsSeller")]
        public async Task<ActionResult<BrijeshSeller>> PostBrijeshSeller(BrijeshSeller brijeshSeller)
        {
            db.BrijeshSellers.Add(brijeshSeller);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BrijeshSellerExists(brijeshSeller.SellerId))
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

        private bool BrijeshSellerExists(int id)
        {
            return db.BrijeshSellers.Any(e => e.SellerId == id);
        }
        


    }
}
