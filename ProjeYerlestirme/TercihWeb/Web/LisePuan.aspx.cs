using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class LisePuan : System.Web.UI.Page
    {
        public string databaseName;

        public LisePuan()
        {
            databaseName = "TercihWeb";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInfoForCheckList();
                GetInfoForDropdown();
                FillDataList();
            }
        }
        protected void GetInfoForCheckList()
        {
            List<string> list = new LisePuanGetComponents(databaseName).GetLiseTuruForCheckList();
            chxl_liseTuru.DataSource = list;
            chxl_liseTuru.DataBind();
        }
        protected void GetInfoForDropdown()
        {
            List<string> list = new LisePuanGetComponents(databaseName).GetIlForDropdown();
            ddl_il.DataSource = list;
            ddl_il.DataBind();
        }

        protected void ddl_il_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new LisePuanGetComponents(databaseName).GetIlceForDropdown(ddl_il.SelectedItem.Text);
            ddl_ilce.DataSource = list;
            ddl_ilce.DataBind();
        }
        /*
          parametreler[0] = Fen Lisesi
          parametreler[1] = Anadolu Lisesi
          parametreler[2] = Sosyal Bilimler Lisesi
          parametreler[3] = Mesleki ve Teknik Anadolu Lisesi
          parametreler[4] = Anadolu İmam Hatip Lisesi
          parametreler[5] = İl
          parametreler[6] = İlce
          parametreler[7] = Alt sınır
          parametreler[8] = Üst sınır
       */

        protected void btn_ara_Click(object sender, EventArgs e)
        {

            if (chxl_liseTuru.Items[0].Selected == true)
                Session["0"] = (chxl_liseTuru.Items[0].Text);
            else Session["0"] = null;

            if (chxl_liseTuru.Items[1].Selected == true)
                Session["1"] = (chxl_liseTuru.Items[1].Text);
            else Session["1"] = null;

            if (chxl_liseTuru.Items[2].Selected == true)
                Session["2"] = (chxl_liseTuru.Items[2].Text);
            else Session["2"] = null;

            if (chxl_liseTuru.Items[3].Selected == true)
                Session["3"] = (chxl_liseTuru.Items[3].Text);
            else Session["3"] = null;
            
            if (chxl_liseTuru.Items[4].Selected == true)
                Session["4"] = (chxl_liseTuru.Items[4].Text);
            else Session["4"] = null;

            if (ddl_il.SelectedItem.Text != "--Seçiniz--")
                Session["5"] = ddl_il.SelectedItem.Text;
            else Session["5"] = null;

            try 
	        {	        
		        if (ddl_ilce.SelectedItem.Text != "--Seçiniz--")
                    Session["6"] = ddl_ilce.SelectedItem.Text;
                    
	        }
	        catch (Exception)
	        {

                Session["6"] = null;
	        }
            

            try
            {
                Session["7"] = (txt_altSinir.Text == "") ? null : Convert.ToDouble(txt_altSinir.Text).ToString();
                Session["8"] = (txt_ustSinir.Text == "") ? null : Convert.ToDouble(txt_ustSinir.Text).ToString();
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('Alt Sınır, Üst Sınır için geçersiz giriş yapıldı. Tekrar deneyin ..')", true);                
            }

            FillDataList();

        }

        private void FillDataList()
        {
            string[] parametreler = new string[9];
            parametreler[0] = (Session["0"] != null) ? Session["0"].ToString() : null;
            parametreler[1] = (Session["1"] != null) ? Session["1"].ToString() : null;
            parametreler[2] = (Session["2"] != null) ? Session["2"].ToString() : null;
            parametreler[3] = (Session["3"] != null) ? Session["3"].ToString() : null;
            parametreler[4] = (Session["4"] != null) ? Session["4"].ToString() : null;
            parametreler[5] = (Session["5"] != null) ? Session["5"].ToString() : null;
            parametreler[6] = (Session["6"] != null) ? Session["6"].ToString() : null;
            parametreler[7] = (Session["7"] != null) ? Session["7"].ToString() : null;
            parametreler[8] = (Session["8"] != null) ? Session["8"].ToString() : null;

            grd_lise.DataSource = new LisePuanGetInfoForDatalist(databaseName).GetList(parametreler);
            grd_lise.DataBind();
        }

        protected void grd_lise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_lise.PageIndex = e.NewPageIndex;
            FillDataList();
        }
    }
}