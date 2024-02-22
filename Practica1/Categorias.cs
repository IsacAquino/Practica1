using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica1
{
    public partial class Categorias : Form
    {
        public Categorias()
        {
            InitializeComponent();
            Load += Categorias_Load1;
        }

        private void Categorias_Load1(object sender, EventArgs e)
        {
            var connectionString = Program.Configuration.GetConnectionString("NorthwindConnectionString");
            var connection = new SqlConnection(connectionString);

            //using (resource)
            //{

            //}
        }

        private void categoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.categoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindbd1DataSet);

        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindbd1DataSet.Categories' Puede moverla o quitarla según sea necesario.
            this.categoriesTableAdapter.Fill(this.northwindbd1DataSet.Categories);

        }
        SqlConnection conexion = new SqlConnection("server=ISAC\\SQLEXPRESS;database=Northwindbd1; integrated security=true");

        private void button1_Click(object sender, EventArgs e)
        {
            //conexion.Open();
            //string consulta = "insert into Categories values('" + categoryNameTextBox.Text + "', '" + descriptionTextBox.Text + "')";
            //SqlCommand comando = new SqlCommand(consulta, conexion);
            //comando.ExecuteNonQuery();
            //MessageBox.Show("Registro agregado");
            //conexion.Close();
            //this.categoriesTableAdapter.Fill(this.northwindbd1DataSet.Categories);
            //categoriesDataGridView.Refresh();

            try
            {
                conexion.Open();
                string consulta = "insert into Categories values('" + categoryNameTextBox.Text + "', '" + descriptionTextBox.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);


                
                var categorias = new categories()
                {
                    categoryId = Convert.ToInt32(categoryIDTextBox.Text),
                    categoryName = categoryNameTextBox.Text,
                    categoryDescription = descriptionTextBox.Text
                    //quantityPerUnit = Convert.ToDouble(quantityPerUnitTextBox.Text),
                    //unitPrice = Convert.ToDouble(unitPriceTextBox.Text),
                    //unitsInStock = Convert.ToDouble(unitsInStockTextBox.Text),
                    //unitsOnOrder = Convert.ToDouble(unitsOnOrderTextBox.Text),
                    //recorderLevel = Convert.ToInt32(reorderLevelTextBox.Text)
                };

                var categoriasValidator = new CategoriasValidator();
                var validationResult = categoriasValidator.Validate(categorias);

                if (validationResult.IsValid)
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro agregado");
                    this.categoriesTableAdapter.Fill(this.northwindbd1DataSet.Categories);
                    categoriesDataGridView.Refresh();
                }
                else
                {
                    try
                    {
                        throw new ApplicationException("Some Error");
                    }
                    catch (Exception ex)
                    {

                        Log.Error(ex, ex.Message);
                        MessageBox.Show("Ocurrió un error inesperado, inténtelo de nuevo");
                    }

                    var message = string.Join("\n", validationResult.Errors.Select(a => a.ErrorMessage));
                    MessageBox.Show(message, "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "update Categories set Category Name = '" + categoryNameTextBox.Text + "', Description = " + descriptionTextBox.Text + ",";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int incremento;
            incremento = comando.ExecuteNonQuery();
            if (incremento > 0)
            {
                MessageBox.Show("Registro actualizado");
            }
            conexion.Close();
            this.categoriesTableAdapter.Fill(this.northwindbd1DataSet.Categories);
            categoriesDataGridView.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "delete from Categories where CategoryID = " + categoryIDTextBox.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");
            conexion.Close();
            this.categoriesTableAdapter.Fill(this.northwindbd1DataSet.Categories);
            categoriesDataGridView.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void categoryIDTextBox_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(categoryIDTextBox, "");
        }

        private void categoryIDTextBox_Validating(object sender, CancelEventArgs e)
        {
            //if (categoryIDTextBox.Text == "")
            //{
            //    errorProvider1.SetError(categoryIDTextBox, "This field is required");
            //    e.Cancel = true;
            //}
        }

        private void categoryNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            //if (categoryNameTextBox.Text == "")
            //{
            //    errorProvider1.SetError(categoryNameTextBox, "This field is required");
            //    e.Cancel = true;
            //}
        }

        private void categoryNameTextBox_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(categoryNameTextBox, "");
        }

        private void descriptionTextBox_Validating(object sender, CancelEventArgs e)
        {
            //if (descriptionTextBox.Text == "")
            //{
            //    errorProvider1.SetError(descriptionTextBox, "This field is required");
            //    e.Cancel = true;
            //}
        }

        private void descriptionTextBox_Validated(object sender, EventArgs e)
        {
            //errorProvider1.SetError(descriptionTextBox, "");
        }
    }
}
