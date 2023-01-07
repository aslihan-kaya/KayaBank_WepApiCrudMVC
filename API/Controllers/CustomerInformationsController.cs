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
    public class CustomerInformationsController : ApiController
    {
        private KayaBankEntities2 db = new KayaBankEntities2();

        // GET: api/CustomerInformations
        public IQueryable<CustomerInformation> GetCustomerInformations()
        {
            return db.CustomerInformations;
        }

        // GET: api/CustomerInformations/5
        [ResponseType(typeof(CustomerInformation))]
        public async Task<IHttpActionResult> GetCustomerInformation(int id)
        {
            CustomerInformation customerInformation = await db.CustomerInformations.FindAsync(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            return Ok(customerInformation);
        }

        // PUT: api/CustomerInformations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerInformation(int id, CustomerInformation customerInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerInformation.CustomerNumber)
            {
                return BadRequest();
            }

            db.Entry(customerInformation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerInformationExists(id))
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

        // POST: api/CustomerInformations
        [ResponseType(typeof(CustomerInformation))]
        public async Task<IHttpActionResult> PostCustomerInformation(CustomerInformation customerInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerInformations.Add(customerInformation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerInformation.CustomerNumber }, customerInformation);
        }

        // DELETE: api/CustomerInformations/5
        [ResponseType(typeof(CustomerInformation))]
        public async Task<IHttpActionResult> DeleteCustomerInformation(int id)
        {
            CustomerInformation customerInformation = await db.CustomerInformations.FindAsync(id);
            if (customerInformation == null)
            {
                return NotFound();
            }

            db.CustomerInformations.Remove(customerInformation);
            await db.SaveChangesAsync();

            return Ok(customerInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerInformationExists(int id)
        {
            return db.CustomerInformations.Count(e => e.CustomerNumber == id) > 0;
        }
    }
}