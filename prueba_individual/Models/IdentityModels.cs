using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace prueba_individual.Models
{
    // Para agregar datos de perfil al usuario, agregue más propiedades a la clase ApplicationUser. Para obtener más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        [ThreadStatic]
        public static ApplicationDbContext applicationDbContext;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new ControlAereoDBInitializer());
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Aeropuerto> Aeropuertos { get; set; }
    }

    public class ControlAereoDBInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            IList<Aeropuerto> defaultAeropuertos = new List<Aeropuerto>();
            IList<Vuelo> defaultVuelos = new List<Vuelo>();

            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "IBE-5543", Companyia = "Iberia", Origen = "Santander", Destino = "Madrid", FechaSalida = new DateTime(2017, 10, 30, 19, 00, 00), FechaLlegada = new DateTime(2017, 10, 30, 20, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "AEA-8899", Companyia = "Air Europa", Origen = "Madrid", Destino = "Gran Canaria", FechaSalida = new DateTime(2016, 10, 30, 19, 00, 00), FechaLlegada = new DateTime(2016, 10, 30, 20, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "IB-0678", Companyia = "Iberia", Origen = "Madrid", Destino = "Ibiza", FechaSalida = new DateTime(2015, 05, 20, 10, 00, 00), FechaLlegada = new DateTime(2015, 05, 20, 11, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "NTN-0743", Companyia = "National Airways", Origen = "Johannesburgo", Destino = "Madrid", FechaSalida = new DateTime(2014, 02, 15, 10, 00, 00), FechaLlegada = new DateTime(2014, 02, 15, 22, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "MXA-5679", Companyia = "Mexicana de Aviación", Origen = "Guadalajara", Destino = "Quito", FechaSalida = new DateTime(2017, 10, 30, 19, 00, 00), FechaLlegada = new DateTime(2017, 10, 30, 20, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "AIC-5543", Companyia = "Air India", Origen = "Bombay", Destino = "Tokio", FechaSalida = new DateTime(2016, 10, 30, 19, 00, 00), FechaLlegada = new DateTime(2016, 10, 30, 20, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "GWI-4044", Companyia = "German Wings", Origen = "Múnich", Destino = "Barcelona", FechaSalida = new DateTime(2017, 10, 30, 19, 00, 00), FechaLlegada = new DateTime(2017, 10, 30, 20, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "LTU-3401", Companyia = "Lufthansa", Origen = "Berlín", Destino = "Londres", FechaSalida = new DateTime(2015, 05, 20, 10, 00, 00), FechaLlegada = new DateTime(2015, 05, 20, 11, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "RYR-3890", Companyia = "Ryanair", Origen = "Santander", Destino = "Roma", FechaSalida = new DateTime(2014, 02, 15, 10, 00, 00), FechaLlegada = new DateTime(2014, 02, 15, 22, 00, 00) });
            defaultVuelos.Add(new Vuelo() { CodigoVuelo = "AAL-8594", Companyia = "American Airlines", Origen = "Oakland", Destino = "Nueva York", FechaSalida = new DateTime(2016, 10, 30, 19, 00, 00), FechaLlegada = new DateTime(2016, 10, 30, 20, 00, 00) });


            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Gando", numTerminales = 2, Ciudad = "Las Palmas", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Barajas", numTerminales = 4, Ciudad = "Madrid", Pais = "España"});
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "El Prat", numTerminales = 3, Ciudad = "Barcelona", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Seve Ballesteros", numTerminales = 1, Ciudad = "Santander", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Los Llanos", numTerminales = 1, Ciudad = "Albacete", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "El Alquilán", numTerminales = 1, Ciudad = "Almería", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "El Atlet", numTerminales = 1, Ciudad = "Alicante", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Villafría", numTerminales = 1, Ciudad = "Burgos", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Alvedro", numTerminales = 1, Ciudad = "La Coruña", Pais = "España" });
            defaultAeropuertos.Add(new Aeropuerto() { Nombre = "Es Codolar", numTerminales = 1, Ciudad = "Ibiza", Pais = "España" });

            foreach (Aeropuerto aeropuerto in defaultAeropuertos)
                context.Aeropuertos.Add(aeropuerto);

            foreach (Vuelo vuelo in defaultVuelos)
                context.Vuelos.Add(vuelo);

            base.Seed(context);
        }
    }
}