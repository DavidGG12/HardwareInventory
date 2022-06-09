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
        public Boolean bandera = false;
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

        protected void Registrar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);


        }

        protected void Buscar_Click(object sender, EventArgs e)
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
                                Nombre = Datos.Rows[0].ItemArray[3].ToString(),
                                Marca = Datos.Rows[0].ItemArray[4].ToString(),
                                Modelo = Datos.Rows[0].ItemArray[5].ToString(),
                                RAM = Datos.Rows[0].ItemArray[6].ToString(),
                                DiscoDuro = Datos.Rows[0].ItemArray[7].ToString(),
                                SO = Datos.Rows[0].ItemArray[8].ToString(),
                                Office = Datos.Rows[0].ItemArray[9].ToString(),
                                Procesador = Datos.Rows[0].ItemArray[10].ToString(),
                                NoInventario = Datos.Rows[0].ItemArray[11].ToString()
                            });

                            //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                            InsertBusq();
                        }
                        else
                        {
                            error.Text = "Registro ya ingresado.";
                        }
                    }
                }
                //BÚSQUEDA POR 'NO DE INVENTARIO'
                else
                {
                    query = "SELECT NoSerie, Tipo, Nombre, Marca, Modelo, [RAM GB], [DiscoDuro GB], SO, Office, Procesador, NoInventario FROM CPU WHERE NoInventario = '" + BuscarTxt.Text + "'";
                    SqlDataAdapter adapterInventario = new SqlDataAdapter(query, con);
                    DataTable DatosInventario = new DataTable();
                    adapterInventario.Fill(DatosInventario);

                    if (DatosInventario.Rows.Count > 0)
                    {
                        if (ViewState["CPU"] == null)
                        {
                            for (int j = 0; j < DatosInventario.Rows.Count; j++)
                            {
                                if (ViewState["CPU"] != null)
                                {
                                    Agregar = ViewState["CPU"] as List<Busqueda.GridV>;
                                }
                                //REGISTRA TODA LA CONSULTA EN EL GRID
                                Agregar.Add(new Busqueda.GridV
                                {
                                    NoSerie = DatosInventario.Rows[j].ItemArray[0].ToString(),
                                    Tipo = DatosInventario.Rows[j].ItemArray[1].ToString(),
                                    Nombre = DatosInventario.Rows[j].ItemArray[3].ToString(),
                                    Marca = DatosInventario.Rows[j].ItemArray[4].ToString(),
                                    Modelo = DatosInventario.Rows[j].ItemArray[5].ToString(),
                                    RAM = DatosInventario.Rows[j].ItemArray[6].ToString(),
                                    DiscoDuro = DatosInventario.Rows[j].ItemArray[7].ToString(),
                                    SO = DatosInventario.Rows[j].ItemArray[8].ToString(),
                                    Office = DatosInventario.Rows[j].ItemArray[9].ToString(),
                                    Procesador = DatosInventario.Rows[j].ItemArray[10].ToString(),
                                    NoInventario = DatosInventario.Rows[j].ItemArray[11].ToString()
                                });

                                //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                                InsertBusq();
                            }
                        }
                        else
                        {
                            bandera = false;


                            for (int i = 0; i <= Agregar.Count; i++)
                            {
                                if (CPUGrid.SelectedRow.Cells[11].Text == BuscarTxt.Text)
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
                                    Tipo = DatosInventario.Rows[0].ItemArray[1].ToString(),
                                    Nombre = DatosInventario.Rows[0].ItemArray[3].ToString(),
                                    Marca = DatosInventario.Rows[0].ItemArray[4].ToString(),
                                    Modelo = DatosInventario.Rows[0].ItemArray[5].ToString(),
                                    RAM = DatosInventario.Rows[0].ItemArray[6].ToString(),
                                    DiscoDuro = DatosInventario.Rows[0].ItemArray[7].ToString(),
                                    SO = DatosInventario.Rows[0].ItemArray[8].ToString(),
                                    Office = DatosInventario.Rows[0].ItemArray[9].ToString(),
                                    Procesador = DatosInventario.Rows[0].ItemArray[10].ToString(),
                                    NoInventario = DatosInventario.Rows[0].ItemArray[11].ToString()
                                });

                                //COLOCAR OTRO QUERY PARA MANDAR A TRAER EL AREA Y LAS FECHAS DEL MANTENIMIENTO

                                InsertBusq();
                            }
                            else
                            {
                                error.Text = "Error";
                            }
                        }
                    }
                    //COLOCAR BUSQUEDA EN DISPOSITIVOS
                    else
                    {
                        query = "SELECT NoSerie, Tipo, Marca, Modelo, NoInventario FROM Dispositivos WHERE NoSerie = '" + BuscarTxt.Text + "'";
                        SqlDataAdapter adapterDisp = new SqlDataAdapter(query, con);
                        DataTable DatosDisp = new DataTable();
                        adapterDisp.Fill(DatosDisp);


                    }
                }
                con.Close();
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
    }
}