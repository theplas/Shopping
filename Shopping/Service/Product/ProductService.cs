using Shopping.Data;
using Shopping.Models.Product;

namespace Shopping.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _context;
        public ProductService(DatabaseContext context)
        {
            _context = context;
        }
        public ProductModel GetProductById(int id)
        {
            var d = _context.products.FirstOrDefault(p => p.Id == id);
            return d;
        }
        public async Task<ProductModel> AddProduct(ProductModel product, IFormFile image)
        {
            if(image != null && image.Length > 0)
            {
                using( var steam = new MemoryStream() )
                {
                    await image.CopyToAsync(steam);
                    product.Image = steam.ToArray();
                }
            }
            _context.products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _context.products.ToList();
        }

        public async  Task<ProductModel> UpdateProduct(ProductModel product, IFormFile image)
        {
            var model = _context.products.Find(product.Id);
            if (model != null)
            {
                if (image != null && image.Length > 0)
                {
                    model.Name = product.Name;
                    model.Description = product.Description;
                    model.Price = product.Price;
                    if (image != null && image.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        image.CopyTo(ms);
                        model.Image = ms.ToArray();
                    }
                }
                 await _context.SaveChangesAsync();
            }
            return model;
        }
    }
}
