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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            SqlCommand cmd = new SqlCommand("Agregar_Usuario", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            string constraseña = Contraseña.Text;

            string nombre = Nombre.Text;
            string apellido_paterno = Apellido_Paterno.Text;
            string apellido_materno = Apellido_Materno.Text;

            nombre = nombre.ToUpper();
            apellido_paterno = apellido_paterno.ToUpper();
            apellido_materno = apellido_materno.ToUpper();


            if (String.IsNullOrEmpty(Nombre.Text) || String.IsNullOrEmpty(Apellido_Paterno.Text) || String.IsNullOrEmpty(Apellido_Materno.Text) || String.IsNullOrEmpty(Usuario.Text) || String.IsNullOrEmpty(Contraseña.Text))
            {
                Error.Text = "Alguno de los campos está vacío.";
            }
            else
            {
                if (constraseña.Length >= 8)
                {
                    if (Contraseña.Text == Contraseña_Revalidar.Text)
                    {
                        try
                        {
                            cmd.Connection.Open();
                            cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 100).Value = TipoList.Text; 
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
                            cmd.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 100).Value = apellido_paterno;
                            cmd.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 100).Value = apellido_materno;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 20).Value = Usuario.Text;
                            cmd.Parameters.Add("@Contraseña", SqlDbType.VarChar, 20).Value = Contraseña.Text;

                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                Error.Text = "Error en el registro";
                            }
                            else
                            {
                                Error.Text = "Registrado con éxito.";
                                Nombre.Text = "";
                                Apellido_Paterno.Text = "";
                                Apellido_Materno.Text = "";
                                Usuario.Text = "";
                            }
                        }
                        catch (Exception er)
                        {
                            Error.Text = "Usuario ya usado";
                        }


                    }
                    else
                    {
                        Error_Contraseña_nCoincide.Text = "Contraseñas no coinciden";
                    }
                }
                else
                {
                    Error_Contraseña.Text = "Contraseña debe contener 8 carácteres.";
                }
            }

            cmd.Connection.Close();
        }
    }
}