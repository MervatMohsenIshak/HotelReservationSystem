using Microsoft.EntityFrameworkCore;
using HotelReservationSystem.Domain.Entities;

namespace HotelReservationSystem.Persistence.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Room> Room { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Reservations> Reservation { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<RoomSpacifications> RoomSpacifications { get; set; }
        public DbSet<RoomTypeSpacifications> RoomTypeSpacifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings (if needed)
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<RoomTypeSpacifications>()
           .HasKey(rt => new { rt.RoomTypeId, rt.RoomSpacificationsId });

            modelBuilder.Entity<RoomType>().HasData(
               new RoomType { Id = 1, Name = "Deluxe" },
               new RoomType { Id = 2, Name = "Single" },
               new RoomType { Id = 3, Name = "Double" }
            );

            modelBuilder.Entity<RoomSpacifications>().HasData(
               new RoomSpacifications { Id = 1, Name = "Pool view" },
               new RoomSpacifications { Id = 2, Name = "See View" },
               new RoomSpacifications { Id = 3, Name = "Air conditioning" },
               new RoomSpacifications { Id = 4, Name = "TV" },
               new RoomSpacifications { Id = 5, Name = "WiFi" },
               new RoomSpacifications { Id = 6, Name = "electric Kettle" }
            );


            modelBuilder.Entity<RoomTypeSpacifications>().HasData(
                new RoomTypeSpacifications { RoomTypeId = 1, RoomSpacificationsId = 1 },
                new RoomTypeSpacifications { RoomTypeId = 1, RoomSpacificationsId = 5 },
                new RoomTypeSpacifications { RoomTypeId = 1, RoomSpacificationsId = 3 },
                new RoomTypeSpacifications { RoomTypeId = 1, RoomSpacificationsId = 4 },
                new RoomTypeSpacifications { RoomTypeId = 1, RoomSpacificationsId = 6 },
                new RoomTypeSpacifications { RoomTypeId = 2, RoomSpacificationsId = 2 },
                new RoomTypeSpacifications { RoomTypeId = 2, RoomSpacificationsId = 5 },
                new RoomTypeSpacifications { RoomTypeId = 2, RoomSpacificationsId = 4 },
                new RoomTypeSpacifications { RoomTypeId = 3, RoomSpacificationsId = 6 },
                new RoomTypeSpacifications { RoomTypeId = 3, RoomSpacificationsId = 3 },
                new RoomTypeSpacifications { RoomTypeId = 3, RoomSpacificationsId = 1 }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomNumber = 1001, RoomTypeId = 1, FloorNumber = 1, AdultNo = 2, ChildNo = 1 },
                new Room { Id = 2, RoomNumber = 2002, RoomTypeId = 2, FloorNumber = 2, AdultNo = 1, ChildNo = 0 }
            );

            modelBuilder.Entity<BoardingType>().HasData(
                new BoardingType { Id = 1, Name = "Full Board" },
                new BoardingType { Id = 2, Name = "Half Board" },
                new BoardingType { Id = 3, Name = "Breakfast only" }
            );

            modelBuilder.Entity<ReservationStatus>().HasData(
                new ReservationStatus { Id = 1, Name = "UpComing" },
                new ReservationStatus { Id = 2, Name = "Active" },
                new ReservationStatus { Id = 3, Name = "Past" },
                new ReservationStatus { Id = 4, Name = "Canceled" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer {Id= Guid.Parse("A38322C7-79EB-409C-8F8C-08DCC87D6780"), Name = "Ali", Email = "Ali@gmail.com", MobileNumber = "0123546987", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow },
                new Customer {Id = Guid.Parse("A38322C7-79EB-409C-8D8D-08DCC87D6780"), Name = "Sara", Email = "Sara@gmail.com", MobileNumber = "01235441987", CreatedOn = DateTime.UtcNow, UpdatedOn = DateTime.UtcNow }
            );

            modelBuilder.Entity<Reservations>().HasData(
                new Reservations 
                { 
                    Id = 1,
                    ReferenceNumber = "RS1050924", 
                    CustomerId = Guid.Parse("A38322C7-79EB-409C-8F8C-08DCC87D6780"), 
                    RoomId = 1,
                    BoardingTypeId = 1,
                    ReservationStatusId = 1, 
                    StartDate = DateTime.UtcNow, 
                    EndDate = DateTime.UtcNow.AddDays(15),
                    CreatedOn = DateTime.UtcNow, 
                    UpdatedOn = DateTime.UtcNow 
                },
                new Reservations
                {
                    Id = 2,
                    ReferenceNumber = "RS2300824",
                    CustomerId = Guid.Parse("A38322C7-79EB-409C-8D8D-08DCC87D6780"),
                    RoomId = 2,
                    BoardingTypeId = 2,
                    ReservationStatusId = 2,
                    StartDate = new DateTime(2024, 8, 30, 14, 30, 0),
                    EndDate = new DateTime(2024, 9, 05, 14, 30, 0),
                    CreatedOn = new DateTime(2024, 8, 29, 14, 30, 0),
                    UpdatedOn = new DateTime(2024, 8, 29, 14, 30, 0)
                }
            );
        }
    }
}
