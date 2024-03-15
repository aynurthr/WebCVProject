using Autofac;
using WebCV.DataAccessLayer;
using WebCV.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Presentation
{
    public class WebCVDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            var assembly = typeof(IRepositoryReference).Assembly;

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var type = typeof(IDataAccessLayerReference).Assembly.GetType("WebCV.DataAccessLayer.Contexts.DataContext");
            builder.RegisterType(type).As<DbContext>().InstancePerLifetimeScope();
        }
    }
}
