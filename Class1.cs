private bool TestSqlConnection()
{
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();  // Intenta abrir la conexión
            MessageBox.Show("Conexión exitosa a la base de datos.");
            return true;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
        return false;
    }
}
