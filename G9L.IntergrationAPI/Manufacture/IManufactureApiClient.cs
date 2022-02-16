using G9L.Data.ViewModel.Catalog.Mannufacture;
using G9L.Data.ViewModel.Common;
using G9L.Data.ViewModel.Mannufacture;
using System.Threading.Tasks;

namespace G9L.IntergrationAPI.Manufacture
{
    public interface IManufactureApiClient
    {
        Task<PagedResult<GetManufactureViewModel>> GetListToManufacture(GetManagerManufactureRequest request);
        Task<bool> CreateToManufacture(GetCreateManufactureRequest request);
        Task<bool> UpdateToManufacture(GetUpdateManufactureRequest request);
    }
}
