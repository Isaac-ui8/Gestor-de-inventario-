using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp5.Repositories
{
    public class SupplierRepository
    {
        private string connectionString = @"Server=LAMAQUINA\SQLEXPRESS;Database=Query1;Trusted_Connection=True;";

        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();

            string query = "SELECT * FROM Suppliers"; // Cambia estos nombres de tabla y columna según tu estructura.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Supplier supplier = new Supplier
                        {
                            SupplierId = Convert.ToInt32(reader["SupplierId"]),
                            Name = reader["Name"].ToString(),
                            // Mapear más campos según tu tabla
                        };
                        suppliers.Add(supplier);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return suppliers;
        }

        public void AddSupplier(Supplier supplier)
        {
            string query = "INSERT INTO Suppliers (Name) VALUES (@Name)"; // Cambia estos nombres según tu tabla.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            string query = "UPDATE Suppliers SET Name = @Name WHERE SupplierId = @SupplierId"; // Cambia estos nombres según tu tabla.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierId", supplier.SupplierId);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        public void DeleteSupplier(int supplierId)
        {
            string query = "DELETE FROM Suppliers WHERE SupplierId = @SupplierId"; // Cambia según tu tabla.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}
