using System.ComponentModel;

namespace ApiKhachSan.Database
{
    public class Phong
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Services { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public string Utilities { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int HotelId { get; set; }
        public virtual KhachSan Hotel { get; set; }
        public ICollection<DatPhong> Booking { get; set; }
        public Phong()
        {
            Booking = new HashSet<DatPhong>();
        }

    }
}
