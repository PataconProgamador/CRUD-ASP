using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace CRUD_ASP.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly MySqlConnection con = new MySqlConnection(
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }

        void CargarTabla()
        {
            using (MySqlDataAdapter da = new MySqlDataAdapter("sp_listar", con))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvusuarios.DataSource = dt;
                gvusuarios.DataBind();
            }
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("Crud.aspx?accion=leer&id=" + id);
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;
            Response.Redirect("Crud.aspx?accion=actualizar&id=" + id);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).CommandArgument;

            con.Open();
            using (MySqlCommand cmd = new MySqlCommand("sp_delete", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("_idUsuario", MySqlDbType.Int32).Value = Convert.ToInt32(id);
                cmd.ExecuteNonQuery();
            }
            con.Close();

            CargarTabla();
        }
    }
}