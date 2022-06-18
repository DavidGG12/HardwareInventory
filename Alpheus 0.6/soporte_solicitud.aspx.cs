using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6.pdf
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["tiposervicio"].ToString() == "PREVENTIVO")
            {
                fecha.Text = Request.Params["fecha"];
                Folio.Text = Request.Params["folio"];
                nombre.Text = Request.Params["nombre"];
                area.Text = Request.Params["area"];
                tipo.Text = Request.Params["tipo"];
                marca.Text = Request.Params["marca"];
                modelo.Text = Request.Params["modelo"];
                noinventario.Text = Request.Params["noinventario"];
                noserie.Text = Request.Params["noserie"];
                observacion.Text = Request.Params["servicio"];
                tecnica.Text = Request.Params["tecnica"];
                soporte.Text = Request.Params["soporte"];
                preventivo.Text = "////";
            }
            else if(Request.Params["tiposervicio"].ToString() == "CORRECTIVO")
            {
                fecha.Text = Request.Params["fecha"];
                Folio.Text = Request.Params["folio"];
                nombre.Text = Request.Params["nombre"];
                area.Text = Request.Params["area"];
                tipo.Text = Request.Params["tipo"];
                marca.Text = Request.Params["marca"];
                modelo.Text = Request.Params["modelo"];
                noinventario.Text = Request.Params["noinventario"];
                noserie.Text = Request.Params["noserie"];
                observacion.Text = Request.Params["servicio"];
                tecnica.Text = Request.Params["tecnica"];
                soporte.Text = Request.Params["soporte"];
                correctivo.Text = "////";
            }
            else
            {
                fecha.Text = Request.Params["fecha"];
                Folio.Text = Request.Params["folio"];
                nombre.Text = Request.Params["nombre"];
                area.Text = Request.Params["area"];
                tipo.Text = Request.Params["tipo"];
                marca.Text = Request.Params["marca"];
                modelo.Text = Request.Params["modelo"];
                noinventario.Text = Request.Params["noinventario"];
                noserie.Text = Request.Params["noserie"];
                observacion.Text = Request.Params["servicio"];
                tecnica.Text = Request.Params["tecnica"];
                soporte.Text = Request.Params["soporte"];
                otro.Text = "////";
            }
        }
    }
}