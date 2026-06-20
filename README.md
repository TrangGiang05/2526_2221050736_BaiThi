*appset: Data Source=app.db; Cache=Shared
* Tạo CSDL
dotnet ef migrations add <Tên_Bất_Kỳ_Viết_Liền>
dotnet ef database update

*sinh code tu dong
dotnet aspnet-codegenerator controller -name <Tên_Controller_Muốn_Tạo> -m <Tên_Class_Model> -dc <Tên_Class_DbContext> --useDefaultLayout --referenceScriptLibraries
vd:
dotnet aspnet-codegenerator controller -name StudentController -m Student -dc ApplicationDbContext --useDefaultLayout --referenceScriptLibraries

* Cài công cụ sinh code: dotnet tool install -g dotnet-aspnet-codegenerator
* Cài thư viện thiết kế: dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet aspnet-codegenerator controller -name StudentController -m Student -dc OnTest.Data.ApplicationDbContext -outDir Controllers --useDefaultLayout --referenceScriptLibraries

*Data Annotation (Bắt lỗi) model
using System.ComponentModel.DataAnnotations;
public int Id { get; set; }
    [Required (ErrorMessage = "Name is required")]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
    [Display(Name = "Student Name")]

*Liên kết khóa ngoại
   - Cha: public ICollection<Student> Students { get; set; }
   - Con: 1. Mã định danh của Cha (Bắt buộc phải viết theo cú pháp: TênBảngCha + Id)
   	 public int LopHocId { get; set; } 
    	 2. Bản thể của Cha (Navigation property)
   	 public LopHoc? LopHoc { get; set; }
   --> sau đó đăng ký cầu nối applicationdbcontext
   --> sau đó tạo bản migrations

* ViewModel (Cái rổ chứa dữ liệu lai tạp để hiển thị lên View)
- Code mẫu: Chỉ khai báo đúng các cột View cần hiển thị
  public class StudentListVM 
  {
      public string TenSinhVien { get; set; }
      public string TenLopHoc { get; set; }
  }

* LINQ (Truy vấn & Gộp bảng)
- Code mẫu trong Action
        public IActionResult StudentList() var data = _context.Students...
- Bên file View (.cshtml) nhớ đổi @model để hứng đúng cái rổ:
  @model IEnumerable<TenDuAn.Models.ViewModels.StudentListVM>

* AJAX XÓA
1. CONTROLLER
[HttpPost]
public IActionResult DeleteAjax(int id) 
{
    var obj = _context.Students.Find(id);
    if (obj == null) return Json(new { success = false });
    
    _context.Students.Remove(obj);
    _context.SaveChanges();
    return Json(new { success = true });
}

2. FILE JAVASCRIPT
- Tạo file mới: wwwroot/js/student.js
- Dán code này vào:
function xoaAjax(id) {
    if (confirm("Chắc chắn xóa?")) {
        $.ajax({
            type: "POST",
            url: "/Student/DeleteAjax", 
            data: { id: id },
            success: function (res) {
                if (res.success) {
                    $("#row_" + id).fadeOut(); // Ẩn dòng bị xóa cực mượt
                } else {
                    alert("Lỗi server!");
                }
            }
        });
    }
}

3. VIEW - HTML (.cshtml)
- Tại bảng dữ liệu, thêm ID cho thẻ tr & Đổi nút xóa:
<tr id="row_@item.Id"> 
    ... các cột td ...
    <td>
        <button type="button" class="btn btn-danger" onclick="xoaAjax(@item.Id)">Xóa AJAX</button>
    </td>
</tr>

- Kéo xuống dưới cùng file (để nhúng file JS kia vào):
@section Scripts {
    <script src="~/js/student.js"></script>
}