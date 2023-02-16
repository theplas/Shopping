using Shopping.Models.Product;

namespace Shopping.Service.Product
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        Task<ProductModel> AddProduct(ProductModel product, IFormFile image);
        Task<ProductModel> UpdateProduct(ProductModel product, IFormFile image);
        void DeleteProduct(int id);
    }
}
