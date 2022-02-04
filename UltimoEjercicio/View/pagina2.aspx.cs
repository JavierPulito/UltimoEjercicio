using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimoEjercicio.View
{
    public partial class pagina2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\ProjectModels;Database=PruebasMascota;Trusted_Connection=True;");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Mascotas", connection);
            SqlDataReader reader = command.ExecuteReader();
            SqlDataReader sqlDataReader = reader;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre");
            while (sqlDataReader.Read())
            {
                DataRow row = dataTable.NewRow();
                row["Nombre"] = sqlDataReader["Nombre"];
                dataTable.Rows.Add(row);
            }
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            reader.Close();
            connection.Close();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/paginaCrear.aspx");

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/paginaEditar.aspx");
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/paginaBorrar.aspx");
        }
    }
}