
namespace GoodsAuctionSystem.Boundary
{
    partial class CreateAuctionMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAuctionMenu));
            label2 = new Label();
            biddingPageTitle = new Label();
            GASimg = new PictureBox();
            logoutButton = new Button();
            label1 = new Label();
            itemNameTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            createAuctButton = new Button();
            startingPrice = new NumericUpDown();
            descripTxt = new TextBox();
            conditionDrop = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)GASimg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startingPrice).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = SystemColors.ControlLightLight;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(-11, 103);
            label2.Name = "label2";
            label2.Size = new Size(1000, 10);
            label2.TabIndex = 20;
            // 
            // biddingPageTitle
            // 
            biddingPageTitle.Anchor = AnchorStyles.Top;
            biddingPageTitle.AutoSize = true;
            biddingPageTitle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            biddingPageTitle.Location = new Point(410, 44);
            biddingPageTitle.Name = "biddingPageTitle";
            biddingPageTitle.Size = new Size(158, 27);
            biddingPageTitle.TabIndex = 19;
            biddingPageTitle.Text = "Create Auction";
            // 
            // GASimg
            // 
            GASimg.Image = (Image)resources.GetObject("GASimg.Image");
            GASimg.Location = new Point(-26, -2);
            GASimg.Margin = new Padding(3, 2, 3, 2);
            GASimg.Name = "GASimg";
            GASimg.Size = new Size(233, 109);
            GASimg.SizeMode = PictureBoxSizeMode.Zoom;
            GASimg.TabIndex = 18;
            GASimg.TabStop = false;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = SystemColors.Control;
            logoutButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            logoutButton.Location = new Point(814, 40);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(112, 34);
            logoutButton.TabIndex = 21;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(112, 139);
            label1.Name = "label1";
            label1.Size = new Size(125, 27);
            label1.TabIndex = 22;
            label1.Text = "Item Name:";
            // 
            // itemNameTxt
            // 
            itemNameTxt.Location = new Point(243, 137);
            itemNameTxt.MaxLength = 16;
            itemNameTxt.Name = "itemNameTxt";
            itemNameTxt.Size = new Size(492, 31);
            itemNameTxt.TabIndex = 23;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(89, 222);
            label3.Name = "label3";
            label3.Size = new Size(148, 27);
            label3.TabIndex = 24;
            label3.Text = "Starting Price:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(124, 301);
            label4.Name = "label4";
            label4.Size = new Size(113, 27);
            label4.TabIndex = 25;
            label4.Text = "Condition:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(108, 430);
            label5.Name = "label5";
            label5.Size = new Size(129, 27);
            label5.TabIndex = 26;
            label5.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(243, 222);
            label6.Name = "label6";
            label6.Size = new Size(24, 27);
            label6.TabIndex = 27;
            label6.Text = "$";
            // 
            // createAuctButton
            // 
            createAuctButton.AutoSize = true;
            createAuctButton.BackColor = SystemColors.Control;
            createAuctButton.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createAuctButton.Location = new Point(405, 520);
            createAuctButton.Name = "createAuctButton";
            createAuctButton.Size = new Size(168, 37);
            createAuctButton.TabIndex = 28;
            createAuctButton.Text = "Create Auction";
            createAuctButton.UseVisualStyleBackColor = false;
            createAuctButton.Click += createAuctButton_Click;
            // 
            // startingPrice
            // 
            startingPrice.Location = new Point(262, 221);
            startingPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            startingPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            startingPrice.Name = "startingPrice";
            startingPrice.Size = new Size(103, 31);
            startingPrice.TabIndex = 29;
            startingPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            startingPrice.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // descripTxt
            // 
            descripTxt.Location = new Point(243, 428);
            descripTxt.MaxLength = 200;
            descripTxt.Name = "descripTxt";
            descripTxt.Size = new Size(492, 31);
            descripTxt.TabIndex = 30;
            // 
            // conditionDrop
            // 
            conditionDrop.DropDownStyle = ComboBoxStyle.DropDownList;
            conditionDrop.FormattingEnabled = true;
            conditionDrop.Items.AddRange(new object[] { "New", "Used" });
            conditionDrop.Location = new Point(243, 299);
            conditionDrop.Name = "conditionDrop";
            conditionDrop.Size = new Size(122, 33);
            conditionDrop.TabIndex = 31;
            conditionDrop.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // CreateAuctionMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(974, 590);
            Controls.Add(conditionDrop);
            Controls.Add(descripTxt);
            Controls.Add(startingPrice);
            Controls.Add(createAuctButton);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(itemNameTxt);
            Controls.Add(label1);
            Controls.Add(logoutButton);
            Controls.Add(label2);
            Controls.Add(biddingPageTitle);
            Controls.Add(GASimg);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateAuctionMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Auction Menu";
            ((System.ComponentModel.ISupportInitialize)GASimg).EndInit();
            ((System.ComponentModel.ISupportInitialize)startingPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label biddingPageTitle;
        private System.Windows.Forms.PictureBox GASimg;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button createAuctButton;
        private System.Windows.Forms.NumericUpDown startingPrice;
        private System.Windows.Forms.TextBox descripTxt;
        private System.Windows.Forms.ComboBox conditionDrop;
    }
}