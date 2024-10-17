using WebApp_vSem2.DTO;

namespace WebApp_vSem2.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupModel> GetAllProductGroups();
        int AddProductGroup(ProductGroupModel productGroupModel);
        void DeleteProductGroup(int id);
    }
}
