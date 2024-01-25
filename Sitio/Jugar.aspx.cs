using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class Jugar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                List<Juego> ListaJuegos = new ServicioClient().ListarJuegosConPreguntas().ToList();
                Session["ListaJuegos"] = ListaJuegos;
                List<object> _lista = (from unJ in ListaJuegos
                                       select new
                                       {
                                           FechaCreado = unJ.FechaCreado,
                                           Dificultad = unJ.Dificultad,
                                           CantP = unJ.Preguntas.Count()
                                       }).ToList<object>();

                gvJuegos.DataSource = _lista;
                gvJuegos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void gvJuegos_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblError.Text = "";

        //Saco el juego seleccionado y lo guardo en la session
        Juego J = ((List<Juego>)Session["ListaJuegos"])[gvJuegos.SelectedIndex];
        Session["JuegoSel"] = J;


        //inicializo la variable de puntaje y pos (de pregunta)
        Session["Puntaje"] = 0;
        Session["Pos"] = 0;


        //muestro la primer pregunta y sus respuestas
        MostrarPregunta(J.Preguntas[0]);

        gvJuegos.Visible = false;
        gvRespuestas.Visible = true;
        btnConfirmarRespuesta.Visible = true;
    }

    protected void btnConfirmarRespuesta_Click(object sender, EventArgs e)
    {
        try
        {
            int pos = (int)Session["Pos"];
            Juego J = (Juego)Session["JuegoSel"];

            //si no selecciono una respuesta doy error y corto
            if (gvRespuestas.SelectedRow == null)
            {
                lblError.Text = "Debe seleccionar una respuesta";
                return;
            }

            //si la respuesta es la correcta sumo al puntaje
            if (J.Preguntas[pos].Respuestas[gvRespuestas.SelectedIndex].Correcta)
            {
                Session["Puntaje"] = (int)Session["Puntaje"] + J.Preguntas[pos].Puntaje;
            }

            //le sumo 1 a la pos
            Session["Pos"] = pos + 1;

            //si el juego tiene mas preguntas, muestro la siguiente
            if ((int)Session["Pos"] < J.Preguntas.Count())
            {
                MostrarPregunta(J.Preguntas[(int)Session["Pos"]]);
            }
            //si no tiene mas preguntas, muestro el puntaje y habilito el boton para confirmar la jugada
            else
            {
                txtNombreJugador.Visible = true;
                lblPregunta.Text = "Ingrese un nombre para registrar la jugada";

                lblError.Text = "Ha terminado el juego con un puntaje de: " + Session["Puntaje"];
                btnTerminarJugada.Visible = true;
                btnConfirmarRespuesta.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    private void MostrarPregunta(Pregunta P)
    {
        gvRespuestas.SelectedIndex = -1;
        lblPregunta.Text = P.Texto;
        gvRespuestas.DataSource = P.Respuestas;
        gvRespuestas.DataBind();
    }

    protected void btnTerminarJugada_Click(object sender, EventArgs e)
    {
        if (txtNombreJugador.Text == "")
        {
            lblError.Text = "Debe ingresar un nombre para registrar la jugada";
            return;
        }

        Jugada J = null;
        try
        {
            J = new Jugada()
            {
                NomJugador = txtNombreJugador.Text.Trim(),
                Puntaje = (int)Session["Puntaje"],
                Juego = (Juego)Session["JuegoSel"]
            };

            new ServicioClient().AgregarJugada(J);

            //si esta todo ok
            lblError.Text = "Jugada registrada con exito";
            Reiniciar();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    void Reiniciar()
    {
        gvJuegos.SelectedIndex = -1;
        gvJuegos.Visible = true;
        btnConfirmarRespuesta.Visible = false;
        btnTerminarJugada.Visible = false;
        txtNombreJugador.Visible = false;
        lblPregunta.Text = "";

        gvRespuestas.DataSource = null;
        gvRespuestas.DataBind();
    }
}