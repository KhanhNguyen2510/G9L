using G9L.Data.ViewModel.Catalog.Product;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Product
{
    public interface IProductSevice
    {


        //Create
        Task<bool> CreateToProduct(GetCreateProductRequest request, int CompanyIndex, string UpdateUser);
        //Update
        Task<bool> UpdateToProduct(GetUpdateProductRequest request, int CompanyIndex, string UpdateUser);
        //Delete
        Task<bool> DeleteToProduct(int ProductID, int CompanyIndex);
        //List
        Task<PagedResult<GetManagerProductViewModel>> GetListToProduct(GetManagerProductRequest request, int CompanyIndex);
        Task<GetManagerProductViewModel> GetToProduct(int ProductID, int CompanyIndex);
        Task<List<GetProduct>> GetToProductToNameAndID(int CompanyIndex);
        Task<List<GetProductByName>> GetToProductToName(int CompanyIndex);
    }

}
