using QLDH.Entities;
using QLDH.Service;

namespace Quản_lý_đoàn_hội;

public partial class FormLogin : Form
{
    public FormLogin()
    {
        InitializeComponent();
        SetupModernLoginUI();
    }

    private void SetupModernLoginUI()
    {
        // Form settings
        this.Text = "Đăng nhập Hệ thống Quản lý Đoàn Hội - UEH";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.BackColor = Color.FromArgb(245, 247, 250);

        // GroupBox hiện đại
        groupBox1.BackColor = Color.White;
        groupBox1.FlatStyle = FlatStyle.Flat;
        groupBox1.Padding = new Padding(40);
        groupBox1.Font = new Font("Segoe UI", 10F);

        // Tiêu đề form
        Label lblTitle = new Label
        {
            Text = "ĐĂNG NHẬP",
            Font = new Font("Segoe UI", 20F, FontStyle.Bold),
            ForeColor = Color.FromArgb(28, 35, 49),
            TextAlign = ContentAlignment.MiddleCenter,
            Dock = DockStyle.Top,
            Height = 80,
            Margin = new Padding(0, 20, 0, 10)
        };
        this.Controls.Add(lblTitle);

        // Style TextBox
        StyleTextBox(txt_username);
        StyleTextBox(txt_password);

        txt_password.PasswordChar = '●';

        // Style Button
        StyleButton(btn_login, Color.FromArgb(0, 122, 255));      // Blue
        StyleButton(btn_exit, Color.FromArgb(220, 53, 69));       // Red

        // Căn giữa GroupBox
        groupBox1.Location = new Point((this.ClientSize.Width - groupBox1.Width) / 2, 180);
    }

    private void StyleTextBox(TextBox tb)
    {
        tb.Font = new Font("Segoe UI", 9F);
        tb.BackColor = Color.FromArgb(249, 250, 251);
        tb.BorderStyle = BorderStyle.FixedSingle;
        tb.Height = 45;
        tb.Padding = new Padding(10, 8, 10, 8);
    }

    private void StyleButton(Button btn, Color backColor)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.BackColor = backColor;
        btn.ForeColor = Color.White;
        btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btn.Height = 50;
        btn.Cursor = Cursors.Hand;

        // Hover effect
        btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(backColor);
        btn.MouseLeave += (s, e) => btn.BackColor = backColor;
    }

    private void btn_login_Click(object sender, EventArgs e)
    {
        string user = txt_username.Text.Trim();
        string pass = txt_password.Text.Trim();

        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        AccountManager accManager = new AccountManager();
        Account acc = accManager.Login(user, pass);

        if (acc != null)
        {
            MessageBox.Show($"Chào mừng {acc.Role}: {acc.Username}!", "Đăng nhập thành công", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormMain main = new FormMain(acc);
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
        else
        {
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", 
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}