using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            try
            {
                List<Jugada> _lista = new ServicioClient().ListarJugadas().ToList();
                Session["ListaJugadas"] = _lista;
                Session["ListaOriginal"] = _lista;

                gvJugadas.DataSource = _lista;
                gvJugadas.DataBind();
            }
            catch(Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void btnFiltroNombre_Click(object sender, EventArgs e)
    {
        try
        {
            //si no ingreso nada
            if (txtNombre.Text == "")
            {
                lblError.Text = "Debe ingresar un nombre para filtrar";
                return;
            }

            //filtro la lista y muestro en la grilla
            List<Jugada> _listaFiltrada = (from unaJ in (List<Jugada>)Session["ListaOriginal"]
                                           where unaJ.NomJugador.Contains(txtNombre.Text.Trim())
                                           select unaJ).ToList<Jugada>();

            Session["ListaJugadas"] = _listaFiltrada;

            gvJugadas.DataSource = _listaFiltrada;
            gvJugadas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnFiltroDificultad_Click(object sender, EventArgs e)
    {
        try
        {
            //filtro la lista y muestro en la grilla
            List<Jugada> _listaFiltrada = (from unaJ in (List<Jugada>)Session["ListaOriginal"]
                                           where unaJ.Juego.Dificultad.Contains(ddlDificultad.SelectedValue)
                                           select unaJ).ToList<Jugada>();

            Session["ListaJugadas"] = _listaFiltrada;

            gvJugadas.DataSource = _listaFiltrada;
            gvJugadas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Session["ListaJugadas"] = Session["ListaOriginal"];

        gvJugadas.DataSource = (List<Jugada>)Session["ListaOriginal"];
        gvJugadas.DataBind();
    }

    protected void btnOrdenar_Click(object sender, EventArgs e)
    {
        try
        {
            List<Jugada> _listaOrdenada = ((List<Jugada>)Session["ListaJugadas"]).OrderBy(j => j.Juego.Dificultad).ThenBy(j => j.Puntaje).ToList();

            gvJugadas.DataSource = _listaOrdenada;
            gvJugadas.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}