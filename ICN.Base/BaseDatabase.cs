using ICN.Generic;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ICN.Base
{
    public abstract class BaseDatabase
    {
        protected static IDbConnection OpenDB()
        {
            AppConfiguration appconfig = new AppConfiguration();
            IDbConnection conn = new MySqlConnection(appconfig.ConnectionString);
            return conn;
        }
    }
}
