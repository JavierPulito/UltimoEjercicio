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
    public partial class paginaEditar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBoxNombre.Visible = false;
                TextBoxRaza.Visible = false;
                TextBoxEdad.Visible = false;
                lblNombre.Visible = false;
                CheckBox1.Visible = false;
                Label3.Visible = false;
                Label2.Visible = false;
                Label4.Visible = false;
                btnAceptar.Visible = false;
                btnVolver.Visible = false;
            }
            PopulateGridView();
        }

        private void PopulateGridView()
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

        //Esconde la columna Id del GridView
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int indexOfColumn = 1;
            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false;
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            //PopulateGridView();
            //Cuando termina este método hace un PostBack y se borra toda la información
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int _id;
            string nombre;
            string raza;
            int edad;
            string vacunados;

            foreach (DictionaryEntry dict in e.NewValues)
            {
                Console.WriteLine(dict);
                if (dict.Key == "Id")
                {
                    _id = Int32.Parse(dict.Value.ToString());
                    Label4.Text = _id.ToString();
                }
                else if (dict.Key == "Nombre")
                {
                    nombre = dict.Value.ToString();
                    TextBoxNombre.Text = nombre;
                }
                else if (dict.Key == "Raza")
                {
                    raza = dict.Value.ToString();
                    TextBoxRaza.Text = raza;
                }
                else if (dict.Key == "Edad")
                {
                    edad = Int32.Parse(dict.Value.ToString());
                    TextBoxEdad.Text = edad.ToString();
                }
                else
                {
                    vacunados = dict.Value.ToString();
                    if(vacunados == "True" || vacunados == "true")
                    {
                        CheckBox1.Checked = true;
                    }
                    else
                    {
                        CheckBox1.Checked = false;
                    }
                }
            }

            GridView1.Visible = false;
            showUpdateComponents();

        }

        protected void showUpdateComponents()
        {
            TextBoxNombre.Visible = true;
            TextBoxRaza.Visible = true;
            TextBoxEdad.Visible = true;
            lblNombre.Visible = true;
            Label3.Visible = true;
            Label2.Visible = true;
            CheckBox1.Visible = true;
            btnAceptar.Visible = true;
            btnVolver.Visible = true;

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string _nombre = TextBoxNombre.Text.ToString();
            string _raza = TextBoxRaza.Text.ToString();
            int _edad = Int32.Parse(TextBoxEdad.Text.ToString());
            string _vacunado = "";
            if (CheckBox1.Checked)
            {
                _vacunado = "true";
            }
            else
            {
                _vacunado = "false";
            }
            int xd = Int32.Parse(Label4.Text.ToString());

            SqlConnection connection = new SqlConnection("Server=(localdb)\\ProjectModels;Database=PruebasMascota;Trusted_Connection=True;");
            connection.Open();

            var sql = "UPDATE Mascotas SET Nombre = @nombre, Raza = @raza, Edad = @edad, Vacunado = @vacunado where Id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@nombre", _nombre);
            command.Parameters.AddWithValue("@raza", _raza);
            command.Parameters.AddWithValue("@edad", _edad);
            command.Parameters.AddWithValue("@vacunado", _vacunado);
            command.Parameters.AddWithValue("@id", Label4.Text.ToString());

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
                Server.Transfer("~/View/paginaEditar.aspx");
            }
        }


    }
}