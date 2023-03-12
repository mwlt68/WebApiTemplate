using Core.BaseModels.DtoModels;

namespace DataAccess.Dtos.Base
{
    public abstract class ProductBaseDto : BaseDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
