using G9L.Data.EFs;
using G9L.Data.ViewModel.Catalog.Provider;
using G9L.Data.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G9L.Aplication.Catalog.Provider
{
    public class ProviderSevice : IProviderSevice
    {
        private readonly G9LDbContext _context;

        public ProviderSevice(G9LDbContext context)
        {
            _context = context;
        }
        //Check
        //Create
        public async Task<bool> CreateToProvider(GetCreateProviderRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var data = new Data.Entities.Provider()
                {
                    ID = 0,
                    Name = !string.IsNullOrEmpty(request.ProviderName) ? request.ProviderName : "",
                    NumberPhone = !string.IsNullOrEmpty(request.NumberPhone) ? request.NumberPhone : "",
                    Address = !string.IsNullOrEmpty(request.Address) ? request.Address : "",

                    UpdateDate = DateTime.Now,
                    CompanyIndex = CompanyIndex,
                    UpdateUser = UpdateUser
                };
                _context.Providers.Add(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Update
        public async Task<bool> UpdateToProvider(GetUpdateProviderRequest request, int CompanyIndex, string UpdateUser)
        {
            try
            {
                var rs = await _context.Providers.FirstOrDefaultAsync(x => x.ID == request.ProviderID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                rs.Name = !string.IsNullOrEmpty(request.ProviderName) ? request.ProviderName : rs.Name;
                rs.NumberPhone = !string.IsNullOrEmpty(request.NumberPhone) ? request.NumberPhone : rs.NumberPhone;
                rs.Address = !string.IsNullOrEmpty(request.Address) ? request.Address : rs.Address;

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
        public async Task<bool> DeleteToProvider(int ProviderID, int CompanyIndex)
        {
            try
            {
                var rs = await _context.Providers.FirstOrDefaultAsync(x => x.ID == ProviderID && x.CompanyIndex == CompanyIndex);

                if (rs == null) return false;

                _context.Providers.Remove(rs);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //List
        public async Task<PagedResult<GetManuProviderViewModel>> GetListToProvider(GetManagerProviderRequest request, int CompanyIndex)
        {
            try
            {
                var query = await _context.Providers.Where(x => x.CompanyIndex == CompanyIndex).ToListAsync();

                if (request.KeyWord != null)
                    query = query.Where(x => x.Name.ToLower().Contains(request.KeyWord.ToLower()) || x.NumberPhone.Contains(request.KeyWord) || x.Address.ToLower().Contains(request.KeyWord.ToLower()) || x.ID.ToString().Contains(request.KeyWord)).ToList();

                int totalRow = query.Count;

                var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                    .Take(request.PageSize).Select(x => new GetManuProviderViewModel()
                    {
                        ID = x.ID,
                        Address = x.Address,
                        Name = x.Name,
                        NumberPhone = x.NumberPhone,
                        UpdateDate = x.UpdateDate,
                        UpdateUser = x.UpdateUser
                    }).ToList();

                var pagedResult = new PagedResult<GetManuProviderViewModel>()
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
        public async Task<GetManuProviderViewModel> GetToProvider(int ProviderID, int CompanyIndex)
        {
            try
            {
                var query = await _context.Providers.Where(x => x.CompanyIndex == CompanyIndex && x.ID == ProviderID).FirstOrDefaultAsync();

                if (query == null) return null;

                var data = new GetManuProviderViewModel()
                {
                    ID = query.ID,
                    Address = query.Address,
                    Name = query.Name,
                    NumberPhone = query.NumberPhone,
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

        public async Task<List<GetProvider>> GetToProvideOnNameAndID(int CompanyIndex)
        {
            try
            {
                var query = await _context.Providers.Where(x => x.CompanyIndex == CompanyIndex).Select(x => new GetProvider()
                {
                    ProviderID = x.ID,
                    ProviderName = x.Name
                }).ToListAsync();

                return query;

            }
            catch
            {
                return null;
            }
        }
    }
}
