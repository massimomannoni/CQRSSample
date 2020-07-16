using Autofac;
using Simple.Application.Configuration.Data;
using Simple.Domain.Users;
using Simple.Infrastructure.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simple.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string connectionString)
        {
            _databaseConnectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
             .As<ISqlConnectionFactory>()
             .WithParameter("connectionString", _databaseConnectionString)
             .InstancePerLifetimeScope();

            //builder.RegisterType<UnitOfWork>()
              //.As<IUnitOfWork>()
              //.InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
             .As<IUserRepository>()
             .InstancePerLifetimeScope();

        }
    }
}
