using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Alpheus_0._6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void boton_ingresar_Click(object sender, EventArgs e)
        {
            string usuario, contraseña;
            try
            {
                usuario = Usuario.Text;
                contraseña = Contraseña.Text;
                string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(conectar);

                //Cambiar parámetros
                SqlCommand cmd = new SqlCommand("Iniciar_Sesion", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 20).Value = usuario;
                cmd.Parameters.Add("@contraseña", SqlDbType.VarChar, 20).Value = contraseña;

                if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(contraseña))
                {
                    error_login.Text = "Error no están llenos";
                }
                else
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Session["UsuarioLogeado"] = usuario;
                        Response.Redirect("Verificar.aspx");
                        
                    }
                    else
                    {
                        error_login.Text = "No lo encontré";

                    }
                }

                cmd.Connection.Close();
            }
            catch (Exception er)
            {
                try
                {
                    string path = @"C:\BACKUP\", fecha_backup = DateTime.Now.ToString("dd_MM_yyyy");
                    
                    string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
                    SqlConnection con = new SqlConnection(conectar); 
                    con.Open();
                    string query = "RESTORE DATABASE AlpheusPlus FROM DISK = '" + path + fecha_backup + ".bak'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    
                }
                catch (Exception) 
                {
                    error_login.Text = "Error base";
                }
            }
        }
    }
}