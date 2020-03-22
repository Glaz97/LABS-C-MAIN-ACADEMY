namespace Part_2_LabWork_4._1
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnNo = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.MdiP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "HOW ARE YOU, BITCH!?";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(15, 49);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "OKEY";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnNo
            // 
            this.BtnNo.Location = new System.Drawing.Point(104, 49);
            this.BtnNo.Name = "BtnNo";
            this.BtnNo.Size = new System.Drawing.Size(75, 23);
            this.BtnNo.TabIndex = 2;
            this.BtnNo.Text = "NO";
            this.BtnNo.UseVisualStyleBackColor = true;
            this.BtnNo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BtnNo_MouseMove);
            // 
            // BtnNext
            // 
            this.BtnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnNext.Location = new System.Drawing.Point(104, 78);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 3;
            this.BtnNext.Text = "EXTENDED BITCH!";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // MdiP
            // 
            this.MdiP.Location = new System.Drawing.Point(192, 49);
            this.MdiP.Name = "MdiP";
            this.MdiP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MdiP.Size = new System.Drawing.Size(75, 23);
            this.MdiP.TabIndex = 5;
            this.MdiP.Text = "MDI-P";
            this.MdiP.UseVisualStyleBackColor = true;
            this.MdiP.Click += new System.EventHandler(this.MdiP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 149);
            this.Controls.Add(this.MdiP);
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.BtnNo);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Part 2 LabWork 4.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnNo;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button MdiP;
    }
}

