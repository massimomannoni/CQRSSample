using Npgsql;
using NpgsqlTypes;
using Simple.Application.Configuration.Data;
using Simple.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public UserRepository(ISqlConnectionFactory connectionFactory)
        {
            _sqlConnectionFactory = connectionFactory;
        }

        public async Task Create(User user)
        {
            //  change using store procedure
            var conn = _sqlConnectionFactory.GetOpenConnection();

            using (var tr = conn.BeginTransaction())
            {
                try
                {
                    // store product
                    using (var cmd = new NpgsqlCommand("INSERT INTO public.web_user(id, name) VALUES(@id, @name)", (NpgsqlConnection)conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Uuid) { Value = user.Id.Value });
                        cmd.Parameters.Add(new NpgsqlParameter("@name", NpgsqlDbType.Varchar) { Value = user.Name });

                        await cmd.ExecuteNonQueryAsync();
                    }

                    //commit
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public Task Change(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
