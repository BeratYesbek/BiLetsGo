using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<BookedSeatManager>().As<IBookedSeatService>().SingleInstance();
            builder.RegisterType<EfBookedSeatDal>().As<IBookedSeatDal>().SingleInstance();

            builder.RegisterType<PurchaseManager>().As<IPurchaseService>().SingleInstance();
            builder.RegisterType<EfPurchaseDal>().As<IPurchaseDal>().SingleInstance();

            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().SingleInstance();

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

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
