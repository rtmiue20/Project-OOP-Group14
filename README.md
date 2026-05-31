# 🏫 Quản Lý Đoàn Hội (QLDH)

Ứng dụng quản lý câu lạc bộ/đoàn hội được xây dựng bằng **C# WinForms** theo mô hình hướng đối tượng (OOP).

> **Môn học:** Lập trình hướng đối tượng  
> **Nhóm:** Group 14  
> **Trường:** Đại học Kinh Tế TPHCM (UEH)

---

## 📋 Mục lục

- [Tính năng](#tính-năng)
- [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
- [Cài đặt và chạy](#cài-đặt-và-chạy)
- [Cấu trúc dự án](#cấu-trúc-dự-án)
- [Thành viên nhóm](#thành-viên-nhóm)

---

## ✨ Tính năng

- Đăng nhập vào hệ thống
- Quản lý Công tác đoàn hội
- Thêm, sửa, xóa, tìm kiếm các thông tin liên quan
- Giao diện thân thiện với Windows Forms

---

## 💻 Yêu cầu hệ thống

| Yêu cầu | Chi tiết |
|---|---|
| Hệ điều hành | Windows 10 / 11 |
| .NET SDK | .NET 6.0 trở lên |
| IDE | JetBrains Rider 2023.x trở lên |
| RAM | Tối thiểu 4GB |

---

## 🚀 Cài đặt và chạy

### Bước 1 — Cài đặt môi trường

1. Cài đặt [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
2. Cài đặt [JetBrains Rider](https://www.jetbrains.com/rider/download/)

### Bước 2 — Clone repository

```bash
git clone https://github.com/rtmiue20/Project-OOP-Group14.git
cd Project-OOP-Group14
```

### Bước 3 — Mở dự án trong Rider

1. Mở **JetBrains Rider**
2. Chọn **Open** ở màn hình chào
3. Tìm đến thư mục vừa clone, chọn file `Quản-lý-đoàn-hội.sln`
4. Nhấn **OK** / **Trust and Open**

### Bước 4 — Restore packages và Build

Rider sẽ tự động restore NuGet packages khi mở solution. Nếu không, làm thủ công:

- Nhấn chuột phải vào **Solution** trong cửa sổ Explorer → chọn **Restore NuGet Packages**
- Sau đó nhấn `Ctrl + F9` để Build toàn bộ solution

### Bước 5 — Chạy ứng dụng

- Chọn project **Winforms** trong thanh Run Configuration (góc trên phải)
- Nhấn **▶ Run** hoặc `Shift + F10`

Hoặc dùng terminal tích hợp trong Rider:

```bash
cd Winforms
dotnet run
```

---

## 📁 Cấu trúc dự án

```
Project-OOP-Group14/
├── QLDH/                      # Business logic layer
│   ├── Data/                  # Xử lý và lưu trữ dữ liệu
│   ├── Entities/              # Các lớp thực thể (Club, Student, Human,...)
│   └── Services/              # Các dịch vụ xử lý nghiệp vụ
│
├── Winforms/                  # Presentation layer (UI)
│   ├── FormLogin.cs           # Form đăng nhập
│   ├── FormMain.cs            # Form chính
│   └── Program.cs             # Điểm khởi chạy ứng dụng
│
└── Quản-lý-đoàn-hội.sln      # Solution file
```

---

## 👥 Thành viên nhóm

| Họ tên | MSSV | Vai trò |
|---|---|---|
| Nguyễn Văn Minh Triều | 31241027455 | Nhóm trưởng |
|Nguyễn Phúc Vương | 31241025017 | Thành viên |
| Ngô Trọng Phúc | 31241020074 | Thành viên |
| Triệu Nguyễn Huỳnh Khang | 31241022785 | Thành viên |
---

## 📄 License

Dự án được thực hiện cho mục đích học tập.
