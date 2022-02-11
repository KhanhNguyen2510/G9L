using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;

namespace G9L.BackEndAPI.Common
{
    public class ApiControllerBase : Controller
    {
        private readonly IServiceProvider _ServiceProvider;
        protected readonly int _CurrentCompanyIndex;
        protected readonly string _CurrentUpdateUser;

        public ApiControllerBase(IServiceProvider pServiceProvider)
        {
            _ServiceProvider = pServiceProvider;
            _CurrentCompanyIndex = GetCurrentCompanyIndex();
            _CurrentUpdateUser = GetCurrentUpdateUser();
        }
        protected T TryResolve<T>()
        {
            return _ServiceProvider.GetService<T>();
        }

        protected string GetCurrentUpdateUser()
        {
            string UpdateUser = "Khanhnguyen@gmail.com";
            //int.TryParse(_contextAccessor.HttpContext.Session.GetString("CompanyIndex"), out int companyIndex);
            return UpdateUser;
        }

        protected int GetCurrentCompanyIndex()
        {
            int companyIndex = 9;
            //int.TryParse(_contextAccessor.HttpContext.Session.GetString("CompanyIndex"), out int companyIndex);
            return companyIndex;
        }
    }
}
