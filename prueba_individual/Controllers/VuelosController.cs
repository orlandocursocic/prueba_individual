using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using prueba_individual.Models;

namespace prueba_individual.Controllers
{
    public class VuelosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Vuelos
        public IQueryable<Vuelo> GetPerfiles()
        {
            return db.Perfiles;
        }

        // GET: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult GetVuelo(long id)
        {
            Vuelo vuelo = db.Perfiles.Find(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            return Ok(vuelo);
        }

        // PUT: api/Vuelos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVuelo(long id, Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vuelo.Id)
            {
                return BadRequest();
            }

            db.Entry(vuelo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(id))
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

        // POST: api/Vuelos
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult PostVuelo(Vuelo vuelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfiles.Add(vuelo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vuelo.Id }, vuelo);
        }

        // DELETE: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult DeleteVuelo(long id)
        {
            Vuelo vuelo = db.Perfiles.Find(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            db.Perfiles.Remove(vuelo);
            db.SaveChanges();

            return Ok(vuelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VueloExists(long id)
        {
            return db.Perfiles.Count(e => e.Id == id) > 0;
        }
    }
}