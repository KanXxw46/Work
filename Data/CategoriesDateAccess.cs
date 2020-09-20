using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OnlineShop.Models;
using System.Data.Common;

namespace OnlineShop.Data
{
    public class CategoriesDateAccess
    {
        public void Create(Categories categories)
        {
            DbProviderFactories.RegisterFactory("mssql", SqlClientFactory.Instance);
            DbProviderFactory factory = DbProviderFactories.GetFactory("mssql");

            DbConnection connection = factory.CreateConnection();
            connection.ConnectionString = "Server = (localdb)\\MSSQLLocalDB;Database = OnlineShopDatabase;Trusted_Connection = True";
            connection.Open();

            DbTransaction transaction = connection.BeginTransaction();

            DbCommand command = factory.CreateCommand();
            command.CommandText = $"insert into Users(Smartphones,PushbuttonPhones,RadioPhones) values (@Smartphones,@PushbuttonPhones,@RadioPhones);";
            command.Connection = connection;

        }
    }
}
