using G9L.Data.Enum;

namespace G9L.Data.ViewModel.Catalog.Import
{
    public class GetAddImport
    {
        public int ImportID { get; set; }
        public int ProviderID { get; set; } //ID nhà cung cấp
        public class GetQuantily
        {
            public int? Quantily_1 { get; set; }
            public int? Quantily_2 { get; set; }
            public int? Quantily_3 { get; set; }
            public int? Quantily_4 { get; set; }
            public int? Quantily_5 { get; set; }
            public int? Quantily_6 { get; set; }
            public int? Quantily_7 { get; set; }
            public int? Quantily_8 { get; set; }
            public int? Quantily_9 { get; set; }
            public int? Quantily_10 { get; set; }
        }
        public class GetCostPrice
        {
            public int? CostPrice_1 { get; set; }
            public int? CostPrice_2 { get; set; }
            public int? CostPrice_3 { get; set; }
            public int? CostPrice_4 { get; set; }
            public int? CostPrice_5 { get; set; }
            public int? CostPrice_6 { get; set; }
            public int? CostPrice_7 { get; set; }
            public int? CostPrice_8 { get; set; }
            public int? CostPrice_9 { get; set; }
            public int? CostPrice_10 { get; set; }

        }
        public class GetProduct
        {
            public int? ProductID_1 { get; set; }
            public int? ProductID_2 { get; set; }
            public int? ProductID_3 { get; set; }
            public int? ProductID_4 { get; set; }
            public int? ProductID_5 { get; set; }
            public int? ProductID_6 { get; set; }
            public int? ProductID_7 { get; set; }
            public int? ProductID_8 { get; set; }
            public int? ProductID_9 { get; set; }
            public int? ProductID_10 { get; set; }
        }
        public class GetIsUnit
        {
            public IsUnit? IsUnit_1 { get; set; }
            public IsUnit? IsUnit_2 { get; set; }
            public IsUnit? IsUnit_3 { get; set; }
            public IsUnit? IsUnit_4 { get; set; }
            public IsUnit? IsUnit_5 { get; set; }
            public IsUnit? IsUnit_6 { get; set; }
            public IsUnit? IsUnit_7 { get; set; }
            public IsUnit? IsUnit_8 { get; set; }
            public IsUnit? IsUnit_9 { get; set; }
            public IsUnit? IsUnit_10 { get; set; }
        }
    }
}
