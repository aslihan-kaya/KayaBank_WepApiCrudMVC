using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class BrachInformationsController : ApiController
    {
        private KayaBankEntities2 db = new KayaBankEntities2();

        // GET: api/BrachInformations
        public IQueryable<BrachInformation> GetBrachInformations()
        {
            return db.BrachInformations;
        }

        // GET: api/BrachInformations/5
        [ResponseType(typeof(BrachInformation))]
        public async Task<IHttpActionResult> GetBrachInformation(int id)
        {
            BrachInformation brachInformation = await db.BrachInformations.FindAsync(id);
            if (brachInformation == null)
            {
                return NotFound();
            }

            return Ok(brachInformation);
        }

        // PUT: api/BrachInformations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBrachInformation(int id, BrachInformation brachInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brachInformation.BranchNo)
            {
                return BadRequest();
            }

            db.Entry(brachInformation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrachInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BrachInformations
        [ResponseType(typeof(BrachInformation))]
        public async Task<IHttpActionResult> PostBrachInformation(BrachInformation brachInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BrachInformations.Add(brachInformation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = brachInformation.BranchNo }, brachInformation);
        }

        // DELETE: api/BrachInformations/5
        [ResponseType(typeof(BrachInformation))]
        public async Task<IHttpActionResult> DeleteBrachInformation(int id)
        {
            BrachInformation brachInformation = await db.BrachInformations.FindAsync(id);
            if (brachInformation == null)
            {
                return NotFound();
            }

            db.BrachInformations.Remove(brachInformation);
            await db.SaveChangesAsync();

            return Ok(brachInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrachInformationExists(int id)
        {
            return db.BrachInformations.Count(e => e.BranchNo == id) > 0;
        }
    }
}