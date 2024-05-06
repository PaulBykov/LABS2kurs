namespace _1
{
    partial class Form1
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
            SinButton = new Button();
            InputField = new TextBox();
            CosButton = new Button();
            CtgButton = new Button();
            TanButton = new Button();
            CubeButton = new Button();
            SquareButton = new Button();
            CbrtButton = new Button();
            SqrtButton = new Button();
            ClearButton = new Button();
            CopyButton = new Button();
            PasteButton = new Button();
            SuspendLayout();
            // 
            // SinButton
            // 
            SinButton.Location = new Point(61, 127);
            SinButton.Name = "SinButton";
            SinButton.Size = new Size(74, 58);
            SinButton.TabIndex = 1;
            SinButton.Text = "sin";
            SinButton.UseVisualStyleBackColor = true;
            SinButton.Click += SinButton_Click;
            // 
            // InputField
            // 
            InputField.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            InputField.Location = new Point(61, 25);
            InputField.Name = "InputField";
            InputField.Size = new Size(403, 43);
            InputField.TabIndex = 2;
            InputField.TextChanged += InputField_TextChanged;
            // 
            // CosButton
            // 
            CosButton.Location = new Point(61, 212);
            CosButton.Name = "CosButton";
            CosButton.Size = new Size(74, 58);
            CosButton.TabIndex = 3;
            CosButton.Text = "cos";
            CosButton.UseVisualStyleBackColor = true;
            CosButton.Click += CosButton_Click;
            // 
            // CtgButton
            // 
            CtgButton.Location = new Point(61, 382);
            CtgButton.Name = "CtgButton";
            CtgButton.Size = new Size(74, 58);
            CtgButton.TabIndex = 5;
            CtgButton.Text = "ctg";
            CtgButton.UseVisualStyleBackColor = true;
            CtgButton.Click += CtgButton_Click;
            // 
            // TanButton
            // 
            TanButton.Location = new Point(61, 297);
            TanButton.Name = "TanButton";
            TanButton.Size = new Size(74, 58);
            TanButton.TabIndex = 4;
            TanButton.Text = "tan";
            TanButton.UseVisualStyleBackColor = true;
            TanButton.Click += TanButton_Click;
            // 
            // CubeButton
            // 
            CubeButton.Location = new Point(180, 382);
            CubeButton.Name = "CubeButton";
            CubeButton.Size = new Size(74, 58);
            CubeButton.TabIndex = 9;
            CubeButton.Text = "pow(3)";
            CubeButton.UseVisualStyleBackColor = true;
            CubeButton.Click += CubeButton_Click;
            // 
            // SquareButton
            // 
            SquareButton.Location = new Point(180, 297);
            SquareButton.Name = "SquareButton";
            SquareButton.Size = new Size(74, 58);
            SquareButton.TabIndex = 8;
            SquareButton.Text = "pow(2)";
            SquareButton.UseVisualStyleBackColor = true;
            SquareButton.Click += SquareButton_Click;
            // 
            // CbrtButton
            // 
            CbrtButton.Location = new Point(180, 212);
            CbrtButton.Name = "CbrtButton";
            CbrtButton.Size = new Size(74, 58);
            CbrtButton.TabIndex = 7;
            CbrtButton.Text = "cbrt";
            CbrtButton.UseVisualStyleBackColor = true;
            CbrtButton.Click += CbrtButton_Click;
            // 
            // SqrtButton
            // 
            SqrtButton.Location = new Point(180, 127);
            SqrtButton.Name = "SqrtButton";
            SqrtButton.Size = new Size(74, 58);
            SqrtButton.TabIndex = 6;
            SqrtButton.Text = "sqrt";
            SqrtButton.UseVisualStyleBackColor = true;
            SqrtButton.Click += SqrtButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Location = new Point(390, 127);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(74, 58);
            ClearButton.TabIndex = 10;
            ClearButton.Text = "C";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.Location = new Point(390, 212);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(74, 58);
            CopyButton.TabIndex = 11;
            CopyButton.Text = "COPY";
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // PasteButton
            // 
            PasteButton.Location = new Point(390, 297);
            PasteButton.Name = "PasteButton";
            PasteButton.Size = new Size(74, 58);
            PasteButton.TabIndex = 12;
            PasteButton.Text = "PASTE";
            PasteButton.UseVisualStyleBackColor = true;
            PasteButton.Click += PasteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 489);
            Controls.Add(PasteButton);
            Controls.Add(CopyButton);
            Controls.Add(ClearButton);
            Controls.Add(CubeButton);
            Controls.Add(SquareButton);
            Controls.Add(CbrtButton);
            Controls.Add(SqrtButton);
            Controls.Add(CtgButton);
            Controls.Add(TanButton);
            Controls.Add(CosButton);
            Controls.Add(InputField);
            Controls.Add(SinButton);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SinButton;
        private TextBox InputField;
        private Button CosButton;
        private Button CtgButton;
        private Button TanButton;
        private Button CubeButton;
        private Button SquareButton;
        private Button CbrtButton;
        private Button SqrtButton;
        private Button ClearButton;
        private Button CopyButton;
        private Button PasteButton;
    }
}
