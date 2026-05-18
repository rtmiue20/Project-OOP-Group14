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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            txtClassName = new System.Windows.Forms.TextBox();
            txtStudentId = new System.Windows.Forms.TextBox();
            txtFullName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dgvStudents = new System.Windows.Forms.DataGridView();
            tabPage2 = new System.Windows.Forms.TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Location = new System.Drawing.Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(2425, 1133);
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
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(2417, 1105);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quản lý Sinh viên";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(481, 173);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(188, 47);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new System.Drawing.Point(481, 90);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(188, 47);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(481, 9);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(188, 47);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtClassName
            // 
            txtClassName.Location = new System.Drawing.Point(120, 173);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new System.Drawing.Size(288, 23);
            txtClassName.TabIndex = 6;
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new System.Drawing.Point(120, 22);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new System.Drawing.Size(288, 23);
            txtStudentId.TabIndex = 5;
            // 
            // txtFullName
            // 
            txtFullName.Location = new System.Drawing.Point(120, 90);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new System.Drawing.Size(288, 23);
            txtFullName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(23, 181);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(27, 15);
            label3.TabIndex = 3;
            label3.Text = "Lớp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(18, 98);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 15);
            label2.TabIndex = 2;
            label2.Text = "Họ Tên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(23, 30);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Mã SV";
            // 
            // dgvStudents
            // 
            dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new System.Drawing.Point(-4, 321);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersWidth = 102;
            dgvStudents.Size = new System.Drawing.Size(2401, 556);
            dgvStudents.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(2417, 1105);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quản lý Sự kiện";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2425, 1133);
            Controls.Add(tabControl1);
            Margin = new System.Windows.Forms.Padding(1);
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
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private Button btnAdd;
    }
}