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
using odatav4webapi.Models;

namespace odatav4webapi.Controllers
{
    public class KupacsController : ApiController
    {
        private AWEntities db = new AWEntities();

        // GET: api/Kupacs
        public IQueryable<Kupac> GetKupacs()
        {
            return db.Kupacs;
        }

        // GET: api/Kupacs/5
        [ResponseType(typeof(Kupac))]
        public async Task<IHttpActionResult> GetKupac(int id)
        {
            Kupac kupac = await db.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return NotFound();
            }

            return Ok(kupac);
        }

        // PUT: api/Kupacs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKupac(int id, Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kupac.IDKupac)
            {
                return BadRequest();
            }

            db.Entry(kupac).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(id))
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

        // POST: api/Kupacs
        [ResponseType(typeof(Kupac))]
        public async Task<IHttpActionResult> PostKupac(Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kupacs.Add(kupac);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kupac.IDKupac }, kupac);
        }

        // DELETE: api/Kupacs/5
        [ResponseType(typeof(Kupac))]
        public async Task<IHttpActionResult> DeleteKupac(int id)
        {
            Kupac kupac = await db.Kupacs.FindAsync(id);
            if (kupac == null)
            {
                return NotFound();
            }

            db.Kupacs.Remove(kupac);
            await db.SaveChangesAsync();

            return Ok(kupac);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KupacExists(int id)
        {
            return db.Kupacs.Count(e => e.IDKupac == id) > 0;
        }
    }
}