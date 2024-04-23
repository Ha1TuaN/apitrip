using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiKhachSan.Database
{
    public class DatPhong
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string CCCD { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set;}
        public virtual Phong Room { get; set; }
    }
}
