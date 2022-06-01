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
        protected void Page_Load(object sender, EventArgs e)
        {

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