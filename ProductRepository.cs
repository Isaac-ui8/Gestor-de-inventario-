using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp5.Repositories
{
    public class ProductRepository
    {
        private string connectionString = @"Server=LAMAQUINA\SQLEXPRESS;Database=Query1;Trusted_Connection=True;";

        // Método para obtener todos los productos
        public List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();

            string query = "SELECT * FROM Products";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Products product = new Products
                        {
                            IdProducto = Convert.ToInt32(reader["ProductId"]),
                            Nombre = reader["ProductName"].ToString(),
                            CodigoProducto = reader["ProductCode"].ToString(),
                            CategoriaId = Convert.ToInt32(reader["CategoryId"]),
                            Precio = Convert.ToDecimal(reader["Price"]),
                            Existencia = Convert.ToInt32(reader["Stock"]),
                            ProveedorId = Convert.ToInt32(reader["ProviderId"]),
                        };
                        products.Add(product);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los productos: {ex.Message}");
                }
            }
            return products;
        }

        // Método para agregar un producto
        public void AddProduct(Products product)
        {
            string query = @"INSERT INTO Products 
                             (ProductName, ProductCode, CategoryId, Price, Stock, ProviderId) 
                             VALUES 
                             (@ProductName, @ProductCode, @CategoryId, @Price, @Stock, @ProviderId)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", product.Nombre);
                cmd.Parameters.AddWithValue("@ProductCode", product.CodigoProducto);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoriaId);
                cmd.Parameters.AddWithValue("@Price", product.Precio);
                cmd.Parameters.AddWithValue("@Stock", product.Existencia);
                cmd.Parameters.AddWithValue("@ProviderId", product.ProveedorId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar el producto: {ex.Message}");
                }
            }
        }

        // Método para actualizar un producto
        public void UpdateProduct(Products product)
        {
            string query = @"UPDATE Products 
                             SET ProductName = @ProductName, 
                                 ProductCode = @ProductCode, 
                                 CategoryId = @CategoryId, 
                                 Price = @Price, 
                                 Stock = @Stock, 
                                 ProviderId = @ProviderId 
                             WHERE ProductId = @ProductId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", product.IdProducto);
                cmd.Parameters.AddWithValue("@ProductName", product.Nombre);
                cmd.Parameters.AddWithValue("@ProductCode", product.CodigoProducto);
                cmd.Parameters.AddWithValue("@CategoryId", product.CategoriaId);
                cmd.Parameters.AddWithValue("@Price", product.Precio);
                cmd.Parameters.AddWithValue("@Stock", product.Existencia);
                cmd.Parameters.AddWithValue("@ProviderId", product.ProveedorId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el producto: {ex.Message}");
                }
            }
        }

        // Método para eliminar un producto
        public void DeleteProduct(int productId)
        {
            string query = "DELETE FROM Products WHERE ProductId = @ProductId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el producto: {ex.Message}");
                }
            }
        }
    }
}
