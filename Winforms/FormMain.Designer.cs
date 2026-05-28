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
        components = new System.ComponentModel.Container();
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
        dgv_event = new System.Windows.Forms.DataGridView();
        groupBox6 = new System.Windows.Forms.GroupBox();
        btn_eventUpdate = new System.Windows.Forms.Button();
        btn_eventDelete = new System.Windows.Forms.Button();
        btn_eventSearch = new System.Windows.Forms.Button();
        btn_eventAdd = new System.Windows.Forms.Button();
        txt_eventSearch = new System.Windows.Forms.TextBox();
        label14 = new System.Windows.Forms.Label();
        groupBox4 = new System.Windows.Forms.GroupBox();
        num_bonusScore = new System.Windows.Forms.NumericUpDown();
        label5 = new System.Windows.Forms.Label();
        txt_eventName = new System.Windows.Forms.TextBox();
        label10 = new System.Windows.Forms.Label();
        label11 = new System.Windows.Forms.Label();
        txt_eventId = new System.Windows.Forms.TextBox();
        tp_TC = new System.Windows.Forms.TabPage();
        dgv_club = new System.Windows.Forms.DataGridView();
        groupBox8 = new System.Windows.Forms.GroupBox();
        btn_clubDelete = new System.Windows.Forms.Button();
        btn_clubUpdate = new System.Windows.Forms.Button();
        btn_clubAdd = new System.Windows.Forms.Button();
        groupBox7 = new System.Windows.Forms.GroupBox();
        btn_clubSearch = new System.Windows.Forms.Button();
        txt_clubSearch = new System.Windows.Forms.TextBox();
        label15 = new System.Windows.Forms.Label();
        groupBox5 = new System.Windows.Forms.GroupBox();
        num_memberCount = new System.Windows.Forms.NumericUpDown();
        dtp_foundedDate = new System.Windows.Forms.DateTimePicker();
        txt_clubId = new System.Windows.Forms.TextBox();
        label8 = new System.Windows.Forms.Label();
        txt_clubName = new System.Windows.Forms.TextBox();
        label9 = new System.Windows.Forms.Label();
        label12 = new System.Windows.Forms.Label();
        label13 = new System.Windows.Forms.Label();
        tp_KT = new System.Windows.Forms.TabPage();
        contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
        bindingSource1 = new System.Windows.Forms.BindingSource(components);
        tc_demo.SuspendLayout();
        tp_SVDV.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nud_birthYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgv_student).BeginInit();
        tp_SK.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_event).BeginInit();
        groupBox6.SuspendLayout();
        groupBox4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)num_bonusScore).BeginInit();
        tp_TC.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_club).BeginInit();
        groupBox8.SuspendLayout();
        groupBox7.SuspendLayout();
        groupBox5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)num_memberCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
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
        tp_SVDV.Location = new System.Drawing.Point(4, 29);
        tp_SVDV.Name = "tp_SVDV";
        tp_SVDV.Padding = new System.Windows.Forms.Padding(3);
        tp_SVDV.Size = new System.Drawing.Size(1900, 1108);
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
        txt_studentSearch.Size = new System.Drawing.Size(373, 27);
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
        txt_term.Size = new System.Drawing.Size(373, 27);
        txt_term.TabIndex = 17;
        // 
        // txt_role
        // 
        txt_role.Location = new System.Drawing.Point(241, 89);
        txt_role.Name = "txt_role";
        txt_role.Size = new System.Drawing.Size(373, 27);
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
        cbb_faculty.Size = new System.Drawing.Size(373, 28);
        cbb_faculty.TabIndex = 20;
        // 
        // nud_birthYear
        // 
        nud_birthYear.Location = new System.Drawing.Point(238, 150);
        nud_birthYear.Name = "nud_birthYear";
        nud_birthYear.Size = new System.Drawing.Size(373, 27);
        nud_birthYear.TabIndex = 19;
        // 
        // txt_class
        // 
        txt_class.Location = new System.Drawing.Point(238, 211);
        txt_class.Name = "txt_class";
        txt_class.Size = new System.Drawing.Size(373, 27);
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
        txt_fullName.Size = new System.Drawing.Size(373, 27);
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
        txt_studentId.Size = new System.Drawing.Size(373, 27);
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
        tp_SK.Controls.Add(dgv_event);
        tp_SK.Controls.Add(groupBox6);
        tp_SK.Controls.Add(groupBox4);
        tp_SK.Location = new System.Drawing.Point(4, 29);
        tp_SK.Name = "tp_SK";
        tp_SK.Padding = new System.Windows.Forms.Padding(3);
        tp_SK.Size = new System.Drawing.Size(1900, 1108);
        tp_SK.TabIndex = 1;
        tp_SK.Text = "Sự kiện";
        tp_SK.UseVisualStyleBackColor = true;
        // 
        // dgv_event
        // 
        dgv_event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_event.Location = new System.Drawing.Point(681, 34);
        dgv_event.Name = "dgv_event";
        dgv_event.RowHeadersWidth = 102;
        dgv_event.Size = new System.Drawing.Size(1253, 1061);
        dgv_event.TabIndex = 7;
        dgv_event.Text = "dataGridView1";
        // 
        // groupBox6
        // 
        groupBox6.Controls.Add(btn_eventUpdate);
        groupBox6.Controls.Add(btn_eventDelete);
        groupBox6.Controls.Add(btn_eventSearch);
        groupBox6.Controls.Add(btn_eventAdd);
        groupBox6.Controls.Add(txt_eventSearch);
        groupBox6.Controls.Add(label14);
        groupBox6.Location = new System.Drawing.Point(7, 300);
        groupBox6.Name = "groupBox6";
        groupBox6.Size = new System.Drawing.Size(617, 353);
        groupBox6.TabIndex = 6;
        groupBox6.TabStop = false;
        // 
        // btn_eventUpdate
        // 
        btn_eventUpdate.Location = new System.Drawing.Point(6, 221);
        btn_eventUpdate.Name = "btn_eventUpdate";
        btn_eventUpdate.Size = new System.Drawing.Size(605, 47);
        btn_eventUpdate.TabIndex = 23;
        btn_eventUpdate.Text = "Cập nhật";
        btn_eventUpdate.UseVisualStyleBackColor = true;
        btn_eventUpdate.Click += btn_eventUpdate_Click;
        // 
        // btn_eventDelete
        // 
        btn_eventDelete.Location = new System.Drawing.Point(6, 285);
        btn_eventDelete.Name = "btn_eventDelete";
        btn_eventDelete.Size = new System.Drawing.Size(605, 47);
        btn_eventDelete.TabIndex = 22;
        btn_eventDelete.Text = "Xóa";
        btn_eventDelete.UseVisualStyleBackColor = true;
        btn_eventDelete.Click += btn_eventDelete_Click;
        // 
        // btn_eventSearch
        // 
        btn_eventSearch.Location = new System.Drawing.Point(6, 93);
        btn_eventSearch.Name = "btn_eventSearch";
        btn_eventSearch.Size = new System.Drawing.Size(605, 47);
        btn_eventSearch.TabIndex = 21;
        btn_eventSearch.Text = "Tìm kiếm";
        btn_eventSearch.UseVisualStyleBackColor = true;
        // 
        // btn_eventAdd
        // 
        btn_eventAdd.Location = new System.Drawing.Point(6, 155);
        btn_eventAdd.Name = "btn_eventAdd";
        btn_eventAdd.Size = new System.Drawing.Size(605, 47);
        btn_eventAdd.TabIndex = 20;
        btn_eventAdd.Text = "Thêm mới";
        btn_eventAdd.UseVisualStyleBackColor = true;
        btn_eventAdd.Click += btn_eventAdd_Click;
        // 
        // txt_eventSearch
        // 
        txt_eventSearch.Location = new System.Drawing.Point(238, 25);
        txt_eventSearch.Name = "txt_eventSearch";
        txt_eventSearch.Size = new System.Drawing.Size(373, 27);
        txt_eventSearch.TabIndex = 19;
        // 
        // label14
        // 
        label14.BackColor = System.Drawing.Color.DarkGray;
        label14.ForeColor = System.Drawing.SystemColors.ControlText;
        label14.Location = new System.Drawing.Point(6, 25);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(226, 47);
        label14.TabIndex = 13;
        label14.Text = "Tìm kiếm:";
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(num_bonusScore);
        groupBox4.Controls.Add(label5);
        groupBox4.Controls.Add(txt_eventName);
        groupBox4.Controls.Add(label10);
        groupBox4.Controls.Add(label11);
        groupBox4.Controls.Add(txt_eventId);
        groupBox4.Location = new System.Drawing.Point(7, 34);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(617, 229);
        groupBox4.TabIndex = 4;
        groupBox4.TabStop = false;
        // 
        // num_bonusScore
        // 
        num_bonusScore.Location = new System.Drawing.Point(238, 150);
        num_bonusScore.Name = "num_bonusScore";
        num_bonusScore.Size = new System.Drawing.Size(373, 27);
        num_bonusScore.TabIndex = 19;
        // 
        // label5
        // 
        label5.BackColor = System.Drawing.Color.DarkGray;
        label5.ForeColor = System.Drawing.SystemColors.ControlText;
        label5.Location = new System.Drawing.Point(6, 150);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(226, 47);
        label5.TabIndex = 10;
        label5.Text = "Điểm cộng rèn luyện:";
        // 
        // txt_eventName
        // 
        txt_eventName.Location = new System.Drawing.Point(238, 87);
        txt_eventName.Name = "txt_eventName";
        txt_eventName.Size = new System.Drawing.Size(373, 27);
        txt_eventName.TabIndex = 4;
        // 
        // label10
        // 
        label10.BackColor = System.Drawing.Color.DarkGray;
        label10.ForeColor = System.Drawing.SystemColors.ControlText;
        label10.Location = new System.Drawing.Point(6, 87);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(226, 47);
        label10.TabIndex = 3;
        label10.Text = "Tên sự kiện:";
        // 
        // label11
        // 
        label11.BackColor = System.Drawing.Color.DarkGray;
        label11.ForeColor = System.Drawing.SystemColors.ControlText;
        label11.Location = new System.Drawing.Point(6, 25);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(226, 47);
        label11.TabIndex = 2;
        label11.Text = "Mã sự kiện:";
        // 
        // txt_eventId
        // 
        txt_eventId.Location = new System.Drawing.Point(238, 34);
        txt_eventId.Name = "txt_eventId";
        txt_eventId.Size = new System.Drawing.Size(373, 27);
        txt_eventId.TabIndex = 1;
        txt_eventId.TextChanged += txt_eventId_TextChanged;
        // 
        // tp_TC
        // 
        tp_TC.Controls.Add(dgv_club);
        tp_TC.Controls.Add(groupBox8);
        tp_TC.Controls.Add(groupBox7);
        tp_TC.Controls.Add(groupBox5);
        tp_TC.Location = new System.Drawing.Point(4, 29);
        tp_TC.Name = "tp_TC";
        tp_TC.Padding = new System.Windows.Forms.Padding(3);
        tp_TC.Size = new System.Drawing.Size(1900, 1108);
        tp_TC.TabIndex = 2;
        tp_TC.Text = "Tổ chức & CLB";
        tp_TC.UseVisualStyleBackColor = true;
        // 
        // dgv_club
        // 
        dgv_club.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_club.Location = new System.Drawing.Point(657, 50);
        dgv_club.Name = "dgv_club";
        dgv_club.RowHeadersWidth = 51;
        dgv_club.Size = new System.Drawing.Size(783, 605);
        dgv_club.TabIndex = 11;
        dgv_club.Text = "dataGridView1";
        // 
        // groupBox8
        // 
        groupBox8.Controls.Add(btn_clubDelete);
        groupBox8.Controls.Add(btn_clubUpdate);
        groupBox8.Controls.Add(btn_clubAdd);
        groupBox8.Location = new System.Drawing.Point(27, 507);
        groupBox8.Name = "groupBox8";
        groupBox8.Size = new System.Drawing.Size(592, 148);
        groupBox8.TabIndex = 10;
        groupBox8.TabStop = false;
        // 
        // btn_clubDelete
        // 
        btn_clubDelete.Location = new System.Drawing.Point(405, 45);
        btn_clubDelete.Name = "btn_clubDelete";
        btn_clubDelete.Size = new System.Drawing.Size(154, 59);
        btn_clubDelete.TabIndex = 2;
        btn_clubDelete.Text = "Xóa";
        btn_clubDelete.UseVisualStyleBackColor = true;
        // 
        // btn_clubUpdate
        // 
        btn_clubUpdate.Location = new System.Drawing.Point(219, 45);
        btn_clubUpdate.Name = "btn_clubUpdate";
        btn_clubUpdate.Size = new System.Drawing.Size(154, 59);
        btn_clubUpdate.TabIndex = 1;
        btn_clubUpdate.Text = "Cập nhật";
        btn_clubUpdate.UseVisualStyleBackColor = true;
        // 
        // btn_clubAdd
        // 
        btn_clubAdd.Location = new System.Drawing.Point(29, 45);
        btn_clubAdd.Name = "btn_clubAdd";
        btn_clubAdd.Size = new System.Drawing.Size(154, 59);
        btn_clubAdd.TabIndex = 0;
        btn_clubAdd.Text = "Thêm mới";
        btn_clubAdd.UseVisualStyleBackColor = true;
        // 
        // groupBox7
        // 
        groupBox7.Controls.Add(btn_clubSearch);
        groupBox7.Controls.Add(txt_clubSearch);
        groupBox7.Controls.Add(label15);
        groupBox7.Location = new System.Drawing.Point(27, 349);
        groupBox7.Name = "groupBox7";
        groupBox7.Size = new System.Drawing.Size(592, 143);
        groupBox7.TabIndex = 9;
        groupBox7.TabStop = false;
        // 
        // btn_clubSearch
        // 
        btn_clubSearch.Location = new System.Drawing.Point(440, 45);
        btn_clubSearch.Name = "btn_clubSearch";
        btn_clubSearch.Size = new System.Drawing.Size(129, 54);
        btn_clubSearch.TabIndex = 2;
        btn_clubSearch.Text = "Tìm kiếm";
        btn_clubSearch.UseVisualStyleBackColor = true;
        // 
        // txt_clubSearch
        // 
        txt_clubSearch.Location = new System.Drawing.Point(212, 59);
        txt_clubSearch.Name = "txt_clubSearch";
        txt_clubSearch.Size = new System.Drawing.Size(200, 27);
        txt_clubSearch.TabIndex = 1;
        // 
        // label15
        // 
        label15.BackColor = System.Drawing.Color.DarkGray;
        label15.Location = new System.Drawing.Point(29, 45);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(145, 52);
        label15.TabIndex = 0;
        label15.Text = "Tìm kiếm";
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(num_memberCount);
        groupBox5.Controls.Add(dtp_foundedDate);
        groupBox5.Controls.Add(txt_clubId);
        groupBox5.Controls.Add(label8);
        groupBox5.Controls.Add(txt_clubName);
        groupBox5.Controls.Add(label9);
        groupBox5.Controls.Add(label12);
        groupBox5.Controls.Add(label13);
        groupBox5.Location = new System.Drawing.Point(27, 37);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new System.Drawing.Size(592, 295);
        groupBox5.TabIndex = 8;
        groupBox5.TabStop = false;
        // 
        // num_memberCount
        // 
        num_memberCount.Location = new System.Drawing.Point(240, 242);
        num_memberCount.Name = "num_memberCount";
        num_memberCount.Size = new System.Drawing.Size(277, 27);
        num_memberCount.TabIndex = 9;
        // 
        // dtp_foundedDate
        // 
        dtp_foundedDate.Location = new System.Drawing.Point(240, 185);
        dtp_foundedDate.Name = "dtp_foundedDate";
        dtp_foundedDate.Size = new System.Drawing.Size(277, 27);
        dtp_foundedDate.TabIndex = 8;
        // 
        // txt_clubId
        // 
        txt_clubId.Location = new System.Drawing.Point(240, 39);
        txt_clubId.Name = "txt_clubId";
        txt_clubId.Size = new System.Drawing.Size(277, 27);
        txt_clubId.TabIndex = 4;
        // 
        // label8
        // 
        label8.BackColor = System.Drawing.Color.DarkGray;
        label8.Location = new System.Drawing.Point(20, 39);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(186, 44);
        label8.TabIndex = 0;
        label8.Text = "Mã CLB:";
        // 
        // txt_clubName
        // 
        txt_clubName.Location = new System.Drawing.Point(240, 110);
        txt_clubName.Name = "txt_clubName";
        txt_clubName.Size = new System.Drawing.Size(277, 27);
        txt_clubName.TabIndex = 7;
        // 
        // label9
        // 
        label9.BackColor = System.Drawing.Color.DarkGray;
        label9.Location = new System.Drawing.Point(20, 110);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(186, 44);
        label9.TabIndex = 1;
        label9.Text = "Tên CLB:";
        label9.Click += label9_Click_1;
        // 
        // label12
        // 
        label12.BackColor = System.Drawing.Color.DarkGray;
        label12.Location = new System.Drawing.Point(20, 172);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(186, 40);
        label12.TabIndex = 2;
        label12.Text = "Ngảy thành lập:";
        // 
        // label13
        // 
        label13.BackColor = System.Drawing.Color.DarkGray;
        label13.Location = new System.Drawing.Point(20, 242);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(186, 40);
        label13.TabIndex = 3;
        label13.Text = "Số thành viên:";
        label13.Click += label13_Click;
        // 
        // tp_KT
        // 
        tp_KT.Location = new System.Drawing.Point(4, 29);
        tp_KT.Name = "tp_KT";
        tp_KT.Padding = new System.Windows.Forms.Padding(3);
        tp_KT.Size = new System.Drawing.Size(1900, 1108);
        tp_KT.TabIndex = 3;
        tp_KT.Text = "Khen thưởng";
        tp_KT.UseVisualStyleBackColor = true;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
        // 
        // FormMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1913, 1055);
        Controls.Add(tc_demo);
        Margin = new System.Windows.Forms.Padding(1);
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
        tp_SK.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv_event).EndInit();
        groupBox6.ResumeLayout(false);
        groupBox6.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)num_bonusScore).EndInit();
        tp_TC.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv_club).EndInit();
        groupBox8.ResumeLayout(false);
        groupBox7.ResumeLayout(false);
        groupBox7.PerformLayout();
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)num_memberCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.NumericUpDown num_memberCount;

    private System.Windows.Forms.DateTimePicker dtp_foundedDate;

    private System.Windows.Forms.DataGridView dgv_club;

    private System.Windows.Forms.Button btn_clubAdd;
    private System.Windows.Forms.Button btn_clubUpdate;
    private System.Windows.Forms.Button btn_clubDelete;

    private System.Windows.Forms.BindingSource bindingSource1;
    private System.Windows.Forms.GroupBox groupBox8;

    private System.Windows.Forms.TextBox txt_clubSearch;
    private System.Windows.Forms.Button btn_clubSearch;

    private System.Windows.Forms.Label label15;

    private System.Windows.Forms.GroupBox groupBox7;

    private System.Windows.Forms.GroupBox groupBox5;

    private System.Windows.Forms.TextBox txt_clubName;

    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.TextBox txt_clubId;

    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;

    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.NumericUpDown num_bonusScore;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txt_eventName;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox txt_eventId;
    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.Button btn_eventUpdate;
    private System.Windows.Forms.Button btn_eventDelete;
    private System.Windows.Forms.Button btn_eventSearch;
    private System.Windows.Forms.Button btn_eventAdd;
    private System.Windows.Forms.TextBox txt_eventSearch;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.DataGridView dgv_event;

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