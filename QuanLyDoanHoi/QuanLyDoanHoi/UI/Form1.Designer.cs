using QuanLyDoanHoi.Service;
using QuanLyDoanHoi.Entities;
namespace QuanLyDoanHoi
{
    partial class Form1 : Form 
    {
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ các TextBox
            string studentId = txtStudentId.Text;
            string fullName = txtFullName.Text;
            string className = txtClassName.Text;
            // 2. Tạo đối tượng Student mới
            Student newStudent = new Student
            {
                StudentId = studentId,
                FullName = fullName,
                ClassName = className
            };
            // 3. Thêm vào Manager
            studentManager.Add(newStudent);
            // 4. Tải lại dữ liệu lên bảng
            LoadData();
        }
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtClassName = new TextBox();
            txtStudentId = new TextBox();
            txtFullName = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvStudents = new DataGridView();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(2425, 1133);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnDelete);
            tabPage1.Controls.Add(btnEdit);
            tabPage1.Controls.Add(btnAdd);
            tabPage1.Controls.Add(txtClassName);
            tabPage1.Controls.Add(txtStudentId);
            tabPage1.Controls.Add(txtFullName);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dgvStudents);
            tabPage1.Location = new Point(10, 58);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(2405, 1065);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quản lý Sinh viên";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(481, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(188, 47);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(481, 90);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(188, 47);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(481, 9);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(188, 47);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(156, 173);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(288, 47);
            txtClassName.TabIndex = 6;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(156, 9);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(288, 47);
            txtStudentId.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(156, 90);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(288, 47);
            txtFullName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 176);
            label3.Name = "label3";
            label3.Size = new Size(68, 41);
            label3.TabIndex = 3;
            label3.Text = "Lớp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 99);
            label2.Name = "label2";
            label2.Size = new Size(111, 41);
            label2.TabIndex = 2;
            label2.Text = "Họ Tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(103, 41);
            label1.TabIndex = 1;
            label1.Text = "Mã SV";
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(3, 324);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 102;
            dgvStudents.Size = new Size(2401, 556);
            dgvStudents.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(10, 58);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(2405, 1065);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quản lý Sự kiện";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2425, 1133);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvStudents;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtClassName;
        private TextBox txtStudentId;
        private TextBox txtFullName;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
    }
}