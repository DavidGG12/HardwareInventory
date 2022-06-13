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
            Error_Verificar.Text = "Usuario";
            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT idTipo FROM Usuario WHERE Usuario = '" + UsuarioLogeado + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            Error_Verificar.Text = "Consulta";
            if (dr.Read())
            {
                String tipo = dr["idTipo"].ToString();
                Error_Verificar.Text = "No Entré";
                if (tipo.Equals("1004"))
                {
                    Error_Verificar.Text = "No entré";
                    Response.Redirect("computadoras.aspx");
                }
                else
                {
                    Error_Verificar.Text = "Entré";
                    Response.Redirect("computadoras.aspx");
                }
            }
        }
    }
}