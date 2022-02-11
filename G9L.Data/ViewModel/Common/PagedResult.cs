using System.Collections.Generic;

namespace G9L.Data.ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
