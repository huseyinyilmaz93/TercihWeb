﻿using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Duyurular : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<Duyuru> DuyurulariGoruntule()
        {
            return DuyuruGetComponents.GetDuyuru();
        }

    }
}