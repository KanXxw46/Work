using System;
using System.Collections.Generic;
using OnlineShop.Models;
using System.Data.SqlClient;
using System.Data.Common;

namespace OnlineShop.Data
{
    public class UserDateAccess
    {
        public void Create(User user)
        {
            DbProviderFactories.RegisterFactory("mssql",SqlClientFactory.Instance);
            DbProviderFactory factory = DbProviderFactories.GetFactory("mssql");

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = "Server = (localdb)\\MSSQLLocalDB;Database = OnlineShopDatabase;Trusted_Connection = True";
            connection.Open();

            DbTransaction transaction = connection.BeginTransaction();

            DbCommand command = factory.CreateCommand();
            command.CommandText = $"insert into Users(Id,Email,Password) values (@Id,@Email,@Password);";
            command.Connection = connection;

            SqlParameter idParameter = new SqlParameter();
            idParameter.ParameterName = "Id";
            idParameter.Value = user.Id;

            command.Parameters.Add(idParameter);

            SqlParameter EmailParameter = new SqlParameter();
            idParameter.ParameterName = "Email";
            idParameter.Value = user.Email;

            command.Parameters.Add(EmailParameter);

            SqlParameter PasswordParameter = new SqlParameter();
            idParameter.ParameterName = "Password";
            idParameter.Value = user.Password;

            command.Parameters.Add(PasswordParameter);

            command.Transaction = transaction;

            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }

            command.Dispose();
            transaction.Dispose();
            connection.Close();
        }

        internal void Create(object user)
        {
            throw new NotImplementedException();
        }

        public void ExecuteInTransaction(SqlConnection connection,params SqlCommand[]sqlCommands)
        {
            var transaction = connection.BeginTransaction();
            try
            {
                foreach (var command in sqlCommands)
                {
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            transaction.Dispose();
        }

        public User Get(User user)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server = (localdb)\\MSSQLLocalDB;Database = OnlineShopDatabase;Trusted_Connection = True";
            connection.Open();

            SqlCommand command = new SqlCommand($"select top 1 from Users where Email ='{user.Email}';", connection);

            SqlDataReader reader = command.ExecuteReader();

            User gotUser = new User();

            while(reader.Read())
            {
                gotUser.Id = Guid.Parse(reader["Id"].ToString());
                gotUser.Email = reader["Email"].ToString();
                gotUser.Phone = reader["Phone"].ToString();
                gotUser.Password = reader["Password"].ToString();
            }

            reader.Close();

            connection.Dispose();

            connection.Close();

            return gotUser;
        }

        //public List<User> GetAll()
        //{
           //TODO 
        //}
        public void Update(User user)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server = (localdb)\\MSSQLLocalDB;Database = OnlineShopDatabase;Trusted_Connection = True";
            connection.Open();

            SqlCommand command = new SqlCommand($"update Users Email ='{user.Email}';", connection);

        }
        public void Delete(Guid id)
        {
            


        }
    }
}
