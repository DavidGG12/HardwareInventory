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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["Alpheus"].ConnectionString;
            SqlConnection con = new SqlConnection(conectar);

            //Cambiar parámetros
            SqlCommand cmd = new SqlCommand("spAgregaCPU", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();

            //cmd.Parameters.Add("@idArea", SqlDbType.Int).Value = Usuario.Text;
        }
    }
}
