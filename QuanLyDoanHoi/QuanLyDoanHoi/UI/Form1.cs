using System;
using System.Windows.Forms;
using QuanLyDoanHoi.Service;
using QuanLyDoanHoi.Entities;

namespace QuanLyDoanHoi
{
    public partial class Form1 : Form
    {
        // 1. Khai báo "bộ não" quản lý sinh viên
        private StudentManager studentManager = new StudentManager();

        public Form1()
        {
            InitializeComponent();

            // 2. Gọi hàm tải dữ liệu ngay khi Form vừa mở lên
            LoadData();
        }

        // 3. Hàm tải dữ liệu lên bảng
        private void LoadData()
        {
            // Xóa sạch dữ liệu cũ trên bảng (nếu có)
            dgvStudents.DataSource = null;

            // Lấy danh sách từ Manager đổ thẳng vào bảng
            dgvStudents.DataSource = studentManager.GetAll();
        }
    }
}