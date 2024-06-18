namespace TestExport.Models
{
    public class ReportModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<ItemModel> Items { get; set; }
    }

    public class ItemModel
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
