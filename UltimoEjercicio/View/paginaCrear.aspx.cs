using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UltimoEjercicio.View
{
    public partial class paginaCrear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\ProjectModels;Database=PruebasMascota;Trusted_Connection=True;");
            connection.Open();

            var sql = "INSERT INTO Mascotas(Nombre, Raza, Edad, Vacunados) VALUES (@nombre, @raza, @edad, @vacunado)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nombre", TextBoxNombre.Text.ToString());
            command.Parameters.AddWithValue("@raza", TextBoxRaza.Text.ToString());
            command.Parameters.AddWithValue("@edad", TextBoxEdad.Text.ToString());
            if (CheckBoxVacunados.Checked == true)
            {
                command.Parameters.AddWithValue("@vacunado", "True");
            }
            else
            {
                command.Parameters.AddWithValue("@vacunado", "False");
            }
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
                Server.Transfer("~/View/pagina2.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/pagina2.aspx");
        }
    }
}