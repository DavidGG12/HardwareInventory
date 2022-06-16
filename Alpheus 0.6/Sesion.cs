using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6
{
    public class Sesion
    {
        public string Nombre(string Usuario)
        {
            string mensaje="";

            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT Nombre, Apellido_Paterno FROM Usuario WHERE Usuario = '" + Usuario + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                mensaje = dr["Nombre"].ToString() + " " + dr["Apellido_Paterno"].ToString();
            }

            con.Close();

            return mensaje;
        }
    }
}