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
    public class AeropuertosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Aeropuertos
        public IQueryable<Aeropuerto> GetCampos()
        {
            return db.Campos;
        }

        // GET: api/Aeropuertos/5
        [ResponseType(typeof(Aeropuerto))]
        public IHttpActionResult GetAeropuerto(long id)
        {
            Aeropuerto aeropuerto = db.Campos.Find(id);
            if (aeropuerto == null)
            {
                return NotFound();
            }

            return Ok(aeropuerto);
        }

        // PUT: api/Aeropuertos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAeropuerto(long id, Aeropuerto aeropuerto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aeropuerto.Id)
            {
                return BadRequest();
            }

            db.Entry(aeropuerto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeropuertoExists(id))
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

        // POST: api/Aeropuertos
        [ResponseType(typeof(Aeropuerto))]
        public IHttpActionResult PostAeropuerto(Aeropuerto aeropuerto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Campos.Add(aeropuerto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aeropuerto.Id }, aeropuerto);
        }

        // DELETE: api/Aeropuertos/5
        [ResponseType(typeof(Aeropuerto))]
        public IHttpActionResult DeleteAeropuerto(long id)
        {
            Aeropuerto aeropuerto = db.Campos.Find(id);
            if (aeropuerto == null)
            {
                return NotFound();
            }

            db.Campos.Remove(aeropuerto);
            db.SaveChanges();

            return Ok(aeropuerto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AeropuertoExists(long id)
        {
            return db.Campos.Count(e => e.Id == id) > 0;
        }
    }
}