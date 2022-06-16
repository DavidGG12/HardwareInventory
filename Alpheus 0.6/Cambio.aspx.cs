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
    public partial class Cambio : System.Web.UI.Page
    {
        static string conectar = System.Configuration.ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
        System.Data.SqlClient.SqlConnection con = new SqlConnection(conectar);
        static int Area;
        static string NoControl, ID_Buscar;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TipoMantenimientoRBtnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoMantenimientoRBtnList.SelectedItem.Text == "Otro")
            {
                OtroTxt.Enabled = true;
            }
            else
            {
                OtroTxt.Enabled = false;
            }
        }

        protected void CPU_DISP_RBtnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
            {
                NoSerieListCPU.Enabled = true;
                NoSerieListDisp.Enabled = false;
            }
            else
            {
                NoSerieListCPU.Enabled = false;
                NoSerieListDisp.Enabled = true;
            }
        }

        protected void RegistrarBtn_Click(object sender, EventArgs e)
        {
            if(CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
            {
                try
                {
                    Error.Text = "";

                    SqlCommand cmd = new SqlCommand("SP_CambioCPU", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("@Portador", SqlDbType.VarChar, 100).Value = NombreTxtList.Text;
                    cmd.Parameters.Add("@NoSerieNuevo", SqlDbType.VarChar, 100).Value = NoSerieListCPU.Text;

                    SqlDataReader dr = cmd.ExecuteReader();

                    Error.Text = "Registrado";
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
                    Error.Text = "";

                    SqlCommand cmd = new SqlCommand("SP_CambioDisp", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("@Portador", SqlDbType.VarChar, 100).Value = NombreTxtList.Text;
                    cmd.Parameters.Add("@NoSerieNuevo", SqlDbType.VarChar, 100).Value = NoSerieListDisp.Text;

                    SqlDataReader dr = cmd.ExecuteReader();

                    Error.Text = "Registrado";
                }
                catch (Exception er)
                {
                    Error.Text = er.Message;
                }
            }
        }

        protected void NoSerieListCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT NoSerie, Tipo, Marca, Modelo, NoInventario FROM CPU WHERE NoSerie = '" + NoSerieListCPU.SelectedItem.Text + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    Error.Text = "";
                    TipoLblEntrega.Text = "Tipo: " + dr["Tipo"].ToString();
                    MarcaLblEntrega.Text = "Marca: " + dr["Marca"].ToString();
                    NoSerieLblEntrega.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                    NoInventarioLblEntrega.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                    ModeloLblEntrega.Text = "Modelo: " + dr["Modelo"].ToString();
                }
            }
            catch(Exception er)
            {
                Error.Text=er.Message;
            }
        }

        protected void BuscarBtn_Click(object sender, EventArgs e)
        {
            if(CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
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
                        TipoLblRetiro.Text = "Tipo: " + dr["Tipo"].ToString();
                        MarcaLbl.Text = "Marca: " + dr["Marca"].ToString();
                        MarcaLblRetiro.Text = "Marca: " + dr["Marca"].ToString();
                        NoSerieLbl.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        NoSerieLblRetiro.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        InventarioLbl.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        NoInventarioLblRetiro.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        ModeloLbl.Text = "Modelo: " + dr["Modelo"].ToString();
                        ModeloLblRetiro.Text = "Modelo: " + dr["Modelo"].ToString();
                        dr.Close();
                    }
                    else
                    {
                        Error.Text = "No hay una computadora ligada.";
                        AreaLbl.Text = "Area: ";
                        TipoLblRetiro.Text = "Tipo: ";
                        MarcaLbl.Text = "Marca: ";
                        MarcaLblRetiro.Text = "Marca: ";
                        NoSerieLbl.Text = "No. De Serie: ";
                        NoSerieLblRetiro.Text = "No. De Serie: ";
                        InventarioLbl.Text = "No. De Inventario: ";
                        NoInventarioLblRetiro.Text = "No. De Inventario: ";
                        ModeloLbl.Text = "Modelo: ";
                        ModeloLblRetiro.Text = "Modelo: ";
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