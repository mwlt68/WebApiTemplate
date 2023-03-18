using AutoMapper;
using Business.Abstract;
using DataAccess.Abstracts;
using DataAccess.Dtos.Product;
using DataAccess.Entities;

namespace Business.Concreate
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly int userId;
        public ProductService(IMapper mapper,IProductRepository productRepository,IHttpContextService httpContextService) 
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.userId = httpContextService.GetUserIdFromClaims();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await productRepository.DeleteAsync(x=> x.Id == id && x.UserId == userId);
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await productRepository.GetListAsync(x=> x.UserId == userId);
            var productsResponse = mapper.Map<List<ProductResponseDto>>(products.ToList());
            return productsResponse;
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await productRepository.GetAsync(x => x.Id == id && x.UserId == userId);
            var productResponse = mapper.Map<ProductResponseDto>(product);
            return productResponse;
        }

        public async Task<ProductResponseDto?> Insert(ProductInsertDto product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            mappedProduct.UserId = userId;
            var addResult = await productRepository.AddAsync(mappedProduct);
            var productResponse = mapper.Map<ProductResponseDto>(addResult);
            return productResponse;
        }

        public async Task<ProductResponseDto?> Update(ProductUpdateDto product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            mappedProduct.UserId = userId;
            var updateResult = await productRepository.UpdateAsync(mappedProduct);
            var productResponse = mapper.Map<ProductResponseDto>(updateResult);
            return productResponse;
        }
    }
}
