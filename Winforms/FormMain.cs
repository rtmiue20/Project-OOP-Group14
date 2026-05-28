using QLDH.Entities;
using QLDH.Service;

namespace Quản_lý_đoàn_hội;

public partial class FormMain : Form
{
    private StudentManager studentManager = new StudentManager();
    private OfficialManager officialManager = new OfficialManager();
    
    public FormMain()
    {
        InitializeComponent();
        dgv_student.CellClick += dgv_student_CellClick;
        btn_studentUpdate.Click += btnStudentUpdate_Click;
        this.dgv_event.CellClick += new DataGridViewCellEventHandler(this.dgv_events_CellClick);
        this.btn_eventSearch.Click += new EventHandler(this.btn_eventSearch_Click);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        LoadStudentData();  // Tab 1 
        LoadEventData();    // Tab 2 
    }
    
    /* ========= TAB 1: Sinh viên & Đoàn viên ========*/
    // 1. LoadData function
    private void LoadStudentData()
    {
        var allStudents = new List<Student>();
        allStudents.AddRange(studentManager.GetAll());
        allStudents.AddRange(officialManager.GetAll());
    
        dgv_student.DataSource = null;
        dgv_student.DataSource = allStudents;
    
        // Tùy chỉnh cột hiển thị cho đẹp
        dgv_student.Columns["StudentId"].HeaderText = "Mã SV";
        dgv_student.Columns["FullName"].HeaderText = "Họ Tên";
        dgv_student.Columns["ClassName"].HeaderText = "Lớp";
        dgv_student.Columns["TrainingScore"].HeaderText = "Điểm RL";
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
                TrainingScore = 0 // Mặc định mới
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
        LoadStudentData();
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
            var off = officialManager.GetById(id);
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
            var st = studentManager.GetById(id);
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
                var off = officialManager.GetById(id);
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
        LoadStudentData();
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
            var studentId = txt_studentId.Text;
            var off = officialManager.GetById(studentId);
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
    
        // Thử xóa ở cả 2 manager (hàm Delete đã có kiểm tra tồn tại)
        studentManager.Delete(id);
        officialManager.Delete(id);
    
        LoadStudentData();
        MessageBox.Show("Đã xóa sinh viên!");
    }
    
    // 5. SolveEvent function (Hide)
    private void chkIsOfficial_CheckedChanged(object sender, EventArgs e)
    {
        bool isOfficial = cb_isOfficial.Checked;
        txt_role.Visible = isOfficial;
        txt_term.Visible = isOfficial;
        // Bạn có thể ẩn luôn cả Label tương ứng
        lbl_role.Visible = isOfficial;
        lbl_term.Visible = isOfficial;
    }
    /* ========= TAB 2: Sự kiện ========*/
    
    // Khai báo tường minh Manager xử lý sự kiện
    private EventManager eventManager = new EventManager();

    // 1. Hàm tải dữ liệu lên DataGridView
    private void LoadEventData()
    {
        List<UnionEvent> danhSach = eventManager.GetAll();

        dgv_event.DataSource = null;
        dgv_event.DataSource = danhSach;

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
    //addEvent Function
    private void btn_eventAdd_Click(object sender, EventArgs e)
    {
        string maSK = txt_eventId.Text.Trim();
        string tenSK = txt_eventName.Text.Trim();

        // Kiểm tra ô nhập liệu không được để trống
        if (maSK == "" || tenSK == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ Mã sự kiện và Tên sự kiện.", "Lỗi nhập liệu");
            return;
        }

        // Kiểm tra trùng mã sự kiện bằng vòng lặp
        List<UnionEvent> danhSachHienTai = eventManager.GetAll();
        bool baTrung = false;
        for (int i = 0; i < danhSachHienTai.Count; i++)
        {
            if (danhSachHienTai[i].EventId == maSK)
            {
                baTrung = true;
                break;
            }
        }

        if (baTrung)
        {
            MessageBox.Show("Mã sự kiện đã tồn tại. Vui lòng nhập mã khác.", "Lỗi trùng lặp");
            return;
        }

        UnionEvent suKienMoi = new UnionEvent
        {
            EventId    = maSK,
            EventName  = tenSK,
            BonusScore = (double)num_bonusScore.Value
        };

        eventManager.Add(suKienMoi);
        MessageBox.Show("Thêm sự kiện thành công!", "Thành công");
        ClearEventForm();
        LoadEventData();
    }
    //UpdateEvent Function
    private void btn_eventUpdate_Click(object sender, EventArgs e)
    {
        string maSK = txt_eventId.Text.Trim();
        string tenSK = txt_eventName.Text.Trim();

        if (maSK == "" || tenSK == "")
        {
            MessageBox.Show("Vui lòng nhập đầy đủ Mã sự kiện và Tên sự kiện.", "Lỗi nhập liệu");
            return;
        }

        // Kiểm tra mã sự kiện có tồn tại không trước khi cập nhật
        UnionEvent suKienCu = eventManager.GetById(maSK);
        if (suKienCu == null)
        {
            MessageBox.Show("Không tìm thấy sự kiện với mã này để cập nhật.", "Lỗi");
            return;
        }

        // Giữ lại danh sách Participants gốc, chỉ cập nhật thông tin cơ bản
        UnionEvent suKienCapNhat = new UnionEvent
        {
            EventId      = maSK,
            EventName    = tenSK,
            BonusScore   = (double)num_bonusScore.Value,
            Address      = suKienCu.Address,
            Participants = suKienCu.Participants
        };

        eventManager.Update(suKienCapNhat);
        MessageBox.Show("Cập nhật sự kiện thành công!", "Thành công");
        ClearEventForm();
        LoadEventData();
    }
    private void dgv_events_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        DataGridViewRow dongDuocChon = dgv_event.Rows[e.RowIndex];

        txt_eventId.Text         = dongDuocChon.Cells["EventId"].Value.ToString();
        txt_eventName.Text       = dongDuocChon.Cells["EventName"].Value.ToString();
        num_bonusScore.Value     = Convert.ToDecimal(dongDuocChon.Cells["BonusScore"].Value);
    }
    //DeleteEvent Function
    private void btn_eventDelete_Click(object sender, EventArgs e)
    {
        string maSK = txt_eventId.Text.Trim();

        if (maSK == "")
        {
            MessageBox.Show("Vui lòng chọn một sự kiện từ danh sách để xóa.", "Lỗi");
            return;
        }

        DialogResult xacNhan = MessageBox.Show(
            "Bạn có chắc chắn muốn xóa sự kiện có mã '" + maSK + "' không?",
            "Xác nhận xóa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        if (xacNhan == DialogResult.Yes)
        {
            eventManager.Delete(maSK);
            MessageBox.Show("Xóa sự kiện thành công!", "Thành công");
            ClearEventForm();
            LoadEventData();
        }throw new System.NotImplementedException();
    }
    //SearchEvent Funtion
    private void btn_eventSearch_Click(object sender, EventArgs e)
    {
        string tuKhoa = txt_eventSearch.Text.Trim();

        List<UnionEvent> ketQua = new List<UnionEvent>();

        if (tuKhoa == "")
        {
            ketQua = eventManager.GetAll();
        }
        else
        {
            ketQua = eventManager.Search(tuKhoa);
        }

        dgv_event.DataSource = null;
        dgv_event.DataSource = ketQua;

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

        if (tuKhoa != "" && ketQua.Count == 0)
            MessageBox.Show("Không tìm thấy sự kiện nào phù hợp.", "Thông báo");
    }
    
// Hàm tiện ích: Xóa trắng toàn bộ ô nhập liệu trên Tab Sự kiện
    private void ClearEventForm()
    {
        txt_eventId.Text     = "";
        txt_eventName.Text   = "";
        num_bonusScore.Value = 0;
    }

    
}