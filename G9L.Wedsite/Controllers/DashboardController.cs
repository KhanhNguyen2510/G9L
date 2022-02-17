using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace G9L.Wedsite.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {
            
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
