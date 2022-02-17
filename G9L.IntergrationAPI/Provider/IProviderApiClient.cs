using G9L.Data.ViewModel.Catalog.Provider;
using G9L.Data.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Provider
{
    public interface IProviderApiClient
    {
        Task<PagedResult<GetManuProviderViewModel>> GetListToProvider(GetManagerProviderRequest request);
        Task<bool> CreateToProvider(GetCreateProviderRequest request);
        Task<bool> UpdateToProvider(GetUpdateProviderRequest request);
        Task<List<GetProvider>> GetToProvideOnNameAndID();
    }
}
