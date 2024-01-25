using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class ABMCategorias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtNombre.Enabled = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            //busco
            Categoria _unaCat = new ServicioClient().BuscarCategoriaActivas(txtCodigo.Text.Trim(), (Usuario)Session["UsuLog"]);

            //fetermino accion
            if (_unaCat == null)
            {
                //no exite categoria, es un alta
                txtNombre.Text = "";
                txtNombre.Enabled = true;
                txtCodigo.Enabled = false;

                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                //exite, cargo y permito eliminar o modificar
                txtNombre.Text = _unaCat.Nombre;
                txtNombre.Enabled = true;
                txtCodigo.Enabled = false;

                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                Session["Categoria"] = _unaCat;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Categoria C = null;
        try
        {
            C = new Categoria()
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim()
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioClient().AgregarCategoria(C, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";

            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtNombre.Enabled = false;
            txtCodigo.Enabled = true;

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
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
            Categoria _unaCat = (Categoria)Session["Categoria"];
            _unaCat.Nombre = txtNombre.Text.Trim();

            //ejecuto operacion de actualizar en bd
            new ServicioClient().ModificarCategoria(_unaCat, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtNombre.Enabled = false;
            txtCodigo.Enabled = true;

            btnAgregar.Enabled = false;
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
            Categoria _unaCat = (Categoria)Session["Categoria"];
            new ServicioClient().EliminarCategoria(_unaCat, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Eliminacion con Exito";

            txtNombre.Text = "";
            txtCodigo.Text = "";
            txtNombre.Enabled = false;
            txtCodigo.Enabled = true;

            btnAgregar.Enabled = false;
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
        lblError.Text = "";
        txtNombre.Text = "";
        txtCodigo.Text = "";
        txtNombre.Enabled = false;
        txtCodigo.Enabled = true;

        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
    }
}