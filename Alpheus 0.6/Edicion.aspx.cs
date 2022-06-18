using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6
{
    public partial class Edicion : System.Web.UI.Page
    {
        static string conectar = System.Configuration.ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
        System.Data.SqlClient.SqlConnection con = new SqlConnection(conectar);
        static string noserie;
        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion nombre = new Sesion();
            String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

            SesionLbl.Text = nombre.Nombre(UsuarioLogeado).ToString();
            UsuarioLbl.Text = UsuarioLogeado;
     
        }

        protected void ActualizarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(NombreUsuarioTxt.Text) || String.IsNullOrEmpty(ApellidoPTxt.Text) || String.IsNullOrEmpty(ApellidoMTxt.Text))
                {
                    Error.Text = "Alguno de los campos está vacío.";
                }
                else
                {
                    NombreUsuarioTxt.Text = NombreUsuarioTxt.Text.ToUpper();
                    ApellidoPTxt.Text = ApellidoPTxt.Text.ToUpper();
                    ApellidoMTxt.Text = ApellidoMTxt.Text.ToUpper();

                    if (String.IsNullOrEmpty(ContraseñaTxt.Text))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Nombre = '" + NombreUsuarioTxt.Text + "', Apellido_Paterno = '" + ApellidoPTxt.Text + "', Apellido_Materno = '" + ApellidoMTxt.Text + "' WHERE Usuario = '" + UsuarioLbl.Text + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();

                        Error.Text = "Usuario Actualizado.";

                        con.Close();
                    }
                    else if(ContraseñaTxt.Text.Count() >= 8)
                    {
                        if(ContraseñaTxt.Text == ContraseñaRevTxt.Text)
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Nombre = '" + NombreUsuarioTxt.Text + "', Apellido_Paterno = '" + ApellidoPTxt.Text + "', Apellido_Materno = '" + ApellidoMTxt.Text + "', Contraseña = '" + ContraseñaTxt.Text + "' WHERE Usuario = '" + UsuarioLbl.Text + "'", con);
                            SqlDataReader dr = cmd.ExecuteReader();

                            Error.Text = "Usuario Actualizado.";

                            con.Close();
                        }
                        else
                        {
                            Error.Text = "Contraseñas no coinciden.";
                        }
                    }
                    else
                    {
                        Error.Text = "Contraseña Inválida.";
                    }
                }
            }
            catch(Exception er)
            {
                Error.Text = er.Message;
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(NoSerieTxt.Text))
                {
                    Error_CPU.Text = "No se ingresaron datos.";
                }
                else
                {
                    if(DispCPURadio.SelectedItem.Text == "CPU")
                    {
                        con.Open();
                        noserie = NoSerieTxt.Text;
                        SqlCommand cmd = new SqlCommand("SELECT Nombre, Marca, Modelo, [RAM GB], [DiscoDuro GB], SO, Office, Procesador, NoInventario, Observacion FROM CPU WHERE NoSerie = '" + noserie + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            NombreTxt.Text = dr["Nombre"].ToString();
                            MarcaTxt.Text = dr["Marca"].ToString();
                            ModeloTxt.Text = dr["Modelo"].ToString();
                            RAMTxt.Text = dr["RAM GB"].ToString();
                            DiscoTxt.Text = dr["DiscoDuro GB"].ToString();
                            SOText.Text = dr["SO"].ToString();
                            OfficeTxt.Text = dr["Office"].ToString();
                            ProcesadorTxt.Text = dr["Procesador"].ToString();
                            NoInventarioTxt.Text = dr["NoInventario"].ToString();
                            ObservacionTxt.Text = dr["Observacion"].ToString();
                        }
                        else
                        {
                            Error_CPU.Text = "No se encontraron registros.";
                        }
                        con.Close();
                    }
                    else
                    {
                        con.Open();
                        noserie = NoSerieTxt.Text;
                        SqlCommand cmd = new SqlCommand("SELECT Marca, Modelo, NoInventario, Observacion FROM Dispositivos WHERE NoSerie = '" + noserie + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            MarcaTxt.Text = dr["Marca"].ToString();
                            ModeloTxt.Text = dr["Modelo"].ToString();
                            NoInventarioTxt.Text = dr["NoInventario"].ToString();
                            ObservacionTxt.Text = dr["Observacion"].ToString();
                        }
                        else
                        {
                            Error_CPU.Text = "No se encontraron registros.";
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception er)
            {
                Error_CPU.Text = er.Message;
            }
        }

        protected void DispCPURadio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DispCPURadio.SelectedItem.Text == "CPU")
            {
                NombreTxt.Enabled = true;
                RAMTxt.Enabled = true;
                DiscoTxt.Enabled = true;
                SOText.Enabled = true;
                OfficeTxt.Enabled = true;
                ProcesadorTxt.Enabled = true;
            }
            else
            {
                NombreTxt.Enabled = false;
                RAMTxt.Enabled = false;
                DiscoTxt.Enabled = false;
                SOText.Enabled = false;
                OfficeTxt.Enabled = false;
                ProcesadorTxt.Enabled = false;
            }
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(DispCPURadio.SelectedItem.Text == "CPU")
                {
                    if(String.IsNullOrEmpty(NombreTxt.Text) || String.IsNullOrEmpty(MarcaTxt.Text) || String.IsNullOrEmpty(ModeloTxt.Text) || String.IsNullOrEmpty(RAMTxt.Text) || String.IsNullOrEmpty(DiscoTxt.Text) || String.IsNullOrEmpty(SOText.Text) || String.IsNullOrEmpty(OfficeTxt.Text) || String.IsNullOrEmpty(ProcesadorTxt.Text) || String.IsNullOrEmpty(ObservacionTxt.Text))
                    {
                        Error_CPU.Text = "Alguno de los campos está vacío.";
                    }
                    else
                    {
                        string ram_cad = RAMTxt.Text, disc_cad = DiscoTxt.Text;
                        int RAM = int.Parse(ram_cad), DISC = int.Parse(disc_cad);
                        
                        if(RAM <= 0 || DISC <=0)
                        {
                            Error_CPU.Text = "Tamaño de RAM o Disco Duro inválidos.";
                        }
                        else
                        {
                            con.Open();

                            NombreTxt.Text = NombreTxt.Text.ToUpper();
                            MarcaTxt.Text = MarcaTxt.Text.ToUpper();
                            ModeloTxt.Text = ModeloTxt.Text.ToUpper();
                            SOText.Text = SOText.Text.ToUpper();
                            OfficeTxt.Text = OfficeTxt.Text.ToUpper();
                            ObservacionTxt.Text = ObservacionTxt.Text.ToUpper();

                            if (String.IsNullOrEmpty(NoInventarioTxt.Text))
                            {
                                SqlCommand cmd = new SqlCommand("UPDATE CPU SET Nombre = '"
                                    +NombreTxt.Text+"', Marca = '"
                                    +MarcaTxt.Text+"', Modelo = '"
                                    +ModeloTxt.Text+"', [RAM GB] = '"
                                    +RAMTxt.Text+"', [DiscoDuro GB] = '"
                                    +DiscoTxt.Text+"', SO = '"
                                    +SOText.Text+"', Office = '"
                                    +OfficeTxt.Text+"', Procesador = '"
                                    +ProcesadorTxt.Text+"', Observacion = '"
                                    +ObservacionTxt.Text+"' WHERE NoSerie = '"
                                    +noserie+"'", con);
                                SqlDataReader dr = cmd.ExecuteReader();
                            }
                            else
                            {
                                SqlCommand cmd = new SqlCommand("UPDATE CPU SET Nombre = '"
                                    + NombreTxt.Text + "', Marca = '"
                                    + MarcaTxt.Text + "', Modelo = '"
                                    + ModeloTxt.Text + "', [RAM GB] = '"
                                    + RAMTxt.Text + "', [DiscoDuro GB] = '"
                                    + DiscoTxt.Text + "', SO = '"
                                    + SOText.Text + "', Office = '"
                                    + OfficeTxt.Text + "', Procesador = '"
                                    + ProcesadorTxt.Text + "', Observacion = '"
                                    + ObservacionTxt.Text +"', NoInventario = '"
                                    + NoInventarioTxt.Text + "' WHERE NoSerie = '"
                                    + noserie + "'", con);
                                SqlDataReader dr = cmd.ExecuteReader();
                            }

                            con.Close();
                        }
                    }
                }
                else
                {
                    if(String.IsNullOrEmpty(MarcaTxt.Text) || String.IsNullOrEmpty(ModeloTxt.Text) || String.IsNullOrEmpty(ObservacionTxt.Text))
                    {
                        Error_CPU.Text = "Alguno de los campos está vacío.";
                    }
                    else
                    {
                        MarcaTxt.Text = MarcaTxt.Text.ToUpper();
                        ModeloTxt.Text = ModeloTxt.Text.ToUpper();
                        ObservacionTxt.Text = ObservacionTxt.Text.ToUpper();

                        con.Open();

                        if(String.IsNullOrEmpty(NoInventarioTxt.Text))
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE Dispositivos SET Marca = '"
                                +MarcaTxt.Text + "', Modelo = '"
                                +ModeloTxt.Text + "', Observacion = '"
                                +ObservacionTxt.Text + "' WHERE NoSerie = '"
                                +noserie + "'", con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            Error_CPU.Text = "Actualizado.";
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE Dispositivos SET Marca = '"
                                + MarcaTxt.Text + "', Modelo = '"
                                + ModeloTxt.Text + "', NoInventario = '"
                                + NoInventarioTxt.Text + "', Observacion = '"
                                + ObservacionTxt.Text + "' WHERE NoSerie = '"
                                + noserie + "'", con);
                            SqlDataReader dr = cmd.ExecuteReader();
                            Error_CPU.Text = "Actualizado.";
                        }

                        con.Close();
                    }
                }
            }
            catch(Exception er)
            {
                Error_CPU.Text = er.Message;
            }
        }
    }
}