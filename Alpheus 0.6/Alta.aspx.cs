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
    public partial class Alta : System.Web.UI.Page
    {
        List<Busqueda.GridV> Agregar = new List<Busqueda.GridV>();
        List<Busqueda.GridVDisp> AgregarDisp = new List<Busqueda.GridVDisp>();
        public Boolean bandera = false;
        VerificarTrans Verificar = new VerificarTrans();
        Dispositivos Dispositivos = new Dispositivos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Insertarlos en la tabla
        protected void InsertBusq()
        {
            ViewState["CPU"] = Agregar;
            CPUGrid.DataSource = Agregar;
            CPUGrid.DataBind();
            for (int k = 0; k < Agregar.Count; k++)
            {
                CPUGrid.SelectedIndex = k;
                CPUGrid.SelectedRow.Cells[0].Text = Agregar[k].NoSerie;
                CPUGrid.SelectedRow.Cells[1].Text = Agregar[k].Tipo;
                CPUGrid.SelectedRow.Cells[2].Text = Agregar[k].Nombre;
                CPUGrid.SelectedRow.Cells[3].Text = Agregar[k].Marca;
                CPUGrid.SelectedRow.Cells[4].Text = Agregar[k].Modelo;
                CPUGrid.SelectedRow.Cells[5].Text = Agregar[k].RAM;
                CPUGrid.SelectedRow.Cells[6].Text = Agregar[k].DiscoDuro;
                CPUGrid.SelectedRow.Cells[7].Text = Agregar[k].SO;
                CPUGrid.SelectedRow.Cells[8].Text = Agregar[k].Office;
                CPUGrid.SelectedRow.Cells[9].Text = Agregar[k].Procesador;
                CPUGrid.SelectedRow.Cells[10].Text = Agregar[k].NoInventario;
            }
        }

        protected void InsertarDisp()
        {
            ViewState["Disp"] = AgregarDisp;
            DisGrid.DataSource = AgregarDisp;
            DisGrid.DataBind();
            for (int k = 0; k < AgregarDisp.Count; k++)
            {
                DisGrid.SelectedIndex = k;
                DisGrid.SelectedRow.Cells[0].Text = AgregarDisp[k].NoSerieDisp;
                DisGrid.SelectedRow.Cells[1].Text = AgregarDisp[k].TipoDisp;
                DisGrid.SelectedRow.Cells[2].Text = AgregarDisp[k].MarcaDisp;
                DisGrid.SelectedRow.Cells[3].Text = AgregarDisp[k].ModeloDisp;
                DisGrid.SelectedRow.Cells[4].Text = AgregarDisp[k].NoInventarioDisp;
            }
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                int rows = CPUGrid.Rows.Count, rowsDisp = DisGrid.Rows.Count;
                string teclado, mouse, monitor;

                string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(conectar);

                SqlCommand cmd = new SqlCommand("SP_TransferenciaCPU", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Connection.Open();

                if(String.IsNullOrEmpty(NoControlTxt.Text) || String.IsNullOrEmpty(RecibeTxt.Text) || String.IsNullOrEmpty(MotivoTxt.Text))
                {
                    Errorl.Text = "Alguno de los campos está vacío.";
                }
                else
                {
                    RecibeTxt.Text = NoControlTxt.Text.ToUpper();
                    MotivoTxt.Text = MotivoTxt.Text.ToUpper();

                    if(rows > 1)
                    {
                        Errorl.Text = "¡Lo siento! Solo se puede transferir un equipo por persona."+rows;
                    }
                    else if(rows == 1)
                    {
                        if(rowsDisp == 0)
                        {
                            try
                            {
                                teclado = "NO";
                                monitor = "NO";
                                mouse = "NO";

                                cmd.Parameters.Add("@Mouse", SqlDbType.VarChar, 100).Value = mouse;
                                cmd.Parameters.Add("@Teclado", SqlDbType.VarChar, 100).Value = teclado;
                                cmd.Parameters.Add("@Monitor", SqlDbType.VarChar, 100).Value = monitor;
                                cmd.Parameters.Add("@NoSerieCPU", SqlDbType.VarChar, 100).Value = CPUGrid.SelectedRow.Cells[0].Text;
                                cmd.Parameters.Add("@NoControl", SqlDbType.VarChar, 500).Value = NoControlTxt.Text;
                                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = UsuarioList.Text;
                                cmd.Parameters.Add("@Subarea", SqlDbType.VarChar, 100).Value = AreaDestinoList.Text;
                                cmd.Parameters.Add("@Usuario_Recibe", SqlDbType.VarChar, 100).Value = RecibeTxt.Text;
                                cmd.Parameters.Add("@Fecha_Emision", SqlDbType.Date).Value = fecha;
                                cmd.Parameters.Add("@Fecha_Entrega", SqlDbType.Date).Value = fecha;

                                SqlDataReader dr = cmd.ExecuteReader();
                                Errorl.Text = Verificar.RollBack_Commit(NoControlTxt.Text, CPUGrid.SelectedRow.Cells[0].Text);
                            }
                            catch (Exception er)
                            {
                                Errorl.Text = er.Message;
                            }
                        }
                        else 
                        {
                            teclado = "NO";
                            monitor = "NO";
                            mouse = "NO";

                            //IMPLEMENTAR SP DE CPU Y DISP
                            for (int i = 0; i <= rowsDisp; i++)
                            {
                                if(Dispositivos.Mouse(DisGrid.SelectedRow.Cells[0].Text, NoControlTxt.Text) == "SI")
                                {
                                    mouse = DisGrid.SelectedRow.Cells[0].Text;
                                    break;
                                }
                            }

                            for (int i = 0; i <= rowsDisp; i++)
                            {
                                if (Dispositivos.Monitor(DisGrid.SelectedRow.Cells[0].Text, NoControlTxt.Text) == "SI")
                                {
                                    monitor = DisGrid.SelectedRow.Cells[0].Text;
                                    break;
                                }
                            }

                            for (int i = 0; i <= rowsDisp; i++)
                            {
                                if (Dispositivos.Teclado(DisGrid.SelectedRow.Cells[0].Text, NoControlTxt.Text) == "SI")
                                {
                                    teclado = DisGrid.SelectedRow.Cells[0].Text;
                                    break;
                                }
                            }

                            if(teclado == "SI" || monitor == "SI" || mouse == "SI")
                            {
                                cmd.Parameters.Add("@Mouse", SqlDbType.VarChar, 100).Value = mouse;
                                cmd.Parameters.Add("@Teclado", SqlDbType.VarChar, 100).Value = teclado;
                                cmd.Parameters.Add("@Monitor", SqlDbType.VarChar, 100).Value = monitor;
                                cmd.Parameters.Add("@NoSerieCPU", SqlDbType.VarChar, 100).Value = CPUGrid.SelectedRow.Cells[0].Text;
                                cmd.Parameters.Add("@NoControl", SqlDbType.VarChar, 500).Value = NoControlTxt.Text;
                                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = UsuarioList.Text;
                                cmd.Parameters.Add("@Subarea", SqlDbType.VarChar, 100).Value = AreaDestinoList.Text;
                                cmd.Parameters.Add("@Usuario_Recibe", SqlDbType.VarChar, 100).Value = RecibeTxt.Text;
                                cmd.Parameters.Add("@Fecha_Emision", SqlDbType.Date).Value = fecha;
                                cmd.Parameters.Add("@Fecha_Entrega", SqlDbType.Date).Value = fecha;
                                
                                SqlDataReader dr = cmd.ExecuteReader();
                            }
                            else
                            {
                                Errorl.Text = "Tienes que agregar el sp de disp";
                            }

                            
                        }
                    }
                    else
                    {
                        Errorl.Text = "No has buscado el CPU o dispositivo.";
                    }
                }
            }
            catch(Exception er)
            {
                Errorl.Text = er.Message;
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(conectar);
                string query;

                if (String.IsNullOrEmpty(BuscarTxt.Text))
                {
                    error.Text = "Campo vacío.";
                }
                else
                {
                    BuscarTxt.Text = BuscarTxt.Text.ToUpper();

                    query = "SELECT NoSerie, Tipo, Nombre, Marca, Modelo, [RAM GB], [DiscoDuro GB], SO, Office, Procesador, NoInventario FROM CPU WHERE NoSerie = '" + BuscarTxt.Text + "'";
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable Datos = new DataTable();
                    adapter.Fill(Datos);

                    if (Datos.Rows.Count > 0)
                    {
                        if (ViewState["CPU"] == null)
                        {
                            //REGISTRA TODA LA CONSULTA EN EL GRID
                            Agregar.Add(new Busqueda.GridV
                            {
                                NoSerie = BuscarTxt.Text,
                                Tipo = Datos.Rows[0].ItemArray[1].ToString(),
                                Nombre = Datos.Rows[0].ItemArray[2].ToString(),
                                Marca = Datos.Rows[0].ItemArray[3].ToString(),
                                Modelo = Datos.Rows[0].ItemArray[4].ToString(),
                                RAM = Datos.Rows[0].ItemArray[5].ToString(),
                                DiscoDuro = Datos.Rows[0].ItemArray[6].ToString(),
                                SO = Datos.Rows[0].ItemArray[7].ToString(),
                                Office = Datos.Rows[0].ItemArray[8].ToString(),
                                Procesador = Datos.Rows[0].ItemArray[9].ToString(),
                                NoInventario = Datos.Rows[0].ItemArray[10].ToString()
                            });

                            //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                            InsertBusq();
                        }
                        else
                        {
                            bandera = false;


                            for (int i = 0; i <= Agregar.Count; i++)
                            {
                                if (CPUGrid.SelectedRow.Cells[0].Text == BuscarTxt.Text)
                                {
                                    bandera = true;
                                    break;

                                }
                            }

                            if (bandera != true)
                            {
                                Agregar = ViewState["CPU"] as List<Busqueda.GridV>;

                                //REGISTRA TODA LA CONSULTA EN EL GRID
                                Agregar.Add(new Busqueda.GridV
                                {
                                    NoSerie = BuscarTxt.Text,
                                    Tipo = Datos.Rows[0].ItemArray[1].ToString(),
                                    Nombre = Datos.Rows[0].ItemArray[2].ToString(),
                                    Marca = Datos.Rows[0].ItemArray[3].ToString(),
                                    Modelo = Datos.Rows[0].ItemArray[4].ToString(),
                                    RAM = Datos.Rows[0].ItemArray[5].ToString(),
                                    DiscoDuro = Datos.Rows[0].ItemArray[6].ToString(),
                                    SO = Datos.Rows[0].ItemArray[7].ToString(),
                                    Office = Datos.Rows[0].ItemArray[8].ToString(),
                                    Procesador = Datos.Rows[0].ItemArray[9].ToString(),
                                    NoInventario = Datos.Rows[0].ItemArray[10].ToString()
                                });

                                //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                                InsertBusq();
                            }
                        }
                    }
                    else
                    {
                        query = "SELECT NoSerie, Tipo, Marca, Modelo, NoInventario FROM Dispositivos WHERE NoSerie = '" + BuscarTxt.Text + "'";
                        SqlDataAdapter adapterDisp = new SqlDataAdapter(query, con);
                        DataTable DatosDisp = new DataTable();
                        adapterDisp.Fill(DatosDisp);

                        if (DatosDisp.Rows.Count > 0)
                        {
                            if (ViewState["Disp"] == null)
                            {
                                //REGISTRA TODA LA CONSULTA EN EL GRID
                                AgregarDisp.Add(new Busqueda.GridVDisp
                                {
                                    NoSerieDisp = BuscarTxt.Text,
                                    TipoDisp = DatosDisp.Rows[0].ItemArray[1].ToString(),
                                    MarcaDisp = DatosDisp.Rows[0].ItemArray[2].ToString(),
                                    ModeloDisp = DatosDisp.Rows[0].ItemArray[3].ToString(),
                                    NoInventarioDisp = DatosDisp.Rows[0].ItemArray[4].ToString()
                                });

                                //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                                InsertarDisp();
                            }
                            else
                            {
                                bandera = false;


                                for (int i = 0; i <= Agregar.Count; i++)
                                {
                                    if (DisGrid.SelectedRow.Cells[0].Text == BuscarTxt.Text)
                                    {
                                        bandera = true;
                                        break;

                                    }
                                }

                                if (bandera != true)
                                {
                                    AgregarDisp = ViewState["Disp"] as List<Busqueda.GridVDisp>;

                                    //REGISTRA TODA LA CONSULTA EN EL GRID
                                    AgregarDisp.Add(new Busqueda.GridVDisp
                                    {
                                        NoSerieDisp = BuscarTxt.Text,
                                        TipoDisp = DatosDisp.Rows[0].ItemArray[1].ToString(),
                                        MarcaDisp = DatosDisp.Rows[0].ItemArray[2].ToString(),
                                        ModeloDisp = DatosDisp.Rows[0].ItemArray[3].ToString(),
                                        NoInventarioDisp = DatosDisp.Rows[0].ItemArray[4].ToString()
                                    });

                                    //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                                    InsertarDisp();
                                }
                            }
                        }
                        else
                        {
                            error.Text = "Registro no encontrado";
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception er)
            {
                Errorl.Text = er.Message;
            }
            
        }

        protected void QuitarBtn(object sender, GridViewCommandEventArgs e)
        {
            int f = Convert.ToInt32(e.CommandArgument);
            Agregar.Clear();
            Agregar = ViewState["CPU"] as List<Busqueda.GridV>;
            Agregar.RemoveAt(f);
            InsertBusq();
        }

        protected void QuitarBtnDisp(object sender, GridViewCommandEventArgs e)
        {
            int f = Convert.ToInt32(e.CommandArgument);
            AgregarDisp.Clear();
            AgregarDisp = ViewState["Disp"] as List<Busqueda.GridVDisp>;
            AgregarDisp.RemoveAt(f);
            InsertarDisp();
        }
    }
}