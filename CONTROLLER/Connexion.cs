using System;
using System.Data;
using System.Data.SqlClient;


namespace CONTROLLER
{
    public static class Connexion
    {
        public static SqlConnection conn = new SqlConnection("database=gestioncode;server=CHEYMA;User ID=sa;pwd=pass");

        public static void connecter()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static bool executeCommand(ref SqlCommand cmd)
        {
            cmd.Connection = conn;
            if (cmd.ExecuteNonQuery() >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static SqlDataReader Rdd(string value)
        {
            SqlCommand command = new SqlCommand(value);
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
