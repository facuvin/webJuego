using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class ListadosSinAsignacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlFiltro.SelectedValue) == 0)
            {
                List<Juego> _lista = new ServicioClient().ListarJuegosSinJugadas((Usuario)Session["UsuLog"]).ToList();
                gvListado.DataSource = _lista;
                gvListado.DataBind();
            }
            else if (Convert.ToInt32(ddlFiltro.SelectedValue) == 1)
            {
                List<Pregunta> _lista = new ServicioClient().PreguntasNuncaUsadas((Usuario)Session["UsuLog"]).ToList();
                gvListado.DataSource = _lista;
                gvListado.DataBind();
            }
            else if (Convert.ToInt32(ddlFiltro.SelectedValue) == 2)
            {
                List<Juego> _lista = new ServicioClient().ListarJuegosSinPreguntas((Usuario)Session["UsuLog"]).ToList();
                gvListado.DataSource = _lista;
                gvListado.DataBind();
            }
            else
            {
                lblError.Text = "Debe seleccionar una opcion";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}