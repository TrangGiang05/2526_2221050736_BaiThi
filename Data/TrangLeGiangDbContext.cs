using Microsoft.EntityFrameworkCore;
using Models.Entities.NhaCungCap;

public class TrangLeGiangDbContext : DbContext
{
    public TrangLeGiangDbContext(DbContextOptions<TrangLeGiangDbContext> options)
        : base(options)
    {
    }

    public DbSet<NhaCungCap> NhaCungCaps { get; set; }
}