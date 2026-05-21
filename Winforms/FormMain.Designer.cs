namespace Quản_lý_đoàn_hội;

partial class FormMain
{
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
        QLDH = new System.Windows.Forms.TabControl();
        tp_QLNS = new System.Windows.Forms.TabPage();
        dgv_human = new System.Windows.Forms.DataGridView();
        groupBox5 = new System.Windows.Forms.GroupBox();
        btn_humanSearch = new System.Windows.Forms.Button();
        btn_humanDelete = new System.Windows.Forms.Button();
        btn_humanUpdate = new System.Windows.Forms.Button();
        btn_humanAdd = new System.Windows.Forms.Button();
        txt_search = new System.Windows.Forms.TextBox();
        label11 = new System.Windows.Forms.Label();
        groupBox4 = new System.Windows.Forms.GroupBox();
        txt_role = new System.Windows.Forms.TextBox();
        txt_term = new System.Windows.Forms.TextBox();
        label8 = new System.Windows.Forms.Label();
        label9 = new System.Windows.Forms.Label();
        txt_class = new System.Windows.Forms.TextBox();
        label10 = new System.Windows.Forms.Label();
        groupBox3 = new System.Windows.Forms.GroupBox();
        txt_street = new System.Windows.Forms.TextBox();
        txt_district = new System.Windows.Forms.TextBox();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        txt_houseNum = new System.Windows.Forms.TextBox();
        label7 = new System.Windows.Forms.Label();
        groupBox2 = new System.Windows.Forms.GroupBox();
        txt_fullName = new System.Windows.Forms.TextBox();
        txt_birthYear = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        txt_humanId = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        groupBox1 = new System.Windows.Forms.GroupBox();
        cbb_obj = new System.Windows.Forms.ComboBox();
        label1 = new System.Windows.Forms.Label();
        tp_QLSK = new System.Windows.Forms.TabPage();
        btn_eventSearch = new System.Windows.Forms.Button();
        btn_eventUpdate = new System.Windows.Forms.Button();
        btn_eventDelete = new System.Windows.Forms.Button();
        btn_eventAdd = new System.Windows.Forms.Button();
        txt_eventSearch = new System.Windows.Forms.TextBox();
        label16 = new System.Windows.Forms.Label();
        dgv_event = new System.Windows.Forms.DataGridView();
        txt_eventAddress = new System.Windows.Forms.TextBox();
        txt_bonusScore = new System.Windows.Forms.TextBox();
        txt_eventName = new System.Windows.Forms.TextBox();
        txt_eventID = new System.Windows.Forms.TextBox();
        label15 = new System.Windows.Forms.Label();
        label14 = new System.Windows.Forms.Label();
        label13 = new System.Windows.Forms.Label();
        label12 = new System.Windows.Forms.Label();
        tp_GNTG = new System.Windows.Forms.TabPage();
        groupBox7 = new System.Windows.Forms.GroupBox();
        btn_LamMoi = new System.Windows.Forms.Button();
        btn_DiemDanh = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        txt_HoTen = new System.Windows.Forms.TextBox();
        txt_MaSo = new System.Windows.Forms.TextBox();
        label19 = new System.Windows.Forms.Label();
        label18 = new System.Windows.Forms.Label();
        groupBox6 = new System.Windows.Forms.GroupBox();
        cbo_SuKien = new System.Windows.Forms.ComboBox();
        label17 = new System.Windows.Forms.Label();
        tp_TH = new System.Windows.Forms.TabPage();
        col_eventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        col_eventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        col_bonusScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
        col_eventAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
        STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
        dgv_DiemDanh = new System.Windows.Forms.DataGridView();
        colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colMaSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
        QLDH.SuspendLayout();
        tp_QLNS.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_human).BeginInit();
        groupBox5.SuspendLayout();
        groupBox4.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        tp_QLSK.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_event).BeginInit();
        tp_GNTG.SuspendLayout();
        groupBox7.SuspendLayout();
        groupBox6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_DiemDanh).BeginInit();
        SuspendLayout();
        // 
        // QLDH
        // 
        QLDH.Controls.Add(tp_QLNS);
        QLDH.Controls.Add(tp_QLSK);
        QLDH.Controls.Add(tp_GNTG);
        QLDH.Controls.Add(tp_TH);
        QLDH.Location = new System.Drawing.Point(1, 3);
        QLDH.Name = "QLDH";
        QLDH.SelectedIndex = 0;
        QLDH.Size = new System.Drawing.Size(2117, 1480);
        QLDH.TabIndex = 0;
        // 
        // tp_QLNS
        // 
        tp_QLNS.Controls.Add(dgv_human);
        tp_QLNS.Controls.Add(groupBox5);
        tp_QLNS.Controls.Add(groupBox4);
        tp_QLNS.Controls.Add(groupBox3);
        tp_QLNS.Controls.Add(groupBox2);
        tp_QLNS.Controls.Add(groupBox1);
        tp_QLNS.Location = new System.Drawing.Point(4, 29);
        tp_QLNS.Name = "tp_QLNS";
        tp_QLNS.Padding = new System.Windows.Forms.Padding(3);
        tp_QLNS.Size = new System.Drawing.Size(2109, 1447);
        tp_QLNS.TabIndex = 0;
        tp_QLNS.Text = "Quản lý Nhân sự";
        tp_QLNS.UseVisualStyleBackColor = true;
        // 
        // dgv_human
        // 
        dgv_human.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_human.Location = new System.Drawing.Point(901, 0);
        dgv_human.Name = "dgv_human";
        dgv_human.RowHeadersWidth = 102;
        dgv_human.Size = new System.Drawing.Size(1181, 999);
        dgv_human.TabIndex = 5;
        dgv_human.Text = "dataGridView1";
        // 
        // groupBox5
        // 
        groupBox5.Controls.Add(btn_humanSearch);
        groupBox5.Controls.Add(btn_humanDelete);
        groupBox5.Controls.Add(btn_humanUpdate);
        groupBox5.Controls.Add(btn_humanAdd);
        groupBox5.Controls.Add(txt_search);
        groupBox5.Controls.Add(label11);
        groupBox5.Location = new System.Drawing.Point(6, 770);
        groupBox5.Name = "groupBox5";
        groupBox5.Size = new System.Drawing.Size(879, 229);
        groupBox5.TabIndex = 4;
        groupBox5.TabStop = false;
        // 
        // btn_humanSearch
        // 
        btn_humanSearch.Location = new System.Drawing.Point(685, 131);
        btn_humanSearch.Name = "btn_humanSearch";
        btn_humanSearch.Size = new System.Drawing.Size(157, 54);
        btn_humanSearch.TabIndex = 9;
        btn_humanSearch.Text = "Tìm";
        btn_humanSearch.UseVisualStyleBackColor = true;
        // 
        // btn_humanDelete
        // 
        btn_humanDelete.Location = new System.Drawing.Point(453, 131);
        btn_humanDelete.Name = "btn_humanDelete";
        btn_humanDelete.Size = new System.Drawing.Size(157, 54);
        btn_humanDelete.TabIndex = 8;
        btn_humanDelete.Text = "Xóa";
        btn_humanDelete.UseVisualStyleBackColor = true;
        // 
        // btn_humanUpdate
        // 
        btn_humanUpdate.Location = new System.Drawing.Point(229, 131);
        btn_humanUpdate.Name = "btn_humanUpdate";
        btn_humanUpdate.Size = new System.Drawing.Size(157, 54);
        btn_humanUpdate.TabIndex = 7;
        btn_humanUpdate.Text = "Sửa";
        btn_humanUpdate.UseVisualStyleBackColor = true;
        // 
        // btn_humanAdd
        // 
        btn_humanAdd.Location = new System.Drawing.Point(35, 131);
        btn_humanAdd.Name = "btn_humanAdd";
        btn_humanAdd.Size = new System.Drawing.Size(157, 54);
        btn_humanAdd.TabIndex = 6;
        btn_humanAdd.Text = "Thêm";
        btn_humanAdd.UseVisualStyleBackColor = true;
        // 
        // txt_search
        // 
        txt_search.Location = new System.Drawing.Point(458, 37);
        txt_search.Name = "txt_search";
        txt_search.Size = new System.Drawing.Size(384, 27);
        txt_search.TabIndex = 5;
        // 
        // label11
        // 
        label11.BackColor = System.Drawing.Color.LightGray;
        label11.Location = new System.Drawing.Point(35, 37);
        label11.Name = "label11";
        label11.Size = new System.Drawing.Size(346, 50);
        label11.TabIndex = 1;
        label11.Text = "Tìm kiếm:";
        label11.Click += label11_Click;
        // 
        // groupBox4
        // 
        groupBox4.Controls.Add(txt_role);
        groupBox4.Controls.Add(txt_term);
        groupBox4.Controls.Add(label8);
        groupBox4.Controls.Add(label9);
        groupBox4.Controls.Add(txt_class);
        groupBox4.Controls.Add(label10);
        groupBox4.Location = new System.Drawing.Point(6, 543);
        groupBox4.Name = "groupBox4";
        groupBox4.Size = new System.Drawing.Size(873, 221);
        groupBox4.TabIndex = 3;
        groupBox4.TabStop = false;
        // 
        // txt_role
        // 
        txt_role.Location = new System.Drawing.Point(458, 93);
        txt_role.Name = "txt_role";
        txt_role.Size = new System.Drawing.Size(384, 27);
        txt_role.TabIndex = 5;
        // 
        // txt_term
        // 
        txt_term.Location = new System.Drawing.Point(458, 163);
        txt_term.Name = "txt_term";
        txt_term.Size = new System.Drawing.Size(384, 27);
        txt_term.TabIndex = 4;
        // 
        // label8
        // 
        label8.BackColor = System.Drawing.Color.LightGray;
        label8.Location = new System.Drawing.Point(40, 90);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(346, 50);
        label8.TabIndex = 3;
        label8.Text = "Chức vụ Đoàn:";
        // 
        // label9
        // 
        label9.BackColor = System.Drawing.Color.LightGray;
        label9.Location = new System.Drawing.Point(40, 160);
        label9.Name = "label9";
        label9.Size = new System.Drawing.Size(346, 50);
        label9.TabIndex = 2;
        label9.Text = "Nhiệm kỳ:";
        // 
        // txt_class
        // 
        txt_class.Location = new System.Drawing.Point(458, 26);
        txt_class.Name = "txt_class";
        txt_class.Size = new System.Drawing.Size(384, 27);
        txt_class.TabIndex = 1;
        // 
        // label10
        // 
        label10.BackColor = System.Drawing.Color.LightGray;
        label10.Location = new System.Drawing.Point(40, 23);
        label10.Name = "label10";
        label10.Size = new System.Drawing.Size(346, 50);
        label10.TabIndex = 0;
        label10.Text = "Lớp/Khoa:";
        // 
        // groupBox3
        // 
        groupBox3.Controls.Add(txt_street);
        groupBox3.Controls.Add(txt_district);
        groupBox3.Controls.Add(label5);
        groupBox3.Controls.Add(label6);
        groupBox3.Controls.Add(txt_houseNum);
        groupBox3.Controls.Add(label7);
        groupBox3.Location = new System.Drawing.Point(6, 316);
        groupBox3.Name = "groupBox3";
        groupBox3.Size = new System.Drawing.Size(873, 221);
        groupBox3.TabIndex = 2;
        groupBox3.TabStop = false;
        // 
        // txt_street
        // 
        txt_street.Location = new System.Drawing.Point(458, 93);
        txt_street.Name = "txt_street";
        txt_street.Size = new System.Drawing.Size(384, 27);
        txt_street.TabIndex = 5;
        // 
        // txt_district
        // 
        txt_district.Location = new System.Drawing.Point(458, 163);
        txt_district.Name = "txt_district";
        txt_district.Size = new System.Drawing.Size(384, 27);
        txt_district.TabIndex = 4;
        // 
        // label5
        // 
        label5.BackColor = System.Drawing.Color.LightGray;
        label5.Location = new System.Drawing.Point(40, 90);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(346, 50);
        label5.TabIndex = 3;
        label5.Text = "Đường:";
        // 
        // label6
        // 
        label6.BackColor = System.Drawing.Color.LightGray;
        label6.Location = new System.Drawing.Point(40, 160);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(346, 50);
        label6.TabIndex = 2;
        label6.Text = "Quận/Huyện:";
        // 
        // txt_houseNum
        // 
        txt_houseNum.Location = new System.Drawing.Point(458, 26);
        txt_houseNum.Name = "txt_houseNum";
        txt_houseNum.Size = new System.Drawing.Size(384, 27);
        txt_houseNum.TabIndex = 1;
        // 
        // label7
        // 
        label7.BackColor = System.Drawing.Color.LightGray;
        label7.Location = new System.Drawing.Point(40, 23);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(346, 50);
        label7.TabIndex = 0;
        label7.Text = "Số nhà:";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(txt_fullName);
        groupBox2.Controls.Add(txt_birthYear);
        groupBox2.Controls.Add(label4);
        groupBox2.Controls.Add(label3);
        groupBox2.Controls.Add(txt_humanId);
        groupBox2.Controls.Add(label2);
        groupBox2.Location = new System.Drawing.Point(1, 100);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(879, 221);
        groupBox2.TabIndex = 1;
        groupBox2.TabStop = false;
        // 
        // txt_fullName
        // 
        txt_fullName.Location = new System.Drawing.Point(458, 93);
        txt_fullName.Name = "txt_fullName";
        txt_fullName.Size = new System.Drawing.Size(389, 27);
        txt_fullName.TabIndex = 5;
        // 
        // txt_birthYear
        // 
        txt_birthYear.Location = new System.Drawing.Point(458, 163);
        txt_birthYear.Name = "txt_birthYear";
        txt_birthYear.Size = new System.Drawing.Size(389, 27);
        txt_birthYear.TabIndex = 4;
        // 
        // label4
        // 
        label4.BackColor = System.Drawing.Color.LightGray;
        label4.Location = new System.Drawing.Point(40, 90);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(346, 50);
        label4.TabIndex = 3;
        label4.Text = "Họ và tên:";
        // 
        // label3
        // 
        label3.BackColor = System.Drawing.Color.LightGray;
        label3.Location = new System.Drawing.Point(40, 160);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(346, 50);
        label3.TabIndex = 2;
        label3.Text = "Năm sinh:";
        // 
        // txt_humanId
        // 
        txt_humanId.Location = new System.Drawing.Point(458, 26);
        txt_humanId.Name = "txt_humanId";
        txt_humanId.Size = new System.Drawing.Size(389, 27);
        txt_humanId.TabIndex = 1;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.LightGray;
        label2.Location = new System.Drawing.Point(40, 23);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(346, 50);
        label2.TabIndex = 0;
        label2.Text = "Mã định danh:";
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(cbb_obj);
        groupBox1.Controls.Add(label1);
        groupBox1.Location = new System.Drawing.Point(1, 3);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(879, 91);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        // 
        // cbb_obj
        // 
        cbb_obj.FormattingEnabled = true;
        cbb_obj.Items.AddRange(new object[] { "Sinh viên", "Cán bộ Đoàn", "Giảng viên" });
        cbb_obj.Location = new System.Drawing.Point(458, 24);
        cbb_obj.Name = "cbb_obj";
        cbb_obj.Size = new System.Drawing.Size(389, 28);
        cbb_obj.TabIndex = 1;
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.LightGray;
        label1.Location = new System.Drawing.Point(40, 23);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(346, 50);
        label1.TabIndex = 0;
        label1.Text = "Chọn loại đối tượng:";
        // 
        // tp_QLSK
        // 
        tp_QLSK.Controls.Add(btn_eventSearch);
        tp_QLSK.Controls.Add(btn_eventUpdate);
        tp_QLSK.Controls.Add(btn_eventDelete);
        tp_QLSK.Controls.Add(btn_eventAdd);
        tp_QLSK.Controls.Add(txt_eventSearch);
        tp_QLSK.Controls.Add(label16);
        tp_QLSK.Controls.Add(dgv_event);
        tp_QLSK.Controls.Add(txt_eventAddress);
        tp_QLSK.Controls.Add(txt_bonusScore);
        tp_QLSK.Controls.Add(txt_eventName);
        tp_QLSK.Controls.Add(txt_eventID);
        tp_QLSK.Controls.Add(label15);
        tp_QLSK.Controls.Add(label14);
        tp_QLSK.Controls.Add(label13);
        tp_QLSK.Controls.Add(label12);
        tp_QLSK.Location = new System.Drawing.Point(4, 29);
        tp_QLSK.Name = "tp_QLSK";
        tp_QLSK.Padding = new System.Windows.Forms.Padding(3);
        tp_QLSK.Size = new System.Drawing.Size(2109, 1447);
        tp_QLSK.TabIndex = 1;
        tp_QLSK.Text = "Quản lý Sự kiện Đoàn Hội";
        tp_QLSK.UseVisualStyleBackColor = true;
        // 
        // btn_eventSearch
        // 
        btn_eventSearch.Location = new System.Drawing.Point(586, 648);
        btn_eventSearch.Name = "btn_eventSearch";
        btn_eventSearch.Size = new System.Drawing.Size(157, 54);
        btn_eventSearch.TabIndex = 15;
        btn_eventSearch.Text = "Tìm";
        btn_eventSearch.UseVisualStyleBackColor = true;
        // 
        // btn_eventUpdate
        // 
        btn_eventUpdate.Location = new System.Drawing.Point(200, 648);
        btn_eventUpdate.Name = "btn_eventUpdate";
        btn_eventUpdate.Size = new System.Drawing.Size(157, 54);
        btn_eventUpdate.TabIndex = 14;
        btn_eventUpdate.Text = "Sửa";
        btn_eventUpdate.UseVisualStyleBackColor = true;
        // 
        // btn_eventDelete
        // 
        btn_eventDelete.Location = new System.Drawing.Point(389, 648);
        btn_eventDelete.Name = "btn_eventDelete";
        btn_eventDelete.Size = new System.Drawing.Size(157, 54);
        btn_eventDelete.TabIndex = 13;
        btn_eventDelete.Text = "Xóa";
        btn_eventDelete.UseVisualStyleBackColor = true;
        // 
        // btn_eventAdd
        // 
        btn_eventAdd.Location = new System.Drawing.Point(27, 648);
        btn_eventAdd.Name = "btn_eventAdd";
        btn_eventAdd.Size = new System.Drawing.Size(157, 54);
        btn_eventAdd.TabIndex = 12;
        btn_eventAdd.Text = "Thêm";
        btn_eventAdd.UseVisualStyleBackColor = true;
        // 
        // txt_eventSearch
        // 
        txt_eventSearch.Location = new System.Drawing.Point(396, 478);
        txt_eventSearch.Name = "txt_eventSearch";
        txt_eventSearch.Size = new System.Drawing.Size(389, 27);
        txt_eventSearch.TabIndex = 11;
        // 
        // label16
        // 
        label16.BackColor = System.Drawing.Color.LightGray;
        label16.Location = new System.Drawing.Point(17, 465);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(346, 50);
        label16.TabIndex = 10;
        label16.Text = "Tìm kiếm";
        // 
        // dgv_event
        // 
        dgv_event.AllowUserToOrderColumns = true;
        dgv_event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_event.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { col_eventID, col_eventName, col_bonusScore, col_eventAddress });
        dgv_event.Location = new System.Drawing.Point(800, 3);
        dgv_event.Name = "dgv_event";
        dgv_event.RowHeadersWidth = 102;
        dgv_event.Size = new System.Drawing.Size(1181, 999);
        dgv_event.TabIndex = 9;
        dgv_event.Text = "dataGridView1";
        dgv_event.CellContentClick += dgv_event_CellContentClick;
        // 
        // col_eventID
        // 
        col_eventID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_eventID.HeaderText = "Mã sự kiện ";
        col_eventID.MinimumWidth = 6;
        col_eventID.Name = "col_eventID";
        col_eventID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // col_eventName
        // 
        col_eventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_eventName.HeaderText = "Tên sự kiện ";
        col_eventName.MinimumWidth = 6;
        col_eventName.Name = "col_eventName";
        col_eventName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // col_bonusScore
        // 
        col_bonusScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_bonusScore.HeaderText = "Điểm cộng rèn luyện";
        col_bonusScore.MinimumWidth = 6;
        col_bonusScore.Name = "col_bonusScore";
        col_bonusScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // col_eventAddress
        // 
        col_eventAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_eventAddress.HeaderText = "Địa điểm";
        col_eventAddress.MinimumWidth = 6;
        col_eventAddress.Name = "col_eventAddress";
        col_eventAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // txt_eventAddress
        // 
        txt_eventAddress.Location = new System.Drawing.Point(396, 340);
        txt_eventAddress.Name = "txt_eventAddress";
        txt_eventAddress.Size = new System.Drawing.Size(389, 27);
        txt_eventAddress.TabIndex = 8;
        // 
        // txt_bonusScore
        // 
        txt_bonusScore.Location = new System.Drawing.Point(405, 243);
        txt_bonusScore.Name = "txt_bonusScore";
        txt_bonusScore.Size = new System.Drawing.Size(389, 27);
        txt_bonusScore.TabIndex = 7;
        // 
        // txt_eventName
        // 
        txt_eventName.Location = new System.Drawing.Point(405, 154);
        txt_eventName.Name = "txt_eventName";
        txt_eventName.Size = new System.Drawing.Size(389, 27);
        txt_eventName.TabIndex = 6;
        // 
        // txt_eventID
        // 
        txt_eventID.Location = new System.Drawing.Point(405, 69);
        txt_eventID.Name = "txt_eventID";
        txt_eventID.Size = new System.Drawing.Size(389, 27);
        txt_eventID.TabIndex = 5;
        // 
        // label15
        // 
        label15.BackColor = System.Drawing.Color.LightGray;
        label15.Location = new System.Drawing.Point(17, 328);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(346, 50);
        label15.TabIndex = 4;
        label15.Text = "Địa điểm";
        // 
        // label14
        // 
        label14.BackColor = System.Drawing.Color.LightGray;
        label14.Location = new System.Drawing.Point(17, 140);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(346, 50);
        label14.TabIndex = 3;
        label14.Text = "Tên sự kiện";
        // 
        // label13
        // 
        label13.BackColor = System.Drawing.Color.LightGray;
        label13.Location = new System.Drawing.Point(17, 233);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(346, 50);
        label13.TabIndex = 2;
        label13.Text = "Điểm cộng rèn luyện";
        // 
        // label12
        // 
        label12.BackColor = System.Drawing.Color.LightGray;
        label12.Location = new System.Drawing.Point(17, 53);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(346, 50);
        label12.TabIndex = 1;
        label12.Text = "Mã sự kiện";
        // 
        // tp_GNTG
        // 
        tp_GNTG.Controls.Add(dgvDiemDanh);
        tp_GNTG.Controls.Add(groupBox7);
        tp_GNTG.Controls.Add(groupBox6);
        tp_GNTG.Location = new System.Drawing.Point(4, 29);
        tp_GNTG.Name = "tp_GNTG";
        tp_GNTG.Padding = new System.Windows.Forms.Padding(3);
        tp_GNTG.Size = new System.Drawing.Size(2109, 1447);
        tp_GNTG.TabIndex = 2;
        tp_GNTG.Text = "Điểm danh & Ghi nhận tham gia";
        tp_GNTG.UseVisualStyleBackColor = true;
        tp_GNTG.Click += tp_GNTG_Click;
        // 
        // groupBox7
        // 
        groupBox7.Controls.Add(btnLamMoi);
        groupBox7.Controls.Add(btnDiemDanh);
        groupBox7.Controls.Add(button1);
        groupBox7.Controls.Add(txtHoTen);
        groupBox7.Controls.Add(txtMaSo);
        groupBox7.Controls.Add(label19);
        groupBox7.Controls.Add(label18);
        groupBox7.Location = new System.Drawing.Point(29, 118);
        groupBox7.Name = "groupBox7";
        groupBox7.Size = new System.Drawing.Size(606, 197);
        groupBox7.TabIndex = 1;
        groupBox7.TabStop = false;
        groupBox7.Text = "groupBox7";
        // 
        // btnLamMoi
        // 
        btnLamMoi.Location = new System.Drawing.Point(334, 98);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new System.Drawing.Size(214, 66);
        btnLamMoi.TabIndex = 6;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        // 
        // btnDiemDanh
        // 
        btnDiemDanh.Location = new System.Drawing.Point(334, 21);
        btnDiemDanh.Name = "btnDiemDanh";
        btnDiemDanh.Size = new System.Drawing.Size(214, 64);
        btnDiemDanh.TabIndex = 5;
        btnDiemDanh.Text = "Điểm danh/Ghi nhận";
        btnDiemDanh.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(320, 57);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(8, 8);
        button1.TabIndex = 4;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // txtHoTen
        // 
        txtHoTen.Location = new System.Drawing.Point(94, 98);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new System.Drawing.Size(197, 27);
        txtHoTen.TabIndex = 3;
        // 
        // txtMaSo
        // 
        txtMaSo.Location = new System.Drawing.Point(94, 40);
        txtMaSo.Name = "txtMaSo";
        txtMaSo.Size = new System.Drawing.Size(197, 27);
        txtMaSo.TabIndex = 2;
        txtMaSo.TextChanged += textBox1_TextChanged;
        // 
        // label19
        // 
        label19.Location = new System.Drawing.Point(6, 102);
        label19.Name = "label19";
        label19.Size = new System.Drawing.Size(100, 23);
        label19.TabIndex = 1;
        label19.Text = "Họ và Tên";
        // 
        // label18
        // 
        label18.Location = new System.Drawing.Point(11, 48);
        label18.Name = "label18";
        label18.Size = new System.Drawing.Size(100, 23);
        label18.TabIndex = 0;
        label18.Text = "Mã Số";
        // 
        // groupBox6
        // 
        groupBox6.Controls.Add(cboSuKien);
        groupBox6.Controls.Add(label17);
        groupBox6.Location = new System.Drawing.Point(19, 21);
        groupBox6.Name = "groupBox6";
        groupBox6.Size = new System.Drawing.Size(361, 91);
        groupBox6.TabIndex = 0;
        groupBox6.TabStop = false;
        groupBox6.Text = "Thông tin sự kiện cần điểm danh";
        // 
        // cboSuKien
        // 
        cboSuKien.FormattingEnabled = true;
        cboSuKien.Location = new System.Drawing.Point(139, 24);
        cboSuKien.Name = "cboSuKien";
        cboSuKien.Size = new System.Drawing.Size(189, 28);
        cboSuKien.TabIndex = 1;
        // 
        // label17
        // 
        label17.Location = new System.Drawing.Point(33, 29);
        label17.Name = "label17";
        label17.Size = new System.Drawing.Size(100, 23);
        label17.TabIndex = 0;
        label17.Text = "Chọn Sự Kiện";
        // 
        // tp_TH
        // 
        tp_TH.Location = new System.Drawing.Point(4, 29);
        tp_TH.Name = "tp_TH";
        tp_TH.Padding = new System.Windows.Forms.Padding(3);
        tp_TH.Size = new System.Drawing.Size(2109, 1447);
        tp_TH.TabIndex = 3;
        tp_TH.Text = "Tổng hợp & Tính điểm rèn luyện";
        tp_TH.UseVisualStyleBackColor = true;
        // 
        // STT
        // 
        STT.HeaderText = "Column1";
        STT.MinimumWidth = 6;
        STT.Name = "STT";
        STT.Width = 125;
        // 
        // dgvDiemDanh
        // 
        dgvDiemDanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDiemDanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSTT, colMaSo, colHoTen, colThoiGian });
        dgvDiemDanh.Location = new System.Drawing.Point(30, 353);
        dgvDiemDanh.Name = "dgvDiemDanh";
        dgvDiemDanh.RowHeadersWidth = 51;
        dgvDiemDanh.Size = new System.Drawing.Size(638, 293);
        dgvDiemDanh.TabIndex = 2;
        dgvDiemDanh.Text = "dataGridView1";
        // 
        // colSTT
        // 
        colSTT.HeaderText = "STT";
        colSTT.MinimumWidth = 6;
        colSTT.Name = "colSTT";
        colSTT.Width = 125;
        // 
        // colMaSo
        // 
        colMaSo.HeaderText = "Mã Số";
        colMaSo.MinimumWidth = 6;
        colMaSo.Name = "colMaSo";
        colMaSo.Width = 125;
        // 
        // colHoTen
        // 
        colHoTen.HeaderText = "Họ và Tên";
        colHoTen.MinimumWidth = 6;
        colHoTen.Name = "colHoTen";
        colHoTen.Width = 125;
        // 
        // colThoiGian
        // 
        colThoiGian.HeaderText = "Thời Gian";
        colThoiGian.MinimumWidth = 6;
        colThoiGian.Name = "colThoiGian";
        colThoiGian.Width = 125;
        // 
        // FormMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1924, 1055);
        Controls.Add(QLDH);
        Margin = new System.Windows.Forms.Padding(1);
        Text = "FormMain";
        QLDH.ResumeLayout(false);
        tp_QLNS.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv_human).EndInit();
        groupBox5.ResumeLayout(false);
        groupBox5.PerformLayout();
        groupBox4.ResumeLayout(false);
        groupBox4.PerformLayout();
        groupBox3.ResumeLayout(false);
        groupBox3.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        groupBox1.ResumeLayout(false);
        tp_QLSK.ResumeLayout(false);
        tp_QLSK.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_event).EndInit();
        tp_GNTG.ResumeLayout(false);
        groupBox7.ResumeLayout(false);
        groupBox7.PerformLayout();
        groupBox6.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDiemDanh).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;

    private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;

    private System.Windows.Forms.DataGridViewTextBoxColumn colMaSo;

    private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;

    private System.Windows.Forms.DataGridViewTextBoxColumn STT;

    private System.Windows.Forms.Button btnDiemDanh;
    private System.Windows.Forms.Button btnLamMoi;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.TextBox txtHoTen;

    private System.Windows.Forms.TextBox txtMaSo;

    private System.Windows.Forms.Label label19;

    private System.Windows.Forms.Label label18;

    private System.Windows.Forms.GroupBox groupBox7;

    private System.Windows.Forms.ComboBox cboSuKien;

    private System.Windows.Forms.Label label17;

    private System.Windows.Forms.GroupBox groupBox6;

    private System.Windows.Forms.DataGridViewTextBoxColumn col_eventID;
    private System.Windows.Forms.DataGridViewTextBoxColumn col_eventName;
    private System.Windows.Forms.DataGridViewTextBoxColumn col_bonusScore;
    private System.Windows.Forms.DataGridViewTextBoxColumn col_eventAddress;

    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.TextBox txt_eventSearch;
    private System.Windows.Forms.Button btn_eventAdd;
    private System.Windows.Forms.Button btn_eventDelete;
    private System.Windows.Forms.Button btn_eventUpdate;
    private System.Windows.Forms.Button btn_eventSearch;

    private System.Windows.Forms.DataGridView dgv_event;

    private System.Windows.Forms.TextBox txt_eventID;
    private System.Windows.Forms.TextBox txt_eventName;
    private System.Windows.Forms.TextBox txt_bonusScore;
    private System.Windows.Forms.TextBox txt_eventAddress;
    private System.Windows.Forms.DataGridView dgvDiemDanh;

    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label15;

    private System.Windows.Forms.DataGridView dgv_human;

    private System.Windows.Forms.Button btn_humanSearch;

    private System.Windows.Forms.Button btn_humanAdd;

    private System.Windows.Forms.Button btn_humanDelete;

    private System.Windows.Forms.Button btn_humanUpdate;

    private System.Windows.Forms.TextBox txt_search;

    private System.Windows.Forms.Label label11;

    private System.Windows.Forms.GroupBox groupBox5;

    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox txt_role;
    private System.Windows.Forms.TextBox txt_term;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox txt_class;
    private System.Windows.Forms.Label label10;

    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox txt_street;
    private System.Windows.Forms.TextBox txt_district;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.TextBox txt_humanId;

    private System.Windows.Forms.TextBox txt_birthYear;
    private System.Windows.Forms.TextBox txt_houseNum;

    private System.Windows.Forms.TextBox txt_fullName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.ComboBox cbb_obj;

    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.TabPage tp_GNTG;
    private System.Windows.Forms.TabPage tp_TH;

    private System.Windows.Forms.TabControl QLDH;
    private System.Windows.Forms.TabPage tp_QLNS;
    private System.Windows.Forms.TabPage tp_QLSK;

    #endregion
}