using G9L.Data.ViewModel.Catalog.ProductType;
using G9L.Data.ViewModel.Common;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.ProductType
{
    public interface IProductTypeSevice
    {
        //Check 
        //Create
        Task<bool> CreateToProductType(GetCreateProductTypeRequest request, int CompanyIndex, string UpdateUser);
        //Update
        Task<bool> UpdateToProductType(GetUpdateProductTypeRequest request, int CompanyIndex, string UpdateUser);
        //Delete
        Task<bool> DeleteToProductType(int ProductTypeID, int CompanyIndex);
        //List
        Task<PagedResult<GetProductTypeViewModel>> GetListToProductType(GetManagerProductTypeRequest request, int CompanyIndex);
        Task<GetProductTypeViewModel> GetToProductType(int ProductTypeID, int CompanyIndex);
    }
}
