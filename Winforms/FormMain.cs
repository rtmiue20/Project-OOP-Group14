using QLDH.Data;
using QLDH.Entities;
using QLDH.Service;

namespace Quản_lý_đoàn_hội;

public partial class FormMain : Form
{
    private StudentManager studentManager = new StudentManager();
    private OfficialManager officialManager = new OfficialManager();
    private RewardManager rewardManager = new RewardManager();
    private FacultyManager facultyManager = new FacultyManager();
    private LecturerManager lecturerManager = new LecturerManager();
    private EventManager eventManager = new EventManager();
    private ClubManager clubManager = new ClubManager();

    private Panel pnl_sidebar;
    private Panel pnl_top;
    private Label lbl_title;
    private Button btn_navStudent;
    private Button btn_navEvent;
    private Button btn_navClub;
    private Button btn_navReward;
    private Button btn_navLecturer;
    private Button btn_navFaculty;
    private Button btn_navAttendance;
    private Button activeBtn;

    private Account currentUser;

    public FormMain(Account account)
    {
        this.currentUser = account;
        InitializeComponent();
        SetupModernUI();
        ApplyRoleBasedAccess();

        // Đăng ký sự kiện DataChanged cho các Manager
        studentManager.DataChanged += (s, e) => LoadStudentData();
        officialManager.DataChanged += (s, e) => LoadStudentData();
        eventManager.DataChanged += (s, e) => LoadEventData();
        clubManager.DataChanged += (s, e) => LoadClubData();
        rewardManager.DataChanged += (s, e) => LoadRewardData();
        facultyManager.DataChanged += (s, e) => LoadFacultyData();
        lecturerManager.DataChanged += (s, e) => LoadLecturerData();

        // TabControl Event
        tc_demo.SelectedIndexChanged += tc_demo_SelectedIndexChanged;

        // Tab 1: Sinh viên
        btn_studentAdd.Click += btnStudentAdd_Click;
        btn_studentUpdate.Click += btnStudentUpdate_Click;
        btn_studentDelete.Click += btnStudentDelete_Click;
        btn_studentSearch.Click += btn_studentSearch_Click;
        dgv_student.CellClick += dgv_student_CellClick;
        cb_isOfficial.CheckedChanged += chkIsOfficial_CheckedChanged;

        // Tab 2: Sự kiện
        this.dgv_event.CellClick += new DataGridViewCellEventHandler(this.dgv_events_CellClick);
        this.btn_eventAdd.Click += btn_eventAdd_Click;
        this.btn_eventUpdate.Click += btn_eventUpdate_Click;
        this.btn_eventDelete.Click += btn_eventDelete_Click;
        this.btn_eventSearch.Click += new EventHandler(this.btn_eventSearch_Click);

        // Tab 3: Câu lạc bộ
        this.dgv_club.CellClick += dgv_club_CellClick;
        this.btn_clubAdd.Click += btn_clubAdd_Click;
        this.btn_clubUpdate.Click += btn_clubUpdate_Click;
        this.btn_clubDelete.Click += btn_clubDelete_Click;
        this.btn_clubSearch.Click += btn_clubSearch_Click;

        // Tab 4: Khen thưởng
        this.dgv_reward.CellClick += dgv_reward_CellClick;
        this.btn_rewardAdd.Click += btn_rewardAdd_Click;
        this.btn_rewardUpdate.Click += btn_rewardUpdate_Click;
        this.btn_rewardDelete.Click += btn_rewardDelete_Click;
        this.btn_rewardSearch.Click += btn_rewardSearch_Click;

        // Tab 5: Khoa
        this.dgv_faculty.CellClick += dgv_faculty_CellClick;
        this.btn_facultyAdd.Click += btn_facultyAdd_Click;
        this.btn_facultyUpdate.Click += btn_facultyUpdate_Click;
        this.btn_facultyDelete.Click += btn_facultyDelete_Click;
        this.btn_facultySearch.Click += btn_facultySearch_Click;

        // Tab 6: Giảng viên
        this.dgv_lecturer.CellClick += dgv_lecturer_CellClick;
        this.btn_lecturerAdd.Click += btn_lecturerAdd_Click;
        this.btn_lecturerUpdate.Click += btn_lecturerUpdate_Click;
        this.btn_lecturerDelete.Click += btn_lecturerDelete_Click;
        this.btn_lecturerSearch.Click += btn_lecturerSearch_Click;

        // Tab 7: Điểm danh
        this.dgv_attendance.CellClick += dgv_attendance_CellClick;
        this.btn_ddAdd.Click += btn_ddAdd_Click;
        this.btn_ddSearch.Click += btn_ddSearch_Click;
        this.button1.Click += btn_ddUpdate_Click;
        this.button2.Click += btn_ddDelete_Click;

        LoadClubData();
        
        // Mặc định chọn tab đầu tiên
        if (btn_navStudent != null) btn_navStudent.PerformClick();
        
        // Cấu hình form toàn màn hình và lấp đầy
        this.WindowState = FormWindowState.Maximized;
    }

    private void StyleButton(Button btn, Color backColor)
    {
        if (btn == null) return;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.BackColor = backColor;
        btn.ForeColor = Color.White;
        btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;
        
        // Thêm hiệu ứng hover nhẹ
        btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(backColor);
        btn.MouseLeave += (s, e) => btn.BackColor = backColor;
    }

    private void ApplyRoleBasedAccess()
    {
        if (currentUser == null) return;

        if (currentUser.Role == "User")
        {
            LoadFacultyData();
            LoadStudentData();
            LoadEventData();
            LoadClubData();
            // Nếu là User thường, ẩn các chức năng quan trọng
            // Giả sử ẩn tab Điểm danh, Khen thưởng và Giảng viên
            if (tc_demo.TabPages.Contains(tp_DD)) tc_demo.TabPages.Remove(tp_DD);
            if (tc_demo.TabPages.Contains(tp_KT)) tc_demo.TabPages.Remove(tp_KT);
            if (tc_demo.TabPages.Contains(tp_GV)) tc_demo.TabPages.Remove(tp_GV);
            
            // Ẩn các nút điều hướng tương ứng ở sidebar nếu có
            if (btn_navAttendance != null) btn_navAttendance.Visible = false;
            if (btn_navReward != null) btn_navReward.Visible = false;
            if (btn_navLecturer != null) btn_navLecturer.Visible = false;
            
            // Có thể hạn chế thêm các nút Thêm/Sửa/Xóa ở các tab còn lại
            btn_studentAdd.Enabled = false;
            btn_studentUpdate.Enabled = false;
            btn_studentDelete.Enabled = false;
            
            btn_eventAdd.Enabled = false;
            btn_eventUpdate.Enabled = false;
            btn_eventDelete.Enabled = false;
            
            btn_clubAdd.Enabled = false;
            btn_clubUpdate.Enabled = false;
            btn_clubDelete.Enabled = false;
            
            btn_facultyAdd.Enabled = false;
            btn_facultyUpdate.Enabled = false;
            btn_facultyDelete.Enabled = false;
        }
        
        lbl_title.Text += $" - [{currentUser.Username} ({currentUser.Role})]";
    }

    private void SetupModernUI()
    {
        // Palette màu hiện đại mới (Deep Blue & Soft White)
        Color primaryDark = Color.FromArgb(28, 35, 49);     // Sidebar background
        Color secondaryDark = Color.FromArgb(35, 45, 63);   // Top Panel
        Color accentColor = Color.FromArgb(0, 150, 255);    // Azure Blue accent
        Color activeMenuColor = Color.FromArgb(43, 54, 76); // Active menu background
        Color textColor = Color.FromArgb(240, 240, 240);

        // Ẩn tab headers
        tc_demo.Appearance = TabAppearance.FlatButtons;
        tc_demo.ItemSize = new Size(0, 1);
        tc_demo.SizeMode = TabSizeMode.Fixed;
        tc_demo.Dock = DockStyle.Fill;

        // Sidebar Panel
        pnl_sidebar = new Panel();
        pnl_sidebar.Dock = DockStyle.Left;
        pnl_sidebar.Width = 400;
        pnl_sidebar.BackColor = primaryDark;
        this.Controls.Add(pnl_sidebar);

        // Sidebar Logo/Header area (Hidden or removed as requested)
        Panel pnl_logo = new Panel();
        pnl_logo.Dock = DockStyle.Top;
        pnl_logo.Height = 0; // Set height to 0 to "remove" it while keeping layout structure if needed, or just don't add label
        pnl_logo.BackColor = Color.FromArgb(23, 29, 41);
        pnl_sidebar.Controls.Add(pnl_logo);

        // Top Panel
        pnl_top = new Panel();
        pnl_top.Dock = DockStyle.Top;
        pnl_top.Height = 60;
        pnl_top.BackColor = Color.White;
        this.Controls.Add(pnl_top);
        
        lbl_title = new Label();
        lbl_title.Text = "BẢNG ĐIỀU KHIỂN";
        lbl_title.ForeColor = Color.FromArgb(45, 52, 54);
        lbl_title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
        lbl_title.TextAlign = ContentAlignment.MiddleLeft;
        lbl_title.Padding = new Padding(20, 0, 0, 0);
        lbl_title.Dock = DockStyle.Fill;
        pnl_top.Controls.Add(lbl_title);

        // Border line for top panel
        Panel pnl_top_border = new Panel();
        pnl_top_border.Dock = DockStyle.Bottom;
        pnl_top_border.Height = 1;
        pnl_top_border.BackColor = Color.FromArgb(220, 220, 220);
        pnl_top.Controls.Add(pnl_top_border);

        // Bring to front to ensure panels are above TabControl
        pnl_sidebar.BringToFront();
        pnl_top.BringToFront();
        tc_demo.BringToFront();

        // Menu Buttons (Thứ tự từ dưới lên vì Dock.Top)
        btn_navAttendance = CreateMenuBtn("📋 Điểm danh", 6);
        btn_navFaculty = CreateMenuBtn("🏫 Khoa", 5);
        btn_navLecturer = CreateMenuBtn("👨‍🏫 Giảng viên", 4);
        btn_navReward = CreateMenuBtn("🏆 Khen thưởng", 3);
        btn_navClub = CreateMenuBtn("🤝 Câu lạc bộ", 2);
        btn_navEvent = CreateMenuBtn("📅 Sự kiện", 1);
        btn_navStudent = CreateMenuBtn("👥 Sinh viên", 0);

        // Styling CRUD Buttons
        Color addColor = Color.FromArgb(46, 204, 113);    // Emerald Green
        Color updateColor = Color.FromArgb(52, 152, 219); // Peter River Blue
        Color deleteColor = Color.FromArgb(231, 76, 60);  // Alizarin Red
        Color searchColor = Color.FromArgb(149, 165, 166); // Asbestos Gray

        // Áp dụng Style cho tất cả các nút CRUD
        StyleAllButtons(addColor, updateColor, deleteColor, searchColor);

        // Styling DataGridViews
        StyleDGV(dgv_student, accentColor);
        StyleDGV(dgv_event, accentColor);
        StyleDGV(dgv_club, accentColor);
        StyleDGV(dgv_reward, accentColor);
        StyleDGV(dgv_lecturer, accentColor);
        StyleDGV(dgv_faculty, accentColor);
        StyleDGV(dgv_attendance, accentColor);
        
        // Font update for all controls
        UpdateFont(this);
    }

    private void StyleAllButtons(Color addColor, Color updateColor, Color deleteColor, Color searchColor)
    {
        StyleButton(btn_studentAdd, addColor);
        StyleButton(btn_studentUpdate, updateColor);
        StyleButton(btn_studentDelete, deleteColor);
        StyleButton(btn_studentSearch, searchColor);

        StyleButton(btn_eventAdd, addColor);
        StyleButton(btn_eventUpdate, updateColor);
        StyleButton(btn_eventDelete, deleteColor);
        StyleButton(btn_eventSearch, searchColor);

        StyleButton(btn_clubAdd, addColor);
        StyleButton(btn_clubUpdate, updateColor);
        StyleButton(btn_clubDelete, deleteColor);
        StyleButton(btn_clubSearch, searchColor);

        StyleButton(btn_rewardAdd, addColor);
        StyleButton(btn_rewardUpdate, updateColor);
        StyleButton(btn_rewardDelete, deleteColor);
        StyleButton(btn_rewardSearch, searchColor);

        StyleButton(btn_lecturerAdd, addColor);
        StyleButton(btn_lecturerUpdate, updateColor);
        StyleButton(btn_lecturerDelete, deleteColor);
        StyleButton(btn_lecturerSearch, searchColor);

        StyleButton(btn_facultyAdd, addColor);
        StyleButton(btn_facultyUpdate, updateColor);
        StyleButton(btn_facultyDelete, deleteColor);
        StyleButton(btn_facultySearch, searchColor);

        StyleButton(btn_ddAdd, addColor);
        StyleButton(button1, updateColor);
        StyleButton(button2, deleteColor);
        StyleButton(btn_ddSearch, searchColor);
    }

    private Button CreateMenuBtn(string text, int tabIndex)
    {
        Button btn = new Button();
        btn.Text = "    " + text;
        btn.Dock = DockStyle.Top;
        btn.Height = 50;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(43, 54, 76);
        btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 54, 76);
        btn.ForeColor = Color.FromArgb(176, 186, 201);
        btn.TextAlign = ContentAlignment.MiddleLeft;
        btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        btn.Tag = tabIndex;
        btn.Cursor = Cursors.Hand;
        btn.Click += NavBtn_Click;
        pnl_sidebar.Controls.Add(btn);
        
        // Hiệu ứng hover menu
        btn.MouseEnter += (s, e) => { 
            if (activeBtn != btn) {
                btn.BackColor = Color.FromArgb(43, 54, 76);
                btn.ForeColor = Color.White;
            }
        };
        btn.MouseLeave += (s, e) => { 
            if (activeBtn != btn) {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(176, 186, 201);
            }
        };
        
        return btn;
    }

    private void NavBtn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int index = (int)btn.Tag;
        tc_demo.SelectedIndex = index;
        
        // Highlight active button
        if (activeBtn != null)
        {
            activeBtn.BackColor = Color.Transparent;
            activeBtn.ForeColor = Color.FromArgb(176, 186, 201);
            activeBtn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }
        activeBtn = btn;
        activeBtn.BackColor = Color.FromArgb(0, 150, 255); // Azure Blue
        activeBtn.ForeColor = Color.White;
        activeBtn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        lbl_title.Text = btn.Text.Trim().ToUpper();

        UpdateFont(tc_demo.SelectedTab);
    }

    private void StyleDGV(DataGridView dgv, Color accentColor)
    {
        if (dgv == null) return;
        dgv.BackgroundColor = Color.White;
        dgv.BorderStyle = BorderStyle.None;
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(242, 245, 250);
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 82, 94);
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        dgv.ColumnHeadersHeight = 45;
        dgv.EnableHeadersVisualStyles = false;
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 245, 255);
        dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 120, 215);
        dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9);
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.RowTemplate.Height = 35;
        dgv.GridColor = Color.FromArgb(239, 243, 247);
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
    }

    private void UpdateFont(Control parent)
    {
        if (parent == null) return;
        foreach (Control c in parent.Controls)
        {
            if (c is Label || c is Button || c is TextBox || c is GroupBox || c is ComboBox || c is CheckBox)
            {
                if (c.Font.Name != "Segoe UI")
                    c.Font = new Font("Segoe UI", 9, c.Font.Style);
            }

            if (c is GroupBox gb)
            {
                gb.FlatStyle = FlatStyle.Flat;
                gb.ForeColor = Color.FromArgb(42, 54, 63);
            }
            
            if (c.HasChildren) UpdateFont(c);
        }
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
    }

    private void tc_demo_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (tc_demo.SelectedIndex)
        {
            case 0: // Sinh viên & Đoàn viên
                LoadStudentData();
                break;
            case 1: // Sự kiện
                LoadEventData();
                break;
            case 2: // Câu lạc bộ
                LoadClubData();
                break;
            case 3: // Khen thưởng
                LoadStudentAndOfficialToComboBox();
                LoadRewardData();
                break;
            case 4: // Giảng viên
                LoadLecturerData();
                break;
            case 5: // Khoa
                LoadFacultyData();
                break;
            case 6: // Điểm danh
                LoadAttendanceData();
                LoadStudentAndEventToComboDD();
                break;
        }
    }

    private void LoadLecturerData()
    {
        var lecturers = lecturerManager.GetAll();
        dgv_lecturer.DataSource = null;
        dgv_lecturer.DataSource = lecturers;

        if (dgv_lecturer.Columns.Count > 0)
        {
            if (dgv_lecturer.Columns["LecturerId"] != null) dgv_lecturer.Columns["LecturerId"].HeaderText = "Mã GV";
            if (dgv_lecturer.Columns["FullName"] != null) dgv_lecturer.Columns["FullName"].HeaderText = "Họ Tên";
            if (dgv_lecturer.Columns["Department"] != null) dgv_lecturer.Columns["Department"].HeaderText = "Phòng ban/Bộ môn";
            if (dgv_lecturer.Columns["BirthYear"] != null) dgv_lecturer.Columns["BirthYear"].HeaderText = "Năm sinh";
        }
    }

    private void LoadFacultyData()
    {
        var faculties = facultyManager.GetAll();
        
        // Load to ComboBox (for Student tab)
        if (cbb_faculty != null)
        {
            cbb_faculty.DataSource = null;
            cbb_faculty.DataSource = faculties;
            cbb_faculty.DisplayMember = "FacultyName";
            cbb_faculty.ValueMember = "FacultyId";
        }

        // Load to DataGridView (for Faculty tab)
        dgv_faculty.DataSource = null;
        dgv_faculty.DataSource = faculties;
        if (dgv_faculty.Columns.Count > 0)
        {
            dgv_faculty.Columns["FacultyId"].HeaderText = "Mã Khoa";
            dgv_faculty.Columns["FacultyName"].HeaderText = "Tên Khoa";
            dgv_faculty.Columns["DeanName"].HeaderText = "Trưởng Khoa";
        }
    }

    /* ========= TAB 1: Sinh viên & Đoàn viên ========*/
    // 1. LoadData function
    private void LoadStudentData()
    {
        List<object> displayList = new List<object>();
        
        // Thêm Student
        foreach (var st in studentManager.GetAll())
        {
            displayList.Add(new {
                st.StudentId,
                st.FullName,
                st.ClassName,
                st.BirthYear,
                st.TrainingScore,
                Role = "Sinh viên",
                Term = "-"
            });
        }
        
        // Thêm Official
        foreach (var off in officialManager.GetAll())
        {
            displayList.Add(new {
                off.StudentId,
                off.FullName,
                off.ClassName,
                off.BirthYear,
                off.TrainingScore,
                off.Role,
                off.Term
            });
        }

        dgv_student.DataSource = null;
        dgv_student.DataSource = displayList;
        
        if (dgv_student.Columns.Count > 0)
        {
            dgv_student.Columns["StudentId"].HeaderText = "MSSV";
            dgv_student.Columns["FullName"].HeaderText = "Họ Tên";
            dgv_student.Columns["ClassName"].HeaderText = "Lớp";
            dgv_student.Columns["BirthYear"].HeaderText = "Năm sinh";
            dgv_student.Columns["TrainingScore"].HeaderText = "ĐRL";
            dgv_student.Columns["Role"].HeaderText = "Chức vụ";
            dgv_student.Columns["Term"].HeaderText = "Nhiệm kỳ";
        }
    }

    // 2. StudentAdd function
    private void btnStudentAdd_Click(object sender, EventArgs e)
    {
        if (cb_isOfficial.Checked)
        {
            Official off = new Official
            {
                StudentId = txt_studentId.Text,
                FullName = txt_fullName.Text,
                ClassName = txt_class.Text,
                BirthYear = (int)nud_birthYear.Value,
                Role = txt_role.Text,
                Term = txt_term.Text,
                TrainingScore = 0 
            };
            officialManager.Add(off);
        }
        else
        {
            Student st = new Student
            {
                StudentId = txt_studentId.Text,
                FullName = txt_fullName.Text,
                ClassName = txt_class.Text,
                BirthYear = (int)nud_birthYear.Value,
                TrainingScore = 0
            };
            studentManager.Add(st);
        }

        MessageBox.Show("Thêm thành công!");
        ClearStudentForm();
    }

    // 3. StudentUpdate function
    private void btnStudentUpdate_Click(object sender, EventArgs e)
    {
        string id = txt_studentId.Text;
        if (string.IsNullOrEmpty(id))
        {
            MessageBox.Show("Vui lòng chọn sinh viên cần cập nhật!");
            return;
        }

        if (cb_isOfficial.Checked)
        {
            Official off = officialManager.GetById(id);
            if (off != null)
            {
                off.FullName = txt_fullName.Text;
                off.ClassName = txt_class.Text;
                off.BirthYear = (int)nud_birthYear.Value;
                off.Role = txt_role.Text;
                off.Term = txt_term.Text;
                officialManager.Update(off);
                MessageBox.Show("Cập nhật Cán bộ Đoàn thành công!");
            }
            else
            {
                // Nếu không tìm thấy trong OfficialManager, có thể là Student được nâng cấp
                studentManager.Delete(id);
                Official newOff = new Official
                {
                    StudentId = id,
                    FullName = txt_fullName.Text,
                    ClassName = txt_class.Text,
                    BirthYear = (int)nud_birthYear.Value,
                    Role = txt_role.Text,
                    Term = txt_term.Text,
                    TrainingScore = 0
                };
                officialManager.Add(newOff);
                MessageBox.Show("Đã cập nhật và nâng cấp lên Cán bộ Đoàn!");
            }
        }
        else
        {
            Student st = studentManager.GetById(id);
            if (st != null)
            {
                st.FullName = txt_fullName.Text;
                st.ClassName = txt_class.Text;
                st.BirthYear = (int)nud_birthYear.Value;
                studentManager.Update(st);
                MessageBox.Show("Cập nhật Sinh viên thành công!");
            }
            else
            {
                // Ngược lại, nếu là Official hạ cấp xuống Student
                Official off = officialManager.GetById(id);
                if (off != null)
                {
                    officialManager.Delete(id);
                    Student newSt = new Student
                    {
                        StudentId = id,
                        FullName = txt_fullName.Text,
                        ClassName = txt_class.Text,
                        BirthYear = (int)nud_birthYear.Value,
                        TrainingScore = off.TrainingScore
                    };
                    studentManager.Add(newSt);
                    MessageBox.Show("Đã cập nhật và thay đổi thành Sinh viên thường!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên để cập nhật!");
                }
            }
        }
        
        ClearStudentForm();
    }

    private void dgv_student_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgv_student.Rows[e.RowIndex];
            txt_studentId.Text = row.Cells["StudentId"].Value?.ToString();
            txt_fullName.Text = row.Cells["FullName"].Value?.ToString();
            txt_class.Text = row.Cells["ClassName"].Value?.ToString();
            if (row.Cells["BirthYear"].Value != null)
                nud_birthYear.Value = Convert.ToInt32(row.Cells["BirthYear"].Value);

            // Kiểm tra xem đối tượng là Official hay Student
            string studentId = txt_studentId.Text;
            Official off = officialManager.GetById(studentId);
            if (off != null)
            {
                cb_isOfficial.Checked = true;
                txt_role.Text = off.Role;
                txt_term.Text = off.Term;
            }
            else
            {
                cb_isOfficial.Checked = false;
                txt_role.Text = "";
                txt_term.Text = "";
            }
        }
    }

    // 4. StudentDelete function
    private void btnStudentDelete_Click(object sender, EventArgs e)
    {
        string id = txt_studentId.Text;

        if (string.IsNullOrEmpty(id))
        {
            MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
            return;
        }

        DialogResult confirm = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa sinh viên này?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (confirm == DialogResult.Yes)
        {
            studentManager.Delete(id);
            officialManager.Delete(id);
            MessageBox.Show("Đã xóa sinh viên!");
            ClearStudentForm();
            LoadStudentData();
        }
    }

    // 5. SearchStudent function
    private void btn_studentSearch_Click(object sender, EventArgs e)
    {
        string keyword = txt_studentSearch.Text.Trim();
        if (string.IsNullOrEmpty(keyword))
        {
            LoadStudentData();
            return;
        }

        List<Student> stResults = studentManager.Search(keyword);
        List<Official> offResults = officialManager.Search(keyword);

        var displayList = new List<object>();
        foreach (var st in stResults)
        {
            displayList.Add(new {
                st.StudentId,
                st.FullName,
                st.ClassName,
                st.BirthYear,
                st.TrainingScore,
                Role = "Sinh viên",
                Term = "-"
            });
        }
        foreach (var off in offResults)
        {
            displayList.Add(new {
                off.StudentId,
                off.FullName,
                off.ClassName,
                off.BirthYear,
                off.TrainingScore,
                off.Role,
                off.Term
            });
        }

        dgv_student.DataSource = null;
        dgv_student.DataSource = displayList;

        if (displayList.Count == 0)
        {
            MessageBox.Show("Không tìm thấy sinh viên phù hợp!");
        }
        else if (dgv_student.Columns.Count > 0)
        {
            dgv_student.Columns["StudentId"].HeaderText = "MSSV";
            dgv_student.Columns["FullName"].HeaderText = "Họ Tên";
            dgv_student.Columns["ClassName"].HeaderText = "Lớp";
            dgv_student.Columns["BirthYear"].HeaderText = "Năm sinh";
            dgv_student.Columns["TrainingScore"].HeaderText = "ĐRL";
            dgv_student.Columns["Role"].HeaderText = "Chức vụ";
            dgv_student.Columns["Term"].HeaderText = "Nhiệm kỳ";
        }
    }

    // 6. ClearStudentForm function
    private void ClearStudentForm()
    {
        txt_studentId.Clear();
        txt_fullName.Clear();
        txt_class.Clear();
        nud_birthYear.Value = 2006;
        cb_isOfficial.Checked = false;
        txt_role.Clear();
        txt_term.Clear();
    }

    // 7. SolveEvent function (Hide)
    private void chkIsOfficial_CheckedChanged(object sender, EventArgs e)
    {
        bool isOfficial = cb_isOfficial.Checked;
        txt_role.Visible = isOfficial;
        txt_term.Visible = isOfficial;
        lbl_role.Visible = isOfficial;
        lbl_term.Visible = isOfficial;
    }
    
    /* ========= TAB 2: Sự kiện ========*/


    // 1. LoadDataEvent function
    private void LoadEventData()
    {
        List<UnionEvent> list = eventManager.GetAll();

        dgv_event.DataSource = null;
        dgv_event.DataSource = list;

        if (dgv_event.Columns.Count > 0)
        {
            // Ẩn các cột hệ thống không cần hiển thị
            if (dgv_event.Columns["Address"] != null)
                dgv_event.Columns["Address"].Visible = false;
            if (dgv_event.Columns["Participants"] != null)
                dgv_event.Columns["Participants"].Visible = false;

            // Đổi tên tiêu đề cột cho thân thiện
            if (dgv_event.Columns["EventId"] != null)
                dgv_event.Columns["EventId"].HeaderText = "Mã Sự Kiện";
            if (dgv_event.Columns["EventName"] != null)
                dgv_event.Columns["EventName"].HeaderText = "Tên Sự Kiện";
            if (dgv_event.Columns["BonusScore"] != null)
                dgv_event.Columns["BonusScore"].HeaderText = "Điểm Cộng";
        }
    }

    // 2. AddEvent function
    private void btn_eventAdd_Click(object sender, EventArgs e)
    {
        string eventId = txt_eventId.Text.Trim();
        string eventName = txt_eventName.Text.Trim();

        // Kiểm tra ô nhập liệu không được để trống
        if (eventId == "" || eventName == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ Mã sự kiện và Tên sự kiện.", "Lỗi nhập liệu");
            return;
        }

        // Kiểm tra trùng mã sự kiện bằng vòng lặp
        List<UnionEvent> curList = eventManager.GetAll();
        bool dupli = false;
        for (int i = 0; i < curList.Count; i++)
        {
            if (curList[i].EventId == eventId)
            {
                dupli = true;
                break;
            }
        }

        if (dupli)
        {
            MessageBox.Show("Mã sự kiện đã tồn tại. Vui lòng nhập mã khác.", "Lỗi trùng lặp");
            return;
        }

        UnionEvent newEvent = new UnionEvent
        {
            EventId = eventId,
            EventName = eventName,
            BonusScore = (double)num_bonusScore.Value
        };

        eventManager.Add(newEvent);
        MessageBox.Show("Thêm sự kiện thành công!", "Thành công");
        ClearEventForm();
    }

    // 3. UpdateEvent function
    private void btn_eventUpdate_Click(object sender, EventArgs e)
    {
        string eventId = txt_eventId.Text.Trim();
        string eventName = txt_eventName.Text.Trim();

        if (eventId == "" || eventName == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ Mã sự kiện và Tên sự kiện.", "Lỗi nhập liệu");
            return;
        }

        // Kiểm tra mã sự kiện có tồn tại không trước khi cập nhật
        UnionEvent oldEvent = eventManager.GetById(eventId);
        if (oldEvent == null)
        {
            MessageBox.Show("Không tìm thấy sự kiện với mã này để cập nhật.", "Lỗi");
            return;
        }

        // Giữ lại danh sách Participants gốc, chỉ cập nhật thông tin cơ bản
        UnionEvent eventUpd = new UnionEvent
        {
            EventId = eventId,
            EventName = eventName,
            BonusScore = (double)num_bonusScore.Value,
            Address = oldEvent.Address,
            Participants = oldEvent.Participants
        };

        eventManager.Update(eventUpd);
        MessageBox.Show("Cập nhật sự kiện thành công!", "Thành công");
        ClearEventForm();
    }

    private void dgv_events_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow lineSel = dgv_event.Rows[e.RowIndex];

        txt_eventId.Text = lineSel.Cells["EventId"].Value.ToString();
        txt_eventName.Text = lineSel.Cells["EventName"].Value.ToString();
        num_bonusScore.Value = Convert.ToDecimal(lineSel.Cells["BonusScore"].Value);
    }

    // 4. DeleteEvent function
    private void btn_eventDelete_Click(object sender, EventArgs e)
    {
        string eventId = txt_eventId.Text.Trim();

        if (eventId == "")
        {
            MessageBox.Show("Vui lòng chọn một sự kiện từ danh sách để xóa.", "Lỗi");
            return;
        }

        DialogResult acp = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa sự kiện có mã '" + eventId + "' không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (acp == DialogResult.Yes)
        {
            eventManager.Delete(eventId);
            MessageBox.Show("Xóa sự kiện thành công!", "Thành công");
            ClearEventForm();
        }
    }

    // 5. SearchEvent function
    private void btn_eventSearch_Click(object sender, EventArgs e)
    {
        string kw = txt_eventSearch.Text.Trim();

        List<UnionEvent> result = new List<UnionEvent>();

        if (kw == "")
        {
            result = eventManager.GetAll();
        }
        else
        {
            result = eventManager.Search(kw);
        }

        dgv_event.DataSource = null;
        dgv_event.DataSource = result;

        if (dgv_event.Columns["Address"] != null)
            dgv_event.Columns["Address"].Visible = false;
        if (dgv_event.Columns["Participants"] != null)
            dgv_event.Columns["Participants"].Visible = false;
        if (dgv_event.Columns["EventId"] != null)
            dgv_event.Columns["EventId"].HeaderText = "Mã Sự Kiện";
        if (dgv_event.Columns["EventName"] != null)
            dgv_event.Columns["EventName"].HeaderText = "Tên Sự Kiện";
        if (dgv_event.Columns["BonusScore"] != null)
            dgv_event.Columns["BonusScore"].HeaderText = "Điểm Cộng";

        if (kw != "" && result.Count == 0)
            MessageBox.Show("Không tìm thấy sự kiện nào phù hợp.", "Thông báo");
    }

    // 6. ClearEventForm function
    private void ClearEventForm()
    {
        txt_eventId.Text = "";
        txt_eventName.Text = "";
        num_bonusScore.Value = 0;
    }


    private void txt_eventId_TextChanged(object sender, EventArgs e)
    {
    }

    private void label9_Click(object sender, EventArgs e)
    {
    }

    private void label12_Click(object sender, EventArgs e)
    {
    }

    private void label13_Click(object sender, EventArgs e)
    {
    }

    private void label9_Click_1(object sender, EventArgs e)
    {
    }

    // 1. LoadClubData function
    private void LoadClubData()
    {
        List<Club> list = clubManager.GetAll();

        dgv_club.DataSource = null;
        dgv_club.DataSource = list;

        // Customize column header
        if (dgv_club.Columns.Count > 0)
        {
            if (dgv_club.Columns["ClubId"] != null)
                dgv_club.Columns["ClubId"].HeaderText = "Mã CLB";

            if (dgv_club.Columns["ClubName"] != null)
                dgv_club.Columns["ClubName"].HeaderText = "Tên CLB";

            if (dgv_club.Columns["FoundedDate"] != null)
                dgv_club.Columns["FoundedDate"].HeaderText = "Ngày thành lập";

            if (dgv_club.Columns["MemberCount"] != null)
                dgv_club.Columns["MemberCount"].HeaderText = "Số thành viên";
        }
    }
    
    // 2. AddClub function
    private void btn_clubAdd_Click(object sender, EventArgs e)
    {
        string clubId = txt_clubId.Text.Trim();
        string clubName = txt_clubName.Text.Trim();

        if (clubId == "" || clubName == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin CLB.");
            return;
        }

        // Check duplicate
        List<Club> list = clubManager.GetAll();
        foreach (Club clb in list)
        {
            if (clb.ClubId == clubId)
            {
                MessageBox.Show("Mã CLB đã tồn tại.");
                return;
            }
        }

        Club club = new Club
        {
            ClubId = clubId,
            ClubName = clubName,
            FoundedDate = dtp_foundedDate.Value,
            MemberCount = (int)num_memberCount.Value
        };

        clubManager.Add(club);

        MessageBox.Show("Thêm CLB thành công!");

        ClearClubForm();
    }
    
    // 3. UpdateClub function
    private void btn_clubUpdate_Click(object sender, EventArgs e)
    {
        string clubId = txt_clubId.Text.Trim();

        if (clubId == "")
        {
            MessageBox.Show("Vui lòng chọn CLB để cập nhật.");
            return;
        }

        Club club = clubManager.GetById(clubId);

        if (club == null)
        {
            MessageBox.Show("Không tìm thấy CLB.");
            return;
        }

        club.ClubName = txt_clubName.Text;
        club.FoundedDate = dtp_foundedDate.Value;
        club.MemberCount = (int)num_memberCount.Value;

        clubManager.Update(club);

        MessageBox.Show("Cập nhật thành công!");

        ClearClubForm();
    }
    
    // 4. DeleteClub function
    private void btn_clubDelete_Click(object sender, EventArgs e)
    {
        string clubId = txt_clubId.Text.Trim();

        if (clubId == "")
        {
            MessageBox.Show("Vui lòng chọn CLB để xóa.");
            return;
        }

        DialogResult confirm = MessageBox.Show(
            "Bạn có chắc muốn xóa CLB này?",
            "Xác nhận",
            MessageBoxButtons.YesNo
        );

        if (confirm == DialogResult.Yes)
        {
            clubManager.Delete(clubId);

            MessageBox.Show("Xóa thành công!");

            ClearClubForm();
        }
    }
    
    // 5. SearchClub function
    private void btn_clubSearch_Click(object sender, EventArgs e)
    {
        string keyword = txt_clubSearch.Text.Trim();

        List<Club> result;

        if (keyword == "")
            result = clubManager.GetAll();
        else
            result = clubManager.Search(keyword);

        dgv_club.DataSource = null;
        dgv_club.DataSource = result;

        if (keyword != "" && result.Count == 0)
            MessageBox.Show("Không tìm thấy CLB.");
    }
    // 6. dgvClub CellClick
    private void dgv_club_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        DataGridViewRow row = dgv_club.Rows[e.RowIndex];

        txt_clubId.Text = row.Cells["ClubId"].Value?.ToString();
        txt_clubName.Text = row.Cells["ClubName"].Value?.ToString();

        if (row.Cells["FoundedDate"].Value != null)
            dtp_foundedDate.Value = Convert.ToDateTime(row.Cells["FoundedDate"].Value);

        if (row.Cells["MemberCount"].Value != null)
            num_memberCount.Value = Convert.ToInt32(row.Cells["MemberCount"].Value);
    }
    // 7. ClearClubForm
    private void ClearClubForm()
    {
        txt_clubId.Text = "";
        txt_clubName.Text = "";
        dtp_foundedDate.Value = DateTime.Now;
        num_memberCount.Value = 0;
    }
    
    /* ========= TAB 4: Reward Management ========*/
    // Class phụ trợ để chứa dữ liệu an toàn cho ComboBox
    public class StudentComboItem
    {
        public string Id { get; set; }
        public string DisplayText { get; set; }
    }

    // 1. Hàm gộp dữ liệu Sinh viên & Cán bộ vào ComboBox
    private void LoadStudentAndOfficialToComboBox()
    {
        List<StudentComboItem> getterList = new List<StudentComboItem>();

        foreach (Student st in studentManager.GetAll())
        {
            getterList.Add(new StudentComboItem
            {
                Id = st.StudentId,
                DisplayText = st.StudentId + " - " + st.FullName + " (st)"
            });
        }

        foreach (Official off in officialManager.GetAll())
        {
            getterList.Add(new StudentComboItem
            {
                Id = off.StudentId,
                DisplayText = off.StudentId + " - " + off.FullName + " (CB)"
            });
        }

        cbo_studentId.DataSource = getterList;
        cbo_studentId.DisplayMember = "DisplayText";
        cbo_studentId.ValueMember = "Id";
    }

    // 2. LoadRewardData function
    private void LoadRewardData()
    {
        var displayList = rewardManager.GetAll().Select(r => {
            string studentName = "Không xác định";
            var st = studentManager.GetById(r.StudentId);
            if (st != null) studentName = st.FullName;
            else {
                var off = officialManager.GetById(r.StudentId);
                if (off != null) studentName = off.FullName;
            }

            return new {
                r.RewardId,
                r.RewardName,
                r.IssueDate,
                r.StudentId,
                StudentName = studentName
            };
        }).ToList();

        dgv_reward.DataSource = null;
        dgv_reward.DataSource = displayList;

        if (dgv_reward.Columns.Count > 0)
        {
            dgv_reward.Columns["RewardId"].HeaderText = "Mã KT";
            dgv_reward.Columns["RewardName"].HeaderText = "Tên Khen thưởng";
            dgv_reward.Columns["IssueDate"].HeaderText = "Ngày QĐ";
            dgv_reward.Columns["StudentId"].HeaderText = "Mã SV/CB";
            dgv_reward.Columns["StudentName"].HeaderText = "Họ Tên Người nhận";
        }
    }

    // 3. AddReward function
    private void btn_rewardAdd_Click(object sender, EventArgs e)
    {
        string rewId = txt_rewardId.Text.Trim();
        string rewName = txt_rewardName.Text.Trim();

        if (cbo_studentId.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn Sinh viên/Cán bộ nhận thưởng.", "Thông báo");
            return;
        }
        string studentId = cbo_studentId.SelectedValue.ToString();

        if (rewId == "" || rewName == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên khen thưởng.", "Thông báo");
            return;
        }

        if (rewardManager.GetById(rewId) != null)
        {
            MessageBox.Show("Mã Khen thưởng đã tồn tại.", "Lỗi");
            return;
        }

        Reward newReward = new Reward
        {
            RewardId = rewId,
            RewardName = rewName,
            IssueDate = dtp_issuedate.Value,
            StudentId = studentId
        };

        rewardManager.Add(newReward);

        MessageBox.Show("Thêm Khen thưởng thành công!", "Thành công");
        ClearRewardForm();
    }

    // 4. UpdateReward function
    private void btn_rewardUpdate_Click(object sender, EventArgs e)
    {
        string rewId = txt_rewardId.Text.Trim();

        if (rewId == "")
        {
            MessageBox.Show("Vui lòng chọn Khen thưởng để cập nhật.", "Thông báo");
            return;
        }

        Reward rew = rewardManager.GetById(rewId);

        if (rew == null)
        {
            MessageBox.Show("Không tìm thấy mã Khen thưởng này trong hệ thống.", "Lỗi");
            return;
        }

        rew.RewardName = txt_rewardName.Text.Trim();
        rew.IssueDate = dtp_issuedate.Value;
        if (cbo_studentId.SelectedValue != null)
        {
            rew.StudentId = cbo_studentId.SelectedValue.ToString();
        }

        rewardManager.Update(rew);

        MessageBox.Show("Cập nhật thành công!", "Thành công");
        ClearRewardForm();
    }

    // 5. DeleteReward function
    private void btn_rewardDelete_Click(object sender, EventArgs e)
    {
        string rewId = txt_rewardId.Text.Trim();

        if (rewId == "")
        {
            MessageBox.Show("Vui lòng chọn Khen thưởng để xóa.", "Thông báo");
            return;
        }

        DialogResult confirm = MessageBox.Show(
            "Bạn có chắc muốn xóa quyết định khen thưởng này?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (confirm == DialogResult.Yes)
        {
            rewardManager.Delete(rewId);
            MessageBox.Show("Xóa thành công!", "Thành công");
            ClearRewardForm();
        }
    }

    // 6. SearchReward function
    private void btn_rewardSearch_Click(object sender, EventArgs e)
    {
        string keyword = txt_rewardSearch.Text.Trim();
        List<Reward> result;

        if (keyword == "")
            result = rewardManager.GetAll();
        else
            result = rewardManager.Search(keyword);

        var displayList = result.Select(r => {
            string studentName = "Không xác định";
            var st = studentManager.GetById(r.StudentId);
            if (st != null) studentName = st.FullName;
            else {
                var off = officialManager.GetById(r.StudentId);
                if (off != null) studentName = off.FullName;
            }

            return new {
                r.RewardId,
                r.RewardName,
                r.IssueDate,
                r.StudentId,
                StudentName = studentName
            };
        }).ToList();

        dgv_reward.DataSource = null;
        dgv_reward.DataSource = displayList;

        if (dgv_reward.Columns.Count > 0)
        {
            dgv_reward.Columns["RewardId"].HeaderText = "Mã KT";
            dgv_reward.Columns["RewardName"].HeaderText = "Tên Khen thưởng";
            dgv_reward.Columns["IssueDate"].HeaderText = "Ngày QĐ";
            dgv_reward.Columns["StudentId"].HeaderText = "Mã SV/CB";
            dgv_reward.Columns["StudentName"].HeaderText = "Họ Tên Người nhận";
        }

        if (keyword != "" && displayList.Count == 0)
            MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo");
    }

    // 7. dgvReward CellClick (Đẩy dữ liệu từ Grid lên Form)
    private void dgv_reward_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return; 

        DataGridViewRow row = dgv_reward.Rows[e.RowIndex];

        txt_rewardId.Text = row.Cells["RewardId"].Value?.ToString();
        txt_rewardName.Text = row.Cells["RewardName"].Value?.ToString();

        if (row.Cells["IssueDate"].Value != null)
            dtp_issuedate.Value = Convert.ToDateTime(row.Cells["IssueDate"].Value);

        if (row.Cells["StudentId"].Value != null)
            cbo_studentId.SelectedValue = row.Cells["StudentId"].Value.ToString();
    }

    // 8. Hàm làm sạch Form
    private void ClearRewardForm()
    {
        txt_rewardId.Text = "";
        txt_rewardName.Text = "";
        dtp_issuedate.Value = DateTime.Now;
        if (cbo_studentId.Items.Count > 0)
            cbo_studentId.SelectedIndex = 0;
    }

    private void btn_rewardUpdate_Click_1(object sender, EventArgs e)
    {
    }

    /* ========= TAB KHOA ========*/
    private void btn_facultyAdd_Click(object sender, EventArgs e)
    {
        Faculty fac = new Faculty
        {
            FacultyId = txt_facultyId.Text,
            FacultyName = txt_facultyName.Text,
            DeanName = txt_deanName.Text
        };
        facultyManager.Add(fac);
        ClearFacultyForm();
        MessageBox.Show("Thêm khoa thành công!");
    }

    private void btn_facultyUpdate_Click(object sender, EventArgs e)
    {
        Faculty fac = new Faculty
        {
            FacultyId = txt_facultyId.Text,
            FacultyName = txt_facultyName.Text,
            DeanName = txt_deanName.Text
        };
        facultyManager.Update(fac);
        MessageBox.Show("Cập nhật khoa thành công!");
    }

    private void btn_facultyDelete_Click(object sender, EventArgs e)
    {
        string id = txt_facultyId.Text;
        if (!string.IsNullOrEmpty(id))
        {
            facultyManager.Delete(id);
            ClearFacultyForm();
            MessageBox.Show("Xóa khoa thành công!");
        }
    }

    private void btn_facultySearch_Click(object sender, EventArgs e)
    {
        string keyword = txt_facultySearch.Text;
        var result = facultyManager.Search(keyword);
        dgv_faculty.DataSource = null;
        dgv_faculty.DataSource = result;
    }

    private void dgv_faculty_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgv_faculty.Rows[e.RowIndex];
            txt_facultyId.Text = row.Cells["FacultyId"].Value?.ToString();
            txt_facultyName.Text = row.Cells["FacultyName"].Value?.ToString();
            txt_deanName.Text = row.Cells["DeanName"].Value?.ToString();
        }
    }

    private void ClearFacultyForm()
    {
        txt_facultyId.Clear();
        txt_facultyName.Clear();
        txt_deanName.Clear();
    }

    // 2. AddLecturer function
    private void btn_lecturerAdd_Click(object sender, EventArgs e)
    {
        string id = txt_lecturerId.Text.Trim();
        string name = txt_lecturerName.Text.Trim();
        if (id == "" || name == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên giảng viên!");
            return;
        }

        Lecturer l = new Lecturer
        {
            LecturerId = id,
            FullName = name,
            BirthYear = (int)nud_lecturerBirthYear.Value,
            Department = "" // Cần thêm TextBox cho Department vào Designer nếu muốn nhập
        };
        lecturerManager.Add(l);
        ClearLecturerForm();
        MessageBox.Show("Thêm giảng viên thành công!");
    }

    // 3. UpdateLecturer function
    private void btn_lecturerUpdate_Click(object sender, EventArgs e)
    {
        string id = txt_lecturerId.Text.Trim();
        if (id == "")
        {
            MessageBox.Show("Vui lòng chọn giảng viên cần cập nhật!");
            return;
        }

        Lecturer l = lecturerManager.GetById(id);
        if (l != null)
        {
            l.FullName = txt_lecturerName.Text;
            l.BirthYear = (int)nud_lecturerBirthYear.Value;
            // l.Department = ... (tương tự)
            lecturerManager.Update(l);
            MessageBox.Show("Cập nhật giảng viên thành công!");
        }
    }

    // 4. DeleteLecturer function
    private void btn_lecturerDelete_Click(object sender, EventArgs e)
    {
        string id = txt_lecturerId.Text.Trim();
        if (id != "")
        {
            lecturerManager.Delete(id);
            ClearLecturerForm();
            MessageBox.Show("Xóa giảng viên thành công!");
        }
    }

    // 5. SearchLecturer function
    private void btn_lecturerSearch_Click(object sender, EventArgs e)
    {
        string keyword = txt_lecturerSearch.Text;
        var result = lecturerManager.Search(keyword);
        dgv_lecturer.DataSource = null;
        dgv_lecturer.DataSource = result;
    }

    // 6. dgvLecturer CellClick
    private void dgv_lecturer_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgv_lecturer.Rows[e.RowIndex];
            txt_lecturerId.Text = row.Cells["LecturerId"].Value?.ToString();
            txt_lecturerName.Text = row.Cells["FullName"].Value?.ToString();
            if (row.Cells["BirthYear"].Value != null)
                nud_lecturerBirthYear.Value = Convert.ToInt32(row.Cells["BirthYear"].Value);
        }
    }

    // 7. ClearLecturerForm function
    private void ClearLecturerForm()
    {
        txt_lecturerId.Clear();
        txt_lecturerName.Clear();
        nud_lecturerBirthYear.Value = 1980;
    }

    /* ========= TAB ĐIỂM DANH (Participation) ========*/
    // 1. LoadDataAttendance function
    private void LoadAttendanceData()
    {
        List<ParticipationHistory> list = FileHelper.Load<ParticipationHistory>("participants.json");
        dgv_attendance.DataSource = null;
        dgv_attendance.DataSource = list;

        if (dgv_attendance.Columns.Count > 0)
        {
            if (dgv_attendance.Columns["StudentIdReference"] != null) dgv_attendance.Columns["StudentIdReference"].HeaderText = "Mã SV";
            if (dgv_attendance.Columns["EventIdReference"] != null) dgv_attendance.Columns["EventIdReference"].HeaderText = "Mã SK";
            if (dgv_attendance.Columns["CheckInTime"] != null) dgv_attendance.Columns["CheckInTime"].HeaderText = "Thời gian";
            if (dgv_attendance.Columns["Status"] != null) dgv_attendance.Columns["Status"].HeaderText = "Trạng thái";
        }
    }

    // 2. Load combo dữ liệu cho tab điểm danh
    private void LoadStudentAndEventToComboDD()
    {
        // Load Students & Officials
        List<StudentComboItem> stList = new List<StudentComboItem>();
        foreach (var s in studentManager.GetAll()) stList.Add(new StudentComboItem { Id = s.StudentId, DisplayText = s.StudentId + " - " + s.FullName });
        foreach (var o in officialManager.GetAll()) stList.Add(new StudentComboItem { Id = o.StudentId, DisplayText = o.StudentId + " - " + o.FullName });
        cbb_studentSelect.DataSource = stList;
        cbb_studentSelect.DisplayMember = "DisplayText";
        cbb_studentSelect.ValueMember = "Id";

        // Load Events
        cbb_eventSelect.DataSource = eventManager.GetAll();
        cbb_eventSelect.DisplayMember = "EventName";
        cbb_eventSelect.ValueMember = "EventId";

        // Status combo
        cbb_status.Items.Clear();
        cbb_status.Items.Add("Có mặt");
        cbb_status.Items.Add("Vắng");
        if (cbb_status.Items.Count > 0) cbb_status.SelectedIndex = 0;
    }

    // 3. AddAttendance function
    private void btn_ddAdd_Click(object sender, EventArgs e)
    {
        if (cbb_studentSelect.SelectedValue == null || cbb_eventSelect.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Sự kiện!");
            return;
        }

        string stId = cbb_studentSelect.SelectedValue.ToString();
        string evId = cbb_eventSelect.SelectedValue.ToString();

        // Kiểm tra xem đã điểm danh chưa
        List<ParticipationHistory> list = FileHelper.Load<ParticipationHistory>("participants.json");
        if (list.Exists(x => x.StudentIdReference == stId && x.EventIdReference == evId))
        {
            MessageBox.Show("Sinh viên này đã được điểm danh trong sự kiện này!");
            return;
        }

        ParticipationHistory ph = new ParticipationHistory
        {
            StudentIdReference = stId,
            EventIdReference = evId,
            CheckInTime = dtp_checkIn.Value,
            Status = cbb_status.SelectedItem?.ToString() ?? "Có mặt"
        };

        // Dùng EventManager để cộng điểm rèn luyện
        Student st = (Student)studentManager.GetById(stId) ?? officialManager.GetById(stId);
        if (st != null)
        {
            eventManager.AddParticipation(ph, st);
            LoadAttendanceData();
            MessageBox.Show("Điểm danh và cộng điểm rèn luyện thành công!");
        }
        else
        {
            MessageBox.Show("Không tìm thấy thông tin sinh viên!");
        }
    }

    // 4. UpdateAttendance function (button1)
    private void btn_ddUpdate_Click(object sender, EventArgs e)
    {
        if (dgv_attendance.CurrentRow == null)
        {
            MessageBox.Show("Vui lòng chọn một dòng điểm danh để cập nhật!", "Thông báo");
            return;
        }

        if (cbb_studentSelect.SelectedValue == null || cbb_eventSelect.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn Sinh viên và Sự kiện!", "Thông báo");
            return;
        }

        string studentId = cbb_studentSelect.SelectedValue.ToString();
        string eventId = cbb_eventSelect.SelectedValue.ToString();
        DateTime checkInTime = dtp_checkIn.Value;
        string status = cbb_status.SelectedItem?.ToString() ?? "Có mặt";

        List<ParticipationHistory> list = FileHelper.Load<ParticipationHistory>("participants.json");

        var existing = list.FirstOrDefault(x => 
            x.StudentIdReference == studentId && x.EventIdReference == eventId);

        if (existing != null)
        {
            existing.CheckInTime = checkInTime;
            existing.Status = status;

            FileHelper.Save<ParticipationHistory>("participants.json", list);

            MessageBox.Show("Cập nhật điểm danh thành công!", "Thành công");
            LoadAttendanceData();
        }
        else
        {
            MessageBox.Show("Không tìm thấy bản ghi điểm danh để cập nhật!", "Lỗi");
        }
    }

    // 5. DeleteAttendance function (button2)
    private void btn_ddDelete_Click(object sender, EventArgs e)
    {
        if (dgv_attendance.CurrentRow == null) return;
        
        string stId = dgv_attendance.CurrentRow.Cells["StudentIdReference"].Value?.ToString();
        string evId = dgv_attendance.CurrentRow.Cells["EventIdReference"].Value?.ToString();

        if (stId != null && evId != null)
        {
            Student st = (Student)studentManager.GetById(stId) ?? officialManager.GetById(stId);
            if (st != null)
            {
                eventManager.DeleteParticipation(stId, evId, st);
                LoadAttendanceData();
                MessageBox.Show("Đã xóa điểm danh và trừ điểm rèn luyện!");
            }
        }
    }

    // 6. SearchAttendance function
    private void btn_ddSearch_Click(object sender, EventArgs e)
    {
        string kw = txt_ddSearch.Text.Trim().ToLower();
        List<ParticipationHistory> list = FileHelper.Load<ParticipationHistory>("participants.json");
        var result = list.FindAll(x => x.StudentIdReference.ToLower().Contains(kw) || x.EventIdReference.ToLower().Contains(kw));
        dgv_attendance.DataSource = null;
        dgv_attendance.DataSource = result;
    }

    // 7. dgvAttendance CellClick
    private void dgv_attendance_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dgv_attendance.Rows[e.RowIndex];
            cbb_studentSelect.SelectedValue = row.Cells["StudentIdReference"].Value;
            cbb_eventSelect.SelectedValue = row.Cells["EventIdReference"].Value;
            dtp_checkIn.Value = Convert.ToDateTime(row.Cells["CheckInTime"].Value);
            cbb_status.SelectedItem = row.Cells["Status"].Value?.ToString();
        }
    }
}