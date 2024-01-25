using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RefWCF;

public partial class ABMUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtPassw.Enabled = false;
            txtNombre.Enabled = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Usuario UsuLog = (Usuario)Session["UsuLog"];
        try
        {
            //busco
            Usuario _unUsuario = new ServicioClient().BuscarUsuariosActivos(txtNomUsu.Text.Trim(), UsuLog);

            //fetermino accion
            if (_unUsuario == null)
            {
                //no exite usuario, es un alta
                txtNombre.Text = "";
                txtPassw.Text = "";
                txtNombre.Enabled = true;
                txtPassw.Enabled = true;
                txtNomUsu.Enabled = false;

                btnAgregar.Enabled = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                //exite, cargo y permito eliminar o modificar
                txtNombre.Text = _unUsuario.NombreCompleto;
                txtPassw.Text = _unUsuario.Passw;
                txtNombre.Enabled = true;
                txtNomUsu.Enabled = false;

                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                Session["Usuario"] = _unUsuario;

                if (UsuLog.NomUsu == _unUsuario.NomUsu) //si quiere modificarse a si mismo le permito editar la contraseña
                    txtPassw.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Usuario U = null;
        try
        {
            U = new Usuario()
            {
                NomUsu = txtNomUsu.Text.Trim(),
                Passw = txtPassw.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim()
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new ServicioClient().AgregarUsuario(U, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";

            txtNombre.Text = "";
            txtPassw.Text = "";
            txtNomUsu.Text = "";
            txtPassw.Enabled = false;
            txtNombre.Enabled = false;
            txtNomUsu.Enabled = true;

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
            Usuario _unUsu = (Usuario)Session["Usuario"];
            _unUsu.Passw = txtPassw.Text.Trim();
            _unUsu.NombreCompleto = txtNombre.Text.Trim();

            //ejecuto operacion de actualizar en bd
            new ServicioClient().ModificarUsuario(_unUsu, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtNombre.Text = "";
            txtPassw.Text = "";
            txtNomUsu.Text = "";
            txtPassw.Enabled = false;
            txtNombre.Enabled = false;
            txtNomUsu.Enabled = true;

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
            Usuario _unUsu = (Usuario)Session["Usuario"];
            new ServicioClient().EliminarUsuario(_unUsu, (Usuario)Session["UsuLog"]);

            //si llego aca, todo salio ok
            lblError.Text = "Eliminacion con Exito";

            txtNombre.Text = "";
            txtPassw.Text = "";
            txtNomUsu.Text = "";
            txtPassw.Enabled = false;
            txtNombre.Enabled = false;
            txtNomUsu.Enabled = true;

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
        txtPassw.Text = "";
        txtNomUsu.Text = "";
        txtPassw.Enabled = false;
        txtNombre.Enabled = false;
        txtNomUsu.Enabled = true;

        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
    }
}