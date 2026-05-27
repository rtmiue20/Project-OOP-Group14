using System.ComponentModel;

namespace Quản_lý_đoàn_hội;

partial class InterfaceDemo
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
        tc_demo = new System.Windows.Forms.TabControl();
        tp_QLNS = new System.Windows.Forms.TabPage();
        tp_QLSK = new System.Windows.Forms.TabPage();
        tp_GNTG = new System.Windows.Forms.TabPage();
        tp_TH = new System.Windows.Forms.TabPage();
        tc_demo.SuspendLayout();
        SuspendLayout();
        // 
        // tc_demo
        // 
        tc_demo.Controls.Add(tp_QLNS);
        tc_demo.Controls.Add(tp_QLSK);
        tc_demo.Controls.Add(tp_GNTG);
        tc_demo.Controls.Add(tp_TH);
        tc_demo.Location = new System.Drawing.Point(1, 2);
        tc_demo.Name = "tc_demo";
        tc_demo.SelectedIndex = 0;
        tc_demo.Size = new System.Drawing.Size(1908, 1141);
        tc_demo.TabIndex = 0;
        // 
        // tp_QLNS
        // 
        tp_QLNS.Location = new System.Drawing.Point(10, 58);
        tp_QLNS.Name = "tp_QLNS";
        tp_QLNS.Padding = new System.Windows.Forms.Padding(3);
        tp_QLNS.Size = new System.Drawing.Size(1888, 1073);
        tp_QLNS.TabIndex = 0;
        tp_QLNS.Text = "Quản lý Nhân sự";
        tp_QLNS.UseVisualStyleBackColor = true;
        // 
        // tp_QLSK
        // 
        tp_QLSK.Location = new System.Drawing.Point(10, 58);
        tp_QLSK.Name = "tp_QLSK";
        tp_QLSK.Padding = new System.Windows.Forms.Padding(3);
        tp_QLSK.Size = new System.Drawing.Size(1888, 1073);
        tp_QLSK.TabIndex = 1;
        tp_QLSK.Text = "Quản lý Sự kiện Đoàn Hội";
        tp_QLSK.UseVisualStyleBackColor = true;
        // 
        // tp_GNTG
        // 
        tp_GNTG.Location = new System.Drawing.Point(10, 58);
        tp_GNTG.Name = "tp_GNTG";
        tp_GNTG.Padding = new System.Windows.Forms.Padding(3);
        tp_GNTG.Size = new System.Drawing.Size(1888, 1073);
        tp_GNTG.TabIndex = 2;
        tp_GNTG.Text = "Điểm danh & Ghi nhận tham gia";
        tp_GNTG.UseVisualStyleBackColor = true;
        // 
        // tp_TH
        // 
        tp_TH.Location = new System.Drawing.Point(10, 58);
        tp_TH.Name = "tp_TH";
        tp_TH.Padding = new System.Windows.Forms.Padding(3);
        tp_TH.Size = new System.Drawing.Size(1888, 1073);
        tp_TH.TabIndex = 3;
        tp_TH.Text = "Tổng hợp & Tính điểm rèn luyện";
        tp_TH.UseVisualStyleBackColor = true;
        // 
        // InterfaceDemo
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1913, 1148);
        Controls.Add(tc_demo);
        Text = "Hệ thống Quản lý Đoàn Hội - UEH";
        tc_demo.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TabControl tc_demo;
    private System.Windows.Forms.TabPage tp_QLNS;
    private System.Windows.Forms.TabPage tp_QLSK;
    private System.Windows.Forms.TabPage tp_GNTG;
    private System.Windows.Forms.TabPage tp_TH;

    #endregion
}