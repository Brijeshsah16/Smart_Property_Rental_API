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
    public class BuyerController : ControllerBase
    {
        private readonly ACE42023Context db;

        public BuyerController(ACE42023Context _db)
        {
            db = _db;
        }

        // GET: api/Buyer
        [HttpGet]
        [Route("ShowYourBookings/id={id:int}")]
         public  async Task<IActionResult> ShowBookings(int id)
        {
            var result= await db.BrijeshTrans.Where(x => x.BuyertId==id).Select(x=>x).ToListAsync();
            return Ok(db.BrijeshTrans);
        }

        [HttpGet]
        [Route("GetBookingDetails/booking_id={id:int}")]
        public async Task<IActionResult> GetBookingDetails(int id)
        {
            var result= await db.BrijeshTrans.Where(x => x.TransId==id).FirstOrDefaultAsync();
            return Ok(result);
        }

        [HttpPut]
        [Route("MakeChangesInBookings/booking_id={id:int}")]
        public async Task<IActionResult> MakeChangesInBookings(int id,BrijeshTran b)
        {
            if(id!=b.TransId) return BadRequest();
             

              db.BrijeshTrans.Update(b);
              await db.SaveChangesAsync();
            return Ok(b);
        }

        [HttpDelete]
        [Route("DeleteBookings/id={id:int}")]
        public async Task<IActionResult> DeleteBookings(int id)
        {
            if(id==null) return BadRequest();

                BrijeshTran p= await db.BrijeshTrans.FindAsync(id);

                if(p!=null){
                     db.BrijeshTrans.Remove(p);
                    await db.SaveChangesAsync();
                    
                }
                else {
                    return NotFound();
                }

                return Ok();     
        }

        [HttpPost]
        [Route("AddBookings/Buyer_id={id:int}")]
        public async Task<IActionResult> MakeBooking(int id,BrijeshTran b)
        {
            if(b.BuyertId!= id) return BadRequest();
            
            db.BrijeshTrans.Add(b);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingExists(b.TransId))
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

         private bool BookingExists(int id)
        {
            return db.BrijeshTrans.Any(e => e.TransId == id);
        }

        [HttpGet]
        [Route("Search/Tran_id={Tid:int}")]
        public async Task<IActionResult> SearchYourBooking(int Tid)
       {
          
        var result=await db.BrijeshTrans.Where(x=>x.TransId==Tid).Select(x=>x).ToListAsync();
        return Ok(result);

     }
       [HttpGet]
        [Route("getProperty")]
        public async Task<ActionResult<List<BrijeshProperty>>> SearchProperty()
       {
          
        var result=await db.BrijeshProperties.ToListAsync();
        return Ok(result);

     } 










   /*

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrijeshBuyer>>> GetBrijeshBuyers()
        {
            return await _context.BrijeshBuyers.ToListAsync();
        }

        // GET: api/Buyer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrijeshBuyer>> GetBrijeshBuyer(int id)
        {
            var brijeshBuyer = await _context.BrijeshBuyers.FindAsync(id);

            if (brijeshBuyer == null)
            {
                return NotFound();
            }

            return brijeshBuyer;
        }

        // PUT: api/Buyer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrijeshBuyer(int id, BrijeshBuyer brijeshBuyer)
        {
            if (id != brijeshBuyer.BuyerId)
            {
                return BadRequest();
            }

            _context.Entry(brijeshBuyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrijeshBuyerExists(id))
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

        // POST: api/Buyer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BrijeshBuyer>> PostBrijeshBuyer(BrijeshBuyer brijeshBuyer)
        {
            _context.BrijeshBuyers.Add(brijeshBuyer);
            try
            {
                await _context.SaveChangesAsync();
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

            return CreatedAtAction("GetBrijeshBuyer", new { id = brijeshBuyer.BuyerId }, brijeshBuyer);
        }

        // DELETE: api/Buyer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrijeshBuyer(int id)
        {
            var brijeshBuyer = await _context.BrijeshBuyers.FindAsync(id);
            if (brijeshBuyer == null)
            {
                return NotFound();
            }

            _context.BrijeshBuyers.Remove(brijeshBuyer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrijeshBuyerExists(int id)
        {
            return _context.BrijeshBuyers.Any(e => e.BuyerId == id);
        }
        */
    }
}
