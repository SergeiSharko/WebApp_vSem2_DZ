using WebApp_vSem2.DTO;

namespace WebApp_vSem2.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        int AddProduct(ProductModel productModel);
        void DeleteProduct(int id);
        (byte[] Content, string FileName) GetProductsCsv();
    }
}
