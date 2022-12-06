using Framework.Shared.Resourses;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Linq;
namespace ShopManagement.Application.Contract.ProductCategory;

public class ProductCategoryViewModel
{
    public long Id { get; set; }
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    public string Name { get; set; }
    public string ImageSrc { get; set; }
    public string CreationDate { get; set; }
 
}