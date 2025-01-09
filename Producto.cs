public class Product
{
    public int ProductId { get; set; }         // Identificador único del producto
    public string ProductName { get; set; }    // Nombre del producto
    public string ProductCode { get; set; }    // Código único del producto
    public decimal ProductPrice { get; set; }  // Precio del producto
    public int ProductStock { get; set; }      // Stock disponible del producto
    public int CategoryId { get; set; }        // ID de la categoría (FK)
    public int ProviderId { get; set; }        // ID del proveedor (FK)
}
