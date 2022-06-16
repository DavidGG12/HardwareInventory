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
    public class VerificarTrans
    {
        public string RollBack_Commit(string NoControl, string NoSerie)
        {
            string mensaje="", comprobar;

            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT idTransferencia FROM CPU WHERE NoSerie = '" + NoSerie + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comprobar = dr["idTransferencia"].ToString();
                if(comprobar == NoControl)
                {
                    mensaje = "Computadora asignada";
                }
                else
                {
                    mensaje = "Computadora ya asignada";
                }
            }

            return mensaje;
        }
    }
}