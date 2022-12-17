using Core.BaseModels;
using DataAccess.Dtos.Base;

namespace DataAccess.Dtos.Product
{
    public class ProductResponseDto : ProductBaseDto, IIdenticalModel
    {
        public int Id { get; set; }
        public int StockQuantity { get; set; }

    }
}
