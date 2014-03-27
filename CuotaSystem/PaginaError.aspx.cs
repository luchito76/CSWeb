using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuotaSystem
{
    public partial class PaginaError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string error = Request["error"].ToString();

            string script = @"<script type='text/javascript'>jError('" + error + "');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}