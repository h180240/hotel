using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;

namespace Hotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext (DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel.Models.Guest> Guest { get; set; } = default!;
        public DbSet<Hotel.Models.Room> Room { get; set; } = default!;
        public DbSet<Hotel.Models.Reservasjon> Reservasjon { get; set; } = default!;
    }
}
