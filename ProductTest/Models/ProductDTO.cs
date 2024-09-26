namespace ProductTest.Models
{
    public class ProductDTO
    {
        public int Upc { get; set; }
        public string? Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public int Quantity { get; set; }
    }
}
