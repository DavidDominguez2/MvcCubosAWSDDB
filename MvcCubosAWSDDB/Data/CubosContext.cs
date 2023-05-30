using Microsoft.EntityFrameworkCore;
using MvcCubosAWSDDB.Models;

namespace MvcCubosAWSDDB.Data {
    public class CubosContext : DbContext {

        public CubosContext(DbContextOptions<CubosContext> options) : base(options) { }

        public DbSet<Cubo> Cubos { get; set; }

    }
}
