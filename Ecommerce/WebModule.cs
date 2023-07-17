using Autofac;
using Ecommerce.Areas.Admin.Models;

namespace Ecommerce
{
    public class WebModule : Module
    {
        public WebModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductListModel>().AsSelf()
                .InstancePerLifetimeScope(); 

            builder.RegisterType<ProductCreateModel>().AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductUpdateModel>().AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
