using G9L.Data.Enum;

namespace G9L.Data.Entities
{
    public class Debit
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantily { get; set; }
        public IsUnit IsUnit { get; set; }
        public int Description { get; set; }
    }
}
