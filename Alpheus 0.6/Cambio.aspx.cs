using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Alpheus_0._6
{
    public partial class Cambio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TipoMantenimientoRBtnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TipoMantenimientoRBtnList.SelectedItem.Text == "Otro")
            {
                OtroTxt.Enabled = true;
            }
            else
            {
                OtroTxt.Enabled = false;
            }
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
    }
}