using System.ComponentModel;

namespace ApiKhachSan.Database
{
    public class KhachSan
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DescHotel { get; set; }
        public string? DescLocation { get; set; }
        public string Address { get; set; }
        public string? Utilities { get; set; }
        public string? Type { get; set; }
        public string ImageUrl { get; set; }
        public List<Phong> Room { get; set; }
        public KhachSan() 
        {
            Room = new List<Phong>();
        }
    }
}
