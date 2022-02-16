using G9L.Data.ViewModel.Catalog.Mannufacture;
using G9L.Data.ViewModel.Common;
using G9L.Data.ViewModel.Mannufacture;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Manufacture
{
    public interface IManufactureSevice
    {
        //Create
        Task<bool> CreateToManufacture(GetCreateManufactureRequest request, int CompanyIndex, string UpdateUser);
        //Update
        Task<bool> UpdateToManufacture(GetUpdateManufactureRequest request, int CompanyIndex, string UpdateUser);
        //Delete
        Task<bool> DeleteToManufacture(int ManufactureID, int CompanyIndex);
        //List
        Task<PagedResult<GetManufactureViewModel>> GetListToManufacture(GetManagerManufactureRequest request, int CompanyIndex);
        Task<GetManufactureViewModel> GetToManufacture(int ManufactureID, int CompanyIndex);
        Task<List<GetManufacture>> GetToManufacturesOnNameAndID(int CompanyIndex);
    }
}
