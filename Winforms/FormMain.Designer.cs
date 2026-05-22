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
        groupBox8 = new System.Windows.Forms.GroupBox();
        label15 = new System.Windows.Forms.Label();
        txt_eventAddress = new System.Windows.Forms.TextBox();
        groupBox7 = new System.Windows.Forms.GroupBox();
        label12 = new System.Windows.Forms.Label();
        label14 = new System.Windows.Forms.Label();
        txt_eventID = new System.Windows.Forms.TextBox();
        txt_eventName = new System.Windows.Forms.TextBox();
        txt_bonusScore = new System.Windows.Forms.TextBox();
        label13 = new System.Windows.Forms.Label();
        groupBox6 = new System.Windows.Forms.GroupBox();
        label16 = new System.Windows.Forms.Label();
        txt_eventSearch = new System.Windows.Forms.TextBox();
        btn_eventSearch = new System.Windows.Forms.Button();
        btn_eventAdd = new System.Windows.Forms.Button();
        btn_eventDelete = new System.Windows.Forms.Button();
        btn_eventUpdate = new System.Windows.Forms.Button();
        dgv_event = new System.Windows.Forms.DataGridView();
        col_eventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
        col_eventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        col_bonusScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
        col_eventAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
        tp_GNTG = new System.Windows.Forms.TabPage();
        tp_TH = new System.Windows.Forms.TabPage();
        dgv_PointsSummary = new System.Windows.Forms.DataGridView();
        groupBox9 = new System.Windows.Forms.GroupBox();
        btn_excelOut = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        btn_pointSearch = new System.Windows.Forms.Button();
        txt_SearchHumanId = new System.Windows.Forms.TextBox();
        label17 = new System.Windows.Forms.Label();
        QLDH.SuspendLayout();
        tp_QLNS.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_human).BeginInit();
        groupBox5.SuspendLayout();
        groupBox4.SuspendLayout();
        groupBox3.SuspendLayout();
        groupBox2.SuspendLayout();
        groupBox1.SuspendLayout();
        tp_QLSK.SuspendLayout();
        groupBox8.SuspendLayout();
        groupBox7.SuspendLayout();
        groupBox6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_event).BeginInit();
        tp_TH.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_PointsSummary).BeginInit();
        groupBox9.SuspendLayout();
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
        tp_QLNS.Location = new System.Drawing.Point(10, 58);
        tp_QLNS.Name = "tp_QLNS";
        tp_QLNS.Padding = new System.Windows.Forms.Padding(3);
        tp_QLNS.Size = new System.Drawing.Size(2097, 1412);
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
        txt_search.Size = new System.Drawing.Size(384, 47);
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
        txt_role.Size = new System.Drawing.Size(384, 47);
        txt_role.TabIndex = 5;
        // 
        // txt_term
        // 
        txt_term.Location = new System.Drawing.Point(458, 163);
        txt_term.Name = "txt_term";
        txt_term.Size = new System.Drawing.Size(384, 47);
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
        txt_class.Size = new System.Drawing.Size(384, 47);
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
        txt_street.Size = new System.Drawing.Size(384, 47);
        txt_street.TabIndex = 5;
        // 
        // txt_district
        // 
        txt_district.Location = new System.Drawing.Point(458, 163);
        txt_district.Name = "txt_district";
        txt_district.Size = new System.Drawing.Size(384, 47);
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
        txt_houseNum.Size = new System.Drawing.Size(384, 47);
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
        txt_fullName.Size = new System.Drawing.Size(389, 47);
        txt_fullName.TabIndex = 5;
        // 
        // txt_birthYear
        // 
        txt_birthYear.Location = new System.Drawing.Point(458, 163);
        txt_birthYear.Name = "txt_birthYear";
        txt_birthYear.Size = new System.Drawing.Size(389, 47);
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
        txt_humanId.Size = new System.Drawing.Size(389, 47);
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
        cbb_obj.Size = new System.Drawing.Size(389, 49);
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
        tp_QLSK.Controls.Add(groupBox8);
        tp_QLSK.Controls.Add(groupBox7);
        tp_QLSK.Controls.Add(groupBox6);
        tp_QLSK.Controls.Add(dgv_event);
        tp_QLSK.Location = new System.Drawing.Point(10, 58);
        tp_QLSK.Name = "tp_QLSK";
        tp_QLSK.Padding = new System.Windows.Forms.Padding(3);
        tp_QLSK.Size = new System.Drawing.Size(2097, 1412);
        tp_QLSK.TabIndex = 1;
        tp_QLSK.Text = "Quản lý Sự kiện Đoàn Hội";
        tp_QLSK.UseVisualStyleBackColor = true;
        // 
        // groupBox8
        // 
        groupBox8.Controls.Add(label15);
        groupBox8.Controls.Add(txt_eventAddress);
        groupBox8.Location = new System.Drawing.Point(6, 251);
        groupBox8.Name = "groupBox8";
        groupBox8.Size = new System.Drawing.Size(791, 100);
        groupBox8.TabIndex = 19;
        groupBox8.TabStop = false;
        // 
        // label15
        // 
        label15.BackColor = System.Drawing.Color.LightGray;
        label15.Location = new System.Drawing.Point(11, 22);
        label15.Name = "label15";
        label15.Size = new System.Drawing.Size(293, 50);
        label15.TabIndex = 4;
        label15.Text = "Địa điểm";
        // 
        // txt_eventAddress
        // 
        txt_eventAddress.Location = new System.Drawing.Point(315, 25);
        txt_eventAddress.Name = "txt_eventAddress";
        txt_eventAddress.Size = new System.Drawing.Size(434, 47);
        txt_eventAddress.TabIndex = 8;
        txt_eventAddress.TextChanged += txt_eventAddress_TextChanged;
        // 
        // groupBox7
        // 
        groupBox7.Controls.Add(label12);
        groupBox7.Controls.Add(label14);
        groupBox7.Controls.Add(txt_eventID);
        groupBox7.Controls.Add(txt_eventName);
        groupBox7.Controls.Add(txt_bonusScore);
        groupBox7.Controls.Add(label13);
        groupBox7.Location = new System.Drawing.Point(6, 6);
        groupBox7.Name = "groupBox7";
        groupBox7.Size = new System.Drawing.Size(791, 239);
        groupBox7.TabIndex = 18;
        groupBox7.TabStop = false;
        // 
        // label12
        // 
        label12.BackColor = System.Drawing.Color.LightGray;
        label12.Location = new System.Drawing.Point(6, 43);
        label12.Name = "label12";
        label12.Size = new System.Drawing.Size(298, 50);
        label12.TabIndex = 1;
        label12.Text = "Mã sự kiện";
        // 
        // label14
        // 
        label14.BackColor = System.Drawing.Color.LightGray;
        label14.Location = new System.Drawing.Point(6, 106);
        label14.Name = "label14";
        label14.Size = new System.Drawing.Size(298, 50);
        label14.TabIndex = 3;
        label14.Text = "Tên sự kiện";
        // 
        // txt_eventID
        // 
        txt_eventID.Location = new System.Drawing.Point(315, 40);
        txt_eventID.Name = "txt_eventID";
        txt_eventID.Size = new System.Drawing.Size(434, 47);
        txt_eventID.TabIndex = 5;
        // 
        // txt_eventName
        // 
        txt_eventName.Location = new System.Drawing.Point(315, 109);
        txt_eventName.Name = "txt_eventName";
        txt_eventName.Size = new System.Drawing.Size(434, 47);
        txt_eventName.TabIndex = 6;
        // 
        // txt_bonusScore
        // 
        txt_bonusScore.Location = new System.Drawing.Point(315, 171);
        txt_bonusScore.Name = "txt_bonusScore";
        txt_bonusScore.Size = new System.Drawing.Size(434, 47);
        txt_bonusScore.TabIndex = 7;
        // 
        // label13
        // 
        label13.BackColor = System.Drawing.Color.LightGray;
        label13.Location = new System.Drawing.Point(6, 168);
        label13.Name = "label13";
        label13.Size = new System.Drawing.Size(298, 50);
        label13.TabIndex = 2;
        label13.Text = "Điểm cộng rèn luyện";
        // 
        // groupBox6
        // 
        groupBox6.Controls.Add(label16);
        groupBox6.Controls.Add(txt_eventSearch);
        groupBox6.Controls.Add(btn_eventSearch);
        groupBox6.Controls.Add(btn_eventAdd);
        groupBox6.Controls.Add(btn_eventDelete);
        groupBox6.Controls.Add(btn_eventUpdate);
        groupBox6.Location = new System.Drawing.Point(3, 357);
        groupBox6.Name = "groupBox6";
        groupBox6.Size = new System.Drawing.Size(794, 171);
        groupBox6.TabIndex = 17;
        groupBox6.TabStop = false;
        // 
        // label16
        // 
        label16.BackColor = System.Drawing.Color.LightGray;
        label16.Location = new System.Drawing.Point(6, 31);
        label16.Name = "label16";
        label16.Size = new System.Drawing.Size(301, 50);
        label16.TabIndex = 10;
        label16.Text = "Tìm kiếm";
        // 
        // txt_eventSearch
        // 
        txt_eventSearch.Location = new System.Drawing.Point(318, 31);
        txt_eventSearch.Name = "txt_eventSearch";
        txt_eventSearch.Size = new System.Drawing.Size(434, 47);
        txt_eventSearch.TabIndex = 11;
        // 
        // btn_eventSearch
        // 
        btn_eventSearch.Location = new System.Drawing.Point(595, 101);
        btn_eventSearch.Name = "btn_eventSearch";
        btn_eventSearch.Size = new System.Drawing.Size(157, 54);
        btn_eventSearch.TabIndex = 15;
        btn_eventSearch.Text = "Tìm";
        btn_eventSearch.UseVisualStyleBackColor = true;
        // 
        // btn_eventAdd
        // 
        btn_eventAdd.Location = new System.Drawing.Point(1, 101);
        btn_eventAdd.Name = "btn_eventAdd";
        btn_eventAdd.Size = new System.Drawing.Size(157, 54);
        btn_eventAdd.TabIndex = 12;
        btn_eventAdd.Text = "Thêm";
        btn_eventAdd.UseVisualStyleBackColor = true;
        // 
        // btn_eventDelete
        // 
        btn_eventDelete.Location = new System.Drawing.Point(405, 101);
        btn_eventDelete.Name = "btn_eventDelete";
        btn_eventDelete.Size = new System.Drawing.Size(157, 54);
        btn_eventDelete.TabIndex = 13;
        btn_eventDelete.Text = "Xóa";
        btn_eventDelete.UseVisualStyleBackColor = true;
        // 
        // btn_eventUpdate
        // 
        btn_eventUpdate.Location = new System.Drawing.Point(206, 101);
        btn_eventUpdate.Name = "btn_eventUpdate";
        btn_eventUpdate.Size = new System.Drawing.Size(157, 54);
        btn_eventUpdate.TabIndex = 14;
        btn_eventUpdate.Text = "Sửa";
        btn_eventUpdate.UseVisualStyleBackColor = true;
        // 
        // dgv_event
        // 
        dgv_event.AllowUserToOrderColumns = true;
        dgv_event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_event.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { col_eventID, col_eventName, col_bonusScore, col_eventAddress });
        dgv_event.Location = new System.Drawing.Point(803, 6);
        dgv_event.Name = "dgv_event";
        dgv_event.RowHeadersWidth = 102;
        dgv_event.Size = new System.Drawing.Size(1288, 999);
        dgv_event.TabIndex = 9;
        dgv_event.Text = "dataGridView1";
        dgv_event.CellContentClick += dgv_event_CellContentClick;
        // 
        // col_eventID
        // 
        col_eventID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_eventID.HeaderText = "Mã sự kiện ";
        col_eventID.MinimumWidth = 12;
        col_eventID.Name = "col_eventID";
        col_eventID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // col_eventName
        // 
        col_eventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_eventName.HeaderText = "Tên sự kiện ";
        col_eventName.MinimumWidth = 12;
        col_eventName.Name = "col_eventName";
        col_eventName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // col_bonusScore
        // 
        col_bonusScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_bonusScore.HeaderText = "Điểm cộng rèn luyện";
        col_bonusScore.MinimumWidth = 12;
        col_bonusScore.Name = "col_bonusScore";
        col_bonusScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // col_eventAddress
        // 
        col_eventAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        col_eventAddress.HeaderText = "Địa điểm";
        col_eventAddress.MinimumWidth = 12;
        col_eventAddress.Name = "col_eventAddress";
        col_eventAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        // 
        // tp_GNTG
        // 
        tp_GNTG.Location = new System.Drawing.Point(10, 58);
        tp_GNTG.Name = "tp_GNTG";
        tp_GNTG.Padding = new System.Windows.Forms.Padding(3);
        tp_GNTG.Size = new System.Drawing.Size(2097, 1412);
        tp_GNTG.TabIndex = 2;
        tp_GNTG.Text = "Điểm danh & Ghi nhận tham gia";
        tp_GNTG.UseVisualStyleBackColor = true;
        // 
        // tp_TH
        // 
        tp_TH.Controls.Add(dgv_PointsSummary);
        tp_TH.Controls.Add(groupBox9);
        tp_TH.Location = new System.Drawing.Point(10, 58);
        tp_TH.Name = "tp_TH";
        tp_TH.Padding = new System.Windows.Forms.Padding(3);
        tp_TH.Size = new System.Drawing.Size(2097, 1412);
        tp_TH.TabIndex = 3;
        tp_TH.Text = "Tổng hợp & Tính điểm rèn luyện";
        tp_TH.UseVisualStyleBackColor = true;
        // 
        // dgv_PointsSummary
        // 
        dgv_PointsSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv_PointsSummary.Location = new System.Drawing.Point(735, 3);
        dgv_PointsSummary.Name = "dgv_PointsSummary";
        dgv_PointsSummary.RowHeadersWidth = 102;
        dgv_PointsSummary.Size = new System.Drawing.Size(1181, 999);
        dgv_PointsSummary.TabIndex = 6;
        dgv_PointsSummary.Text = "dataGridView1";
        // 
        // groupBox9
        // 
        groupBox9.Controls.Add(btn_excelOut);
        groupBox9.Controls.Add(button1);
        groupBox9.Controls.Add(btn_pointSearch);
        groupBox9.Controls.Add(txt_SearchHumanId);
        groupBox9.Controls.Add(label17);
        groupBox9.Location = new System.Drawing.Point(0, 6);
        groupBox9.Name = "groupBox9";
        groupBox9.Size = new System.Drawing.Size(729, 312);
        groupBox9.TabIndex = 1;
        groupBox9.TabStop = false;
        // 
        // btn_excelOut
        // 
        btn_excelOut.Location = new System.Drawing.Point(468, 205);
        btn_excelOut.Name = "btn_excelOut";
        btn_excelOut.Size = new System.Drawing.Size(224, 78);
        btn_excelOut.TabIndex = 12;
        btn_excelOut.Text = "Xuất ra Excel\r\n";
        btn_excelOut.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
        button1.Location = new System.Drawing.Point(25, 205);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(224, 78);
        button1.TabIndex = 11;
        button1.Text = "Tổng điểm rèn luyện";
        button1.UseVisualStyleBackColor = true;
        // 
        // btn_pointSearch
        // 
        btn_pointSearch.Location = new System.Drawing.Point(535, 111);
        btn_pointSearch.Name = "btn_pointSearch";
        btn_pointSearch.Size = new System.Drawing.Size(157, 54);
        btn_pointSearch.TabIndex = 10;
        btn_pointSearch.Text = "Tìm";
        btn_pointSearch.UseVisualStyleBackColor = true;
        // 
        // txt_SearchHumanId
        // 
        txt_SearchHumanId.Location = new System.Drawing.Point(303, 28);
        txt_SearchHumanId.Name = "txt_SearchHumanId";
        txt_SearchHumanId.Size = new System.Drawing.Size(389, 47);
        txt_SearchHumanId.TabIndex = 2;
        // 
        // label17
        // 
        label17.BackColor = System.Drawing.Color.LightGray;
        label17.Location = new System.Drawing.Point(7, 23);
        label17.Name = "label17";
        label17.Size = new System.Drawing.Size(277, 50);
        label17.TabIndex = 1;
        label17.Text = "Mã định danh:";
        // 
        // FormMain
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(2029, 1055);
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
        groupBox8.ResumeLayout(false);
        groupBox8.PerformLayout();
        groupBox7.ResumeLayout(false);
        groupBox7.PerformLayout();
        groupBox6.ResumeLayout(false);
        groupBox6.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgv_event).EndInit();
        tp_TH.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv_PointsSummary).EndInit();
        groupBox9.ResumeLayout(false);
        groupBox9.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btn_excelOut;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Button btn_pointSearch;

    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.TextBox txt_SearchHumanId;

    private System.Windows.Forms.GroupBox groupBox9;

    private System.Windows.Forms.GroupBox groupBox6;
    private System.Windows.Forms.GroupBox groupBox7;
    private System.Windows.Forms.GroupBox groupBox8;

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
    private System.Windows.Forms.DataGridView dgv_PointsSummary;

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