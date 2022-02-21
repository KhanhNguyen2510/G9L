using G9L.Data.EFs;
using G9L.Data.ViewModel.Mannufacture;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using G9L.Data.ViewModel.Common;
using System.Linq;
using G9L.Data.ViewModel.Catalog.Mannufacture;
using System.Collections.Generic;

namespace G9L.Aplication.Catalog.Manufacture
{
    public class ManufactureSevice : IManufactureSevice
    {
        private readonly G9LDbContext _context;

        public ManufactureSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check

        //Create
        public async Task<bool> CreateToManufacture(GetCreateManufactureRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.Manufacture()
                {
                    ID = 0,
                    Name = !string.IsNullOrEmpty(request.Name) ? request.Name : "",
                    Local = !string.IsNullOrEmpty(request.Name) ? request.Local : "",

                    UpdateDate = DateTime.Now,
                    CompanyIndex = CompanyIndex,
                    UpdateUser = UpdateUser
                };
                _context.Manufactures.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }
        //Update
        public async Task<bool> UpdateToManufacture(GetUpdateManufactureRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.Manufactures.FirstOrDefaultAsync(x => x.ID == request.ManufactureID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                rs.Name = !string.IsNullOrEmpty(request.ManufactureName) ? request.ManufactureName : rs.Name;
                rs.Local = !string.IsNullOrEmpty(request.Local) ? request.Local : rs.Local;

                rs.UpdateUser = !string.IsNullOrEmpty(UpdateUser) ? UpdateUser : rs.UpdateUser;
                rs.UpdateDate = DateTime.Now;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        //Delete
        public async Task<bool> DeleteToManufacture(int ManufactureID , int CompanyIndex)
        {
            try
            {
                var rs = await _context.Manufactures.FirstOrDefaultAsync(x => x.ID == ManufactureID && x.CompanyIndex == CompanyIndex);
               
                if (rs == null) return false;

                _context.Manufactures.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        //List
        public async Task<PagedResult<GetManufactureViewModel>> GetListToManufacture(GetManagerManufactureRequest request, int CompanyIndex)
        {
            try
            {
                var query = await _context.Manufactures.Where(x=>x.CompanyIndex == CompanyIndex).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.Name.ToLower().Contains(request.KeyWord.ToLower()) || x.Local.ToLower().Contains(request.KeyWord.ToLower()) || x.ID.ToString().Contains(request.KeyWord)).ToList();

                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetManufactureViewModel()
                    {
                        ManufactureID = x.ID,
                        ManufactureName = x.Name,
                        Local = x.Local,
                        UpdateDate = x.UpdateDate,
                        UpdateUser = x.UpdateUser
                    }).ToList();

                var pagedResult = new PagedResult<GetManufactureViewModel>()
                {
                    TotalRecords = totalRow,
                    PageIndex = request.PageIndex,
                    PageSize = request.PageSize,
                    Items = data
                };
                return pagedResult;
            }
            catch
            {
                return null;
            }
        }
        public async Task<GetManufactureViewModel> GetToManufacture(int ManufactureID, int CompanyIndex)
        {
            try
            {
                var query = await _context.Manufactures.Where(x => x.CompanyIndex == CompanyIndex && x.ID == ManufactureID).FirstOrDefaultAsync();
                if (query == null) return null;
                var data = new GetManufactureViewModel()
                {
                    ManufactureID = query.ID,
                    ManufactureName = query.Name,
                    Local = query.Local,
                    UpdateDate = query.UpdateDate,
                    UpdateUser = query.UpdateUser
                };
                return data;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<GetManufacture>> GetToManufacturesOnNameAndID(int CompanyIndex)
        {
            try
            {
                var rs = await _context.Manufactures.Where(x => x.CompanyIndex == CompanyIndex).Select(x => new GetManufacture()
                {
                    ManufactureID = x.ID,
                    ManufactureName = x.Name
                }).ToListAsync();

                return rs;
            }
            catch
            {
                return null;
            }
        }
    }
}
