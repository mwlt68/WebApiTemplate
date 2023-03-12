using DataAccess.Dtos.Base;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Dtos.Product
{
    public class ProductInsertDto :ProductBaseDto
    {
        public int StockQuantity { get; set; }
        public IFormFile? Image {get;set; }
    }
}
