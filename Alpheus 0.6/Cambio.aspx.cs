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
        List<Busqueda.Cambio> Agregar = new List<Busqueda.Cambio>();

        static string conectar = System.Configuration.ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
        System.Data.SqlClient.SqlConnection con = new SqlConnection(conectar);
        static int Area;
        static string NoControl, ID_Buscar;
        static string folio_cad, nombre_cad, area_cad, marca_retira, noserie_retira, modelo_retira, noinventario_retira, razon, tipo_retira;

        static string marca_entrega, noserie_entrega, modelo_entrega, noinventario_entrega, tipo_entrega;
        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion nombre = new Sesion();
            String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

            SesionLbl.Text = nombre.Nombre(UsuarioLogeado).ToString();
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

        protected void BuscarBtn_Click(object sender, EventArgs e)
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

                        nombre_cad = portador;

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

                        area_cad = dr["Subarea"].ToString();

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
                        tipo_retira = dr["Tipo"].ToString();
                        MarcaLbl.Text = "Marca: " + dr["Marca"].ToString();
                        MarcaLblRetiro.Text = "Marca: " + dr["Marca"].ToString();
                        marca_retira = dr["Marca"].ToString();
                        NoSerieLbl.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        NoSerieLblRetiro.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        noserie_retira = dr["NoSerie"].ToString();
                        InventarioLbl.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        NoInventarioLblRetiro.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        noinventario_retira = dr["NoInventario"].ToString();
                        ModeloLbl.Text = "Modelo: " + dr["Modelo"].ToString();
                        ModeloLblRetiro.Text = "Modelo: " + dr["Modelo"].ToString();
                        modelo_retira = dr["Modelo"].ToString();
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
                        TipoLblRetiro.Text = "Tipo: " + dr["Tipo"].ToString();
                        tipo_retira = dr["Tipo"].ToString();
                        MarcaLbl.Text = "Marca: " + dr["Marca"].ToString();
                        MarcaLblRetiro.Text = "Marca: " + dr["Marca"].ToString();
                        marca_retira = dr["Marca"].ToString();
                        NoSerieLbl.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        NoSerieLblRetiro.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        noserie_retira = dr["NoSerie"].ToString();
                        InventarioLbl.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        NoInventarioLblRetiro.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        noinventario_retira = dr["NoInventario"].ToString();
                        ModeloLbl.Text = "Modelo: " + dr["Modelo"].ToString();
                        ModeloLblRetiro.Text = "Modelo: " + dr["Modelo"].ToString();
                        modelo_retira = dr["Modelo"].ToString();
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

        protected void RegistrarBtn_Click(object sender, EventArgs e)
        {
            if(CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
            {
                
                try
                {
                    Error.Text = "";
                    
                    if(String.IsNullOrEmpty(FolioTxt.Text) || String.IsNullOrEmpty(ObservacionTxt.Text) || String.IsNullOrEmpty(noserie_entrega) || String.IsNullOrEmpty(noserie_retira))
                    {
                        Error.Text = "Alguno de los campos está vacío." +noserie_entrega + noserie_retira;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("SP_CambioCPU", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        folio_cad = FolioTxt.Text;
                        razon = ObservacionTxt.Text;

                        cmd.Connection.Open();

                        cmd.Parameters.Add("@Portador", SqlDbType.VarChar, 100).Value = NombreTxtList.Text;
                        cmd.Parameters.Add("@NoSerieNuevo", SqlDbType.VarChar, 100).Value = NoSerieListCPU.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        Error.Text = "Registrado";
                        Response.Redirect("entregaRetiro.aspx?folio="+folio_cad.ToString()
                            +"&CPU_Disp=CPU"
                            +"&nombre="+nombre_cad.ToString()
                            +"&observacion="+ObservacionTxt.Text
                            +"&area="+area_cad.ToString()
                            +"&tipo_retira="+tipo_retira.ToString()
                            +"&marca_retira="+marca_retira.ToString()
                            +"&noserie_retira="+noserie_retira.ToString()
                            +"&noinventario_retira="+noinventario_retira.ToString()
                            +"&modelo_retira"+modelo_retira.ToString()
                            +"&marca_entrega"+marca_entrega.ToString()
                            +"&modelo_entrega"+modelo_entrega.ToString()
                            +"&noserie_entrega=" + noserie_entrega.ToString()
                            +"&noinventario_retira=" + noinventario_entrega.ToString());
                    }
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

                    Response.Redirect("entregaRetiro.aspx?folio=" + folio_cad.ToString()
                            + "&CPU_Disp=Disp"
                            + "&nombre=" + nombre_cad.ToString()
                            + "&observacion=" + ObservacionTxt.Text
                            + "&area=" + area_cad.ToString()
                            + "&tipo_retira=" + tipo_retira.ToString()
                            + "&marca_retira=" + marca_retira.ToString()
                            + "&noserie_retira=" + noserie_retira.ToString()
                            + "&noinventario_retira=" + noinventario_retira.ToString()
                            + "&modelo_retira" + modelo_retira.ToString()
                            + "&marca_entrega" + marca_entrega.ToString()
                            + "&modelo_entrega" + modelo_entrega.ToString()
                            + "&noserie_entrega=" + noserie_entrega.ToString()
                            + "&noinventario_retira=" + noinventario_entrega.ToString());

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
                    tipo_entrega = dr["Tipo"].ToString();
                    MarcaLblEntrega.Text = "Marca: " + dr["Marca"].ToString();
                    marca_entrega = dr["Marca"].ToString();
                    NoSerieLblEntrega.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                    noserie_entrega = dr["NoSerie"].ToString();
                    NoInventarioLblEntrega.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                    noinventario_entrega = dr["NoInventario"].ToString();
                    ModeloLblEntrega.Text = "Modelo: " + dr["Modelo"].ToString();
                    modelo_entrega = dr["Modelo"].ToString();
                }
            }
            catch(Exception er)
            {
                Error.Text=er.Message;
            }
        }

        protected void NoSerieListDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT NoSerie, Tipo, Marca, Modelo, NoInventario FROM Dispositivos WHERE NoSerie = '" + NoSerieListDisp.SelectedItem.Text + "'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Error.Text = "";
                    TipoLblEntrega.Text = "Tipo: " + dr["Tipo"].ToString();
                    tipo_entrega = dr["Tipo"].ToString();
                    MarcaLblEntrega.Text = "Marca: " + dr["Marca"].ToString();
                    marca_entrega = dr["Marca"].ToString();
                    NoSerieLblEntrega.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                    noserie_entrega = dr["NoSerie"].ToString();
                    NoInventarioLblEntrega.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                    noinventario_entrega = dr["NoInventario"].ToString();
                    ModeloLblEntrega.Text = "Modelo: " + dr["Modelo"].ToString();
                    modelo_entrega = dr["Modelo"].ToString();
                }
            }
            catch (Exception er)
            {
                Error.Text = er.Message;
            }
        }
    }
}