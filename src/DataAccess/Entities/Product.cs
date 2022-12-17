using Core.BaseModels.EntityModels;
using Core.Utilities.Helpers;

namespace DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
