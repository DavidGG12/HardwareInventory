using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Alpheus_0._6
{
    public partial class computadoras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            string usuario = null;

            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            //VOLVER TODOS LOS REGISTROS EN UPPER CASE
            SqlCommand cmd = new SqlCommand("REGISTRAR_CPU", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();

            if(String.IsNullOrEmpty(UsuarioTxt.Text))
            {
                usuario = "NO";
                /*
                try
                {

                }
                catch(Exception ex)
                {
                    Error.Text = "Error en el registro.";
                }
                */
                cmd.Parameters.Add("@Subarea", SqlDbType.VarChar, 100).Value = SubList.Text;
                cmd.Parameters.Add("@No_Serie", SqlDbType.VarChar, 100).Value = NoSerieTxt.Text;
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value = TipoList.Text;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = usuario;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = NombreTxt.Text;
                cmd.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = MarcaTxt.Text;
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar, 100).Value = ModeloTxt.Text;
                //CONVERTIR RAM Y DISCODURO EN STRING
                cmd.Parameters.Add("@RAM", SqlDbType.Int).Value = RAMTxt.Text;
                cmd.Parameters.Add("@DISCODURO", SqlDbType.Int).Value = DiscoTxt.Text;

                cmd.Parameters.Add("@SO", SqlDbType.VarChar, 100).Value = SOText.Text;
                cmd.Parameters.Add("@Office", SqlDbType.VarChar, 100).Value = OfficeTxt.Text;
                //COLOCAR MÁS TEXT BOX A PROCESADOR PARA LOS GHZ Y TIPO
                cmd.Parameters.Add("@Procesador", SqlDbType.VarChar, 100).Value = ProcesadorTxt.Text;
                cmd.Parameters.Add("@Mouse", SqlDbType.VarChar, 100).Value = MouseList.Text;
                cmd.Parameters.Add("@Teclado", SqlDbType.VarChar, 100).Value = TecladoList.Text;
                cmd.Parameters.Add("@Monitor", SqlDbType.VarChar, 100).Value = MonitorList.Text;
                cmd.Parameters.Add("@NoInventario", SqlDbType.VarChar, 100).Value = NoInventarioTxt.Text;
                cmd.Parameters.Add("@Estatus", SqlDbType.VarChar, 100).Value = EstatusList.Text;
                
                //CONVERTIR FECHAS EN DATE
                cmd.Parameters.Add("@Fecha_ult", SqlDbType.Date).Value = FechaUltTxt.Text;
                cmd.Parameters.Add("@Fecha_pro", SqlDbType.Date).Value = FechaProxTxt.Text;

                cmd.Parameters.Add("@Encargado", SqlDbType.VarChar, 100).Value = EncargadoList.Text;
                cmd.Parameters.Add("@Observacion", SqlDbType.Text).Value = ObservacionTxt.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Error.Text = "No Registrado";
                }
                else
                {
                    Error.Text = "Registrado";
                }
            }
            else 
            {
                usuario = UsuarioTxt.Text;

                cmd.Parameters.Add("@Subarea", SqlDbType.VarChar, 100).Value = SubList.Text;
                cmd.Parameters.Add("@No_Serie", SqlDbType.VarChar, 100).Value = NoSerieTxt.Text;
                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value = TipoList.Text;
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = usuario;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = NombreTxt.Text;
                cmd.Parameters.Add("@Marca", SqlDbType.VarChar, 100).Value = MarcaTxt.Text;
                cmd.Parameters.Add("@Modelo", SqlDbType.VarChar, 100).Value = ModeloTxt.Text;
                //CONVERTIR RAM Y DISCODURO EN STRING
                cmd.Parameters.Add("@RAM", SqlDbType.Int).Value = RAMTxt.Text;
                cmd.Parameters.Add("@DISCODURO", SqlDbType.Int).Value = DiscoTxt.Text;

                cmd.Parameters.Add("@SO", SqlDbType.VarChar, 100).Value = SOText.Text;
                cmd.Parameters.Add("@Office", SqlDbType.VarChar, 100).Value = OfficeTxt.Text;
                //COLOCAR MÁS TEXT BOX A PROCESADOR PARA LOS GHZ Y TIPO
                cmd.Parameters.Add("@Procesador", SqlDbType.VarChar, 100).Value = ProcesadorTxt.Text;
                cmd.Parameters.Add("@Mouse", SqlDbType.VarChar, 100).Value = MouseList.Text;
                cmd.Parameters.Add("@Teclado", SqlDbType.VarChar, 100).Value = TecladoList.Text;
                cmd.Parameters.Add("@Monitor", SqlDbType.VarChar, 100).Value = MonitorList.Text;
                cmd.Parameters.Add("@NoInventario", SqlDbType.VarChar, 100).Value = NoInventarioTxt.Text;
                cmd.Parameters.Add("@Estatus", SqlDbType.VarChar, 100).Value = EstatusList.Text;

                //CONVERTIR FECHAS EN DATE
                cmd.Parameters.Add("@Fecha_ult", SqlDbType.Date).Value = FechaUltTxt.Text;
                cmd.Parameters.Add("@Fecha_pro", SqlDbType.Date).Value = FechaProxTxt.Text;

                cmd.Parameters.Add("@Encargado", SqlDbType.VarChar, 100).Value = EncargadoList.Text;
                cmd.Parameters.Add("@Observacion", SqlDbType.Text).Value = ObservacionTxt.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Error.Text = "No Registrado";
                }
                else
                {
                    Error.Text = "Registrado";
                }
            }
        }
    }
}
