using MarvelFlow.Classes;
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
    public class SelectDB
    {
        private SqlConnection dbCon { get; set; }

        public SelectDB()
        {
            dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MarvelFlowDB"].ConnectionString);
        }

        public bool CheckLogin(string login)
        {
            using (dbCon)
            {
                dbCon.Open();
                SqlCommand CheckLogin = new SqlCommand("CheckLogin", dbCon);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.AddWithValue("@Login", login);

                int count = Convert.ToInt32(CheckLogin.ExecuteScalar());

                return (count != 0);
            }
        }

        public bool CheckConnexion(string login, string password)
        {
            using (dbCon)
            {
                dbCon.Open();
                SqlCommand CheckConnexion = new SqlCommand("CheckConnexion", dbCon);
                CheckConnexion.CommandType = CommandType.StoredProcedure;
                CheckConnexion.Parameters.AddWithValue("@Login", login);
                CheckConnexion.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(CheckConnexion.ExecuteScalar());

                return (count != 0);
            }
        }

        public User SelectUser(string login)
        {
            using (dbCon)
            {
                User u = null;
                dbCon.Open();
                SqlCommand CheckLogin = new SqlCommand("CheckLogin", dbCon);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.AddWithValue("@Login", login);

                int count = Convert.ToInt32(CheckLogin.ExecuteScalar());

                if (count == 0)
                {
                    return u;
                }

                SqlCommand SelectUser = new SqlCommand("SelectUser", dbCon);
                SelectUser.CommandType = CommandType.StoredProcedure;
                SelectUser.Parameters.AddWithValue("@Login", login);

                SqlDataReader reader = SelectUser.ExecuteReader();
                while(reader.Read())
                {
                    string log = reader[0].ToString();
                    string pwd = reader[1].ToString();
                    string date = ((DateTime)reader[2]).ToString("dd/MM/yyyy");
                    string mail = reader[3].ToString();
                    string nom = reader[4].ToString();
                    string prenom = reader[5].ToString();
                    bool isAdmin = Convert.ToInt32(reader[6]) == 1 ? true : false;
                    string hero = reader[7].ToString();
                    u = new User(log, pwd, date, mail, nom, prenom, isAdmin, hero);
                }
                return u;
            }
        }

    }
}
