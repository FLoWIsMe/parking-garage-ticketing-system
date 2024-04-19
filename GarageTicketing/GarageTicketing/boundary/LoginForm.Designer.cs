
namespace GoodsAuctionSystem.Boundary
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            GASimg = new PictureBox();
            logo = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            userLable = new Label();
            userText = new TextBox();
            passText = new TextBox();
            passLable = new Label();
            loginButt = new Button();
            label2 = new Label();
            loginError = new Label();
            ((System.ComponentModel.ISupportInitialize)GASimg).BeginInit();
            SuspendLayout();
            // 
            // GASimg
            // 
            GASimg.Image = (Image)resources.GetObject("GASimg.Image");
            GASimg.Location = new Point(-26, -2);
            GASimg.Margin = new Padding(3, 2, 3, 2);
            GASimg.Name = "GASimg";
            GASimg.Size = new Size(233, 109);
            GASimg.SizeMode = PictureBoxSizeMode.Zoom;
            GASimg.TabIndex = 0;
            GASimg.TabStop = false;
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Top;
            logo.AutoSize = true;
            logo.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point);
            logo.Location = new Point(232, 40);
            logo.Name = "logo";
            logo.Size = new Size(309, 36);
            logo.TabIndex = 1;
            logo.Text = "Goods Auction System ";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // userLable
            // 
            userLable.Anchor = AnchorStyles.None;
            userLable.AutoSize = true;
            userLable.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            userLable.Location = new Point(89, 158);
            userLable.Name = "userLable";
            userLable.Size = new Size(132, 33);
            userLable.TabIndex = 4;
            userLable.Text = "Username:";
            // 
            // userText
            // 
            userText.Anchor = AnchorStyles.None;
            userText.Location = new Point(217, 160);
            userText.Margin = new Padding(3, 2, 3, 2);
            userText.MaxLength = 30;
            userText.Name = "userText";
            userText.Size = new Size(344, 28);
            userText.TabIndex = 5;
            userText.TextChanged += userText_TextChanged;
            // 
            // passText
            // 
            passText.Anchor = AnchorStyles.None;
            passText.Location = new Point(217, 250);
            passText.Margin = new Padding(3, 2, 3, 2);
            passText.MaxLength = 50;
            passText.Name = "passText";
            passText.PasswordChar = '*';
            passText.Size = new Size(344, 28);
            passText.TabIndex = 7;
            passText.TextChanged += passText_TextChanged;
            // 
            // passLable
            // 
            passLable.Anchor = AnchorStyles.None;
            passLable.AutoSize = true;
            passLable.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            passLable.Location = new Point(89, 247);
            passLable.Name = "passLable";
            passLable.Size = new Size(129, 33);
            passLable.TabIndex = 6;
            passLable.Text = "Password:";
            // 
            // loginButt
            // 
            loginButt.Anchor = AnchorStyles.None;
            loginButt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButt.BackColor = SystemColors.MenuBar;
            loginButt.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            loginButt.Location = new Point(324, 380);
            loginButt.Margin = new Padding(3, 2, 3, 2);
            loginButt.Name = "loginButt";
            loginButt.Size = new Size(130, 50);
            loginButt.TabIndex = 8;
            loginButt.Text = "Login";
            loginButt.UseVisualStyleBackColor = false;
            loginButt.Click += loginButt_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(-11, 103);
            label2.Name = "label2";
            label2.Size = new Size(800, 10);
            label2.TabIndex = 3;
            // 
            // loginError
            // 
            loginError.Anchor = AnchorStyles.None;
            loginError.AutoSize = true;
            loginError.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            loginError.ForeColor = Color.Red;
            loginError.Location = new Point(121, 316);
            loginError.Name = "loginError";
            loginError.Size = new Size(535, 33);
            loginError.TabIndex = 9;
            loginError.Text = "Username or password wrong, please try again!";
            loginError.Click += loginError_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(778, 494);
            Controls.Add(loginError);
            Controls.Add(loginButt);
            Controls.Add(passText);
            Controls.Add(passLable);
            Controls.Add(userText);
            Controls.Add(userLable);
            Controls.Add(label2);
            Controls.Add(logo);
            Controls.Add(GASimg);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(680, 443);
            Name = "LoginForm";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)GASimg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox GASimg;
        private System.Windows.Forms.Label logo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label userLable;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.TextBox passText;
        private System.Windows.Forms.Label passLable;
        private System.Windows.Forms.Button loginButt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label loginError;
    }
}

