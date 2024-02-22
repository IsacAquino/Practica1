using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class Suplidores : Form
    {
        public Suplidores()
        {
            InitializeComponent();
        }

        private void Suplidores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindbd1DataSet.Suppliers' Puede moverla o quitarla según sea necesario.
            this.suppliersTableAdapter.Fill(this.northwindbd1DataSet.Suppliers);

        }

        private void suppliersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.suppliersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindbd1DataSet);

        }
        SqlConnection conexion = new SqlConnection("server=ISAC\\SQLEXPRESS;database=Northwindbd1; integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();
                string consulta = "insert into Suppliers values('" + companyNameTextBox.Text + "', '" + contactNameTextBox.Text + "', '" + contactTitleTextBox.Text + "', '" + addressTextBox.Text + "', '" + cityTextBox.Text + "', '" + regionTextBox.Text + "', '" + postalCodeTextBox.Text + "', '" + countryTextBox.Text + "', '" + phoneTextBox.Text + "', '" + faxTextBox.Text + "', '" + homePageTextBox.Text + "')";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                var suppliers = new Suppliers()
                {
                    supplierId = Convert.ToInt32(supplierIDTextBox.Text),
                    companyName = companyNameTextBox.Text,
                    contactName = contactNameTextBox.Text,
                    contactTitle = contactTitleTextBox.Text,
                    address = addressTextBox.Text,
                    city = cityTextBox.Text,
                    country = countryTextBox.Text,
                    phone = phoneTextBox.Text
                };


                var suppliersValidator = new SuppliersValidator();
                var validationResult = suppliersValidator.Validate(suppliers);

                if (validationResult.IsValid)
                {
                    
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro agregado");
                    this.suppliersTableAdapter.Fill(this.northwindbd1DataSet.Suppliers);
                    suppliersDataGridView.Refresh();
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
            string consulta = "update Suppliers set Company Name = '" + companyNameTextBox.Text + "', Contact Name = '" + contactNameTextBox.Text + "', Contact Title = '"+ contactTitleTextBox.Text+ "', Address = '"+ addressTextBox.Text+ "', City = '" + cityTextBox.Text + "', Region = '"+ regionTextBox.Text+ "', Postal Code = '"+postalCodeTextBox.Text+"', Country = '"+countryTextBox.Text+"', Phone = '"+phoneTextBox.Text+"', Fax = '"+faxTextBox.Text+"', Home Page = '"+ homePageTextBox.Text+ "'";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int incremento;
            incremento = comando.ExecuteNonQuery();
            if (incremento > 0)
            {
                MessageBox.Show("Registro actualizado");
            }
            conexion.Close();
            this.suppliersTableAdapter.Fill(this.northwindbd1DataSet.Suppliers);
            suppliersDataGridView.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "delete from Suppliers where SupplierID = " + supplierIDTextBox.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");
            conexion.Close();
            this.suppliersTableAdapter.Fill(this.northwindbd1DataSet.Suppliers);
            suppliersDataGridView.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
