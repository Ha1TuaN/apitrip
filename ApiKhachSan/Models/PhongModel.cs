using System.ComponentModel;

namespace ApiKhachSan.Models
{
    public enum RoomType
    {
        [Description("Giường đơn")]
        OneBed,
        [Description("Giường đôi")]
        TwoBed,
    }
    public class PhongModel
    {
        public string? Name { get; set; }
        public string? Services { get; set; }
        public RoomType Type { get; set; }
        public string? Utilities { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile[]? fileName { get; set; }
        public int HotelId { get; set; }
    }
}
