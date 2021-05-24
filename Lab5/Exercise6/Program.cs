using System;
using System.Data.SqlClient;

namespace Exercise6
{
    class Program
    {

        /*
         * In the second function the connection will be live only with in the using scope and connection will close when control comes out of using scope.
         * But in first function the conncetion will be still open until the function returns to calling function.
         */
        public static void CreateCommand1(string MyconnectString)
        {
            SqlConnection conn = new SqlConnection(MyconnectString);
            SqlCommand cmd = new SqlCommand("sp_Myproc", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        public static void CreateCommand2(string MyconnectString)
        {
            SqlConnection conn = new SqlConnection(MyconnectString);
            SqlCommand cmd = new SqlCommand("sp_Myproc", conn);
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
