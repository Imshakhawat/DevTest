using Autofac;
using Ecom.Application.Features.Training.Services;
using Ecom.Infrastructure.Features.Services;

namespace Ecom.Infrastructure
{
    public class InfrastructureModule : Module
    {


        public InfrastructureModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductServices>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}