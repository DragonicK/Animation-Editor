namespace Animation_Editor {
    partial class FormExport {
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
            this.LabelAnimID = new System.Windows.Forms.Label();
            this.TextAnimationID = new System.Windows.Forms.TextBox();
            this.ButtonExport = new System.Windows.Forms.Button();
            this.LabelFrameCount = new System.Windows.Forms.Label();
            this.LabelWidth = new System.Windows.Forms.Label();
            this.LabelHeight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelAnimID
            // 
            this.LabelAnimID.BackColor = System.Drawing.SystemColors.Control;
            this.LabelAnimID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAnimID.Location = new System.Drawing.Point(34, 22);
            this.LabelAnimID.Name = "LabelAnimID";
            this.LabelAnimID.Size = new System.Drawing.Size(97, 18);
            this.LabelAnimID.TabIndex = 0;
            this.LabelAnimID.Text = "Animation ID :";
            // 
            // TextAnimationID
            // 
            this.TextAnimationID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAnimationID.Location = new System.Drawing.Point(137, 19);
            this.TextAnimationID.Name = "TextAnimationID";
            this.TextAnimationID.Size = new System.Drawing.Size(100, 22);
            this.TextAnimationID.TabIndex = 1;
            this.TextAnimationID.Text = "0";
            this.TextAnimationID.TextChanged += new System.EventHandler(this.TextAnimationID_TextChanged);
            this.TextAnimationID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextAnimationID_KeyPress);
            // 
            // ButtonExport
            // 
            this.ButtonExport.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonExport.Location = new System.Drawing.Point(76, 112);
            this.ButtonExport.Name = "ButtonExport";
            this.ButtonExport.Size = new System.Drawing.Size(120, 21);
            this.ButtonExport.TabIndex = 17;
            this.ButtonExport.Text = "Exportar";
            this.ButtonExport.UseVisualStyleBackColor = true;
            this.ButtonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // LabelFrameCount
            // 
            this.LabelFrameCount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameCount.Location = new System.Drawing.Point(34, 44);
            this.LabelFrameCount.Name = "LabelFrameCount";
            this.LabelFrameCount.Size = new System.Drawing.Size(185, 18);
            this.LabelFrameCount.TabIndex = 18;
            this.LabelFrameCount.Text = "Frame Count : 0";
            // 
            // LabelWidth
            // 
            this.LabelWidth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelWidth.Location = new System.Drawing.Point(34, 64);
            this.LabelWidth.Name = "LabelWidth";
            this.LabelWidth.Size = new System.Drawing.Size(185, 18);
            this.LabelWidth.TabIndex = 19;
            this.LabelWidth.Text = "Width : 0";
            // 
            // LabelHeight
            // 
            this.LabelHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelHeight.Location = new System.Drawing.Point(34, 84);
            this.LabelHeight.Name = "LabelHeight";
            this.LabelHeight.Size = new System.Drawing.Size(185, 18);
            this.LabelHeight.TabIndex = 20;
            this.LabelHeight.Text = "Height : 0";
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 145);
            this.Controls.Add(this.LabelHeight);
            this.Controls.Add(this.LabelWidth);
            this.Controls.Add(this.LabelFrameCount);
            this.Controls.Add(this.ButtonExport);
            this.Controls.Add(this.TextAnimationID);
            this.Controls.Add(this.LabelAnimID);
            this.MaximizeBox = false;
            this.Name = "FormExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Animation Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelAnimID;
        private System.Windows.Forms.TextBox TextAnimationID;
        private System.Windows.Forms.Button ButtonExport;
        private System.Windows.Forms.Label LabelFrameCount;
        private System.Windows.Forms.Label LabelWidth;
        private System.Windows.Forms.Label LabelHeight;
    }
}