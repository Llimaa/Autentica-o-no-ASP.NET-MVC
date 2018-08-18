using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutenticacaoAspnet._1_Infra
{
    public class MSSQLDB : IDb, IDisposable
    {
        private SqlConnection _con;
        public IDbConnection connection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Usuario"].ConnectionString);
        }

        public void Dispose()
        {

            _con.Open();
            _con.Dispose();
        }
    }
}