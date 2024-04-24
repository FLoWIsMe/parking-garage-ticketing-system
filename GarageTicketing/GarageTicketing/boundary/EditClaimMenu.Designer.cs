
namespace GarageTicketing.Boundary
{
   public partial class EditClaimMenu
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
            label4 = new Label();
            label5 = new Label();
            logo = new Label();
            loginButt = new Button();
            button1 = new Button();
            label3 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(217, 198);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(61, 22);
            label4.TabIndex = 25;
            label4.Text = "Time: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(217, 252);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(85, 22);
            label5.TabIndex = 26;
            label5.Text = "Location:";
            // 
            // logo
            // 
            logo.Anchor = AnchorStyles.Top;
            logo.AutoSize = true;
            logo.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point);
            logo.Location = new Point(301, 27);
            logo.Name = "logo";
            logo.Size = new Size(132, 31);
            logo.TabIndex = 32;
            logo.Text = "Edit Claim";
            logo.Click += logo_Click;
            // 
            // loginButt
            // 
            loginButt.Anchor = AnchorStyles.None;
            loginButt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginButt.BackColor = SystemColors.MenuBar;
            loginButt.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            loginButt.Location = new Point(12, 11);
            loginButt.Margin = new Padding(3, 2, 3, 2);
            loginButt.Name = "loginButt";
            loginButt.Size = new Size(130, 50);
            loginButt.TabIndex = 33;
            loginButt.Text = "Logout";
            loginButt.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = SystemColors.MenuBar;
            button1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(296, 376);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(137, 50);
            button1.TabIndex = 34;
            button1.Text = "Save Spot";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(217, 93);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(142, 22);
            label3.TabIndex = 37;
            label3.Text = "Customer Name:";
            label3.Click += label3_Click_2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(217, 143);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(53, 22);
            label6.TabIndex = 38;
            label6.Text = "Date:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(217, 312);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(126, 22);
            label7.TabIndex = 39;
            label7.Text = "Reserve Time:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(391, 95);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(107, 22);
            label8.TabIndex = 40;
            label8.Text = "Adam Smith";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(391, 143);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(102, 22);
            label9.TabIndex = 41;
            label9.Text = "12/31/2023";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(391, 198);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(91, 22);
            label10.TabIndex = 42;
            label10.Text = "08:32 AM";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(391, 252);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(136, 22);
            label11.TabIndex = 43;
            label11.Text = "Parking Spot #1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(391, 311);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 44;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged_1;
            // 
            // EditClaimMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(779, 472);
            Controls.Add(numericUpDown1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(loginButt);
            Controls.Add(logo);
            Controls.Add(label5);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(2, 2, 2, 2);
            Name = "EditClaimMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Garage Ticketing";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label label5;
        private Label logo;
        private Button loginButt;
        private Button button1;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private NumericUpDown numericUpDown1;
    }
}