using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using prueba_individual.Exceptions;
using prueba_individual.Models;
using prueba_individual.Repositories;
using prueba_individual.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Unity.WebApi;

namespace prueba_individual
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.AddNewExtension<Interception>();
            
            container.RegisterType<IVuelosService, VuelosService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IVuelosRepository, VuelosRepository>();

            container.RegisterType<IAeropuertosService, AeropuertosService>(new Interceptor<InterfaceInterceptor>(), new InterceptionBehavior<DBInterceptor>());
            container.RegisterType<IAeropuertosRepository, AeropuertosRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public class DBInterceptor : IInterceptionBehavior
        {
            public IMethodReturn Invoke(IMethodInvocation input,
              GetNextInterceptionBehaviorDelegate getNext)
            {
                IMethodReturn result;
                if (ApplicationDbContext.applicationDbContext == null)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        ApplicationDbContext.applicationDbContext = context;
                        using (var dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {

                                result = getNext()(input, getNext);


                                if (result.Exception != null)
                                {
                                    throw result.Exception;
                                }
                                context.SaveChanges();

                                dbContextTransaction.Commit();
                            }
                            catch (NoEncontradoException e)
                            {
                                dbContextTransaction.Rollback();
                                ApplicationDbContext.applicationDbContext = null;
                                throw e;
                            }
                            catch (Exception e)
                            {
                                dbContextTransaction.Rollback();
                                ApplicationDbContext.applicationDbContext = null;
                                throw new Exception("He hecho rollback de la transaccion", e);
                            }
                        }
                    }
                    ApplicationDbContext.applicationDbContext = null;
                }
                else
                {

                    result = getNext()(input, getNext);


                    if (result.Exception != null)
                    {
                        throw result.Exception;
                    }
                }
                return result;
            }

            public IEnumerable<Type> GetRequiredInterfaces()
            {
                return Type.EmptyTypes;
            }

            public bool WillExecute
            {
                get { return true; }
            }

            private void WriteLog(string message)
            {

            }
        }
    }
}