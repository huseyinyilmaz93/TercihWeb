using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class PuanHesaplama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_uniPuan_Click(object sender, EventArgs e)
        {
            Response.Redirect("UniPuanHesaplama.aspx");
        }

        protected void btn_lisePuan_Click(object sender, EventArgs e)
        {
            Response.Redirect("LisePuanHesaplama.aspx");

        }
    }
}