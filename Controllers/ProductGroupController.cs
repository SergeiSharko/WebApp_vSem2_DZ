using Microsoft.AspNetCore.Mvc;
using WebApp_vSem2.Abstraction;
using WebApp_vSem2.DTO;

namespace WebApp_vSem2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController(IProductGroupRepository _productGroupRepository) : ControllerBase
    {
        [HttpPost("add_group")]
        public ActionResult AddProductGroup(ProductGroupModel productGroupModel)
        {            
            try
            {
                var id = _productGroupRepository.AddProductGroup(productGroupModel);
                return Ok(id);
            }
            catch (Exception)
            {
                return StatusCode(409);
            }            
        }

        [HttpGet("get_groups")]
        public ActionResult<IEnumerable<ProductGroupModel>> GetAllGroups()
        {
            return Ok(_productGroupRepository.GetAllProductGroups());
        }

        [HttpDelete("delete_group_on_id")]
        public ActionResult DeleteProductGroup(int id)
        {
            try
            {
                _productGroupRepository.DeleteProductGroup(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(409);
            }
        }
    }
}
