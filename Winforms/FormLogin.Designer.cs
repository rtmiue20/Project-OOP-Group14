using System.ComponentModel;

namespace Quản_lý_đoàn_hội;

partial class FormLogin
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
        label1 = new System.Windows.Forms.Label();
        txt_username = new System.Windows.Forms.TextBox();
        groupBox1 = new System.Windows.Forms.GroupBox();
        btn_exit = new System.Windows.Forms.Button();
        btn_login = new System.Windows.Forms.Button();
        txt_password = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.SystemColors.ControlDark;
        label1.Location = new System.Drawing.Point(6, 43);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(254, 50);
        label1.TabIndex = 0;
        label1.Text = "Tên đăng nhập: ";
        // 
        // txt_username
        // 
        txt_username.Location = new System.Drawing.Point(266, 46);
        txt_username.Name = "txt_username";
        txt_username.Size = new System.Drawing.Size(550, 47);
        txt_username.TabIndex = 1;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(btn_exit);
        groupBox1.Controls.Add(btn_login);
        groupBox1.Controls.Add(txt_password);
        groupBox1.Controls.Add(label2);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(txt_username);
        groupBox1.Location = new System.Drawing.Point(336, 344);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(1061, 205);
        groupBox1.TabIndex = 2;
        groupBox1.TabStop = false;
        groupBox1.Enter += groupBox1_Enter;
        // 
        // btn_exit
        // 
        btn_exit.Location = new System.Drawing.Point(822, 120);
        btn_exit.Name = "btn_exit";
        btn_exit.Size = new System.Drawing.Size(233, 47);
        btn_exit.TabIndex = 5;
        btn_exit.Text = "Thoát";
        btn_exit.UseVisualStyleBackColor = true;
        btn_exit.Click += btn_exit_Click;
        // 
        // btn_login
        // 
        btn_login.Location = new System.Drawing.Point(822, 46);
        btn_login.Name = "btn_login";
        btn_login.Size = new System.Drawing.Size(233, 50);
        btn_login.TabIndex = 4;
        btn_login.Text = "Đăng nhập";
        btn_login.UseVisualStyleBackColor = true;
        btn_login.Click += btn_login_Click;
        // 
        // txt_password
        // 
        txt_password.Location = new System.Drawing.Point(266, 120);
        txt_password.Name = "txt_password";
        txt_password.Size = new System.Drawing.Size(550, 47);
        txt_password.TabIndex = 3;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.SystemColors.ControlDark;
        label2.Location = new System.Drawing.Point(6, 117);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(254, 50);
        label2.TabIndex = 2;
        label2.Text = "Mật khẩu: ";
        // 
        // FormLogin
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1829, 1038);
        Controls.Add(groupBox1);
        Text = "Đăng nhập Hệ thống Đoàn Hội - UEH";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btn_login;
    private System.Windows.Forms.Button btn_exit;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txt_password;

    private System.Windows.Forms.TextBox txt_username;
    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.Label label1;

    #endregion
}