using G9L.Data.EFs;

namespace G9L.Common.Sevices
{
    public interface IBaseSevices
    {
        G9LDbContext _DBContext { get; set; }
    }
}
