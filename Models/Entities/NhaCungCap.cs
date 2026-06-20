using Microsoft.EntityFrameworkCore;

namespace Models.Entities.NhaCungCap
{
    public class NhaCungCap
    {
        public string? MaNCC { get; set; }
        public string? TenNCC { get; set; }
        public ICollection<SanPham.SanPham>? SanPhams { get; set; }
    }
}