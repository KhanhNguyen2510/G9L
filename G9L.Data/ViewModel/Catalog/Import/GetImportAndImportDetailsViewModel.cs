using System.Collections.Generic;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetImportAndImportDetailsViewModel<T>
    {
        public List<T> Items { get; set; }
        public int ImportID { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
