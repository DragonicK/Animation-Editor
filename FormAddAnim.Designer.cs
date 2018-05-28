namespace Animation_Editor {
    partial class FormAddAnim {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.PictureAnimation = new System.Windows.Forms.PictureBox();
            this.TextName = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.TextFrameCount = new System.Windows.Forms.TextBox();
            this.LabelFrameCount = new System.Windows.Forms.Label();
            this.TextWidth = new System.Windows.Forms.TextBox();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.TextHeight = new System.Windows.Forms.TextBox();
            this.LabelHeight = new System.Windows.Forms.Label();
            this.CheckCreateAnimation = new System.Windows.Forms.CheckBox();
            this.TextX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelColorKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureAnimation)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAdd.Location = new System.Drawing.Point(12, 265);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(353, 24);
            this.ButtonAdd.TabIndex = 8;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // PictureAnimation
            // 
            this.PictureAnimation.BackColor = System.Drawing.Color.Black;
            this.PictureAnimation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PictureAnimation.Location = new System.Drawing.Point(12, 15);
            this.PictureAnimation.Name = "PictureAnimation";
            this.PictureAnimation.Size = new System.Drawing.Size(192, 192);
            this.PictureAnimation.TabIndex = 1;
            this.PictureAnimation.TabStop = false;
            this.PictureAnimation.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureAnimation_Paint);
            // 
            // TextName
            // 
            this.TextName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextName.Location = new System.Drawing.Point(213, 36);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(149, 22);
            this.TextName.TabIndex = 0;
            // 
            // LabelName
            // 
            this.LabelName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelName.Location = new System.Drawing.Point(210, 15);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(138, 18);
            this.LabelName.TabIndex = 2;
            this.LabelName.Text = "Object Name";
            // 
            // TextFrameCount
            // 
            this.TextFrameCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameCount.Location = new System.Drawing.Point(213, 82);
            this.TextFrameCount.Name = "TextFrameCount";
            this.TextFrameCount.Size = new System.Drawing.Size(149, 22);
            this.TextFrameCount.TabIndex = 1;
            this.TextFrameCount.Text = "0";
            this.TextFrameCount.TextChanged += new System.EventHandler(this.TextFrameCount_TextChanged);
            // 
            // LabelFrameCount
            // 
            this.LabelFrameCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameCount.Location = new System.Drawing.Point(210, 61);
            this.LabelFrameCount.Name = "LabelFrameCount";
            this.LabelFrameCount.Size = new System.Drawing.Size(162, 18);
            this.LabelFrameCount.TabIndex = 4;
            this.LabelFrameCount.Text = "Frame Count";
            // 
            // TextWidth
            // 
            this.TextWidth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextWidth.Location = new System.Drawing.Point(214, 126);
            this.TextWidth.Name = "TextWidth";
            this.TextWidth.Size = new System.Drawing.Size(149, 22);
            this.TextWidth.TabIndex = 2;
            this.TextWidth.Text = "0";
            this.TextWidth.TextChanged += new System.EventHandler(this.TextWidth_TextChanged);
            // 
            // LabelWidth
            // 
            this.LabelWidth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelWidth.Location = new System.Drawing.Point(211, 105);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(162, 18);
            this.LabelWidth.TabIndex = 8;
            this.LabelWidth.Text = "Frames Width";
            // 
            // TextHeight
            // 
            this.TextHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextHeight.Location = new System.Drawing.Point(214, 170);
            this.TextHeight.Name = "TextHeight";
            this.TextHeight.Size = new System.Drawing.Size(149, 22);
            this.TextHeight.TabIndex = 3;
            this.TextHeight.Text = "0";
            this.TextHeight.TextChanged += new System.EventHandler(this.TextHeight_TextChanged);
            // 
            // LabelHeight
            // 
            this.LabelHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHeight.Location = new System.Drawing.Point(211, 149);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(162, 18);
            this.LabelHeight.TabIndex = 10;
            this.LabelHeight.Text = "Frames Height";
            // 
            // CheckCreateAnimation
            // 
            this.CheckCreateAnimation.AutoSize = true;
            this.CheckCreateAnimation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckCreateAnimation.Location = new System.Drawing.Point(213, 207);
            this.CheckCreateAnimation.Name = "CheckCreateAnimation";
            this.CheckCreateAnimation.Size = new System.Drawing.Size(156, 18);
            this.CheckCreateAnimation.TabIndex = 4;
            this.CheckCreateAnimation.Text = "Create a new animation";
            this.CheckCreateAnimation.UseVisualStyleBackColor = true;
            this.CheckCreateAnimation.CheckedChanged += new System.EventHandler(this.CheckCreateAnimation_CheckedChanged);
            // 
            // TextX
            // 
            this.TextX.Enabled = false;
            this.TextX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextX.Location = new System.Drawing.Point(13, 237);
            this.TextX.Name = "TextX";
            this.TextX.Size = new System.Drawing.Size(91, 22);
            this.TextX.TabIndex = 5;
            this.TextX.Text = "0";
            this.TextX.TextChanged += new System.EventHandler(this.TextX_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "X";
            // 
            // TextY
            // 
            this.TextY.Enabled = false;
            this.TextY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextY.Location = new System.Drawing.Point(114, 237);
            this.TextY.Name = "TextY";
            this.TextY.Size = new System.Drawing.Size(91, 22);
            this.TextY.TabIndex = 6;
            this.TextY.Text = "0";
            this.TextY.TextChanged += new System.EventHandler(this.TextY_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y";
            // 
            // LabelColorKey
            // 
            this.LabelColorKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelColorKey.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelColorKey.Location = new System.Drawing.Point(212, 237);
            this.LabelColorKey.Name = "LabelColorKey";
            this.LabelColorKey.Size = new System.Drawing.Size(151, 22);
            this.LabelColorKey.TabIndex = 18;
            this.LabelColorKey.Text = "Color Key";
            this.LabelColorKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelColorKey.Click += new System.EventHandler(this.LabelColorKey_Click);
            // 
            // FormAddAnim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 317);
            this.Controls.Add(this.LabelColorKey);
            this.Controls.Add(this.TextY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckCreateAnimation);
            this.Controls.Add(this.TextHeight);
            this.Controls.Add(this.LabelHeight);
            this.Controls.Add(this.TextWidth);
            this.Controls.Add(this.LabelWidth);
            this.Controls.Add(this.TextFrameCount);
            this.Controls.Add(this.LabelFrameCount);
            this.Controls.Add(this.TextName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.PictureAnimation);
            this.Controls.Add(this.ButtonAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAddAnim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Animação";
            ((System.ComponentModel.ISupportInitialize)(this.PictureAnimation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.PictureBox PictureAnimation;
        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox TextFrameCount;
        private System.Windows.Forms.Label LabelFrameCount;
        private System.Windows.Forms.TextBox TextWidth;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.TextBox TextHeight;
        private System.Windows.Forms.Label LabelHeight;
        private System.Windows.Forms.CheckBox CheckCreateAnimation;
        private System.Windows.Forms.TextBox TextX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelColorKey;
    }
}