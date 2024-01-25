using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["UsuLog"] = null;
        }
    }

    protected void btnLogueo_Click(object sender, EventArgs e)
    {
        try
        {

            RefWCF.Usuario _unUsu = new RefWCF.ServicioClient().Logueo(txtNomUsu.Text.Trim(), txtPassw.Text.Trim());

            //si encuentra
            if (_unUsu != null)
            {
                Session["UsuLog"] = _unUsu;
                Response.Redirect("~/ABMUsuarios.aspx");
            }
            else
            {
                lblError.Text = "Usuario o conttraseña incorrecta";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            txtNomUsu.Text = "";
            txtPassw.Text = "";
        }
    }
}