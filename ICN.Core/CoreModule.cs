using Autofac;
using ICN.Core.Account;
using ICN.Core.Category;
using ICN.Core.Expense;
using ICN.Core.Income;
using ICN.Core.Register;
using ICN.Core.Roles;
using ICN.Core.Setting;
using ICN.Core.Tipologi;
using ICN.Core.Tree;
using ICN.Core.User;
using ICN.Interface;
using ICN.Model;

namespace ICN.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AccountServices>().As<IBusiness<AccountModel>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterServices>().As<IBusiness<RegisterModel>>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryServices>().As<IBusiness<CategoryModel>>().InstancePerLifetimeScope();
            builder.RegisterType<IncomeServices>().As<IBusiness<TransIncomeModel>>().InstancePerLifetimeScope();
            builder.RegisterType<ExpenseServices>().As<IBusiness<TransExpenseModel>>().InstancePerLifetimeScope();
            builder.RegisterType<SettingServices>().As<IBusiness<SettingModel>>().InstancePerLifetimeScope();
            builder.RegisterType<UserServices>().As<IBusiness<UserModel>>().InstancePerLifetimeScope();
            builder.RegisterType<TreeServices>().As<IBusiness<TreeModel>>().InstancePerLifetimeScope();
            builder.RegisterType<RolesServices>().As<IBusiness<RoleModel>>().InstancePerLifetimeScope();
            builder.RegisterType<TipologiServices>().As<IBusiness<MosqueCategoryModel>>().InstancePerLifetimeScope();
        }
    }
}
