﻿namespace G9L.Wedsite.Models
{
    public class MessageModel
    {
        public static string AddItemSuccessful() => "Thêm thông tin thành công!";

        public static string AddItemFaled() => "Thêm thông tin thất bại!";

        public static string UpdateItemSuccessful() => "Cập nhật thông tin thành công!";

        public static string UpdateItemFaled() => "Cập nhật tin thất bại!";

        public  const string DeleteItemSuccessful = "Xóa thông tin thành công!";

        public const string DeleteItemFaled = "Xóa thông tin thất bại!";

        public const string ConnectionFaled = "Kết nối với dự liệu thất bại!";
    }
}
