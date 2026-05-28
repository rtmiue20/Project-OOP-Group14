# Project Quản Lý Đoàn Hội - Group 14

Dự án quản lý hoạt động Đoàn - Hội sinh viên bằng C# WinForms, sử dụng mô hình lập trình hướng đối tượng (OOP) và lưu trữ dữ liệu JSON.

## 📌 Các chức năng chính đã thực hiện

### 1. Hệ thống & Bảo mật
- **BaseManager**: Lớp cơ sở dùng Generic (`BaseManager<T>`) để quản lý CRUD. Đã chuyển đổi từ `BinaryFormatter` sang `System.Text.Json` để đảm bảo bảo mật và tương thích .NET 9.
- **FileHelper**: Hỗ trợ lưu/đọc dữ liệu JSON tự động trong thư mục `data/`.
- **FormLogin**: Giao diện đăng nhập, phân quyền người dùng (Admin/User).

### 2. Quản lý Đoàn viên & Sinh viên
- **StudentManager**: Quản lý thông tin sinh viên cơ bản.
- **OfficialManager**: Quản lý cán bộ Đoàn (kế thừa từ Sinh viên).
- **Tính điểm rèn luyện**: Tự động cộng/trừ điểm khi tham gia sự kiện (sử dụng Đa hình - Polymorphism).

### 3. Quản lý Sự kiện & Tổ chức
- **EventManager**: Quản lý các sự kiện Đoàn - Hội, ghi nhận lịch sử tham gia.
- **ClubManager**: Quản lý các Câu lạc bộ.
- **FacultyManager**: Quản lý thông tin các Khoa.

### 4. Khen thưởng
- **RewardManager**: Theo dõi danh sách khen thưởng của từng sinh viên.

## 🛠 Hướng dẫn giao diện FormMain

Giao diện chính được chia thành các Tab để dễ quản lý:

1. **Tab Sinh viên**:
   - `DataGridView`: Hiển thị danh sách.
   - `GroupBox` chứa các `TextBox` (Mã SV, Họ tên, Lớp, Điểm RL).
   - Nút: Thêm, Sửa, Xóa, Tìm kiếm.
2. **Tab Sự kiện**:
   - Danh sách sự kiện và điểm thưởng tương ứng.
   - Nút "Đăng ký tham gia" để ghi nhận cho sinh viên.
3. **Tab Tổ chức**:
   - Quản lý CLB và Khoa.
4. **Tab Khen thưởng**:
   - Tra cứu khen thưởng theo mã sinh viên.

## 📂 Cấu trúc thư mục
- `QLDH/Entities`: Các lớp đối tượng (Student, Event, Account, ...).
- `QLDH/Services`: Các lớp xử lý logic (Manager).
- `QLDH/Data`: Lớp hỗ trợ đọc/ghi file.
- `Winforms/`: Giao diện người dùng.

## 🚀 Lưu ý kỹ thuật
- **Framework**: .NET 9.0 (Windows Forms).
- **Dữ liệu**: Các file `.json` được lưu trong `Winforms/bin/Debug/net9.0-windows/data/`.
- **Tài khoản mặc định**: `admin` / `admin123`.
