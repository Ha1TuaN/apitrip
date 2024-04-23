using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiKhachSan.Database;
using ApiKhachSan.Models;

namespace ApiKhachSan.Controller
{
    [Route("api/DuLich")]
    [ApiController]
    public class PhongsController : ControllerBase
    {
        private DuLichContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public PhongsController(DuLichContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetRooms")]
        public async Task<ActionResult<IEnumerable<Phong>>> GetRooms()
        {
            return await db.Rooms.ToListAsync();
        }
        [HttpGet("GetRoom")]
        public async Task<ActionResult<Phong>> GetRoom([FromQuery] int? id = null,[FromQuery] int? hotelID = null)
        {
            IQueryable<Phong> query = db.Rooms;

            if (id != null)
            {
                query = query.Where(r => r.Id == id);
            }

            if (hotelID != null)
            {
                query = query.Where(r => r.HotelId == hotelID);
            }

            var phong = await query.ToListAsync();

            if (phong == null)
            {
                return NotFound();
            }

            return Ok(phong);
        }


        [HttpPost("PostRoom")]
        public async Task<ActionResult<KhachSan>> PostHotel([FromForm] PhongModel model)
        {
            var phong = new Phong()
            {
                Name = model.Name,
                Services = model.Services,
                Type = model.Type.ToString(),
                Utilities = model.Utilities,
                Description = model.Description,
                ImageUrl = await SaveFile(model.fileName),
                Price = model.Price,
                HotelId = model.HotelId,
            };
            db.Rooms.Add(phong);
            await db.SaveChangesAsync();
            return Ok(phong);
        }
        [HttpDelete("DeleteRoom/{id}")]
        public async Task<IActionResult> DeletePhong(int id)
        {
            var phong = await db.Rooms.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            db.Rooms.Remove(phong);
            await db.SaveChangesAsync();

            return NoContent();
        }


        [NonAction]
        public async Task<string> SaveFile(IFormFile[] fileNames)
        {
            var request = httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            string picture = "";
            if (fileNames.Length > 0)
            {
                foreach (var file in fileNames)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", file.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await file.CopyToAsync(stream);
                    }
                    picture += baseUrl + "/Uploads/" + file.FileName + ";";
                }
            }
            return picture;
        }
       
    }
}
