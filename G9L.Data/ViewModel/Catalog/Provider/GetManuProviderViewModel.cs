using System;

namespace G9L.Data.ViewModel.Catalog.Provider
{
    public class GetManuProviderViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }

        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
