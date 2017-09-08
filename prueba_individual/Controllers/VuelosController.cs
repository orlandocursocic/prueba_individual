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
    public class VuelosController : ApiController
    {
        private IVuelosService vuelosService;

        public VuelosController(IVuelosService vuelosService)
        {
            this.vuelosService = vuelosService;
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Vuelos
        public IQueryable<Vuelo> GetPerfiles()
        {
            return vuelosService.ReadAll();
        }

        // GET: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult GetVuelo(long id)
        {
            Vuelo vuelo = vuelosService.Read(id);
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

            try
            {
                vuelosService.Update(vuelo);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
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

            vuelo = vuelosService.Create(vuelo);

            return CreatedAtRoute("DefaultApi", new { id = vuelo.Id }, vuelo);
        }

        // DELETE: api/Vuelos/5
        [ResponseType(typeof(Vuelo))]
        public IHttpActionResult DeleteVuelo(long id)
        {
            Vuelo vuelo;
            try
            {
                vuelo = vuelosService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(vuelo);
        }

    }
}