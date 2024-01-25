using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class MPUsuarios : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Session["UsuLog"] is Usuario))
            Response.Redirect("~/Default.aspx");
    }

    protected void btnDeslogueo_Click(object sender, EventArgs e)
    {
        Session["UsuLog"] = null;
        Response.Redirect("~/Default.aspx");
    }
}
