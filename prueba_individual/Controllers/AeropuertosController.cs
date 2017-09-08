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
using prueba_individual.Services;
using System.Web.Http.Cors;
using prueba_individual.Exceptions;

namespace prueba_individual.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class AeropuertosController : ApiController
    {
        private IAeropuertosService aeropuertosService;

        public AeropuertosController(IAeropuertosService aeropuertosService)
        {
            this.aeropuertosService = aeropuertosService;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Aeropuertos
        public IQueryable<Aeropuerto> GetCampos()
        {
            return aeropuertosService.ReadAll();
        }

        // GET: api/Aeropuertos/5
        [ResponseType(typeof(Aeropuerto))]
        public IHttpActionResult GetAeropuerto(long id)
        {
            Aeropuerto aeropuerto = aeropuertosService.Read(id);
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

            try
            {
                aeropuertosService.Update(aeropuerto);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
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

            aeropuerto = aeropuertosService.Create(aeropuerto);

            return CreatedAtRoute("DefaultApi", new { id = aeropuerto.Id }, aeropuerto);
        }

        // DELETE: api/Aeropuertos/5
        [ResponseType(typeof(Aeropuerto))]
        public IHttpActionResult DeleteAeropuerto(long id)
        {
            Aeropuerto aeropuerto;
            try
            {
                aeropuerto = aeropuertosService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(aeropuerto);
        }
    }
}