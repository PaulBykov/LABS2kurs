namespace Harmony
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.header = new System.Windows.Forms.Panel();
            this.RestoreButton = new FontAwesome.Sharp.IconButton();
            this.MinimizeButton = new FontAwesome.Sharp.IconButton();
            this.CloseButton = new FontAwesome.Sharp.IconButton();
            this.player = new System.Windows.Forms.Panel();
            this.CurrentSongTime_label = new System.Windows.Forms.Label();
            this.SongLen_label = new System.Windows.Forms.Label();
            this.Icon_Pause = new FontAwesome.Sharp.IconButton();
            this.Icon_Next = new FontAwesome.Sharp.IconButton();
            this.Icon_Prev = new FontAwesome.Sharp.IconButton();
            this.IconHolder = new System.Windows.Forms.Panel();
            this.LogoName = new System.Windows.Forms.Label();
            this.LogoPicture = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.SongProgress_guna2TrackBar = new Guna.UI2.WinForms.Guna2TrackBar();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.guna2TrackBar1 = new Guna.UI2.WinForms.Guna2TrackBar();
            this.header.SuspendLayout();
            this.player.SuspendLayout();
            this.IconHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationInterval = 50;
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(0)))), ((int)(((byte)(24)))));
            this.header.Controls.Add(this.RestoreButton);
            this.header.Controls.Add(this.MinimizeButton);
            this.header.Controls.Add(this.CloseButton);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1128, 30);
            this.header.TabIndex = 0;
            this.header.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.header_MouseDoubleClick);
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            this.header.MouseMove += new System.Windows.Forms.MouseEventHandler(this.header_MouseMove);
            this.header.MouseUp += new System.Windows.Forms.MouseEventHandler(this.header_MouseUp);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RestoreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestoreButton.FlatAppearance.BorderSize = 0;
            this.RestoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestoreButton.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.RestoreButton.IconColor = System.Drawing.Color.WhiteSmoke;
            this.RestoreButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.RestoreButton.IconSize = 24;
            this.RestoreButton.Location = new System.Drawing.Point(1059, 0);
            this.RestoreButton.Margin = new System.Windows.Forms.Padding(0);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(30, 30);
            this.RestoreButton.TabIndex = 2;
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.MinimizeButton.IconColor = System.Drawing.Color.WhiteSmoke;
            this.MinimizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MinimizeButton.IconSize = 28;
            this.MinimizeButton.Location = new System.Drawing.Point(1029, 0);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(30, 30);
            this.MinimizeButton.TabIndex = 1;
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.iconButton5_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.CloseButton.IconColor = System.Drawing.Color.WhiteSmoke;
            this.CloseButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CloseButton.IconSize = 34;
            this.CloseButton.Location = new System.Drawing.Point(1089, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Black;
            this.player.Controls.Add(this.guna2TrackBar1);
            this.player.Controls.Add(this.iconButton1);
            this.player.Controls.Add(this.SongProgress_guna2TrackBar);
            this.player.Controls.Add(this.CurrentSongTime_label);
            this.player.Controls.Add(this.SongLen_label);
            this.player.Controls.Add(this.Icon_Pause);
            this.player.Controls.Add(this.Icon_Next);
            this.player.Controls.Add(this.Icon_Prev);
            this.player.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player.Location = new System.Drawing.Point(0, 552);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(1128, 99);
            this.player.TabIndex = 2;
            // 
            // CurrentSongTime_label
            // 
            this.CurrentSongTime_label.AutoSize = true;
            this.CurrentSongTime_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentSongTime_label.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.CurrentSongTime_label.Location = new System.Drawing.Point(342, 40);
            this.CurrentSongTime_label.Name = "CurrentSongTime_label";
            this.CurrentSongTime_label.Size = new System.Drawing.Size(41, 20);
            this.CurrentSongTime_label.TabIndex = 5;
            this.CurrentSongTime_label.Text = "0:00";
            // 
            // SongLen_label
            // 
            this.SongLen_label.AutoSize = true;
            this.SongLen_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SongLen_label.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.SongLen_label.Location = new System.Drawing.Point(745, 40);
            this.SongLen_label.Name = "SongLen_label";
            this.SongLen_label.Size = new System.Drawing.Size(41, 20);
            this.SongLen_label.TabIndex = 4;
            this.SongLen_label.Text = "2:23";
            // 
            // Icon_Pause
            // 
            this.Icon_Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Icon_Pause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.Icon_Pause.IconColor = System.Drawing.Color.White;
            this.Icon_Pause.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icon_Pause.IconSize = 44;
            this.Icon_Pause.Location = new System.Drawing.Point(527, 10);
            this.Icon_Pause.Name = "Icon_Pause";
            this.Icon_Pause.Size = new System.Drawing.Size(71, 47);
            this.Icon_Pause.TabIndex = 2;
            this.Icon_Pause.UseVisualStyleBackColor = true;
            // 
            // Icon_Next
            // 
            this.Icon_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Icon_Next.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.Icon_Next.IconColor = System.Drawing.Color.White;
            this.Icon_Next.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icon_Next.Location = new System.Drawing.Point(603, 10);
            this.Icon_Next.Name = "Icon_Next";
            this.Icon_Next.Size = new System.Drawing.Size(71, 47);
            this.Icon_Next.TabIndex = 1;
            this.Icon_Next.UseVisualStyleBackColor = true;
            // 
            // Icon_Prev
            // 
            this.Icon_Prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Icon_Prev.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.Icon_Prev.IconColor = System.Drawing.Color.White;
            this.Icon_Prev.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icon_Prev.Location = new System.Drawing.Point(450, 10);
            this.Icon_Prev.Name = "Icon_Prev";
            this.Icon_Prev.Size = new System.Drawing.Size(71, 47);
            this.Icon_Prev.TabIndex = 0;
            this.Icon_Prev.UseVisualStyleBackColor = true;
            // 
            // IconHolder
            // 
            this.IconHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.IconHolder.Controls.Add(this.guna2CheckBox1);
            this.IconHolder.Controls.Add(this.LogoName);
            this.IconHolder.Controls.Add(this.LogoPicture);
            this.IconHolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconHolder.Location = new System.Drawing.Point(0, 30);
            this.IconHolder.Margin = new System.Windows.Forms.Padding(0);
            this.IconHolder.Name = "IconHolder";
            this.IconHolder.Size = new System.Drawing.Size(296, 522);
            this.IconHolder.TabIndex = 6;
            // 
            // LogoName
            // 
            this.LogoName.AutoSize = true;
            this.LogoName.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoName.ForeColor = System.Drawing.Color.White;
            this.LogoName.Location = new System.Drawing.Point(85, 33);
            this.LogoName.Name = "LogoName";
            this.LogoName.Size = new System.Drawing.Size(212, 59);
            this.LogoName.TabIndex = 6;
            this.LogoName.Text = "Harmony";
            // 
            // LogoPicture
            // 
            this.LogoPicture.Image = global::Harmony.Properties.Resources.logo;
            this.LogoPicture.Location = new System.Drawing.Point(20, 28);
            this.LogoPicture.Name = "LogoPicture";
            this.LogoPicture.Size = new System.Drawing.Size(65, 65);
            this.LogoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoPicture.TabIndex = 5;
            this.LogoPicture.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(296, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 522);
            this.panel1.TabIndex = 7;
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.Magenta;
            this.guna2CheckBox1.CheckedState.BorderRadius = 2;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.Magenta;
            this.guna2CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.guna2CheckBox1.ForeColor = System.Drawing.Color.White;
            this.guna2CheckBox1.Location = new System.Drawing.Point(20, 128);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(110, 24);
            this.guna2CheckBox1.TabIndex = 7;
            this.guna2CheckBox1.Text = "Only Liked";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.guna2CheckBox1.UncheckedState.BorderRadius = 2;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.Silver;
            // 
            // SongProgress_guna2TrackBar
            // 
            this.SongProgress_guna2TrackBar.Location = new System.Drawing.Point(346, 63);
            this.SongProgress_guna2TrackBar.Name = "SongProgress_guna2TrackBar";
            this.SongProgress_guna2TrackBar.Size = new System.Drawing.Size(440, 23);
            this.SongProgress_guna2TrackBar.TabIndex = 6;
            this.SongProgress_guna2TrackBar.ThumbColor = System.Drawing.Color.Magenta;
            this.SongProgress_guna2TrackBar.Value = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.VolumeLow;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 24;
            this.iconButton1.Location = new System.Drawing.Point(921, 40);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(25, 23);
            this.iconButton1.TabIndex = 7;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // guna2TrackBar1
            // 
            this.guna2TrackBar1.Location = new System.Drawing.Point(952, 37);
            this.guna2TrackBar1.Name = "guna2TrackBar1";
            this.guna2TrackBar1.Size = new System.Drawing.Size(78, 23);
            this.guna2TrackBar1.TabIndex = 8;
            this.guna2TrackBar1.ThumbColor = System.Drawing.Color.Magenta;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 651);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.IconHolder);
            this.Controls.Add(this.header);
            this.Controls.Add(this.player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.header.ResumeLayout(false);
            this.player.ResumeLayout(false);
            this.player.PerformLayout();
            this.IconHolder.ResumeLayout(false);
            this.IconHolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Panel player;
        private System.Windows.Forms.Panel header;
        private FontAwesome.Sharp.IconButton CloseButton;
        private FontAwesome.Sharp.IconButton RestoreButton;
        private FontAwesome.Sharp.IconButton MinimizeButton;
        private FontAwesome.Sharp.IconButton Icon_Prev;
        private FontAwesome.Sharp.IconButton Icon_Pause;
        private FontAwesome.Sharp.IconButton Icon_Next;
        private System.Windows.Forms.Label CurrentSongTime_label;
        private System.Windows.Forms.Label SongLen_label;
        private System.Windows.Forms.Panel IconHolder;
        private System.Windows.Forms.Label LogoName;
        private System.Windows.Forms.PictureBox LogoPicture;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private Guna.UI2.WinForms.Guna2TrackBar SongProgress_guna2TrackBar;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Guna.UI2.WinForms.Guna2TrackBar guna2TrackBar1;
    }
}

