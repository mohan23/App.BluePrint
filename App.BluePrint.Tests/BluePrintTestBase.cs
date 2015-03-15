using Abp.Collections;
using Abp.Modules;
using Abp.TestBase;
using App.BluePrint.EntityFramework;
using App.BluePrint.Migrations.Data;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BluePrint.Tests
{
    public abstract class BluePrintTestBase : AbpIntegratedTestBase
    {
        protected BluePrintTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Creating initial data
            UsingDbContext(context => {
                                        new InitialDataBuilder().Build(context);
                                        new AdministrationDataBuilder().Build(context);
                            });
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);
            modules.Add<ApplicationModule>();
            modules.Add<AppDataModule>();
        }

        public void UsingDbContext(Action<AppDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<AppDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<AppDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<AppDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

    }
}
