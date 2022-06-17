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
    public partial class Mantenimiento : System.Web.UI.Page
    {
        static string conectar = System.Configuration.ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
        System.Data.SqlClient.SqlConnection con = new SqlConnection(conectar);
        static int Area;
        static string NoControl, ID_Buscar;
        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion nombre = new Sesion();
            String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

            SesionLbl.Text = nombre.Nombre(UsuarioLogeado).ToString();
        }

        protected void RegistrarBtn_Click(object sender, EventArgs e)
        {

        }

        protected void BuscarBtn_Click(object sender, EventArgs e)
        {
            if(CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
            {
                if (CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
                {
                    try
                    {
                        con.Open();
                        Error.Text = "";
                        string portador = NombreTxtList.Text;
                        SqlCommand cmd = new SqlCommand("SELECT idArea_Destino, NoControlInterno FROM Transferencia WHERE Usuario_Recibidor = '" + portador + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Error.Text = "";
                            ID_Buscar = dr["idArea_Destino"].ToString();
                            NoControl = dr["NoControlInterno"].ToString();
                            Area = int.Parse(ID_Buscar);
                            dr.Close();
                        }
                        else
                        {
                            Error.Text = "No jale";
                        }


                        //SELECCIONAR EL ÁREA
                        cmd = new SqlCommand("SELECT Subarea FROM Subareas WHERE ID ='" + Area + "'", con);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            Error.Text = "";
                            AreaLbl.Text = "Area: " + dr["Subarea"].ToString();
                            dr.Close();
                        }
                        else
                        {

                        }

                        cmd = new SqlCommand("SELECT Tipo, Marca, NoSerie, NoInventario, Modelo FROM CPU WHERE idTransferencia = '" + NoControl + "'", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Error.Text = "";
                            MarcaLbl.Text = "Marca: " + dr["Marca"].ToString();
                            NoSerieLbl.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                            InventarioLbl.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                            ModeloLbl.Text = "Modelo: " + dr["Modelo"].ToString();
                            dr.Close();
                        }
                        else
                        {
                            Error.Text = "No hay una computadora ligada.";
                            AreaLbl.Text = "Area: ";
                            MarcaLbl.Text = "Marca: ";
                            NoSerieLbl.Text = "No. De Serie: ";
                            InventarioLbl.Text = "No. De Inventario: ";
                            ModeloLbl.Text = "Modelo: ";
                        }
                        con.Close();
                    }
                    catch (Exception er)
                    {
                        Error.Text = er.Message;
                    }
                }
                else
                {
                    try
                    {
                        con.Open();
                        Error.Text = "";
                        string portador = NombreTxtList.Text;
                        SqlCommand cmd = new SqlCommand("SELECT idArea_Destino, NoControlInterno FROM Transferencia WHERE Usuario_Recibidor = '" + portador + "'", con);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Error.Text = "";
                            ID_Buscar = dr["idArea_Destino"].ToString();
                            NoControl = dr["NoControlInterno"].ToString();
                            Area = int.Parse(ID_Buscar);
                            dr.Close();
                        }
                        else
                        {
                            Error.Text = "No jale";
                        }


                        //SELECCIONAR EL ÁREA
                        cmd = new SqlCommand("SELECT Subarea FROM Subareas WHERE ID ='" + Area + "'", con);
                        dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            Error.Text = "";
                            AreaLbl.Text = "Area: " + dr["Subarea"].ToString();
                            dr.Close();
                        }
                        else
                        {

                        }

                        cmd = new SqlCommand("SELECT Tipo, Marca, NoSerie, NoInventario, Modelo FROM Dispositivos WHERE idTransferencia = '" + NoControl + "'", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Error.Text = "";
                            MarcaLbl.Text = "Marca: " + dr["Marca"].ToString();
                            NoSerieLbl.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                            InventarioLbl.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                            ModeloLbl.Text = "Modelo: " + dr["Modelo"].ToString();
                            dr.Close();
                        }
                        else
                        {
                            Error.Text = "No hay una computadora ligada.";
                            AreaLbl.Text = "Area: ";
                            MarcaLbl.Text = "Marca: ";
                            NoSerieLbl.Text = "No. De Serie: ";
                            InventarioLbl.Text = "No. De Inventario: ";
                            ModeloLbl.Text = "Modelo: ";
                        }
                        con.Close();
                    }
                    catch (Exception er)
                    {
                        Error.Text = er.Message;
                    }
                }
            }
        }
    }
}