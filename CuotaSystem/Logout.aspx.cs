using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuotaSystem
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logOut();
        }

        private void logOut()
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

    }
}