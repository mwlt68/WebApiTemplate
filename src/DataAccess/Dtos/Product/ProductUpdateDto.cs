using Core.BaseModels;
using DataAccess.Dtos.Base;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Dtos.Product
{
    public class ProductUpdateDto : ProductBaseDto, IIdenticalModel
    {
        public int Id { get ; set ; }
        public IFormFile? Image {get;set; }
    }
}
