using Microsoft.EntityFrameworkCore;
using Models.Entities.NhaCungCap;

namespace Models.Entities.SanPham
{
    public class SanPham
    {
        public string? MaSP { get; set; }
        public string? TenSP { get; set; }
        
        public string? MaNCC { get; set; }
        public NhaCungCap? NhaCungCap { get; set; }
    }
}