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
    public class DebtInformationsController : ApiController
    {
        private KayaBankEntities2 db = new KayaBankEntities2();

        // GET: api/DebtInformations
        public IQueryable<DebtInformation> GetDebtInformations()
        {
            return db.DebtInformations;
        }

        // GET: api/DebtInformations/5
        [ResponseType(typeof(DebtInformation))]
        public async Task<IHttpActionResult> GetDebtInformation(int id)
        {
            DebtInformation debtInformation = await db.DebtInformations.FindAsync(id);
            if (debtInformation == null)
            {
                return NotFound();
            }

            return Ok(debtInformation);
        }

        // PUT: api/DebtInformations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDebtInformation(int id, DebtInformation debtInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != debtInformation.DebtNumber)
            {
                return BadRequest();
            }

            db.Entry(debtInformation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebtInformationExists(id))
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

        // POST: api/DebtInformations
        [ResponseType(typeof(DebtInformation))]
        public async Task<IHttpActionResult> PostDebtInformation(DebtInformation debtInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DebtInformations.Add(debtInformation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = debtInformation.DebtNumber }, debtInformation);
        }

        // DELETE: api/DebtInformations/5
        [ResponseType(typeof(DebtInformation))]
        public async Task<IHttpActionResult> DeleteDebtInformation(int id)
        {
            DebtInformation debtInformation = await db.DebtInformations.FindAsync(id);
            if (debtInformation == null)
            {
                return NotFound();
            }

            db.DebtInformations.Remove(debtInformation);
            await db.SaveChangesAsync();

            return Ok(debtInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DebtInformationExists(int id)
        {
            return db.DebtInformations.Count(e => e.DebtNumber == id) > 0;
        }
    }
}