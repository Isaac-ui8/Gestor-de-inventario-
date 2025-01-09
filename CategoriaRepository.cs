using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp5.Repositories
{
    public class CategoryRepository
    {
        private string connectionString = @"Server=LAMAQUINA\SQLEXPRESS;Database=Query1;Trusted_Connection=True;";

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            string query = "SELECT * FROM Categories"; // Cambia estos nombres de tabla y columna según tu estructura.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            Name = reader["Name"].ToString(),
                            // Mapear más campos según tu tabla
                        };
                        categories.Add(category);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return categories;
        }

        public void AddCategory(Category category)
        {
            string query = "INSERT INTO Categories (Name) VALUES (@Name)"; // Cambia estos nombres según tu tabla.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", category.Name);
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

        public void UpdateCategory(Category category)
        {
            string query = "UPDATE Categories SET Name = @Name WHERE CategoryId = @CategoryId"; // Cambia estos nombres según tu tabla.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                cmd.Parameters.AddWithValue("@Name", category.Name);
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

        public void DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM Categories WHERE CategoryId = @CategoryId"; // Cambia según tu tabla.

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
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
