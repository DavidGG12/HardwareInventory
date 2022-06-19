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
        static string NoControl, ID_Buscar, noserie;
        static string folio, nombre_servicio, area, marca, noinventario, modelo, servicio, tipo_d, tipo_servicio, tecnica, soporte;

        static string fecha_realizada = DateTime.Now.ToString("dd/MM/yyyy");
        static DateTime fecha_usada = Convert.ToDateTime(fecha_realizada);
        static DateTime fecha_programadapre = fecha_usada.AddMonths(6);
        static string fecha_programada = Convert.ToString(fecha_programadapre);

        protected void Page_Load(object sender, EventArgs e)
        {
            Sesion nombre = new Sesion();
            String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

            SesionLbl.Text = nombre.Nombre(UsuarioLogeado).ToString();
        }

        protected void RegistrarBtn_Click(object sender, EventArgs e)
        {
            if(CPU_DISP_RBtnList.SelectedItem.Text == "CPU")
            {
                try
                {
                    con.Open();

                    Sesion nombre = new Sesion();
                    String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

                    SqlCommand cmd = new SqlCommand("SP_Mantenimiento", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if(String.IsNullOrEmpty(FolioTxt.Text) || String.IsNullOrEmpty(ServicioTxt.Text) || String.IsNullOrEmpty(DescripcionFallaTxt.Text) || String.IsNullOrEmpty(DescripcionSoporteTxt.Text) || String.IsNullOrEmpty(TipoMantenimientoRBtnList.SelectedItem.Text))
                    {
                        Error.Text = "Algún campo está vacío.";
                    }
                    else
                    {
                        string tipo = TipoMantenimientoRBtnList.SelectedItem.Text.ToUpper();
                        tecnica = DescripcionFallaTxt.Text;
                        soporte = DescripcionSoporteTxt.Text;
                        servicio = ServicioTxt.Text;

                        if(TipoMantenimientoRBtnList.SelectedItem.Text == "Otro:")
                        {
                            OtroTxt.Enabled = true;

                            if(String.IsNullOrEmpty(OtroTxt.Text))
                            {
                                Error.Text = "Algún campo está vacío.";
                            }
                            else
                            {
                                cmd.Parameters.Add("@Folio", SqlDbType.VarChar, 500).Value = FolioTxt.Text;
                                cmd.Parameters.Add("@NoSerie", SqlDbType.VarChar, 100).Value = noserie;
                                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value = OtroTxt.Text.ToUpper();
                                cmd.Parameters.Add("@Fecha_Programada", SqlDbType.Date).Value = fecha_programada;
                                cmd.Parameters.Add("@Fecha_Realizada", SqlDbType.Date).Value = fecha_realizada;
                                cmd.Parameters.Add("@Encargado", SqlDbType.VarChar, 100).Value = UsuarioLogeado;

                                folio = FolioTxt.Text;
                                tipo_servicio = OtroTxt.Text;

                                SqlDataReader dr = cmd.ExecuteReader();
                                Error.Text = "Generado";
                                Response.Redirect("soporte_solicitud.aspx?folio=" + folio
                                + "&fecha=" + fecha_realizada
                                + "&nombre=" + nombre_servicio
                                + "&area=" + area
                                + "&marca=" + marca
                                + "&noinventario" + noinventario
                                + "&modelo=" + modelo
                                + "&tiposervicio=" + tipo_servicio
                                + "&tecnica=" + tecnica
                                + "&soporte=" + soporte
                                + "&noserie=" + noserie
                                +"&servicio="+servicio
                                +"&tipo="+tipo_d);
                            }
                        }
                        else
                        {
                            cmd.Parameters.Add("@Folio", SqlDbType.VarChar, 500).Value = FolioTxt.Text;
                            cmd.Parameters.Add("@NoSerie", SqlDbType.VarChar, 100).Value = noserie;
                            cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value = tipo;
                            cmd.Parameters.Add("@Fecha_Programada", SqlDbType.Date).Value = fecha_programada;
                            cmd.Parameters.Add("@Fecha_Realizada", SqlDbType.Date).Value = fecha_realizada;
                            cmd.Parameters.Add("@Encargado", SqlDbType.VarChar, 100).Value = UsuarioLogeado;

                            folio = FolioTxt.Text;
                            tipo_servicio = tipo;

                            SqlDataReader dr = cmd.ExecuteReader();
                            Error.Text = "Generado";

                            Response.Redirect("soporte_solicitud.aspx?folio="+folio
                                +"&fecha="+fecha_realizada
                                +"&nombre="+nombre_servicio
                                +"&area="+area
                                +"&marca="+marca
                                +"&noinventario"+noinventario
                                +"&modelo="+modelo
                                +"&tiposervicio="+tipo_servicio
                                +"&tecnica="+tecnica
                                +"&soporte="+soporte
                                + "&noserie=" + noserie
                                + "&servicio=" + servicio
                                + "&tipo=" + tipo_d);
                        }
                    }

                    con.Close();
                }
                catch(Exception er)
                {
                    Error.Text = er.Message;
                }
            }
            else
            {
                try
                {
                    con.Open();

                    Sesion nombre = new Sesion();
                    String UsuarioLogeado = Session["UsuarioLogeado"].ToString();

                    SqlCommand cmd = new SqlCommand("SP_MantenimientoDisp", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (String.IsNullOrEmpty(FolioTxt.Text) || String.IsNullOrEmpty(ServicioTxt.Text) || String.IsNullOrEmpty(DescripcionFallaTxt.Text) || String.IsNullOrEmpty(DescripcionSoporteTxt.Text) || String.IsNullOrEmpty(TipoMantenimientoRBtnList.SelectedItem.Text))
                    {
                        Error.Text = "Algún campo está vacío.";
                    }
                    else
                    {
                        string tipo = TipoMantenimientoRBtnList.SelectedItem.Text.ToUpper();
                        tecnica = DescripcionFallaTxt.Text;
                        soporte = DescripcionSoporteTxt.Text;
                        servicio = ServicioTxt.Text;

                        if (TipoMantenimientoRBtnList.SelectedItem.Text == "Otro:")
                        {
                            OtroTxt.Enabled = true;

                            if (String.IsNullOrEmpty(OtroTxt.Text))
                            {
                                Error.Text = "Algún campo está vacío.";
                            }
                            else
                            {
                                cmd.Parameters.Add("@Folio", SqlDbType.VarChar, 500).Value = FolioTxt.Text;
                                cmd.Parameters.Add("@NoSerie", SqlDbType.VarChar, 100).Value = noserie;
                                cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value = OtroTxt.Text.ToUpper();
                                cmd.Parameters.Add("@Fecha_Programada", SqlDbType.Date).Value = fecha_programada;
                                cmd.Parameters.Add("@Fecha_Realizada", SqlDbType.Date).Value = fecha_realizada;
                                cmd.Parameters.Add("@Encargado", SqlDbType.VarChar, 100).Value = UsuarioLogeado;

                                folio = FolioTxt.Text;
                                tipo_servicio = OtroTxt.Text;

                                SqlDataReader dr = cmd.ExecuteReader();
                                Error.Text = "Generado";
                                Response.Redirect("soporte_solicitud.aspx?folio=" + folio
                                + "&fecha=" + fecha_realizada
                                + "&nombre=" + nombre_servicio
                                + "&area=" + area
                                + "&marca=" + marca
                                + "&noinventario" + noinventario
                                + "&modelo=" + modelo
                                + "&tiposervicio=" + tipo_servicio
                                + "&tecnica=" + tecnica
                                + "&soporte=" + soporte
                                + "&noserie=" + noserie
                                + "&servicio=" + servicio
                                + "&tipo=" + tipo_d);
                            }
                        }
                        else
                        {
                            cmd.Parameters.Add("@Folio", SqlDbType.VarChar, 500).Value = FolioTxt.Text;
                            cmd.Parameters.Add("@NoSerie", SqlDbType.VarChar, 100).Value = noserie;
                            cmd.Parameters.Add("@Tipo", SqlDbType.VarChar, 100).Value = tipo;
                            cmd.Parameters.Add("@Fecha_Programada", SqlDbType.Date).Value = fecha_programada;
                            cmd.Parameters.Add("@Fecha_Realizada", SqlDbType.Date).Value = fecha_realizada;
                            cmd.Parameters.Add("@Encargado", SqlDbType.VarChar, 100).Value = UsuarioLogeado;

                            folio = FolioTxt.Text;
                            tipo_servicio = tipo;

                            SqlDataReader dr = cmd.ExecuteReader();
                            Error.Text = "Generado";
                            Response.Redirect("soporte_solicitud.aspx?folio=" + folio
                                + "&fecha=" + fecha_realizada
                                + "&nombre=" + nombre_servicio
                                + "&area=" + area
                                + "&marca=" + marca
                                + "&noinventario" + noinventario
                                + "&modelo=" + modelo
                                + "&tiposervicio=" + tipo_servicio
                                + "&tecnica=" + tecnica
                                + "&soporte=" + soporte
                                +"&noserie="+noserie
                                + "&servicio=" + servicio
                                + "&tipo=" + tipo_d);
                        }
                    }

                    con.Close();
                }
                catch (Exception er)
                {
                    Error.Text = er.Message;
                }
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
                        dr.Close();
                    }
                    else
                    {
                        Error.Text = "No jale";
                    }

                    nombre_servicio = portador;

                    //SELECCIONAR EL ÁREA
                    cmd = new SqlCommand("SELECT Subarea FROM Subareas WHERE ID ='" + Area + "'", con);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Error.Text = "";
                        AreaLbl.Text = "Area: " + dr["Subarea"].ToString();
                        area = dr["Subarea"].ToString();
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
                        noserie = dr["NoSerie"].ToString();
                        MarcaLbl.Text = "Marca: " + dr["Marca"].ToString();
                        marca = dr["Marca"].ToString();
                        NoSerieLbl.Text = "No. De Serie: " + dr["NoSerie"].ToString();
                        InventarioLbl.Text = "No. De Inventario: " + dr["NoInventario"].ToString();
                        noinventario = dr["NoInventario"].ToString();
                        ModeloLbl.Text = "Modelo: " + dr["Modelo"].ToString();
                        modelo = dr["Modelo"].ToString();
                        tipo_d = dr["Tipo"].ToString();
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
                        tipo_d = dr["Tipo"].ToString();
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

        protected void TipoMantenimientoRBtnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoMantenimientoRBtnList.SelectedItem.Text == "Otro:")
            {
                OtroTxt.Enabled = true;
            }
            else
            {
                OtroTxt.Enabled = false;
            }
        }
    }
}