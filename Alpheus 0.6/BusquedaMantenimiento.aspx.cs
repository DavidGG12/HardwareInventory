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
    public partial class BusquedaMantenimiento : System.Web.UI.Page
    {
        List<BusquedaMantenimientoClase.GridV> Agregar = new List<BusquedaMantenimientoClase.GridV>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Insertarlos en la tabla
        protected void InsertBusq()
        {
            ViewState["Area"] = Agregar;
            AreaGrid.DataSource = Agregar;
            AreaGrid.DataBind();
            for(int k = 0; k < Agregar.Count; k++)
            {
                AreaGrid.SelectedIndex = k;
                AreaGrid.SelectedRow.Cells[0].Text = Agregar[k].id;
                AreaGrid.SelectedRow.Cells[1].Text = Agregar[k].Dat1;
            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["MatiasConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);
            string query;

            if (String.IsNullOrEmpty(Buscartxt.Text))
            {
                LabelPrueba.Text = "No se han encontrado registros";
            }
            else
            {
                query = "SELECT Area FROM Areas WHERE ID = '" + Buscartxt.Text + "'";
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable Datos = new DataTable();
                adapter.Fill(Datos);

                if (Datos.Rows.Count > 0)
                {
                    LabelPrueba.Text = Datos.Rows[0].ItemArray[0].ToString();
                    if (ViewState["Area"] != null)
                    {
                        Agregar = ViewState["Area"] as List<BusquedaMantenimientoClase.GridV>;
                    }
                    Agregar.Add(new BusquedaMantenimientoClase.GridV { id = Buscartxt.Text, Dat1 = LabelPrueba.Text });
                    InsertBusq();
                }
                else
                {
                    LabelPrueba.Text = "No se han encontrado registros";
                }
                con.Close();
            }
        }
    }
}