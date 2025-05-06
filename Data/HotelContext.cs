using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelLib.Models;

namespace Hotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext (DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<HotelLib.Models.Guest> Guest { get; set; } = default!;
        public DbSet<HotelLib.Models.Room> Room { get; set; } = default!;
        public DbSet<HotelLib.Models.Reservasjon> Reservasjon { get; set; } = default!;
    }
}
