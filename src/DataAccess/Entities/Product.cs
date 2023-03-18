using Core.BaseModels.EntityModels;

namespace DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image {get;set;}
        public string? ImageType {get;set;}
        public DateTime CreateDateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
