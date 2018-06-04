using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.DataBase
{
    public class SelectDB
    {
        private SqlConnection dbCon { get; set; }

        public SelectDB()
        {
            dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MarvelFlowDB"].ConnectionString);
        }
    }
}
