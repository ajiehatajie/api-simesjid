using Autofac;
using ICN.Security.Bus;
using ICN.Security.Interface;

namespace ICN.Security
{
    public class ICNSecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TokenAuthenticate>().As<IAuthenticate>().InstancePerLifetimeScope();
            builder.RegisterType<CheckUserRepository>().As<IUserCheck>().InstancePerLifetimeScope();
        }
    }
}
