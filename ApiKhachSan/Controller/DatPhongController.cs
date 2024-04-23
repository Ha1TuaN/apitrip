using ApiKhachSan.Database;
using ApiKhachSan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiKhachSan.Controller
{
    [Route("api/DuLich")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        private readonly DuLichContext db;
        public DatPhongController(DuLichContext db)
        {
            this.db = db;
        }
        [HttpGet("GetBookings")]
        public async Task<ActionResult<DatPhong>> GetBookings()
        {
            var result = db.Bookings.ToList();
            return Ok(result);
        }
        [HttpPost("PostBooking")]
        public async Task<ActionResult<DatPhong>> PostBooking(DatPhongModel model)
        {
            var booking = new DatPhong()
            {
                RoomId = model.RoomId,
                Name = model.Name,
                Sdt = model.Sdt,
                Email = model.Email,
                CCCD = model.CCCD,
                dateStart = model.dateStart,
                dateEnd = model.dateEnd,
            };
            db.Bookings.Add(booking);
            await db.SaveChangesAsync();
            return Ok("Add success");
        }
    }
}
