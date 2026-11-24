using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CRUD_ASP.Pages
{
    public partial class Crud : System.Web.UI.Page
    {
        readonly MySqlConnection con = new MySqlConnection(
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        string sID = "";
        string sAccion = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
                sID = Request.QueryString["id"];
            if (Request.QueryString["accion"] != null)
                sAccion = Request.QueryString["accion"];

            if (!IsPostBack)
            {
                ConfigurarPantalla();
                if (sID != "")
                    CargarDatos();
            }
        }

        // Muestra u oculta botones según la acción de la URL
        void ConfigurarPantalla()
        {
            btnGuardar.Visible = false;
            btnActualizar.Visible = false;

            switch (sAccion)
            {
                case "leer":
                    lblTitulo.Text = "Detalle del usuario";
                    txtNombre.Enabled = false;
                    txtEdad.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtFechaNac.Enabled = false;
                    break;
                case "actualizar":
                    lblTitulo.Text = "Actualizar usuario";
                    btnActualizar.Visible = true;
                    break;
                default:
                    lblTitulo.Text = "Nuevo usuario";
                    btnGuardar.Visible = true;
                    break;
            }
        }

        void CargarDatos()
        {
            con.Open();
            using (MySqlDataAdapter da = new MySqlDataAdapter("sp_read", con))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("_idUsuario", MySqlDbType.Int32).Value = Convert.ToInt32(sID);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow fila = ds.Tables[0].Rows[0];
                    txtNombre.Text = fila["Nombre"].ToString();
                    txtEdad.Text = fila["Edad"].ToString();
                    txtCorreo.Text = fila["Correo"].ToString();
                    txtFechaNac.Text = Convert.ToDateTime(fila["FechaNacimiento"]).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            con.Open();
            using (MySqlCommand cmd = new MySqlCommand("insert_user", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_Nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                cmd.Parameters.Add("_Edad", MySqlDbType.Int32).Value = Convert.ToInt32(txtEdad.Text);
                cmd.Parameters.Add("_Correo", MySqlDbType.VarChar).Value = txtCorreo.Text;
                cmd.Parameters.Add("_FechaNacimiento", MySqlDbType.Date).Value = Convert.ToDateTime(txtFechaNac.Text);
                cmd.ExecuteNonQuery();
            }
            con.Close();

            Response.Redirect("Index.aspx");
        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            con.Open();
            using (MySqlCommand cmd = new MySqlCommand("sp_update", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_idUsuario", MySqlDbType.Int32).Value = Convert.ToInt32(sID);
                cmd.Parameters.Add("_Nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                cmd.Parameters.Add("_Edad", MySqlDbType.Int32).Value = Convert.ToInt32(txtEdad.Text);
                cmd.Parameters.Add("_Correo", MySqlDbType.VarChar).Value = txtCorreo.Text;
                cmd.Parameters.Add("_FechaNacimiento", MySqlDbType.Date).Value = Convert.ToDateTime(txtFechaNac.Text);
                cmd.ExecuteNonQuery();
            }
            con.Close();

            Response.Redirect("Index.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        // Revisa que no falte ningún dato
        bool Validar()
        {
            if (txtNombre.Text.Trim() == "" || txtEdad.Text.Trim() == "" ||
                txtCorreo.Text.Trim() == "" || txtFechaNac.Text.Trim() == "")
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                return false;
            }
            return true;
        }
    }
}