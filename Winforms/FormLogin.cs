using QLDH.Entities;
using QLDH.Service;

namespace Quản_lý_đoàn_hội;

public partial class FormLogin : Form
{
    public FormLogin()
    {
        InitializeComponent();
    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void btn_login_Click(object sender, EventArgs e)
    {
            string user = txt_username.Text;
            string pass = txt_password.Text;

            AccountManager accManager = new AccountManager();
            Account acc = accManager.Login(user, pass);

            if (acc != null)
            {
                MessageBox.Show($"Chào mừng {acc.Role}: {acc.Username}!", "Thành công");
                // Mở Form chính sau khi đăng nhập thành công
                FormMain main = new FormMain();
                this.Hide();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo");
            }
    }

    private void btn_exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}