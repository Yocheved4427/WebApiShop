using Entities;
using Repositories;
using DTOs;
using AutoMapper;
namespace Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;
        public ProductsServices(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PageResponseDTO<ProductDTO>> GetProducts(int position, int skip, int?[] categoryIds,
           string? description, int? maxPrice, int? minPrice)
        {

            (List<Product>, int) response = await _repository.GetProducts(position, skip, categoryIds, description, maxPrice, minPrice);
            List<ProductDTO> data = _mapper.Map<List<Product>, List<ProductDTO>>(response.Item1);
            PageResponseDTO<ProductDTO> pageResponse = new ();
            pageResponse.Data = data;
            pageResponse.TotalItems = response.Item2;
            pageResponse.CurrentPage = position;
            pageResponse.PageSize = skip;
            pageResponse.HasPreviousPage = position > 1;
            int numOfPages = pageResponse.TotalItems / skip;
            if (pageResponse.TotalItems % skip != 0)
                numOfPages++;
            pageResponse.HasNextPage = position < numOfPages;
            return pageResponse;

        }





    }
}
