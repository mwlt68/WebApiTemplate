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
        public ProductService(IMapper mapper,IProductRepository productRepository) 
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await productRepository.GetListAsync();
            var productsResponse = mapper.Map<List<ProductResponseDto>>(products.ToList());
            return productsResponse;
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var product = await productRepository.GetAsync(x => x.Id == id);
            var productResponse = mapper.Map<ProductResponseDto>(product);
            return productResponse;
        }

        public async Task<ProductResponseDto?> Insert(ProductInsertDto product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            var addResult = await productRepository.AddAsync(mappedProduct);
            var productResponse = mapper.Map<ProductResponseDto>(addResult);
            return productResponse;
        }

        public async Task<ProductResponseDto?> Update(ProductUpdateDto product)
        {
            var mappedProduct = mapper.Map<Product>(product);
            var updateResult = await productRepository.UpdateAsync(mappedProduct);
            var productResponse = mapper.Map<ProductResponseDto>(updateResult);
            return productResponse;
        }
    }
}
