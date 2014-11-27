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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using odatav4webapi.Models;

namespace odatav4webapi.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using odatav4webapi.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Kupac>("Okupacs");
    builder.EntitySet<Grad>("Grads"); 
    builder.EntitySet<Racun>("Racuns"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OkupacsController : ODataController
    {
        private AWEntities db = new AWEntities();

        // GET: odata/Okupacs
        [EnableQuery]
        public IQueryable<Kupac> GetOkupacs()
        {
            return db.Kupacs;
        }

        // GET: odata/Okupacs(5)
        [EnableQuery]
        public SingleResult<Kupac> GetKupac([FromODataUri] int key)
        {
            return SingleResult.Create(db.Kupacs.Where(kupac => kupac.IDKupac == key));
        }

        // PUT: odata/Okupacs(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Kupac> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kupac kupac = await db.Kupacs.FindAsync(key);
            if (kupac == null)
            {
                return NotFound();
            }

            patch.Put(kupac);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(kupac);
        }

        // POST: odata/Okupacs
        public async Task<IHttpActionResult> Post(Kupac kupac)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kupacs.Add(kupac);
            await db.SaveChangesAsync();

            return Created(kupac);
        }

        // PATCH: odata/Okupacs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Kupac> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kupac kupac = await db.Kupacs.FindAsync(key);
            if (kupac == null)
            {
                return NotFound();
            }

            patch.Patch(kupac);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KupacExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(kupac);
        }

        // DELETE: odata/Okupacs(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Kupac kupac = await db.Kupacs.FindAsync(key);
            if (kupac == null)
            {
                return NotFound();
            }

            db.Kupacs.Remove(kupac);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Okupacs(5)/Grad
        [EnableQuery]
        public SingleResult<Grad> GetGrad([FromODataUri] int key)
        {
            return SingleResult.Create(db.Kupacs.Where(m => m.IDKupac == key).Select(m => m.Grad));
        }

        // GET: odata/Okupacs(5)/Racuns
        [EnableQuery]
        public IQueryable<Racun> GetRacuns([FromODataUri] int key)
        {
            return db.Kupacs.Where(m => m.IDKupac == key).SelectMany(m => m.Racuns);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KupacExists(int key)
        {
            return db.Kupacs.Count(e => e.IDKupac == key) > 0;
        }
    }
}
