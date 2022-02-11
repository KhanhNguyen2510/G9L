using System;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetImportViewModel
    {
        public int ID { get; set; }
        public string ProviderName { get; set; }//nhà cung cấp
        public DateTime ImportDate { get; set; }// ngày thêm
        public decimal TotalAmount { get; set; }// tổng tiền

        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
