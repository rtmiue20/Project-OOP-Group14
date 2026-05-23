using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QLDH.Entities;
using QLDH.Service;

namespace Quản_lý_đoàn_hội;

public partial class FormMain : Form
{
    private readonly StudentManager _studentManager = new();
    private readonly OfficialManager _officialManager = new();
    private readonly LecturerManager _lecturerManager = new();

    public FormMain()
    {
        InitializeComponent();
        SetupEvents();
        cbb_obj.SelectedIndex = 0; // Mặc định chọn Sinh viên
        LoadData();
    }

    private void SetupEvents()
    {
        cbb_obj.SelectedIndexChanged += (s, e) => LoadData();
        btn_humanAdd.Click += btn_humanAdd_Click;
        btn_humanUpdate.Click += btn_humanUpdate_Click;
        btn_humanDelete.Click += btn_humanDelete_Click;
        btn_humanSearch.Click += btn_humanSearch_Click;
        dgv_human.CellClick += dgv_human_CellClick;
    }

    private void LoadData()
    {
        try
        {
            string type = cbb_obj.SelectedItem?.ToString();
            dgv_human.DataSource = null;

            if (type == "Sinh viên")
                dgv_human.DataSource = _studentManager.GetAll();
            else if (type == "Cán bộ Đoàn")
                dgv_human.DataSource = _officialManager.GetAll();
            else if (type == "Giảng viên")
                dgv_human.DataSource = _lecturerManager.GetAll();

            FormatDataGridView();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
        }
    }

    private void FormatDataGridView()
    {
        if (dgv_human.Columns.Contains("ResidentAddress"))
            dgv_human.Columns["ResidentAddress"].Visible = false;
    }

    private void dgv_human_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        DataGridViewRow row = dgv_human.Rows[e.RowIndex];

        txt_humanId.Text = row.Cells[0].Value?.ToString();
        txt_fullName.Text = row.Cells["FullName"].Value?.ToString();
        txt_birthYear.Text = row.Cells["BirthYear"].Value?.ToString();

        string type = cbb_obj.SelectedItem?.ToString();
        
        // Load địa chỉ
        Human human = row.DataBoundItem as Human;
        if (human?.ResidentAddress != null)
        {
            txt_houseNum.Text = human.ResidentAddress.HouseNumber;
            txt_street.Text = human.ResidentAddress.Street;
            txt_district.Text = human.ResidentAddress.District;
        }

        if (type == "Sinh viên" || type == "Cán bộ Đoàn")
        {
            txt_class.Text = row.Cells["ClassName"].Value?.ToString();
        }
        else if (type == "Giảng viên")
        {
            txt_class.Text = row.Cells["Department"].Value?.ToString();
        }

        if (type == "Cán bộ Đoàn")
        {
            txt_role.Text = row.Cells["Role"].Value?.ToString();
            txt_term.Text = row.Cells["Term"].Value?.ToString();
        }
        else
        {
            txt_role.Clear();
            txt_term.Clear();
        }
    }

    private void btn_humanAdd_Click(object sender, EventArgs e)
    {
        try
        {
            string type = cbb_obj.SelectedItem?.ToString();
            Address addr = new Address(txt_houseNum.Text, txt_street.Text, txt_district.Text);

            if (type == "Sinh viên")
            {
                Student st = new Student
                {
                    StudentId = txt_humanId.Text,
                    FullName = txt_fullName.Text,
                    BirthYear = int.Parse(txt_birthYear.Text),
                    ClassName = txt_class.Text,
                    ResidentAddress = addr,
                    TrainingScore = 0
                };
                _studentManager.Add(st);
            }
            else if (type == "Cán bộ Đoàn")
            {
                Official off = new Official
                {
                    StudentId = txt_humanId.Text,
                    FullName = txt_fullName.Text,
                    BirthYear = int.Parse(txt_birthYear.Text),
                    ClassName = txt_class.Text,
                    Role = txt_role.Text,
                    Term = txt_term.Text,
                    ResidentAddress = addr,
                    TrainingScore = 0
                };
                _officialManager.Add(off);
            }
            else if (type == "Giảng viên")
            {
                Lecturer lec = new Lecturer
                {
                    LecturerId = txt_humanId.Text,
                    FullName = txt_fullName.Text,
                    BirthYear = int.Parse(txt_birthYear.Text),
                    Department = txt_class.Text,
                    ResidentAddress = addr
                };
                _lecturerManager.Add(lec);
            }

            MessageBox.Show("Thêm thành công!");
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}");
        }
    }

    private void btn_humanUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string type = cbb_obj.SelectedItem?.ToString();
            Address addr = new Address(txt_houseNum.Text, txt_street.Text, txt_district.Text);

            if (type == "Sinh viên")
            {
                Student st = new Student
                {
                    StudentId = txt_humanId.Text,
                    FullName = txt_fullName.Text,
                    BirthYear = int.Parse(txt_birthYear.Text),
                    ClassName = txt_class.Text,
                    ResidentAddress = addr
                };
                _studentManager.Update(st);
            }
            else if (type == "Cán bộ Đoàn")
            {
                Official off = new Official
                {
                    StudentId = txt_humanId.Text,
                    FullName = txt_fullName.Text,
                    BirthYear = int.Parse(txt_birthYear.Text),
                    ClassName = txt_class.Text,
                    Role = txt_role.Text,
                    Term = txt_term.Text,
                    ResidentAddress = addr
                };
                _officialManager.Update(off);
            }
            else if (type == "Giảng viên")
            {
                Lecturer lec = new Lecturer
                {
                    LecturerId = txt_humanId.Text,
                    FullName = txt_fullName.Text,
                    BirthYear = int.Parse(txt_birthYear.Text),
                    Department = txt_class.Text,
                    ResidentAddress = addr
                };
                _lecturerManager.Update(lec);
            }

            MessageBox.Show("Cập nhật thành công!");
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}");
        }
    }

    private void btn_humanDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string type = cbb_obj.SelectedItem?.ToString();
            string id = txt_humanId.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã để xóa!");
                return;
            }

            if (type == "Sinh viên") _studentManager.Delete(id);
            else if (type == "Cán bộ Đoàn") _officialManager.Delete(id);
            else if (type == "Giảng viên") _lecturerManager.Delete(id);

            MessageBox.Show("Xóa thành công!");
            LoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi: {ex.Message}");
        }
    }

    private void btn_humanSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string type = cbb_obj.SelectedItem?.ToString();
            string keyword = txt_search.Text;

            if (type == "Sinh viên") dgv_human.DataSource = _studentManager.Search(keyword);
            else if (type == "Cán bộ Đoàn") dgv_human.DataSource = _officialManager.Search(keyword);
            else if (type == "Giảng viên") dgv_human.DataSource = _lecturerManager.Search(keyword);
            
            FormatDataGridView();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
        }
    }

    private void label11_Click(object sender, EventArgs e)
    {
    }

    private void groupBox5_Enter(object sender, EventArgs e)
    {
    }

    private void dgv_event_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void txt_eventAddress_TextChanged(object sender, EventArgs e)
    {
    }

    private void tp_TH_Click(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void txt_recordCode_TextChanged(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}