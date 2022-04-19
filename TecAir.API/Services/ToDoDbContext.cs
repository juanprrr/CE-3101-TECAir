using Microsoft.EntityFrameworkCore;
using TecAir.API.Models;

namespace TecAir.API.Services
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
        public DbSet<AeroportDto> Aeroport { get; set; }
        public DbSet<AirplaneDto> Airplane { get; set; }
        public DbSet<DestinationDto> Destination { get; set; }
        public DbSet<EmployeeDto> Employee { get; set; }
        public DbSet<FlightDto> Flight { get; set; }
        public DbSet<GateDto> Gate { get; set; }
        public DbSet<OriginDto> Origin { get; set; }
        public DbSet<PromotionDto> Promotion { get; set; }
        public DbSet<ReservationDto> Reservation { get; set; }
        public DbSet<RoleDto> Role { get; set; }
        public DbSet<RouteDto> Route { get; set; }
        public DbSet<SeatDto> Seat { get; set; }
        public DbSet<SuitcaseDto> Suitcase { get; set; }
        public DbSet<TravelDto> Travel { get; set; }
        public DbSet<UniversityDto> University { get; set; }
        public DbSet<UserDto> User { get; set; }
    }
}
