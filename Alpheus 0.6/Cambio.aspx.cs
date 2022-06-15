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
                    SqlCommand cmd = new SqlCommand("SP_CambioCPU", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("@Portador", SqlDbType.VarChar, 100).Value = NombreList.Text;
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
                    SqlCommand cmd = new SqlCommand("SP_CambioDisp", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Connection.Open();

                    cmd.Parameters.Add("@Portador", SqlDbType.VarChar, 100).Value = NombreList.Text;
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

        protected void BuscarBtn_Click(object sender, EventArgs e)
        {

            string portador = NombreList.Text;
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT idArea_Destino, NoControlInterno FROM Transferencia WHERE Usuario_Recibidor = '" + portador + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                String NoControl = dr["NoControlInterno"].ToString(), ID = dr["idArea_Destino"].ToString();
                int Area = int.Parse(ID);
                
                dr.Close();

                //SELECCIONAR EL ÁREA
                cmd = new SqlCommand("SELECT Subarea FROM Subareas WHERE ID ='" + Area + "'", con);
                dr = cmd.ExecuteReader();
                AreaLbl.Text = "Area: " + dr["Subarea"].ToString();
                dr.Close();

                cmd = new SqlCommand("SELECT Marca, NoSerie, NoInventario, Modelo FROM CPU WHERE idTransferencia = '" + NoControl + "'",con);
                dr = cmd.ExecuteReader();
                MarcaLbl.Text = dr["Marca"].ToString();
                NoSerieLbl.Text = dr["NoSerie"].ToString();
                InventarioLbl.Text = dr["NoInventario"].ToString();
                ModeloLbl.Text = dr["Modelo"].ToString();
                dr.Close();

                con.Close();
            }
            catch (Exception er)
            {
                Error.Text = er.Message;
            }
        }
    }
}