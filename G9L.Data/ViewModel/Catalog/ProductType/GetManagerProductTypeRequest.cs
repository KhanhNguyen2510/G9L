using G9L.Data.ViewModel.Common;
namespace G9L.Data.ViewModel.Catalog.ProductType
{
    public class GetManagerProductTypeRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
