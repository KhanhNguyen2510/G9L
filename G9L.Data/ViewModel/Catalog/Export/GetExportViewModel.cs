using G9L.Data.Enum;
using System;

namespace G9L.Data.ViewModel.Catalog.Export
{
    public class GetExportViewModel
    {
        public int ID { get; set; }
        public DateTime ExportDate { get; set; }// ngày thêm
        public decimal TotalAmount { get; set; }// tổng tiền
        public IsExport IsExport { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
