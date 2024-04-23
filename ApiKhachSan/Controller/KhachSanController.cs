using ApiKhachSan.Database;
using ApiKhachSan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiKhachSan.Controller
{
    [Route("api/DuLich")]
    [ApiController]
    public class KhachSanController : ControllerBase
    {
        private DuLichContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        public KhachSanController(DuLichContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetHotels")]
        public async Task<ActionResult<IEnumerable<KhachSan>>> GetHotels()
        {
            return await db.Hotels.ToListAsync();
        }

        [HttpGet("GetHotel")]
        public async Task<ActionResult<KhachSan>> GetHotel([FromQuery] int? id=null,[FromQuery] string? address=null,[FromQuery] string? search=null)
        {
            IQueryable<KhachSan> query = db.Hotels;

            if (id != null)
            {
                query = query.Where(r => r.Id == id);
            }

            if (!string.IsNullOrEmpty(address))
            {
                string addressUnicode = address.ToLower().Trim();
                query = query.Where(x => x.Address.ToLower().Contains(addressUnicode));
            }

            if (!string.IsNullOrEmpty(search))
            {
                string searchUnicode = search.ToLower().Trim();
                query = query.Where(x => x.Name.ToLower().Contains(searchUnicode));
            }


            var hotels = await query.ToListAsync();

            if (!hotels.Any())
            {
                hotels = await db.Hotels.ToListAsync();
            }

            return Ok(hotels);
        }
      

        [HttpPost("PostHotel")]
        public async Task<ActionResult<KhachSan>> PostHotel([FromForm] KhachSanModel model)
        {
            var khachSan = new KhachSan()
            {
                Name = model.Name,
                DescHotel = model.DescHotel,
                DescLocation = model.DescLocation,
                Address = model.Address,
                Utilities = model.Utilities,
                Type = model.Type.ToString(),
                ImageUrl = await SaveFile(model.FileImages),
                Room = model.Room,
            };
            db.Hotels.Add(khachSan);
            await db.SaveChangesAsync();
            return Ok(model);
        }
       
        [HttpDelete("DeleteHotel/{id}")]
        public async Task<IActionResult> DeletePhong(int id)
        {
            var phong = await db.Hotels.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            db.Hotels.Remove(phong);
            await db.SaveChangesAsync();

            return NoContent();
        }


        [NonAction]
        public async Task<string> SaveFile(IFormFile[] fileNames)
        {
            var request = httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            string picture = "";
            if(fileNames.Length > 0)
            {
                foreach(var file in fileNames)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);
                    using(var stream = System.IO.File.Create(path))
                    {
                        await file.CopyToAsync(stream);
                    }
                    picture += baseUrl+"/Uploads/"+file.FileName + ";";
                }
            }
            return picture;
            
        }
    }
}
