using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.DataBase
{
    public class UpdateDB
    {
        private SqlConnection dbCon { get; set; }

        public UpdateDB()
        {
            dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MarvelFlowDB"].ConnectionString);
        }

        public void Inscription(string login, string password, DateTime date, string mail,string nom, string prenom, bool isAdmin)
        {
            using(dbCon)
            {
                dbCon.Open();

                SqlCommand Inscription = new SqlCommand("Inscription", dbCon);
                Inscription.CommandType = CommandType.StoredProcedure;
                Inscription.Parameters.AddWithValue("@Login", login);
                Inscription.Parameters.AddWithValue("@Password", password);
                Inscription.Parameters.AddWithValue("@Date", date);
                Inscription.Parameters.AddWithValue("@Mail", mail);
                Inscription.Parameters.AddWithValue("@Nom", nom);
                Inscription.Parameters.AddWithValue("@Prenom", prenom);
                Inscription.Parameters.AddWithValue("@IsAdmin", isAdmin);

                Inscription.ExecuteNonQuery();
            };
        }
    }
}
