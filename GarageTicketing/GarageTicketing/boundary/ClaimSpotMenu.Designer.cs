
namespace GarageTicketing.Boundary
{
    partial class ClaimSpotMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClaimSpotMenu));
            label2 = new Label();
            biddingPageTitle = new Label();
            GASimg = new PictureBox();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            dollar2LOL = new Label();
            descripLabel = new Label();
            condNewUsedLabel = new Label();
            highBidValLabel = new Label();
            conditionLabel = new Label();
            highestBidLabel = new Label();
            itemNameLabel = new Label();
            panel2 = new Panel();
            ClaimSpotButton = new Button();
            numericUpDown1 = new NumericUpDown();
            dollarLOL = new Label();
            bidNowLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)GASimg).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BackColor = SystemColors.ControlLight;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(-11, 103);
            label2.Name = "label2";
            label2.Size = new Size(1000, 10);
            label2.TabIndex = 15;
            // 
            // biddingPageTitle
            // 
            biddingPageTitle.Anchor = AnchorStyles.Top;
            biddingPageTitle.AutoSize = true;
            biddingPageTitle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            biddingPageTitle.Location = new Point(419, 42);
            biddingPageTitle.Name = "biddingPageTitle";
            biddingPageTitle.Size = new Size(140, 27);
            biddingPageTitle.TabIndex = 14;
            biddingPageTitle.Text = "Bidding Page";
            biddingPageTitle.Click += logo_Click;
            // 
            // GASimg
            // 
            GASimg.Image = (Image)resources.GetObject("GASimg.Image");
            GASimg.Location = new Point(-26, -2);
            GASimg.Margin = new Padding(3, 2, 3, 2);
            GASimg.Name = "GASimg";
            GASimg.Size = new Size(233, 109);
            GASimg.SizeMode = PictureBoxSizeMode.Zoom;
            GASimg.TabIndex = 13;
            GASimg.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 412);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 16;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.Location = new Point(-11, 109);
            label3.Name = "label3";
            label3.Size = new Size(1000, 16);
            label3.TabIndex = 17;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dollar2LOL);
            panel1.Controls.Add(descripLabel);
            panel1.Controls.Add(condNewUsedLabel);
            panel1.Controls.Add(highBidValLabel);
            panel1.Controls.Add(conditionLabel);
            panel1.Controls.Add(highestBidLabel);
            panel1.Controls.Add(itemNameLabel);
            panel1.Location = new Point(25, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(564, 440);
            panel1.TabIndex = 18;
            // 
            // dollar2LOL
            // 
            dollar2LOL.AutoSize = true;
            dollar2LOL.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dollar2LOL.Location = new Point(167, 108);
            dollar2LOL.Name = "dollar2LOL";
            dollar2LOL.Size = new Size(24, 27);
            dollar2LOL.TabIndex = 6;
            dollar2LOL.Text = "$";
            // 
            // descripLabel
            // 
            descripLabel.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            descripLabel.Location = new Point(20, 235);
            descripLabel.Name = "descripLabel";
            descripLabel.Size = new Size(525, 179);
            descripLabel.TabIndex = 5;
            descripLabel.Text = "This is a place holder for a description";
            // 
            // condNewUsedLabel
            // 
            condNewUsedLabel.AutoSize = true;
            condNewUsedLabel.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            condNewUsedLabel.Location = new Point(148, 175);
            condNewUsedLabel.Name = "condNewUsedLabel";
            condNewUsedLabel.Size = new Size(103, 27);
            condNewUsedLabel.TabIndex = 4;
            condNewUsedLabel.Text = "new/used";
            // 
            // highBidValLabel
            // 
            highBidValLabel.AutoSize = true;
            highBidValLabel.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            highBidValLabel.Location = new Point(186, 108);
            highBidValLabel.Name = "highBidValLabel";
            highBidValLabel.Size = new Size(78, 27);
            highBidValLabel.TabIndex = 3;
            highBidValLabel.Text = "xxx.xx";
            // 
            // conditionLabel
            // 
            conditionLabel.AutoSize = true;
            conditionLabel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            conditionLabel.Location = new Point(20, 174);
            conditionLabel.Name = "conditionLabel";
            conditionLabel.Size = new Size(122, 26);
            conditionLabel.TabIndex = 2;
            conditionLabel.Text = "Condition:";
            // 
            // highestBidLabel
            // 
            highestBidLabel.AutoSize = true;
            highestBidLabel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            highestBidLabel.Location = new Point(20, 108);
            highestBidLabel.Name = "highestBidLabel";
            highestBidLabel.Size = new Size(141, 26);
            highestBidLabel.TabIndex = 1;
            highestBidLabel.Text = "Highest Bid:";
            // 
            // itemNameLabel
            // 
            itemNameLabel.AutoSize = true;
            itemNameLabel.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            itemNameLabel.Location = new Point(224, 12);
            itemNameLabel.Name = "itemNameLabel";
            itemNameLabel.Size = new Size(142, 32);
            itemNameLabel.TabIndex = 0;
            itemNameLabel.Text = "Item Name";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLightLight;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(ClaimSpotButton);
            panel2.Controls.Add(numericUpDown1);
            panel2.Controls.Add(dollarLOL);
            panel2.Controls.Add(bidNowLabel);
            panel2.Location = new Point(661, 270);
            panel2.Name = "panel2";
            panel2.Size = new Size(287, 150);
            panel2.TabIndex = 19;
            // 
            // ClaimSpotButton
            // 
            ClaimSpotButton.BackColor = SystemColors.Control;
            ClaimSpotButton.Font = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point);
            ClaimSpotButton.Location = new Point(153, 72);
            ClaimSpotButton.Name = "ClaimSpotButton";
            ClaimSpotButton.Size = new Size(112, 34);
            ClaimSpotButton.TabIndex = 6;
            ClaimSpotButton.Text = "ClaimSpot";
            ClaimSpotButton.UseVisualStyleBackColor = false;
            ClaimSpotButton.Click += ClaimSpotButton_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(51, 75);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(82, 31);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dollarLOL
            // 
            dollarLOL.AutoSize = true;
            dollarLOL.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dollarLOL.Location = new Point(33, 76);
            dollarLOL.Name = "dollarLOL";
            dollarLOL.Size = new Size(24, 27);
            dollarLOL.TabIndex = 4;
            dollarLOL.Text = "$";
            // 
            // bidNowLabel
            // 
            bidNowLabel.AutoSize = true;
            bidNowLabel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bidNowLabel.Location = new Point(33, 46);
            bidNowLabel.Name = "bidNowLabel";
            bidNowLabel.Size = new Size(100, 26);
            bidNowLabel.TabIndex = 3;
            bidNowLabel.Text = "Bid Now";
            // 
            // ClaimSpotMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(978, 594);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(biddingPageTitle);
            Controls.Add(GASimg);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ClaimSpotMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Place Bid Menu";
            ((System.ComponentModel.ISupportInitialize)GASimg).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label biddingPageTitle;
        private System.Windows.Forms.PictureBox GASimg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label descripLabel;
        private System.Windows.Forms.Label condNewUsedLabel;
        private System.Windows.Forms.Label highBidValLabel;
        private System.Windows.Forms.Label conditionLabel;
        private System.Windows.Forms.Label highestBidLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ClaimSpotButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label dollarLOL;
        private System.Windows.Forms.Label bidNowLabel;
        private System.Windows.Forms.Label dollar2LOL;
    }
}