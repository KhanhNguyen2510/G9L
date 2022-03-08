using G9L.Data.Enum;
using System;

namespace G9L.Data.ViewModel.Catalog.ShoppingCart
{
    public class GetShoppingCartViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantily { get; set; }
        public IsUnit IsUnit { get; set; }
        public DateTime DateCreate { get; set; }
        public decimal TotalAmountProduct{get; set;}
        public string UpdateUser { get; set; }
    }
}