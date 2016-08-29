namespace ChitChatClient
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtserverip = new System.Windows.Forms.TextBox();
            this.linkreg = new System.Windows.Forms.LinkLabel();
            this.linkforgot = new System.Windows.Forms.LinkLabel();
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtport);
            this.groupBox1.Controls.Add(this.txtserverip);
            this.groupBox1.Controls.Add(this.linkreg);
            this.groupBox1.Controls.Add(this.linkforgot);
            this.groupBox1.Controls.Add(this.btnlogin);
            this.groupBox1.Controls.Add(this.txtpass);
            this.groupBox1.Controls.Add(this.txtusername);
            this.groupBox1.Location = new System.Drawing.Point(3, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 323);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtserverip
            // 
            this.txtserverip.Location = new System.Drawing.Point(153, 260);
            this.txtserverip.Name = "txtserverip";
            this.txtserverip.Size = new System.Drawing.Size(144, 20);
            this.txtserverip.TabIndex = 6;
            // 
            // linkreg
            // 
            this.linkreg.AutoSize = true;
            this.linkreg.Location = new System.Drawing.Point(251, 234);
            this.linkreg.Name = "linkreg";
            this.linkreg.Size = new System.Drawing.Size(46, 13);
            this.linkreg.TabIndex = 5;
            this.linkreg.TabStop = true;
            this.linkreg.Text = "Register";
            // 
            // linkforgot
            // 
            this.linkforgot.AutoSize = true;
            this.linkforgot.Location = new System.Drawing.Point(109, 234);
            this.linkforgot.Name = "linkforgot";
            this.linkforgot.Size = new System.Drawing.Size(86, 13);
            this.linkforgot.TabIndex = 4;
            this.linkforgot.TabStop = true;
            this.linkforgot.Text = "Forgot Password";
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(153, 185);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(102, 32);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Text = "LOG-IN";
            this.btnlogin.UseVisualStyleBackColor = true;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(112, 159);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(185, 20);
            this.txtpass.TabIndex = 1;
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(112, 133);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(185, 20);
            this.txtusername.TabIndex = 0;
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(153, 286);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(73, 20);
            this.txtport.TabIndex = 7;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 327);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkreg;
        private System.Windows.Forms.LinkLabel linkforgot;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtserverip;
        private System.Windows.Forms.TextBox txtport;
    }
}