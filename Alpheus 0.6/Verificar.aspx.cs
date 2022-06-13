using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6
{
    public partial class Verificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT idTipo FROM Usuario WHERE Usuario = '" + UsuarioLogeado + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                String tipo = dr["idTipo"].ToString();

                if(tipo.Equals("1004"))
                {
                    Response.Redirect("computadoras.aspx");
                }
                else
                {
                    Response.Redirect("computadoras.aspx");
                }
            }
        }
    }
}