using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimoEjercicio.View
{
    public partial class paginaBorrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\ProjectModels;Database=PruebasMascota;Trusted_Connection=True;");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Mascotas", connection);
            SqlDataReader reader = command.ExecuteReader();
            SqlDataReader sqlDataReader = reader;
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Nombre");
            dataTable.Columns.Add("Raza");
            dataTable.Columns.Add("Edad");
            dataTable.Columns.Add("Vacunados");
            while (sqlDataReader.Read())
            {
                DataRow row = dataTable.NewRow();
                row["Id"] = sqlDataReader["Id"];
                row["Nombre"] = sqlDataReader["Nombre"];
                row["Raza"] = sqlDataReader["Raza"];
                row["Edad"] = sqlDataReader["Edad"];
                row["Vacunados"] = sqlDataReader["Vacunados"];
                dataTable.Rows.Add(row);
            }
            GridView1.DataSource = dataTable;
            GridView1.DataBind();
            reader.Close();
            connection.Close();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int indexOfColumn = 1;
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false;
            }
        }

        protected void GridView1_RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            int _id = 0;
            foreach (DictionaryEntry dict in e.Values)
            {
                if (dict.Key == "Id")
                {
                    _id = Int32.Parse(dict.Value.ToString());
                }

            }

            SqlConnection connection = new SqlConnection("Server=(localdb)\\ProjectModels;Database=PruebasMascota;Trusted_Connection=True;");
            connection.Open();

            var sql = "DELETE FROM Mascotas where Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", _id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Algo salió mal");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/View/pagina2.aspx");
        }
    }
}