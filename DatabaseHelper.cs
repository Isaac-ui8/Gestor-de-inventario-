using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WinFormsApp5.Helpers
{
    public class DatabaseHelper
    {
        // Cadena de conexión que se obtiene del archivo app.config
        private string connectionString;

        public DatabaseHelper()
        {
            // Obtener la cadena de conexión desde el archivo app.config
            connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        }

        // Método para obtener todos los productos desde la base de datos
        public DataTable GetAllProducts()
        {
            DataTable productsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta SQL para obtener todos los productos
                string query = "SELECT p.ProductId, p.ProductName, p.ProductCode, p.ProductPrice, p.ProductStock, c.CategoryName, pr.ProviderName " +
                               "FROM Products p " +
                               "JOIN Categories c ON p.CategoryId = c.CategoryId " +
                               "JOIN Providers pr ON p.ProviderId = pr.ProviderId";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(productsTable); // Llenamos el DataTable con los datos obtenidos
            }

            return productsTable;
        }

        // Método para obtener todas las categorías
        public DataTable GetCategories()
        {
            DataTable categoriesTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta SQL para obtener todas las categorías
                string query = "SELECT CategoryId, CategoryName FROM Categories";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(categoriesTable); // Llenamos el DataTable con los datos obtenidos
            }

            return categoriesTable;
        }

        // Método para obtener todos los proveedores
        public DataTable GetProviders()
        {
            DataTable providersTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta SQL para obtener todos los proveedores
                string query = "SELECT ProviderId, ProviderName FROM Providers";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(providersTable); // Llenamos el DataTable con los datos obtenidos
            }

            return providersTable;
        }

        // Método para agregar un producto
        public void AddProduct(string productName, string productCode, decimal productPrice, int productStock, int categoryId, int providerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (ProductName, ProductCode, ProductPrice, ProductStock, CategoryId, ProviderId) " +
                               "VALUES (@ProductName, @ProductCode, @ProductPrice, @ProductStock, @CategoryId, @ProviderId)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@ProductCode", productCode);
                command.Parameters.AddWithValue("@ProductPrice", productPrice);
                command.Parameters.AddWithValue("@ProductStock", productStock);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@ProviderId", providerId);

                connection.Open();
                command.ExecuteNonQuery(); // Ejecutamos la consulta
            }
        }

        // Método para actualizar un producto
        public void UpdateProduct(int productId, string productName, string productCode, decimal productPrice, int productStock, int categoryId, int providerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET ProductName = @ProductName, ProductCode = @ProductCode, " +
                               "ProductPrice = @ProductPrice, ProductStock = @ProductStock, CategoryId = @CategoryId, ProviderId = @ProviderId " +
                               "WHERE ProductId = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@ProductCode", productCode);
                command.Parameters.AddWithValue("@ProductPrice", productPrice);
                command.Parameters.AddWithValue("@ProductStock", productStock);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@ProviderId", providerId);

                connection.Open();
                command.ExecuteNonQuery(); // Ejecutamos la consulta
            }
        }

        // Método para eliminar un producto
        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductId = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery(); // Ejecutamos la consulta
            }
        }
    }
}
