using G9L.Data.ViewModel.Common;

namespace G9L.Data.ViewModel.Catalog.Provider
{
    public class GetManagerProviderRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
