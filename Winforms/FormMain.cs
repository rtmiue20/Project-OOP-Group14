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
}