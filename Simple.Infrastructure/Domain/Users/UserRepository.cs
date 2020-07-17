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
                    using (var cmd = new NpgsqlCommand("INSERT INTO public.web_user(id, first_name, last_name, email) VALUES(@id, @first_name, @last_name, @email)", (NpgsqlConnection)conn))
                    {
                        cmd.Parameters.Add(new NpgsqlParameter("@id", NpgsqlDbType.Uuid) { Value = user.Id.Value });
                        cmd.Parameters.Add(new NpgsqlParameter("@first_name", NpgsqlDbType.Varchar) { Value = user.FirstName });
                        cmd.Parameters.Add(new NpgsqlParameter("@last_name", NpgsqlDbType.Varchar) { Value = user.LastName });
                        cmd.Parameters.Add(new NpgsqlParameter("@email", NpgsqlDbType.Varchar) { Value = user.Email });

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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
