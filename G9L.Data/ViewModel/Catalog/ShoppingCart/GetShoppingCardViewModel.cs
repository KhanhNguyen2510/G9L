using System.Collections.Generic;

namespace G9L.Data.ViewModel.Catalog.ShoppingCart
{
    public class GetShoppingCardViewModel<T>
    {
        public List<T> Items { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
