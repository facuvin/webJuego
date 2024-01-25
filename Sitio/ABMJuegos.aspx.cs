using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class ABMJuegos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDificultad.Enabled = false;
            txtFecha.Enabled = false;
            txtUsuario.Enabled = false;

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            //busco
            Juego _unJ = new ServicioClient().BuscarJuego(Convert.ToInt32(txtCodigo.Text.Trim()));

            //fetermino accion
            if (_unJ != null)
            {
                //exite, cargo y permito eliminar o modificar
                txtDificultad.Text = _unJ.Dificultad;
                txtFecha.Text = _unJ.FechaCreado.ToString();
                txtUsuario.Text = _unJ.Usuario.NomUsu;
                txtCodigo.Enabled = false;
                txtDificultad.Enabled = true;

                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                Session["Juego"] = _unJ;
            }
            else
            {
                //no exite categoria, es un alta
                txtCodigo.Text = "0";
                txtDificultad.Enabled = true;
                txtCodigo.Enabled = false;
                txtUsuario.Text = ((Usuario)Session["UsuLog"]).NomUsu;

                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo objeto y lo modifico
            Juego _unJuego = (Juego)Session["Juego"];
            _unJuego.Usuario = (Usuario)Session["UsuLog"];
            _unJuego.Dificultad = txtDificultad.Text.Trim().ToUpper();

            //ejecuto operacion de actualizar en bd
            new ServicioClient().ModificarJuego(_unJuego, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtDificultad.Text = "";
            txtCodigo.Text = "";
            txtUsuario.Text = "";
            txtFecha.Text = "";
            txtDificultad.Enabled = false;
            txtCodigo.Enabled = true;

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Juego _unJuego = (Juego)Session["Juego"];
            new ServicioClient().EliminarJuego(_unJuego, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Eliminacion con Exito";

            txtDificultad.Text = "";
            txtCodigo.Text = "";
            txtUsuario.Text = "";
            txtFecha.Text = "";
            txtDificultad.Enabled = false;
            txtCodigo.Enabled = true;

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtDificultad.Text = "";
        txtCodigo.Text = "";
        txtUsuario.Text = "";
        txtFecha.Text = "";
        txtDificultad.Enabled = false;
        txtCodigo.Enabled = true;

        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        lblError.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Juego J = null;
        try
        {
            J = new Juego()
            {
                Dificultad = txtDificultad.Text.Trim().ToUpper(),
                Usuario = (Usuario)Session["UsuLog"]
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioClient().AgregarJuego(J, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";


            txtDificultad.Text = "";
            txtCodigo.Text = "";
            txtUsuario.Text = "";
            txtFecha.Text = "";
            txtDificultad.Enabled = false;
            txtCodigo.Enabled = true;

            btnAgregar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}