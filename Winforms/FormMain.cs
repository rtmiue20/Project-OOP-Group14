using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using QLDH.Entities;
using QLDH.Service;

namespace Quản_lý_đoàn_hội;

public partial class FormMain : Form
{
    private readonly StudentManager _studentManager = new();
    private readonly OfficialManager _officialManager = new();
    private readonly LecturerManager _lecturerManager = new();
    private readonly EventManager _eventManager = new();

    private sealed class EventListItem
    {
        public required string EventId { get; init; }
        public required string EventName { get; init; }
        public double BonusScore { get; init; }
        public string Display => $"{EventId} - {EventName}";
    }

    private sealed class TrainingScoreRow
    {
        public string MaDinhDanh { get; set; } = "";
        public string HoTen { get; set; } = "";
        public string LopKhoa { get; set; } = "";
        public double DiemRenLuyen { get; set; }
        public string Loai { get; set; } = "";
    }

    public FormMain()
    {
        InitializeComponent();
        Text = "Hệ thống Quản lý Đoàn Hội - UEH";
        SetupFormAppearance();
        SetupEvents();
        cbb_obj.SelectedIndex = 0;
        UpdateFieldsForHumanType();
        LoadData();
    }

    private void SetupFormAppearance()
    {
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        BackColor = Color.FromArgb(245, 247, 250);
        ForeColor = Color.FromArgb(41, 50, 65);
        QLDH.Dock = DockStyle.Fill;
        QLDH.Appearance = TabAppearance.Normal;
        QLDH.SizeMode = TabSizeMode.Normal;

        StyleTabPage(tp_QLNS);
        StyleTabPage(tp_QLSK);
        StyleTabPage(tp_GNTG);
        StyleTabPage(tp_TH);

        StyleGroupBoxes();
        StyleInputs();
        StyleButtons();

        foreach (DataGridView grid in new[] { dgv_human, dgv_event, dgv_pointsSummary, dgv_participation })
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.FromArgb(225, 230, 238);
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(61, 90, 128);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 239, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(35, 43, 57);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 253);
            grid.RowTemplate.Height = 32;
            grid.RowHeadersVisible = false;
        }

        dgv_event.AutoGenerateColumns = true;
        dgv_event.Columns.Clear();
    }

    private static void StyleTabPage(TabPage page)
    {
        page.BackColor = Color.FromArgb(245, 247, 250);
    }

    private void StyleGroupBoxes()
    {
        foreach (GroupBox group in new[] { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox9, groupBox10 })
        {
            group.BackColor = Color.White;
            group.ForeColor = Color.FromArgb(54, 62, 77);
            group.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        }

        foreach (Label label in new[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11, label12, label13, label14, label15, label16, label17, label_attendanceEvent, label_attendanceStudent, label_attendanceStatus, label_attendanceTime })
        {
            label.BackColor = Color.FromArgb(246, 248, 252);
            label.ForeColor = Color.FromArgb(58, 66, 79);
            label.BorderStyle = BorderStyle.FixedSingle;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }
    }

    private void StyleInputs()
    {
        foreach (TextBox textBox in new[] { txt_humanId, txt_fullName, txt_birthYear, txt_houseNum, txt_street, txt_district, txt_class, txt_role, txt_term, txt_search, txt_eventID, txt_eventName, txt_bonusScore, txt_eventAddress, txt_eventSearch, txt_attendanceStudentId, txt_attendanceStatus, txt_SearchHumanId })
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.FromArgb(31, 38, 52);
            textBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }

        foreach (ComboBox combo in new[] { cbb_obj, cbb_attendanceEvent })
        {
            combo.FlatStyle = FlatStyle.Flat;
            combo.BackColor = Color.White;
            combo.ForeColor = Color.FromArgb(31, 38, 52);
            combo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }

        dtp_checkIn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        dtp_checkIn.CalendarMonthBackground = Color.White;
    }

    private void StyleButtons()
    {
        foreach (Button btn in new[] { btn_humanAdd, btn_humanUpdate, btn_humanDelete, btn_humanSearch, btn_eventAdd, btn_eventUpdate, btn_eventDelete, btn_eventSearch, btn_attendanceAdd, btn_attendanceRefresh, btn_attendanceRemove, btn_pointSearch, button1, btn_excelOut })
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(61, 90, 128);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btn.Cursor = Cursors.Hand;
        }

        btn_humanDelete.BackColor = Color.FromArgb(190, 65, 72);
        btn_eventDelete.BackColor = Color.FromArgb(190, 65, 72);
        btn_attendanceRemove.BackColor = Color.FromArgb(190, 65, 72);
        btn_excelOut.BackColor = Color.FromArgb(44, 126, 81);
    }

    private void SetupEvents()
    {
        cbb_obj.SelectedIndexChanged += (_, _) =>
        {
            UpdateFieldsForHumanType();
            LoadData();
        };

        QLDH.SelectedIndexChanged += QLDH_SelectedIndexChanged;

        btn_humanAdd.Click += btn_humanAdd_Click;
        btn_humanUpdate.Click += btn_humanUpdate_Click;
        btn_humanDelete.Click += btn_humanDelete_Click;
        btn_humanSearch.Click += btn_humanSearch_Click;
        dgv_human.CellClick += dgv_human_CellClick;

        btn_eventAdd.Click += btn_eventAdd_Click;
        btn_eventUpdate.Click += btn_eventUpdate_Click;
        btn_eventDelete.Click += btn_eventDelete_Click;
        btn_eventSearch.Click += btn_eventSearch_Click;
        dgv_event.CellClick += dgv_event_CellClick;

        btn_pointSearch.Click += BtnPointSearch_Click;
        button1.Click += BtnLoadAllTrainingScores_Click;
        btn_excelOut.Click += BtnExportScores_Click;

        cbb_attendanceEvent.SelectedIndexChanged += (_, _) => LoadParticipationGrid();
        btn_attendanceAdd.Click += BtnAttendanceAdd_Click;
        btn_attendanceRefresh.Click += (_, _) => LoadParticipationGrid();
        btn_attendanceRemove.Click += BtnAttendanceRemove_Click;
    }

    private void QLDH_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (QLDH.SelectedTab == tp_QLSK)
            LoadEventData();
        else if (QLDH.SelectedTab == tp_GNTG)
            LoadAttendanceEvents();
        else if (QLDH.SelectedTab == tp_TH)
            BtnLoadAllTrainingScores_Click(sender, e);
    }

    private void UpdateFieldsForHumanType()
    {
        string? type = cbb_obj.SelectedItem?.ToString();
        bool isOfficial = type == "Cán bộ Đoàn";
        bool isLecturer = type == "Giảng viên";

        label10.Text = isLecturer ? "Khoa:" : "Lớp/Khoa:";
        label8.Enabled = isOfficial;
        label9.Enabled = isOfficial;
        txt_role.Enabled = isOfficial;
        txt_term.Enabled = isOfficial;

        if (!isOfficial)
        {
            txt_role.Clear();
            txt_term.Clear();
        }
    }

    private void LoadData()
    {
        try
        {
            string? type = cbb_obj.SelectedItem?.ToString();
            dgv_human.DataSource = null;

            if (type == "Sinh viên")
                dgv_human.DataSource = _studentManager.GetAll();
            else if (type == "Cán bộ Đoàn")
                dgv_human.DataSource = _officialManager.GetAll();
            else if (type == "Giảng viên")
                dgv_human.DataSource = _lecturerManager.GetAll();

            FormatHumanGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void FormatHumanGrid()
    {
        if (dgv_human.Columns.Contains("ResidentAddress"))
            dgv_human.Columns["ResidentAddress"].Visible = false;

        SetHeader(dgv_human, "StudentId", "Mã SV/GV");
        SetHeader(dgv_human, "LecturerId", "Mã GV");
        SetHeader(dgv_human, "FullName", "Họ và tên");
        SetHeader(dgv_human, "BirthYear", "Năm sinh");
        SetHeader(dgv_human, "ClassName", "Lớp");
        SetHeader(dgv_human, "Department", "Khoa");
        SetHeader(dgv_human, "TrainingScore", "Điểm rèn luyện");
        SetHeader(dgv_human, "Role", "Chức vụ");
        SetHeader(dgv_human, "Term", "Nhiệm kỳ");
    }

    private static void SetHeader(DataGridView grid, string columnName, string header)
    {
        if (grid.Columns.Contains(columnName))
            grid.Columns[columnName].HeaderText = header;
    }

    private void dgv_human_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        DataGridViewRow row = dgv_human.Rows[e.RowIndex];
        string? type = cbb_obj.SelectedItem?.ToString();

        if (row.DataBoundItem is Human human)
        {
            txt_fullName.Text = human.FullName;
            txt_birthYear.Text = human.BirthYear.ToString();

            if (human is Student student)
                txt_humanId.Text = student.StudentId;
            else if (human is Lecturer lecturer)
                txt_humanId.Text = lecturer.LecturerId;

            if (human.ResidentAddress != null)
            {
                txt_houseNum.Text = human.ResidentAddress.HouseNumber;
                txt_street.Text = human.ResidentAddress.Street;
                txt_district.Text = human.ResidentAddress.District;
            }
            else
            {
                txt_houseNum.Clear();
                txt_street.Clear();
                txt_district.Clear();
            }

            if (human is Student s)
            {
                txt_class.Text = s.ClassName;
                if (human is Official off)
                {
                    txt_role.Text = off.Role;
                    txt_term.Text = off.Term;
                }
            }
            else if (human is Lecturer lec)
            {
                txt_class.Text = lec.Department;
            }
        }

        if (type != "Cán bộ Đoàn")
        {
            txt_role.Clear();
            txt_term.Clear();
        }
    }

    private void btn_humanAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!TryParseBirthYear(txt_birthYear.Text, out int birthYear))
                return;

            string? type = cbb_obj.SelectedItem?.ToString();
            Address addr = new Address(txt_houseNum.Text, txt_street.Text, txt_district.Text);

            if (type == "Sinh viên")
            {
                _studentManager.Add(new Student
                {
                    StudentId = txt_humanId.Text.Trim(),
                    FullName = txt_fullName.Text.Trim(),
                    BirthYear = birthYear,
                    ClassName = txt_class.Text.Trim(),
                    ResidentAddress = addr,
                    TrainingScore = 0
                });
            }
            else if (type == "Cán bộ Đoàn")
            {
                _officialManager.Add(new Official
                {
                    StudentId = txt_humanId.Text.Trim(),
                    FullName = txt_fullName.Text.Trim(),
                    BirthYear = birthYear,
                    ClassName = txt_class.Text.Trim(),
                    Role = txt_role.Text.Trim(),
                    Term = txt_term.Text.Trim(),
                    ResidentAddress = addr,
                    TrainingScore = 0
                });
            }
            else if (type == "Giảng viên")
            {
                _lecturerManager.Add(new Lecturer
                {
                    LecturerId = txt_humanId.Text.Trim(),
                    FullName = txt_fullName.Text.Trim(),
                    BirthYear = birthYear,
                    Department = txt_class.Text.Trim(),
                    ResidentAddress = addr
                });
            }

            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_humanUpdate_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!TryParseBirthYear(txt_birthYear.Text, out int birthYear))
                return;

            string? type = cbb_obj.SelectedItem?.ToString();
            Address addr = new Address(txt_houseNum.Text, txt_street.Text, txt_district.Text);

            if (type == "Sinh viên")
            {
                _studentManager.Update(new Student
                {
                    StudentId = txt_humanId.Text.Trim(),
                    FullName = txt_fullName.Text.Trim(),
                    BirthYear = birthYear,
                    ClassName = txt_class.Text.Trim(),
                    ResidentAddress = addr
                });
            }
            else if (type == "Cán bộ Đoàn")
            {
                _officialManager.Update(new Official
                {
                    StudentId = txt_humanId.Text.Trim(),
                    FullName = txt_fullName.Text.Trim(),
                    BirthYear = birthYear,
                    ClassName = txt_class.Text.Trim(),
                    Role = txt_role.Text.Trim(),
                    Term = txt_term.Text.Trim(),
                    ResidentAddress = addr
                });
            }
            else if (type == "Giảng viên")
            {
                _lecturerManager.Update(new Lecturer
                {
                    LecturerId = txt_humanId.Text.Trim(),
                    FullName = txt_fullName.Text.Trim(),
                    BirthYear = birthYear,
                    Department = txt_class.Text.Trim(),
                    ResidentAddress = addr
                });
            }

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_humanDelete_Click(object? sender, EventArgs e)
    {
        try
        {
            string? type = cbb_obj.SelectedItem?.ToString();
            string id = txt_humanId.Text.Trim();

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa mã {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (type == "Sinh viên") _studentManager.Delete(id);
            else if (type == "Cán bộ Đoàn") _officialManager.Delete(id);
            else if (type == "Giảng viên") _lecturerManager.Delete(id);

            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_humanSearch_Click(object? sender, EventArgs e)
    {
        try
        {
            string? type = cbb_obj.SelectedItem?.ToString();
            string keyword = txt_search.Text.Trim();

            if (type == "Sinh viên") dgv_human.DataSource = _studentManager.Search(keyword);
            else if (type == "Cán bộ Đoàn") dgv_human.DataSource = _officialManager.Search(keyword);
            else if (type == "Giảng viên") dgv_human.DataSource = _lecturerManager.Search(keyword);

            FormatHumanGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgv_event_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (dgv_event.Rows[e.RowIndex].DataBoundItem is not UnionEvent ev)
            return;

        txt_eventID.Text = ev.EventId;
        txt_eventName.Text = ev.EventName;
        txt_bonusScore.Text = ev.BonusScore.ToString(CultureInfo.InvariantCulture);
        txt_eventAddress.Text = ev.Address;
    }

    private void btn_eventAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!TryParseBonusScore(txt_bonusScore.Text, out double bonus))
                return;

            _eventManager.Add(new UnionEvent
            {
                EventId = txt_eventID.Text.Trim(),
                EventName = txt_eventName.Text.Trim(),
                BonusScore = bonus,
                Address = txt_eventAddress.Text.Trim()
            });

            MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEventData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadEventData()
    {
        try
        {
            dgv_event.DataSource = null;
            dgv_event.DataSource = _eventManager.GetAll();
            SetHeader(dgv_event, "EventId", "Mã sự kiện");
            SetHeader(dgv_event, "EventName", "Tên sự kiện");
            SetHeader(dgv_event, "BonusScore", "Điểm cộng");
            SetHeader(dgv_event, "Address", "Địa điểm");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tải dữ liệu sự kiện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_eventUpdate_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!TryParseBonusScore(txt_bonusScore.Text, out double bonus))
                return;

            _eventManager.Update(new UnionEvent
            {
                EventId = txt_eventID.Text.Trim(),
                EventName = txt_eventName.Text.Trim(),
                BonusScore = bonus,
                Address = txt_eventAddress.Text.Trim()
            });

            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEventData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_eventDelete_Click(object? sender, EventArgs e)
    {
        try
        {
            string id = txt_eventID.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã sự kiện để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận xóa sự kiện {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _eventManager.Delete(id);
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEventData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_eventSearch_Click(object? sender, EventArgs e)
    {
        try
        {
            dgv_event.DataSource = _eventManager.Search(txt_eventSearch.Text.Trim());
            SetHeader(dgv_event, "EventId", "Mã sự kiện");
            SetHeader(dgv_event, "EventName", "Tên sự kiện");
            SetHeader(dgv_event, "BonusScore", "Điểm cộng");
            SetHeader(dgv_event, "Address", "Địa điểm");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadAttendanceEvents()
    {
        cbb_attendanceEvent.Items.Clear();
        foreach (UnionEvent ev in _eventManager.GetAll())
        {
            cbb_attendanceEvent.Items.Add(new EventListItem
            {
                EventId = ev.EventId ?? "",
                EventName = ev.EventName ?? "",
                BonusScore = ev.BonusScore
            });
        }

        cbb_attendanceEvent.DisplayMember = "Display";
        if (cbb_attendanceEvent.Items.Count > 0)
            cbb_attendanceEvent.SelectedIndex = 0;
        else
            LoadParticipationGrid();
    }

    private EventListItem? GetSelectedAttendanceEvent()
    {
        return cbb_attendanceEvent.SelectedItem as EventListItem;
    }

    private void LoadParticipationGrid()
    {
        EventListItem? ev = GetSelectedAttendanceEvent();
        if (ev == null)
        {
            dgv_participation.DataSource = null;
            return;
        }

        dgv_participation.DataSource = _eventManager.GetParticipantsByEvent(ev.EventId);
        SetHeader(dgv_participation, "StudentIdReference", "Mã SV");
        SetHeader(dgv_participation, "EventIdReference", "Mã SK");
        SetHeader(dgv_participation, "CheckInTime", "Thời gian");
        SetHeader(dgv_participation, "Status", "Trạng thái");
    }

    private void BtnAttendanceAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            EventListItem? ev = GetSelectedAttendanceEvent();
            if (ev == null)
            {
                MessageBox.Show("Vui lòng chọn sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentId = txt_attendanceStudentId.Text.Trim();
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var history = new ParticipationHistory
            {
                StudentIdReference = studentId,
                EventIdReference = ev.EventId,
                CheckInTime = dtp_checkIn.Value,
                Status = string.IsNullOrWhiteSpace(txt_attendanceStatus.Text) ? "Có mặt" : txt_attendanceStatus.Text.Trim()
            };

            _eventManager.AddParticipation(history, ev.BonusScore);
            MessageBox.Show("Điểm danh và cộng điểm rèn luyện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadParticipationGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnAttendanceRemove_Click(object? sender, EventArgs e)
    {
        try
        {
            EventListItem? ev = GetSelectedAttendanceEvent();
            if (ev == null || dgv_participation.CurrentRow?.DataBoundItem is not ParticipationHistory row)
            {
                MessageBox.Show("Vui lòng chọn dòng tham gia cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Hủy tham gia của {row.StudentIdReference}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _eventManager.DeleteParticipation(row.StudentIdReference, row.EventIdReference, ev.BonusScore);
            MessageBox.Show("Đã hủy tham gia và trừ điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadParticipationGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private List<TrainingScoreRow> BuildAllTrainingScoreRows()
    {
        var rows = new List<TrainingScoreRow>();
        foreach (Student st in _studentManager.GetAll())
        {
            rows.Add(new TrainingScoreRow
            {
                MaDinhDanh = st.StudentId ?? "",
                HoTen = st.FullName ?? "",
                LopKhoa = st.ClassName ?? "",
                DiemRenLuyen = st.TrainingScore,
                Loai = "Sinh viên"
            });
        }

        foreach (Official off in _officialManager.GetAll())
        {
            rows.Add(new TrainingScoreRow
            {
                MaDinhDanh = off.StudentId ?? "",
                HoTen = off.FullName ?? "",
                LopKhoa = off.ClassName ?? "",
                DiemRenLuyen = off.TrainingScore,
                Loai = "Cán bộ Đoàn"
            });
        }

        return rows;
    }

    private void BindTrainingGrid(List<TrainingScoreRow> rows)
    {
        dgv_pointsSummary.DataSource = null;
        dgv_pointsSummary.DataSource = rows;
        SetHeader(dgv_pointsSummary, "MaDinhDanh", "Mã định danh");
        SetHeader(dgv_pointsSummary, "HoTen", "Họ và tên");
        SetHeader(dgv_pointsSummary, "LopKhoa", "Lớp/Khoa");
        SetHeader(dgv_pointsSummary, "DiemRenLuyen", "Điểm rèn luyện");
        SetHeader(dgv_pointsSummary, "Loai", "Loại");
    }

    private void BtnLoadAllTrainingScores_Click(object? sender, EventArgs e)
    {
        try
        {
            BindTrainingGrid(BuildAllTrainingScoreRows());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnPointSearch_Click(object? sender, EventArgs e)
    {
        try
        {
            string id = txt_SearchHumanId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                BtnLoadAllTrainingScores_Click(sender, e);
                return;
            }

            var rows = new List<TrainingScoreRow>();
            Student? st = _studentManager.GetById(id);
            if (st != null)
            {
                rows.Add(new TrainingScoreRow
                {
                    MaDinhDanh = st.StudentId ?? "",
                    HoTen = st.FullName ?? "",
                    LopKhoa = st.ClassName ?? "",
                    DiemRenLuyen = st.TrainingScore,
                    Loai = "Sinh viên"
                });
            }

            Official? off = _officialManager.GetById(id);
            if (off != null)
            {
                rows.Add(new TrainingScoreRow
                {
                    MaDinhDanh = off.StudentId ?? "",
                    HoTen = off.FullName ?? "",
                    LopKhoa = off.ClassName ?? "",
                    DiemRenLuyen = off.TrainingScore,
                    Loai = "Cán bộ Đoàn"
                });
            }

            if (rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sinh viên / cán bộ đoàn với mã này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BindTrainingGrid(rows);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnExportScores_Click(object? sender, EventArgs e)
    {
        if (dgv_pointsSummary.Rows.Count == 0)
        {
            MessageBox.Show("Không có dữ liệu để xuất. Hãy bấm \"Tổng điểm rèn luyện\" hoặc \"Tìm\" trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new SaveFileDialog
        {
            Filter = "CSV (*.csv)|*.csv",
            FileName = $"DiemRenLuyen_{DateTime.Now:yyyyMMdd_HHmm}.csv"
        };

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        var sb = new StringBuilder();
        var headers = new List<string>();
        foreach (DataGridViewColumn col in dgv_pointsSummary.Columns)
        {
            if (col.Visible)
                headers.Add(col.HeaderText);
        }
        sb.AppendLine(string.Join(",", headers));

        foreach (DataGridViewRow row in dgv_pointsSummary.Rows)
        {
            if (row.IsNewRow) continue;
            var cells = new List<string>();
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.OwningColumn.Visible)
                    cells.Add(EscapeCsv(cell.Value?.ToString() ?? ""));
            }
            sb.AppendLine(string.Join(",", cells));
        }

        File.WriteAllText(dialog.FileName, sb.ToString(), Encoding.UTF8);
        MessageBox.Show($"Đã xuất file:\n{dialog.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static string EscapeCsv(string value)
    {
        if (value.Contains('"') || value.Contains(',') || value.Contains('\n'))
            return $"\"{value.Replace("\"", "\"\"")}\"";
        return value;
    }

    private bool TryParseBirthYear(string text, out int year)
    {
        if (int.TryParse(text, out year) && year >= 1950 && year <= DateTime.Now.Year)
            return true;

        MessageBox.Show("Năm sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        year = 0;
        return false;
    }

    private static bool TryParseBonusScore(string text, out double score)
    {
        if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out score) ||
            double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out score))
        {
            if (score >= 0) return true;
        }

        MessageBox.Show("Điểm cộng rèn luyện phải là số >= 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        score = 0;
        return false;
    }
}
