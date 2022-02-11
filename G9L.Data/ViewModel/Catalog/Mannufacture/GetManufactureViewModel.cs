using System;

namespace G9L.Data.ViewModel.Catalog.Mannufacture
{
    public class GetManufactureViewModel
    {
        public int ManufactureID { get; set; }
        public string ManufactureName { get; set; }
        public string Local { get; set; }

        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
