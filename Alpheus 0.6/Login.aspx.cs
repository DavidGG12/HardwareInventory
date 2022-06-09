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
            try
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

                if (String.IsNullOrEmpty(Usuario.Text) || String.IsNullOrEmpty(contraseña.Text))
                {
                    msg.Text = "Alguno de los campos está vacío.";
                    AjaModal.Show();
                }
                else
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Session["UsuarioLogeado"] = Usuario.Text;
                        msg.Text = "Iniciado";
                        AjaModal.Show();
                        Response.Redirect("Verificar.aspx");
                    }
                    else
                    {
                        msg.Text = "Correo/contraseña inválidos";
                        AjaModal.Show();
                    }
                }

                cmd.Connection.Close();
            }
            catch (Exception er)
            {
                try
                {
                    string path = @"C:\BACKUP";
                    /*
                    string conectar = ConfigurationManager.ConnectionStrings["Backup"].ConnectionString;
                    SqlConnection con = new SqlConnection(conectar); 
                    string direccion = "C:\BACKUP\AlpheusBak.bak";
                    con.Open();
                    string query = "RESTORE DATABASE AlpheusPlus TO DISK = 'C:\BACKUP'";

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader dr = cmd.ExecuteReader();

                    msg.Text = "Base de Datos recuperada.";
                    AjaModal.Show();
                    */
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {

                    }
                }
                catch (Exception) 
                {
                    msg.Text = er.Message;
                    AjaModal.Show();
                }
            }
        }

        protected void boton_registrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro_Usuario.aspx");
        }
    }
}