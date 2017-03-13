using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoVD
{
    public class AdaptadorBD
    {
        SqlConnection conn;
        // C#
        public void conectar()
        {
            //String conexion = "Data Source=10.3.18.46; Initial Catalog=Concursos; Integrated Security = SSPI";
            String conexion = "Data Source=10.3.18.46; Initial Catalog=Concursos; user id= Armando ; password= armando11";
            //conn.ConnectionString = "Server=tcp:xrk60dol8s.database.windows.net,1433;Database=codigosDS;User " +
            //"ID=armando@xrk60dol8s;Password=Mamiester12;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            conn = new SqlConnection(conexion);

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {

            }

        }

        public void desconectar()
        {
            conn.Close();
        }

        internal void insertar(String consulta)
        {
            conectar();
            SqlCommand comando = new SqlCommand(consulta, conn);
            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            desconectar();

        }

        public DataTable consultar(String consulta)
        {
            conectar();
            SqlCommand comando = new SqlCommand(consulta, conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            desconectar();
            return dt;
        }
    }
}