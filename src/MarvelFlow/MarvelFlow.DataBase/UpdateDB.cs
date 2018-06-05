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

        public bool Inscription(string login, string password, DateTime date, string mail,string nom, string prenom, bool isAdmin, string heroFav)
        {
            int admin = isAdmin ? 1 : 0;
            using(dbCon)
            {
                dbCon.Open();

                SqlCommand CheckLogin = new SqlCommand("CheckLogin", dbCon);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.AddWithValue("@Login", login);
                int count = Convert.ToInt32(CheckLogin.ExecuteScalar());

                if (count !=0)
                {
                    return false;
                }

                SqlCommand Inscription = new SqlCommand("Inscription", dbCon);
                Inscription.CommandType = CommandType.StoredProcedure;

                Inscription.Parameters.AddWithValue("@Login", login);
                Inscription.Parameters.AddWithValue("@Password", password);
                Inscription.Parameters.AddWithValue("@Date", date);
                Inscription.Parameters.AddWithValue("@Mail", mail);
                Inscription.Parameters.AddWithValue("@Nom", nom);
                Inscription.Parameters.AddWithValue("@Prenom", prenom);
                Inscription.Parameters.AddWithValue("@IsAdmin", admin);
                Inscription.Parameters.AddWithValue("@HeroFav", heroFav);

                Inscription.ExecuteNonQuery();
            };

            return true;
        }

        public bool UpdateHeroFav(string login, string heroFav)
        {
            using (dbCon)
            {
                dbCon.Open();

                SqlCommand CheckLogin = new SqlCommand("CheckLogin", dbCon);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.AddWithValue("@Login", login);
                int count = Convert.ToInt32(CheckLogin.ExecuteScalar());

                if (count == 0)
                {
                    return false;
                }

                SqlCommand UpdateHeroFav = new SqlCommand("UpdateHeroFav", dbCon);
                UpdateHeroFav.CommandType = CommandType.StoredProcedure;

                UpdateHeroFav.Parameters.AddWithValue("@Login", login);
                UpdateHeroFav.Parameters.AddWithValue("@HeroFav", heroFav);

                UpdateHeroFav.ExecuteNonQuery();
            };

            return true;
        }
    }
}
