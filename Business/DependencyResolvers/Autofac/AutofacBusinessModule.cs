using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<SalonManager>().As<ISalonService>().SingleInstance();
            builder.RegisterType<EfSalonDal>().As<ISalonDal>().SingleInstance();

            builder.RegisterType<SeatManager>().As<ISeatService>().SingleInstance();
            builder.RegisterType<EfSeatDal>().As<ISeatDal>().SingleInstance();

            builder.RegisterType<TicketFileManager>().As<ITicketFileService>().SingleInstance();
            builder.RegisterType<EfTicketFileDal>().As<ITicketFileDal>().SingleInstance();

            builder.RegisterType<TicketManager>().As<ITicketService>().SingleInstance();
            builder.RegisterType<EfTicketDal>().As<ITicketDal>().SingleInstance();


            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
