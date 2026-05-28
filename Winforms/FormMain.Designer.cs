using System.ComponentModel;

namespace Quản_lý_đoàn_hội;

partial class FormMain
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        tc_demo = new System.Windows.Forms.TabControl();
        tp_SVDV = new System.Windows.Forms.TabPage();
        groupBox3 = new System.Windows.Forms.GroupBox();
        btn_studentUpdate = new System.Windows.Forms.Button();
        btn_studentDelete = new System.Windows.Forms.Button();
        btn_studentSearch = new System.Windows.Forms.Button();
        btn_studentAdd = new System.Windows.Forms.Button();
        txt_studentSearch = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        groupBox2 = new System.Windows.Forms.GroupBox();
        cb_isOfficial = new System.Windows.Forms.CheckBox();
        lbl_role = new System.Windows.Forms.Label();
        txt_term = new System.Windows.Forms.TextBox();
        txt_role = new System.Windows.Forms.TextBox();
        lbl_term = new System.Windows.Forms.Label();
        groupBox1 = new System.Windows.Forms.GroupBox();
        cbb_faculty = new System.Windows.Forms.ComboBox();
        nud_birthYear = new System.Windows.Forms.NumericUpDown();
        txt_class = new System.Windows.Forms.TextBox();
        label7 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        txt_fullName = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        txt_studentId = new System.Windows.Forms.TextBox();
        dgv_student = new System.Windows.Forms.DataGridView();
        tp_SK = new System.Windows.Forms.TabPage();
        tp_TC = new System.Windows.Forms.TabPage();
        tp_KT = new System.Windows.Forms.TabPage();
        tc_demo.SuspendLayout();
        tp_SVDV.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nud_birthYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgv_student).BeginInit();
        SuspendLayout();
        // 
        // tc_demo
        // 
        tc_demo.Controls.Add(tp_SVDV);
        tc_demo.Controls.Add(tp_SK);
        tc_demo.Controls.Add(tp_TC);
        tc_demo.Controls.Add(tp_KT);
        tc_demo.Location = new System.Drawing.Point(1, 2);
        tc_demo.Name = "tc_demo";
        tc_demo.SelectedIndex = 0;
        tc_demo.Size = new System.Drawing.Size(1908, 1141);
        tc_demo.TabIndex = 0;
        // 
        // tp_SVDV
        // 
        tp_SVDV.BackColor = System.Drawing.Color.Transparent;
        tp_SVDV.Controls.Add(groupBox3);
        tp_SVDV.Controls.Add(groupBox2);
        tp_SVDV.Controls.Add(groupBox1);
        tp_SVDV.Controls.Add(dgv_student);
        tp_SVDV.Location = new System.Drawing.Point(10, 58);
        tp_SVDV.Name = "tp_SVDV";
        tp_SVDV.Padding = new System.Windows.Forms.Padding(3);
        tp_SVDV.Size = new System.Drawing.Size(1888, 1073);
        tp_SVDV.TabIndex = 0;
        tp_SVDV.Text = "Sinh viên & Đoàn viên";
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(btn_studentUpdate);
        groupBox3.Controls.Add(btn_studentDelete);
        groupBox3.Controls.Add(btn_studentSearch);
        groupBox3.Controls.Add(btn_studentAdd);
        groupBox3.Controls.Add(txt_studentSearch);
        groupBox3.Controls.Add(label4);
        groupBox3.Location = new System.Drawing.Point(6, 571);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(617, 353);
        groupBox3.TabIndex = 5;
        groupBox3.TabStop = false;
        // 
        // btn_studentUpdate
        // 
        btn_studentUpdate.Location = new System.Drawing.Point(6, 221);
        btn_studentUpdate.Name = "btn_studentUpdate";
        btn_studentUpdate.Size = new System.Drawing.Size(605, 47);
        btn_studentUpdate.TabIndex = 23;
        btn_studentUpdate.Text = "Cập nhật";
        btn_studentUpdate.UseVisualStyleBackColor = true;
        // 
        // btn_studentDelete
        // 
        btn_studentDelete.Location = new System.Drawing.Point(6, 285);
        btn_studentDelete.Name = "btn_studentDelete";
        btn_studentDelete.Size = new System.Drawing.Size(605, 47);
        btn_studentDelete.TabIndex = 22;
        btn_studentDelete.Text = "Xóa";
        btn_studentDelete.UseVisualStyleBackColor = true;
        // 
        // btn_studentSearch
        // 
        btn_studentSearch.Location = new System.Drawing.Point(6, 93);
        btn_studentSearch.Name = "btn_studentSearch";
        btn_studentSearch.Size = new System.Drawing.Size(605, 47);
        btn_studentSearch.TabIndex = 21;
        btn_studentSearch.Text = "Tìm kiếm";
        btn_studentSearch.UseVisualStyleBackColor = true;
        // 
        // btn_studentAdd
        // 
        btn_studentAdd.Location = new System.Drawing.Point(6, 155);
        btn_studentAdd.Name = "btn_studentAdd";
        btn_studentAdd.Size = new System.Drawing.Size(605, 47);
        btn_studentAdd.TabIndex = 20;
        btn_studentAdd.Text = "Thêm mới";
        btn_studentAdd.UseVisualStyleBackColor = true;
        // 
        // txt_studentSearch
        // 
        txt_studentSearch.Location = new System.Drawing.Point(238, 25);
        txt_studentSearch.Name = "txt_studentSearch";
        txt_studentSearch.Size = new System.Drawing.Size(373, 47);
        txt_studentSearch.TabIndex = 19;
        // 
        // label4
        // 
        label4.BackColor = System.Drawing.Color.DarkGray;
        label4.ForeColor = System.Drawing.SystemColors.ControlText;
        label4.Location = new System.Drawing.Point(6, 25);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(226, 47);
        label4.TabIndex = 13;
        label4.Text = "Tìm kiếm:";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(cb_isOfficial);
        groupBox2.Controls.Add(lbl_role);
        groupBox2.Controls.Add(txt_term);
        groupBox2.Controls.Add(txt_role);
        groupBox2.Controls.Add(lbl_term);
        groupBox2.Location = new System.Drawing.Point(3, 343);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(617, 222);
        groupBox2.TabIndex = 4;
        groupBox2.TabStop = false;
        // 
        // cb_isOfficial
        // 
        cb_isOfficial.BackColor = System.Drawing.Color.DarkGray;
        cb_isOfficial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
        cb_isOfficial.Location = new System.Drawing.Point(9, 27);
        cb_isOfficial.Name = "cb_isOfficial";
        cb_isOfficial.Size = new System.Drawing.Size(605, 47);
        cb_isOfficial.TabIndex = 13;
        cb_isOfficial.Text = "Là Cán bộ Đoàn?";
        cb_isOfficial.UseVisualStyleBackColor = false;
        // 
        // lbl_role
        // 
        lbl_role.BackColor = System.Drawing.Color.DarkGray;
        lbl_role.ForeColor = System.Drawing.SystemColors.ControlText;
        lbl_role.Location = new System.Drawing.Point(9, 89);
        lbl_role.Name = "lbl_role";
        lbl_role.Size = new System.Drawing.Size(226, 47);
        lbl_role.TabIndex = 12;
        lbl_role.Text = "Chức vụ:";
        // 
        // txt_term
        // 
        txt_term.Location = new System.Drawing.Point(241, 150);
        txt_term.Name = "txt_term";
        txt_term.Size = new System.Drawing.Size(373, 47);
        txt_term.TabIndex = 17;
        // 
        // txt_role
        // 
        txt_role.Location = new System.Drawing.Point(241, 89);
        txt_role.Name = "txt_role";
        txt_role.Size = new System.Drawing.Size(373, 47);
        txt_role.TabIndex = 18;
        // 
        // lbl_term
        // 
        lbl_term.BackColor = System.Drawing.Color.DarkGray;
        lbl_term.ForeColor = System.Drawing.SystemColors.ControlText;
        lbl_term.Location = new System.Drawing.Point(9, 150);
        lbl_term.Name = "lbl_term";
        lbl_term.Size = new System.Drawing.Size(226, 47);
        lbl_term.TabIndex = 11;
        lbl_term.Text = "Nhiệm kỳ:";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(cbb_faculty);
        groupBox1.Controls.Add(nud_birthYear);
        groupBox1.Controls.Add(txt_class);
        groupBox1.Controls.Add(label7);
        groupBox1.Controls.Add(label6);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(txt_fullName);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(txt_studentId);
        groupBox1.Location = new System.Drawing.Point(6, 6);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(617, 331);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        // 
        // cbb_faculty
        // 
        cbb_faculty.FormattingEnabled = true;
        cbb_faculty.Location = new System.Drawing.Point(238, 273);
        cbb_faculty.Name = "cbb_faculty";
        cbb_faculty.Size = new System.Drawing.Size(373, 49);
        cbb_faculty.TabIndex = 20;
        // 
        // nud_birthYear
        // 
        nud_birthYear.Location = new System.Drawing.Point(238, 150);
        nud_birthYear.Name = "nud_birthYear";
        nud_birthYear.Size = new System.Drawing.Size(373, 47);
        nud_birthYear.TabIndex = 19;
        // 
        // txt_class
        // 
        txt_class.Location = new System.Drawing.Point(238, 211);
        txt_class.Name = "txt_class";
        txt_class.Size = new System.Drawing.Size(373, 47);
        txt_class.TabIndex = 15;
        // 
        // label7
        // 
        label7.BackColor = System.Drawing.Color.DarkGray;
        label7.ForeColor = System.Drawing.SystemColors.ControlText;
        label7.Location = new System.Drawing.Point(6, 150);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(226, 47);
        label7.TabIndex = 10;
        label7.Text = "Năm sinh:";
        // 
        // label6
        // 
        label6.BackColor = System.Drawing.Color.DarkGray;
        label6.ForeColor = System.Drawing.SystemColors.ControlText;
        label6.Location = new System.Drawing.Point(6, 273);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(226, 47);
        label6.TabIndex = 9;
        label6.Text = "Khoa:";
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.DarkGray;
        label3.ForeColor = System.Drawing.SystemColors.ControlText;
        label3.Location = new System.Drawing.Point(6, 211);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(226, 47);
        label3.TabIndex = 6;
        label3.Text = "Lớp:";
        // 
        // txt_fullName
        // 
        txt_fullName.Location = new System.Drawing.Point(238, 87);
        txt_fullName.Name = "txt_fullName";
        txt_fullName.Size = new System.Drawing.Size(373, 47);
        txt_fullName.TabIndex = 4;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.DarkGray;
        label2.ForeColor = System.Drawing.SystemColors.ControlText;
        label2.Location = new System.Drawing.Point(6, 87);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(226, 47);
        label2.TabIndex = 3;
        label2.Text = "Họ và tên:";
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.DarkGray;
        label1.ForeColor = System.Drawing.SystemColors.ControlText;
        label1.Location = new System.Drawing.Point(6, 25);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(226, 47);
        label1.TabIndex = 2;
        label1.Text = "MSSV:";
        // 
        // txt_studentId
        // 
        txt_studentId.Location = new System.Drawing.Point(238, 25);
        txt_studentId.Name = "txt_studentId";
        txt_studentId.Size = new System.Drawing.Size(373, 47);
        txt_studentId.TabIndex = 1;
        // 
        // dgv_student
        // 
        dgv_student.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_student.Location = new System.Drawing.Point(629, 6);
        dgv_student.Name = "dgv_student";
        dgv_student.RowHeadersWidth = 102;
        dgv_student.Size = new System.Drawing.Size(1253, 1061);
        dgv_student.TabIndex = 0;
        dgv_student.Text = "dataGridView1";
        // 
        // tp_SK
        // 
        tp_SK.Location = new System.Drawing.Point(10, 58);
        tp_SK.Name = "tp_SK";
        tp_SK.Padding = new System.Windows.Forms.Padding(3);
        tp_SK.Size = new System.Drawing.Size(1888, 1073);
        tp_SK.TabIndex = 1;
        tp_SK.Text = "Sự kiện";
        tp_SK.UseVisualStyleBackColor = true;
        // 
        // tp_TC
        // 
        tp_TC.Location = new System.Drawing.Point(10, 58);
        tp_TC.Name = "tp_TC";
        tp_TC.Padding = new System.Windows.Forms.Padding(3);
        tp_TC.Size = new System.Drawing.Size(1888, 1073);
        tp_TC.TabIndex = 2;
        tp_TC.Text = "Tổ chức & CLB";
        tp_TC.UseVisualStyleBackColor = true;
        // 
        // tp_KT
        // 
        tp_KT.Location = new System.Drawing.Point(10, 58);
        tp_KT.Name = "tp_KT";
        tp_KT.Padding = new System.Windows.Forms.Padding(3);
        tp_KT.Size = new System.Drawing.Size(1888, 1073);
        tp_KT.TabIndex = 3;
        tp_KT.Text = "Khen thưởng";
        tp_KT.UseVisualStyleBackColor = true;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1913, 1148);
        Controls.Add(tc_demo);
        Text = "Hệ thống Quản lý Đoàn Hội - UEH";
        tc_demo.ResumeLayout(false);
        tp_SVDV.ResumeLayout(false);
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nud_birthYear).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgv_student).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox txt_studentSearch;
    private System.Windows.Forms.TextBox txt_class;
    private System.Windows.Forms.TextBox txt_term;
    private System.Windows.Forms.TextBox txt_role;
    private System.Windows.Forms.NumericUpDown nud_birthYear;
    private System.Windows.Forms.ComboBox cbb_faculty;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button btn_studentAdd;
    private System.Windows.Forms.Button btn_studentSearch;
    private System.Windows.Forms.Button btn_studentDelete;
    private System.Windows.Forms.Button btn_studentUpdate;

    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lbl_term;
    private System.Windows.Forms.Label lbl_role;
    private System.Windows.Forms.CheckBox cb_isOfficial;

    private System.Windows.Forms.TextBox txt_fullName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.DataGridView dgv_student;
    private System.Windows.Forms.TextBox txt_studentId;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.TabControl tc_demo;
    private System.Windows.Forms.TabPage tp_SVDV;
    private System.Windows.Forms.TabPage tp_SK;
    private System.Windows.Forms.TabPage tp_TC;
    private System.Windows.Forms.TabPage tp_KT;

    #endregion
}