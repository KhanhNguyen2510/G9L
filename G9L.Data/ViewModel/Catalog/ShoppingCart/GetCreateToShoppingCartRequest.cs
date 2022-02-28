using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.ShoppingCart
{
    public class GetCreateToShoppingCartRequest
    {
        public int ProductID { get; set; }
        public int? Quantily { get; set; }
        public IsUnit? IsUnit { get; set; }
    }
}
