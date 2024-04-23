using ApiKhachSan.Database;
using System.ComponentModel;

namespace ApiKhachSan.Models
{
    public enum HotelType
    {
        [Description("5 sao")]
        FiveStar,
        [Description("4 sao")]
        FourStar,
        [Description("3 sao")]
        ThreeStar,
        [Description("2 sao")]
        TwoStar,
        [Description("1 sao")]
        OneStar
    }
    public class KhachSanModel
    {
        public string Name { get; set; }
        public string? DescHotel { get; set; }
        public string? DescLocation { get; set; }
        public string? Utilities { get; set; }   
        public string Address { get; set; }
        public HotelType? Type { get; set; }
        public IFormFile[] FileImages { get; set; }

        public List<Phong> Room = new List<Phong>();
    }
}
