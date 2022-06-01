using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Alpheus_0._6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string patron = "InfoToolsSV";
        protected void boton_ingresar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            //Cambiar parámetros
            SqlCommand cmd = new SqlCommand("Iniciar_Sesion", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = Usuario.Text;
            cmd.Parameters.Add("@contraseña", SqlDbType.VarChar, 20).Value = contraseña.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;

            if (String.IsNullOrEmpty(Usuario.Text) || String.IsNullOrEmpty(contraseña.Text))
            {
                Error.Text = "Alguno de los campos está vacío.";
            }
            else
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Error.Text = "Correo/contraseña inválidos";
                }
                else
                {
                    Error.Text = "Iniciado";
                }
            }

            cmd.Connection.Close();
        }

        protected void boton_registrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro_Usuario.aspx");
        }
    }
}