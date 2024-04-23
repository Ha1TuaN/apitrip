using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace ApiKhachSan.Database
{
    public class DuLichContext : DbContext
    {
        public DuLichContext(DbContextOptions options) : base(options) { }
        
        public DbSet<KhachSan> Hotels { get; set; }
        public DbSet<Phong> Rooms { get; set; }
        public DbSet<DatPhong> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KhachSan>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Phong>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<Phong>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.Room)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<DatPhong>()
                .HasKey(k => k.Id);


            modelBuilder.Entity<DatPhong>()
                .HasOne(b => b.Room)
                .WithMany(r => r.Booking)
                .HasForeignKey(b => b.RoomId);
        }
       

    }
}
