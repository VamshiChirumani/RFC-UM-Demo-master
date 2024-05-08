
namespace RFC_UM_Demo
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ant1 = new System.Windows.Forms.PictureBox();
            this.ant2 = new System.Windows.Forms.PictureBox();
            this.ant3 = new System.Windows.Forms.PictureBox();
            this.ant4 = new System.Windows.Forms.PictureBox();
            this.cbSGTIN = new System.Windows.Forms.CheckBox();
            this.cbGIAI = new System.Windows.Forms.CheckBox();
            this.cbGRAI = new System.Windows.Forms.CheckBox();
            this.UnidentifiedTag = new System.Windows.Forms.PictureBox();
            this.FrequencyAdjust = new System.Windows.Forms.NumericUpDown();
            this.ClearScreen = new System.Windows.Forms.Button();
            this.cbGDTI = new System.Windows.Forms.CheckBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PointsWithStomp = new System.Windows.Forms.Button();
            this.Stomp_stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHeatmap = new System.Windows.Forms.Button();
            this.btnToggleFilter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bgwHeatMap = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ant1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnidentifiedTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyAdjust)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ant1
            // 
            this.ant1.Image = ((System.Drawing.Image)(resources.GetObject("ant1.Image")));
            this.ant1.Location = new System.Drawing.Point(814, 619);
            this.ant1.Name = "ant1";
            this.ant1.Size = new System.Drawing.Size(40, 40);
            this.ant1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ant1.TabIndex = 7;
            this.ant1.TabStop = false;
            this.ant1.Visible = false;
            // 
            // ant2
            // 
            this.ant2.Image = ((System.Drawing.Image)(resources.GetObject("ant2.Image")));
            this.ant2.Location = new System.Drawing.Point(814, 289);
            this.ant2.Name = "ant2";
            this.ant2.Size = new System.Drawing.Size(40, 40);
            this.ant2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ant2.TabIndex = 8;
            this.ant2.TabStop = false;
            this.ant2.Visible = false;
            // 
            // ant3
            // 
            this.ant3.Image = ((System.Drawing.Image)(resources.GetObject("ant3.Image")));
            this.ant3.Location = new System.Drawing.Point(1290, 289);
            this.ant3.Name = "ant3";
            this.ant3.Size = new System.Drawing.Size(40, 40);
            this.ant3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ant3.TabIndex = 9;
            this.ant3.TabStop = false;
            this.ant3.Visible = false;
            // 
            // ant4
            // 
            this.ant4.Image = ((System.Drawing.Image)(resources.GetObject("ant4.Image")));
            this.ant4.Location = new System.Drawing.Point(1290, 619);
            this.ant4.Name = "ant4";
            this.ant4.Size = new System.Drawing.Size(40, 40);
            this.ant4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ant4.TabIndex = 10;
            this.ant4.TabStop = false;
            this.ant4.Visible = false;
            // 
            // cbSGTIN
            // 
            this.cbSGTIN.AutoSize = true;
            this.cbSGTIN.BackColor = System.Drawing.Color.Transparent;
            this.cbSGTIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSGTIN.Location = new System.Drawing.Point(105, 101);
            this.cbSGTIN.Name = "cbSGTIN";
            this.cbSGTIN.Size = new System.Drawing.Size(106, 33);
            this.cbSGTIN.TabIndex = 13;
            this.cbSGTIN.Text = "SGTIN";
            this.cbSGTIN.UseVisualStyleBackColor = false;
            // 
            // cbGIAI
            // 
            this.cbGIAI.AutoSize = true;
            this.cbGIAI.BackColor = System.Drawing.Color.Transparent;
            this.cbGIAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGIAI.Location = new System.Drawing.Point(106, 128);
            this.cbGIAI.Name = "cbGIAI";
            this.cbGIAI.Size = new System.Drawing.Size(77, 33);
            this.cbGIAI.TabIndex = 14;
            this.cbGIAI.Text = "GIAI";
            this.cbGIAI.UseVisualStyleBackColor = false;
            // 
            // cbGRAI
            // 
            this.cbGRAI.AutoSize = true;
            this.cbGRAI.BackColor = System.Drawing.Color.Transparent;
            this.cbGRAI.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGRAI.Location = new System.Drawing.Point(106, 155);
            this.cbGRAI.Name = "cbGRAI";
            this.cbGRAI.Size = new System.Drawing.Size(88, 33);
            this.cbGRAI.TabIndex = 15;
            this.cbGRAI.Text = "GRAI";
            this.cbGRAI.UseVisualStyleBackColor = false;
            // 
            // UnidentifiedTag
            // 
            this.UnidentifiedTag.Image = ((System.Drawing.Image)(resources.GetObject("UnidentifiedTag.Image")));
            this.UnidentifiedTag.Location = new System.Drawing.Point(649, 915);
            this.UnidentifiedTag.Name = "UnidentifiedTag";
            this.UnidentifiedTag.Size = new System.Drawing.Size(33, 35);
            this.UnidentifiedTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UnidentifiedTag.TabIndex = 17;
            this.UnidentifiedTag.TabStop = false;
            this.UnidentifiedTag.Tag = "unidentified";
            this.UnidentifiedTag.Visible = false;
            this.UnidentifiedTag.Click += new System.EventHandler(this.Pb_Click);
            // 
            // FrequencyAdjust
            // 
            this.FrequencyAdjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrequencyAdjust.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FrequencyAdjust.Location = new System.Drawing.Point(112, 416);
            this.FrequencyAdjust.Name = "FrequencyAdjust";
            this.FrequencyAdjust.Size = new System.Drawing.Size(113, 32);
            this.FrequencyAdjust.TabIndex = 19;
            this.FrequencyAdjust.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FrequencyAdjust.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ClearScreen
            // 
            this.ClearScreen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearScreen.Location = new System.Drawing.Point(90, 224);
            this.ClearScreen.Name = "ClearScreen";
            this.ClearScreen.Size = new System.Drawing.Size(115, 36);
            this.ClearScreen.TabIndex = 20;
            this.ClearScreen.Text = "Clear Screen";
            this.ClearScreen.UseVisualStyleBackColor = false;
            this.ClearScreen.Click += new System.EventHandler(this.ClearScreen_Click);
            // 
            // cbGDTI
            // 
            this.cbGDTI.AutoSize = true;
            this.cbGDTI.BackColor = System.Drawing.Color.Transparent;
            this.cbGDTI.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGDTI.Location = new System.Drawing.Point(106, 185);
            this.cbGDTI.Name = "cbGDTI";
            this.cbGDTI.Size = new System.Drawing.Size(89, 33);
            this.cbGDTI.TabIndex = 21;
            this.cbGDTI.Text = "GDTI";
            this.cbGDTI.UseVisualStyleBackColor = false;
            // 
            // cbFilter
            // 
            this.cbFilter.AllowDrop = true;
            this.cbFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "All Tags"});
            this.cbFilter.Location = new System.Drawing.Point(2, 266);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(307, 37);
            this.cbFilter.Sorted = true;
            this.cbFilter.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(99, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 37);
            this.label2.TabIndex = 29;
            this.label2.Text = "Filters";
            // 
            // PointsWithStomp
            // 
            this.PointsWithStomp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsWithStomp.Location = new System.Drawing.Point(105, 309);
            this.PointsWithStomp.Name = "PointsWithStomp";
            this.PointsWithStomp.Size = new System.Drawing.Size(89, 29);
            this.PointsWithStomp.TabIndex = 30;
            this.PointsWithStomp.Text = "STOMP";
            this.PointsWithStomp.UseVisualStyleBackColor = true;
            this.PointsWithStomp.Click += new System.EventHandler(this.PointsWithStomp_Click);
            // 
            // Stomp_stop
            // 
            this.Stomp_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stomp_stop.Location = new System.Drawing.Point(105, 344);
            this.Stomp_stop.Name = "Stomp_stop";
            this.Stomp_stop.Size = new System.Drawing.Size(89, 30);
            this.Stomp_stop.TabIndex = 31;
            this.Stomp_stop.Text = "STOP";
            this.Stomp_stop.UseVisualStyleBackColor = true;
            this.Stomp_stop.Click += new System.EventHandler(this.Stomp_stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 26);
            this.label1.TabIndex = 28;
            this.label1.Text = "Smoothing";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.cbSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectAll.Location = new System.Drawing.Point(105, 72);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(120, 33);
            this.cbSelectAll.TabIndex = 33;
            this.cbSelectAll.Text = "All Tags";
            this.cbSelectAll.UseVisualStyleBackColor = false;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnHeatmap);
            this.panel1.Controls.Add(this.cbSelectAll);
            this.panel1.Controls.Add(this.Stomp_stop);
            this.panel1.Controls.Add(this.cbFilter);
            this.panel1.Controls.Add(this.PointsWithStomp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbGDTI);
            this.panel1.Controls.Add(this.ClearScreen);
            this.panel1.Controls.Add(this.FrequencyAdjust);
            this.panel1.Controls.Add(this.cbGRAI);
            this.panel1.Controls.Add(this.cbGIAI);
            this.panel1.Controls.Add(this.cbSGTIN);
            this.panel1.Location = new System.Drawing.Point(1433, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 469);
            this.panel1.TabIndex = 34;
            this.panel1.Visible = false;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnHeatmap
            // 
            this.btnHeatmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeatmap.Location = new System.Drawing.Point(17, 405);
            this.btnHeatmap.Name = "btnHeatmap";
            this.btnHeatmap.Size = new System.Drawing.Size(75, 28);
            this.btnHeatmap.TabIndex = 34;
            this.btnHeatmap.Text = "HeatMap";
            this.btnHeatmap.UseVisualStyleBackColor = true;
            this.btnHeatmap.Click += new System.EventHandler(this.btnHeatmap_Click);
            // 
            // btnToggleFilter
            // 
            this.btnToggleFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleFilter.Location = new System.Drawing.Point(0, 0);
            this.btnToggleFilter.Name = "btnToggleFilter";
            this.btnToggleFilter.Size = new System.Drawing.Size(46, 38);
            this.btnToggleFilter.TabIndex = 35;
            this.btnToggleFilter.Text = "<<";
            this.btnToggleFilter.UseVisualStyleBackColor = true;
            this.btnToggleFilter.Click += new System.EventHandler(this.btnToggleFilter_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnToggleFilter);
            this.panel2.Location = new System.Drawing.Point(1751, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(46, 37);
            this.panel2.TabIndex = 36;
            // 
            // bgwHeatMap
            // 
            this.bgwHeatMap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHeatMap_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UnidentifiedTag);
            this.Controls.Add(this.ant4);
            this.Controls.Add(this.ant3);
            this.Controls.Add(this.ant2);
            this.Controls.Add(this.ant1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFC Demo (v0.2)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            ((System.ComponentModel.ISupportInitialize)(this.ant1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ant4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnidentifiedTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyAdjust)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ant1;
        private System.Windows.Forms.PictureBox ant2;
        private System.Windows.Forms.PictureBox ant3;
        private System.Windows.Forms.PictureBox ant4;
        private System.Windows.Forms.CheckBox cbSGTIN;
        private System.Windows.Forms.CheckBox cbGIAI;
        private System.Windows.Forms.CheckBox cbGRAI;
        private System.Windows.Forms.PictureBox UnidentifiedTag;
        private System.Windows.Forms.NumericUpDown FrequencyAdjust;
        private System.Windows.Forms.Button ClearScreen;
        private System.Windows.Forms.CheckBox cbGDTI;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PointsWithStomp;
        private System.Windows.Forms.Button Stomp_stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToggleFilter;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker bgwHeatMap;
        private System.Windows.Forms.Button btnHeatmap;
    }
}

