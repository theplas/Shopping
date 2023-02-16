namespace Shopping.Models.Product
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string? ImageBase64
        {
            get
            {
                if (Image != null)
                {
                    return Convert.ToBase64String(Image);
                }
                return null;
            }
        }

    }
/*    public class ProductModels : ProductModel
    {
        public string ImageBase64
        {
            get
            {
                return Convert.ToBase64String(Image);
            }
        }
        public List<ProductModel> ProductModel { get; set; }
    }*/
}
