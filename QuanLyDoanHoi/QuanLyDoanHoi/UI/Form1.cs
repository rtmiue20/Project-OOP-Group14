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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            
            string studentId = txtStudentId.Text.Trim(); 

            // Kiểm tra xem người dùng đã nhập Mã SV chưa
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Mã SV cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên có mã {studentId} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    
            if (confirm == DialogResult.Yes)
            {
                // Gọi hàm Delete từ Manager
                studentManager.Delete(studentId);

                // Tải lại dữ liệu lên DataGridView để cập nhật giao diện
                LoadData();

                
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                txtStudentId.Clear();
                txtFullName.Clear(); 
                txtClassName.Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}