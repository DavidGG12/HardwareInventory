using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6.pdf
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        List<Busqueda.Cambio> Agregar = new List<Busqueda.Cambio>();
        Cambio pdf = new Cambio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["CPU_Disp"].ToString() == "CPU")
            {
                Observacion.Text = Request.Params["observacion"];
                folio.Text = Request.Params["folio"];
                nombre.Text = Request.Params["nombre"];
                area.Text = Request.Params["area"];
                tipo.Text = Request.Params["tipo_retira"];
                marca.Text = Request.Params["marca_retira"];
                marca_retiraCPU.Text = Request.Params["marca_retira"];
                marca_entregaCPU.Text = Request.Params["marca_entrega"];
                noserie.Text = Request.Params["noserie_retira"];
                noserie_entregaCPU.Text = Request.Params["noserie_entrega"];
                noserie_retiraCPU.Text = Request.Params["noserie_retira"];
                noinventario.Text = Request.Params["noinventario_retira"];
                noinvetario_retiraCPU.Text = Request.Params["noinventario_retira"];
                noinvetario_entregaCPU.Text = Request.Params["noinventario_entrega"];
                modelo.Text = Request.Params["modelo_retira"];
                modelo_retiraCPU.Text = Request.Params["modelo_retira"];
                modelo_entregaCPU.Text = Request.Params["modelo_entrega"];
            }
            else
            {
                Observacion.Text = Request.Params["observacion"];
                folio.Text = Request.Params["folio"];
                nombre.Text = Request.Params["nombre"];
                area.Text = Request.Params["area"];
                tipo.Text = Request.Params["tipo_retira"];
                marca.Text = Request.Params["marca_retira"];
                marca_retiraDisp.Text = Request.Params["marca_retira"];
                marca_entregaDisp.Text = Request.Params["marca_entrega"];
                noserie.Text = Request.Params["noserie_retira"];
                noserie_entregaDisp.Text = Request.Params["noserie_entrega"];
                noserie_retiraDisp.Text = Request.Params["noserie_retira"];
                noinventario.Text = Request.Params["noinventario_retira"];
                noinvetario_retiraDisp.Text = Request.Params["noinventario_retira"];
                noinvetario_entregaDisp.Text = Request.Params["noinventario_entrega"];
                modelo.Text = Request.Params["modelo_retira"];
                modelo_retiraDisp.Text = Request.Params["modelo_retira"];
                modelo_entregaDisp.Text = Request.Params["modelo_entrega"];
            }
        }
    }
}