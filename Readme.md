## Controller
~ Là một lớp kế thừa từ lớp Controller: Microsoft.Asp.NetCore.Mvc.Controller
- Action trong Controller là một phương thức public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào Controller qua hàm tạo

## View
- Là file .cshtml
- View cho Action lưu tai : /View/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View
```
// {0} => name Action
// {1} => name Controller
// {2} => name Area
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```
### Truyền duữ liệu ssang View
- Model
- ViewData
- ViewBag
- TempData
