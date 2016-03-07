using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;

namespace Web
{
    public partial class UniPuan : System.Web.UI.Page
    {
        public string databaseName;
        string altSinir;
        string ustSinir;
        public UniPuan()
        {
            databaseName = "TercihWeb";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDownUniAdi();
                Session["VeriCekme"] = VeriCekme.Bos;
                Session["UniAdi"] = null;
                Session["FakAdi"] = null;
                Session["BolAdi"] = null;
                FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(null,VeriCekme.Bos));
            }
        }
        void FillDataList(DataTable dt)
        { 
            grd_uni.DataSource = dt;
            grd_uni.DataBind();
        }

        void FillDropDownUniAdi()
        {
            List<string> list = new UniPuanGetComponents(databaseName).GetUniAdiForDropdown();
            ddl_uniAdi.DataSource = list;
            ddl_uniAdi.DataBind();
        }

        protected void ddl_uniAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Temizle();
            List<string> list = new UniPuanGetComponents(databaseName).GetFakAdiForDropdown(ddl_uniAdi.SelectedItem.Text);
            try
            {
                ddl_fakAdi.SelectedIndex = 0;
                ddl_bolAdi.SelectedIndex = 0;
                ddl_bolAdi.DataSource = null;
                ddl_bolAdi.DataBind();
            }
            catch (Exception)
            { }

            ddl_fakAdi.DataSource = list;
            ddl_fakAdi.DataBind();

            Session["UniAdi"] = (ddl_uniAdi.SelectedItem.Text == "--SEÇİNİZ--") ? null : ddl_uniAdi.SelectedItem.Text;

            if (Session["UniAdi"] == null) return;
            Session["VeriCekme"] = VeriCekme.SadeceUniversite;
            FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(new string[] { Session["UniAdi"].ToString() }, VeriCekme.SadeceUniversite));
        }

        protected void ddl_fakAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = new UniPuanGetComponents(databaseName).GetBolAdiForDropdown(ddl_uniAdi.SelectedItem.Text,ddl_fakAdi.SelectedItem.Text);
            try
            {
                ddl_bolAdi.SelectedIndex = 0; 
                ddl_bolAdi.DataSource = null;
            }
            catch (Exception)
            { }
            ddl_bolAdi.DataSource = list;
            ddl_bolAdi.DataBind();

            Session["UniAdi"] = (ddl_uniAdi.SelectedItem.Text == "--SEÇİNİZ--") ? null : ddl_uniAdi.SelectedItem.Text;
            Session["FakAdi"] = (ddl_fakAdi.SelectedItem.Text == "--SEÇİNİZ--") ? null : ddl_fakAdi.SelectedItem.Text;


            if (Session["UniAdi"] == null || Session["FakAdi"] == null) return;

            string[] parametreler = new string[5];
            parametreler[0] = Session["UniAdi"].ToString();
            parametreler[1] = Session["FakAdi"].ToString();
            Session["VeriCekme"] = VeriCekme.UniVeFak;
            FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(parametreler, VeriCekme.UniVeFak));
        }

        protected void ddl_bolAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["BolAdi"] = (ddl_bolAdi.SelectedItem.Text == "--SEÇİNİZ--") ? null : ddl_bolAdi.SelectedItem.Text;
            Session["UniAdi"] = (ddl_uniAdi.SelectedItem.Text == "--SEÇİNİZ--") ? null : ddl_uniAdi.SelectedItem.Text;
            Session["FakAdi"] = (ddl_fakAdi.SelectedItem.Text == "--SEÇİNİZ--") ? null : ddl_fakAdi.SelectedItem.Text;

            if (Session["UniAdi"] == null || Session["FakAdi"] == null || Session["BolAdi"] == null) return;

            string[] parametreler = new string[5];
            parametreler[0] = Session["UniAdi"].ToString();
            parametreler[1] = Session["FakAdi"].ToString();
            parametreler[2] = Session["BolAdi"].ToString();
            Session["VeriCekme"] = VeriCekme.UniVeBolVeFak;
            FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(parametreler, VeriCekme.UniVeBolVeFak));
        }

        protected void txt_bolum_TextChanged(object sender, EventArgs e)
        {
            if (txt_bolum.Text == "")
            {
                Session["VeriCekme"] = VeriCekme.Bos;
                FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(null, VeriCekme.Bos));
                return;
            }
            else
            {
                Session["VeriCekme"] = VeriCekme.SadeceBolum;
                this.Session["BolAdi"] = txt_bolum.Text;
                FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(new string[] { null, null, Session["BolAdi"].ToString() }, VeriCekme.SadeceBolum));
            }

            try
            {
                ddl_bolAdi.SelectedIndex = 0;
                ddl_fakAdi.SelectedIndex = 0;
                ddl_uniAdi.SelectedIndex = 0;
            }
            catch (Exception)
            { }

        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                ddl_bolAdi.SelectedIndex = 0;
                ddl_fakAdi.SelectedIndex = 0;
                ddl_uniAdi.SelectedIndex = 0;
            }
            catch (Exception)
            { }

            if (txt_altSinir.Text == "" || txt_ustSinir.Text == "" || txt_bolum.Text == "" )
            {
                Session["VeriCekme"] = VeriCekme.Bos;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "alert('Alt Sınır, Üst Sınır veya Bolüm Adı alanları boş bırakılamaz. Tekrar deneyin ..')", true);
                FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(null, VeriCekme.Bos));
                return;
            }
            string[] parametreler = new string[5];
            this.altSinir = txt_altSinir.Text;
            this.ustSinir = txt_ustSinir.Text;
            parametreler[2] = txt_bolum.Text;
            parametreler[3] = txt_altSinir.Text;
            parametreler[4] = txt_ustSinir.Text;
            Session["VeriCekme"] = VeriCekme.SadeceBolumPuanla;
            FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(parametreler, VeriCekme.SadeceBolumPuanla));
            Session["BolAdi"] = txt_bolum.Text;
        }
        protected void Temizle()
        {
            txt_bolum.Text = "";
            txt_altSinir.Text = "";
            txt_ustSinir.Text = "";
        }

        protected void grd_uni_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string[] parametreler = new string[5];
            VeriCekme gecerliVeriCekme = (VeriCekme)Session["VeriCekme"];
            switch (gecerliVeriCekme)
            {
                case VeriCekme.SadeceUniversite:
                    grd_uni.PageIndex = e.NewPageIndex;
                    FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(new string[] { Session["UniAdi"].ToString() }, VeriCekme.SadeceUniversite));
                    break;
                case VeriCekme.UniVeFak:
                    parametreler[0] = Session["UniAdi"].ToString();
                    parametreler[1] = Session["FakAdi"].ToString();
                    grd_uni.PageIndex = e.NewPageIndex;
                    FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(parametreler, VeriCekme.UniVeFak));
                    break;
                case VeriCekme.UniVeBolVeFak:
                    parametreler[0] = Session["UniAdi"].ToString();
                    parametreler[1] = Session["FakAdi"].ToString();
                    parametreler[2] = Session["BolAdi"].ToString();
                    grd_uni.PageIndex = e.NewPageIndex;
                    FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(parametreler, VeriCekme.UniVeBolVeFak));
                    break;
                case VeriCekme.SadeceBolum:
                    grd_uni.PageIndex = e.NewPageIndex;
                    FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(new string[] { null, null, Session["BolAdi"].ToString() }, VeriCekme.SadeceBolum));
                    break;
                case VeriCekme.SadeceBolumPuanla:
                    parametreler[2] = txt_bolum.Text;
                    parametreler[3] = txt_altSinir.Text;
                    parametreler[4] = txt_ustSinir.Text;
                    grd_uni.PageIndex = e.NewPageIndex;
                    FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(parametreler, VeriCekme.SadeceBolumPuanla));
                    break;
                default:
                    FillDataList(new UniPuanGetInfoForDatalist(databaseName).GetList(null, VeriCekme.Bos));
                    grd_uni.PageIndex = e.NewPageIndex;
                    break;
            }
            

        }

    }
}