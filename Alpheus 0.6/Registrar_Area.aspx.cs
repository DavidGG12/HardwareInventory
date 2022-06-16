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
    public partial class Registrar_Area : System.Web.UI.Page
    {
        static string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conectar);
        protected void Page_Load(object sender, EventArgs e)
        {
            //COLOCAR QUE SOLO EL ADMINISTRADOR PUEDE INTERACTUAR CON ESTA INTERFAZ
            Sesion nombre = new Sesion();
            String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

            SesionLbl.Text = nombre.Nombre(UsuarioLogeado).ToString();
        }

        protected void AreaSubAreaListTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(AreaSubAreaListTxt.SelectedItem.Text == "Área")
            {
                AreaTxt.Enabled = true;
                AreaListTxt.Enabled = false;
                SubAreaTxt.Enabled = false;
            }
            else
            {
                AreaTxt.Enabled = false;
                AreaListTxt.Enabled = true;
                SubAreaTxt.Enabled = true;
            }
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            string caracter, cadena;

            try
            {
                if(AreaSubAreaListTxt.SelectedItem.Text == "Área")
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarArea", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Connection.Open();

                    if (String.IsNullOrEmpty(AreaTxt.Text))
                    {
                        Error.Text = "El campo está vacío";
                    }
                    else
                    {
                        if (AdminLabRBtnList.SelectedItem.Text == "Administrativos")
                        {
                            caracter = "!_";
                        }
                        else if (AdminLabRBtnList.SelectedItem.Text == "Laboratorio")
                        {
                            caracter = "#_";
                        }
                        else
                        {
                            caracter = "¿_";
                        }
                        cadena = caracter + AreaTxt.Text.ToUpper();
                        cmd.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = cadena;
                        SqlDataReader dr = cmd.ExecuteReader();

                        Error.Text = "Registrado";

                        AreaTxt.Text = "";
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarSubArea", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Connection.Open();

                    if (String.IsNullOrEmpty(SubAreaTxt.Text))
                    {
                        Error.Text = "El campo está vacío";
                    }
                    else
                    {
                        cadena = SubAreaTxt.Text.ToUpper();

                        cmd.Parameters.Add("@Area", SqlDbType.VarChar, 100).Value = AreaListTxt.Text;
                        cmd.Parameters.Add("@Subarea", SqlDbType.VarChar, 100).Value = cadena;
                        SqlDataReader dr = cmd.ExecuteReader();

                        Error.Text = "Registrado";

                        SubAreaTxt.Text = "";
                    }
                }
            }
            catch (Exception er)
            {
                Error.Text = er.Message;
            }
        }
    }
}