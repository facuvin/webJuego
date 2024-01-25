using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class AltaPreguntas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["Respuestas"] = new List<Respuesta>();

                List<Categoria> _categorias = new ServicioClient().ListarCategoria((Usuario)Session["UsuLog"]).ToList();
                Session["Categorias"] = _categorias;

                ddlCategoria.DataSource = _categorias;
                ddlCategoria.DataTextField = "Nombre";
                ddlCategoria.DataValueField = "Codigo";
                ddlCategoria.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAltaRespuesta_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico que ingrese texto 
            if (txtTextoRespuesta.Text.Length <= 0)
            {
                lblError.Text = "Debe ingresar un texto";
                return;
            }

            //recupero la lista de respuestas
            List<Respuesta> _listaRespuestas = (List<Respuesta>)Session["Respuestas"];

            //si la respuesta ingresada es correcta, verifico que no haya otra respuesta que tambien sea correcta
            if (Convert.ToBoolean(ddlCorrecta.SelectedValue))
            {
                Respuesta r = _listaRespuestas.Where(res => res.Correcta == true).FirstOrDefault();

                if (r != null)
                {
                    lblError.Text = "Ya hay una respuesta correcta para esta pregunta";
                    return;
                }
            }

            //creo la respuesta y la agrego a la lista y a la listbox
            Respuesta _respuesta = new Respuesta()
            {
                Texto = txtTextoRespuesta.Text.Trim(),
                Correcta = Convert.ToBoolean(ddlCorrecta.SelectedValue)
            };

            _listaRespuestas.Add(_respuesta);
            lbRespuestas.Items.Add(_respuesta.Texto);

            txtTextoRespuesta.Text = "";
            lblError.Text = "Se agrego correctamente la respuesta a la lista";

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAltaPregunta_Click(object sender, EventArgs e)
    {
        try
        {
            List<Respuesta> _respuestas = (List<Respuesta>)Session["Respuestas"];
            List<Categoria> _categorias = (List<Categoria>)Session["Categorias"];

            Pregunta p = new Pregunta
            {
                Codigo = txtCodigo.Text.Trim(),
                Puntaje = Convert.ToInt32(txtPuntaje.Text.Trim()),
                Categoria = _categorias[ddlCategoria.SelectedIndex],
                Texto = txtTextoPregunta.Text.Trim(),
                Respuestas = _respuestas.ToArray()
            };

            //verifico que haya al menos una respuesta correcta antes de agregar
            Respuesta r = _respuestas.Where(res => res.Correcta == true).FirstOrDefault();

            if (r == null)
            {
                lblError.Text = "La pregunta debe tener al menos una respuesta correcta";
                return;
            }

            new ServicioClient().AgregarPregunta(p, (Usuario)Session["UsuLog"]);

            //si llego aca salio todo ok
            lblError.Text = "Alta pregunta con exito";

            txtCodigo.Text = "";
            txtPuntaje.Text = "";
            txtTextoPregunta.Text = "";
            lbRespuestas.Items.Clear();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}