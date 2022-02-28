namespace G9L.Data.Enum
{
    public enum CheckProductInWarehouse
    {
        /// <summary>
        /// Không tìm thấy hàng cần
        /// </summary>
        Undiscovered = 0,
        /// <summary>
        /// Hết hàng 
        /// </summary>
        OutOfStock = 1,
        /// <summary>
        /// Không đủ hàng bán
        /// </summary>
        InsufficientOfStock = 2,
        /// <summary>
        /// Bán hàng thành công
        /// </summary>
        SuccessfulSales = 3,
        /// <summary>
        /// Thành công
        /// </summary>
        Successful = 4
    }
}
