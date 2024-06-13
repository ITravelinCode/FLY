namespace FLY.Business.Models.ProductCategory
{
    public class ProductCategoryResponse
    {
        public int ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; } = null!;

        public string ImageProduct { get; set; } = null!;

        public int Status { get; set; }
    }
}
