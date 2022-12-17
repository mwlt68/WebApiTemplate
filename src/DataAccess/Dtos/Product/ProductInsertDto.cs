using DataAccess.Dtos.Base;

namespace DataAccess.Dtos.Product
{
    public class ProductInsertDto :ProductBaseDto
    {
        public int StockQuantity { get; set; }
    }
}
