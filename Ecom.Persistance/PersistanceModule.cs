using Autofac;
using Ecom.Application;
using Ecom.Application.Features.Training.Repositories;
using Ecom.Persistance.Features.Training.Repositories;
using Ecommerce.Persistance;
using NuGet.Protocol.Core.Types;

namespace Ecom.Persistance
{
    public class PersistanceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public PersistanceModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssembly;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
    .InstancePerLifetimeScope();


            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();
        }








    }
}