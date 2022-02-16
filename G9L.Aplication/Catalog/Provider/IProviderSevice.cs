using G9L.Data.ViewModel.Catalog.Provider;
using G9L.Data.ViewModel.Common;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Provider
{
    public interface IProviderSevice
    {
        //Create
        Task<bool> CreateToProvider(GetCreateProviderRequest request, int CompanyIndex, string UpdateUser);
        //Update
        Task<bool> UpdateToProvider(GetUpdateProviderRequest request, int CompanyIndex, string UpdateUser);
        //Delete
        Task<bool> DeleteToProvider(int ProviderID, int CompanyIndex);
        //List
        Task<PagedResult<GetManuProviderViewModel>> GetListToProvider(GetManagerProviderRequest request, int CompanyIndex);
        Task<GetManuProviderViewModel> GetToProvider(int ProviderID, int CompanyIndex);
    }
}
