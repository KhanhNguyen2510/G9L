using System;

namespace G9L.Data.ViewModel.Catalog.ProductType
{
    public class GetProductTypeViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
