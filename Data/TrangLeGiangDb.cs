using Microsoft.EntityFrameworkCore;
using Models.Entities.NhaCungCap;

namespace _2526_2221050736_BaiThi.Data
{
    public class TrangLeGiangDb : DbContext
    {
        public TrangLeGiangDb(DbContextOptions<TrangLeGiangDb> options) : base(options)
        {
        }

        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
    }
}