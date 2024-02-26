using FluentValidation.Results;
using Practica1;
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

namespace Practica1
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindbd1DataSet);

        }

        private void Productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'northwindbd1DataSet.Products' Puede moverla o quitarla según sea necesario.
            this.productsTableAdapter.Fill(this.northwindbd1DataSet.Products);
            productsDataGridView.Refresh();

        }

        SqlConnection conexion = new SqlConnection("server=ISAC\\SQLEXPRESS;database=Northwindbd1; integrated security=true");

        private void button1_Click(object sender, EventArgs e)
        {
            //conexion.Open();
            //string consulta = "insert into Products values('" + productNameTextBox.Text + "', " + supplierIDTextBox.Text + ", " + categoryIDTextBox.Text + ", '" + quantityPerUnitTextBox.Text + "', " + unitPriceTextBox.Text + ", " + unitPriceTextBox.Text + ", " + unitsInStockTextBox.Text + ", " + unitsOnOrderTextBox.Text + ", " + reorderLevelTextBox.Text + ")";
            //SqlCommand comando = new SqlCommand(consulta, conexion);
            //comando.ExecuteNonQuery();

            //var productos = new Productos01()
            //{
            //    productId = Convert.ToInt32(productIDTextBox.Text),
            //    productName = productNameTextBox.Text,
            //    supplierId = Convert.ToInt32(supplierIDTextBox.Text),
            //    categoryId = Convert.ToInt32(categoryIDTextBox.Text),
            //    //quantityPerUnit = Convert.ToDouble(quantityPerUnitTextBox.Text),
            //    //unitPrice = Convert.ToDouble(unitPriceTextBox.Text),
            //    //unitsInStock = Convert.ToDouble(unitsInStockTextBox.Text),
            //    //unitsOnDouble = Convert.ToDouble(unitsOnOrderTextBox.Text),
            //    //recorderLevel = Convert.ToInt32(reorderLevelTextBox.Text)

            //};
            //var productosValidator = new ProductosValidator();
            //var validationResult = productosValidator.Validate(productos);


            //if (validationResult.IsValid)
            //{

            //    MessageBox.Show("Registro agregado");
            //    this.productsTableAdapter.Fill(this.northwindbd1DataSet.Products);
            //    productsDataGridView.Refresh();
            //}
            //else
            //{
            //    var message = string.Join("\n", validationResult.Errors.Select(a => a.ErrorMessage));
            //    MessageBox.Show(message, "validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

            //conexion.Close();

            try
            {
                conexion.Open();
                string consulta = "insert into Products values('" + productNameTextBox.Text + "', " + supplierIDTextBox + ", " + categoryIDTextBox.Text + ", '" + quantityPerUnitTextBox.Text + "', " + unitPriceTextBox.Text + ", " + unitsInStockTextBox.Text + ", " + unitsOnOrderTextBox.Text + ", " + reorderLevelTextBox.Text + ")";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                var productos = new Productos01()
                {
                    productId = Convert.ToInt32(productIDTextBox.Text),
                    productName = productNameTextBox.Text,
                    //supplierId = Convert.ToInt32(supplierIDTextBox.Text),
                    categoryId = Convert.ToInt32(categoryIDTextBox.Text),
                    //quantityPerUnit = Convert.ToDouble(quantityPerUnitTextBox.Text),
                    //unitPrice = Convert.ToDouble(unitPriceTextBox.Text),
                    //unitsInStock = Convert.ToDouble(unitsInStockTextBox.Text),
                    //unitsOnOrder = Convert.ToDouble(unitsOnOrderTextBox.Text),
                    //recorderLevel = Convert.ToInt32(reorderLevelTextBox.Text)
                };

                var productosValidator = new ProductosValidator();
                var validationResult = productosValidator.Validate(productos);

                if (validationResult.IsValid)
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro agregado");
                    this.productsTableAdapter.Fill(this.northwindbd1DataSet.Products);
                    productsDataGridView.Refresh();
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
            try
            {
                conexion.Open();
                string consulta = "update Products set Product Name = '" + productNameTextBox.Text + "', SupplierID = " + supplierIDTextBox.Text + ", Category ID = " + categoryIDTextBox.Text + ", Quantity Per Unit = '" + quantityPerUnitTextBox.Text + "', Unit Price = " + unitPriceTextBox.Text + ",  Units In Stock =  " + unitsInStockTextBox.Text + ", Units On Order = " + unitsOnOrderTextBox.Text + ", Reorder Level = " + reorderLevelTextBox.Text + " WHERE Product ID = " + productIDTextBox.Text + "";
                SqlCommand comando = new SqlCommand(consulta, conexion);

                var productos = new Productos01()
                {
                    productId = Convert.ToInt32(productIDTextBox.Text),
                    productName = productNameTextBox.Text,
                    supplierId = Convert.ToInt32(supplierIDTextBox.Text),
                    categoryId = Convert.ToInt32(categoryIDTextBox.Text),
                    //quantityPerUnit = Convert.ToDouble(quantityPerUnitTextBox.Text),
                    //unitPrice = Convert.ToDouble(unitPriceTextBox.Text),
                    //unitsInStock = Convert.ToDouble(unitsInStockTextBox.Text),
                    //unitsOnOrder = Convert.ToDouble(unitsOnOrderTextBox.Text),
                    //recorderLevel = Convert.ToInt32(reorderLevelTextBox.Text)
                };

                var productosValidator = new ProductosValidator();
                var validationResult = productosValidator.Validate(productos);
                int incremento;
                if (validationResult.IsValid)
                {
                    incremento = comando.ExecuteNonQuery();
                    if (incremento > 0)
                    {
                        MessageBox.Show("Registro actualizado");

                    }
                    this.productsTableAdapter.Fill(this.northwindbd1DataSet.Products);
                    productsDataGridView.Refresh();
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
                    }

                    MessageBox.Show("Ocurrió un error inesperado, inténtelo de nuevo");
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

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string consulta = "delete from Products where ProductID = " + productIDTextBox.Text + "";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro eliminado");
            conexion.Close();
            this.productsTableAdapter.Fill(this.northwindbd1DataSet.Products);
            productsDataGridView.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
