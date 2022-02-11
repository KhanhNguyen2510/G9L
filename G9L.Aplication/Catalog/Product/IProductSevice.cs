using G9L.Data.ViewModel.Catalog.Product;
using G9L.Data.ViewModel.Common;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Product
{
    public interface IProductSevice
    {
        //Create
        Task<bool> CreateToProvider(GetCreateProductRequest request, int CompanyIndex, string UpdateUser);
        //Update
        Task<bool> UpdateToProvider(GetUpdateProductRequest request, int CompanyIndex, string UpdateUser);
        //Delete
        Task<bool> DeleteToProduct(int ProductID, int CompanyIndex);
        //List
        Task<PagedResult<GetManagerProductViewModel>> GetListToProduct(GetManagerProductRequest request, int CompanyIndex);
    }

}
