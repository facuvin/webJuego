using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class ManejoPreguntasDeJuego : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //traigo la lista de juegos con y sin preguntas
                List<Juego> _listaJuegos = new ServicioClient().ListarJuegosConPreguntas().ToList();
                List<Juego> _listaJuegos2 = new ServicioClient().ListarJuegosSinPreguntas((Usuario)Session["UsuLog"]).ToList();

                //los combino en una sola lista y los ordeno por codigo
                List<Juego> _listaJuegosCombinada = new List<Juego>();
                _listaJuegosCombinada.AddRange(_listaJuegos);
                _listaJuegosCombinada.AddRange(_listaJuegos2);
                _listaJuegosCombinada = _listaJuegosCombinada.OrderBy(juego => juego.Cod).ToList();

                //guardo la lista en la session y cargo la grilla
                Session["ListaJuegos"] = _listaJuegosCombinada;
                gvJuegos.DataSource = _listaJuegosCombinada;
                gvJuegos.DataBind();

            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void gvJuegos_SelectedIndexChanged(object sender, EventArgs e)
    {
        //saco el juego seleccionado, lo guardo en la session y muestro sus preguntas en la otra grilla
        Juego _juegoSel = ((List<Juego>)Session["ListaJuegos"])[gvJuegos.SelectedIndex];
        Session["JuegoSel"] = _juegoSel;

        gvPreguntasJuegos.DataSource = _juegoSel.Preguntas;
        gvPreguntasJuegos.DataBind();
    }


    protected void btnQuitarPregunta_Click(object sender, EventArgs e)
    {
        //si no selecciono niguna pregunta
        if (gvPreguntasJuegos.SelectedRow == null)
        {
            lblError.Text = "Debe seleccionar una pregunta";
            return;
        }

        try
        {
            Juego j = (Juego)Session["JuegoSel"];
            Pregunta p = j.Preguntas[gvPreguntasJuegos.SelectedIndex];

            //ejecuto el sp de quitar pregunta de juego
            new ServicioClient().QuitarPreguntaAJuego(p, j, (Usuario)Session["UsuLog"]);

            //si llego aca salio todo bien en la bdd, tengo que actualizar la parte grafica
            //creo un nuevo array de preguntas sin la pregunta seleccionada
            Pregunta[] nuevasPreguntas = j.Preguntas.Where(pr => pr.Codigo != p.Codigo).ToArray();

            //uso el nuevo array de preguntas como la lista de preguntas del juego
            j.Preguntas = nuevasPreguntas;

            //actualizo la grilla de preguntas
            gvPreguntasJuegos.DataSource = j.Preguntas;
            gvPreguntasJuegos.DataBind();

            lblError.Text = "Pregunta quitada con exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregarPregunta_Click(object sender, EventArgs e)
    {
        //si el codigo no tiene largo correcto
        if (txtCodigo.Text.Trim().Length != 5)
        {
            lblError.Text = "El codigo de pregunta debe tener 5 caracteres de largo";
            return;
        }
        try
        {
            Juego j = (Juego)Session["JuegoSel"];

            //busco la pregunta
            Pregunta p = new ServicioClient().BuscarPregunta(txtCodigo.Text.Trim(), (Usuario)Session["UsuLog"]);
            if (p == null)
            {
                lblError.Text = "No existe una pregunta con ese codigo";
                return;
            }

            //la agrego la juego en la bdd
            new ServicioClient().AsignarPreguntaAJuego(p, j, (Usuario)Session["UsuLog"]);

            //si llego aca salio todo bien en la bdd, tengo que actualizar la parte grafica
            //clono la lista de preguntas actual
            Pregunta[] nuevasPreguntas = new Pregunta[j.Preguntas.Length + 1];
            Array.Copy(j.Preguntas, nuevasPreguntas, j.Preguntas.Length);

            //agrego la nueva pregunta al array actualizado
            nuevasPreguntas[nuevasPreguntas.Length - 1] = p;

            // Asigna el array actualizado a la propiedad Preguntas del objeto Juego
            j.Preguntas = nuevasPreguntas;

            // Actualiza la grilla de preguntas
            gvPreguntasJuegos.DataSource = j.Preguntas;
            gvPreguntasJuegos.DataBind();

            lblError.Text = "Pregunta agregada con exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}