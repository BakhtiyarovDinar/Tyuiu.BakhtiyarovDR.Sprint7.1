
namespace Tyuiu.BakhtiyarovDR.Sprint7.Project.V15
{
    partial class FormWriteText
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
            this.textBoxLabelColumn_BDR = new System.Windows.Forms.TextBox();
            this.textBoxInputLabelColumn_BDR = new System.Windows.Forms.TextBox();
            this.buttonOK_BDR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLabelColumn_BDR
            // 
            this.textBoxLabelColumn_BDR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLabelColumn_BDR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLabelColumn_BDR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLabelColumn_BDR.Location = new System.Drawing.Point(0, 0);
            this.textBoxLabelColumn_BDR.Name = "textBoxLabelColumn_BDR";
            this.textBoxLabelColumn_BDR.ReadOnly = true;
            this.textBoxLabelColumn_BDR.Size = new System.Drawing.Size(273, 22);
            this.textBoxLabelColumn_BDR.TabIndex = 0;
            this.textBoxLabelColumn_BDR.TabStop = false;
            this.textBoxLabelColumn_BDR.Text = "Введите название столбца";
            this.textBoxLabelColumn_BDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxInputLabelColumn_BDR
            // 
            this.textBoxInputLabelColumn_BDR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInputLabelColumn_BDR.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInputLabelColumn_BDR.Location = new System.Drawing.Point(16, 38);
            this.textBoxInputLabelColumn_BDR.Name = "textBoxInputLabelColumn_BDR";
            this.textBoxInputLabelColumn_BDR.Size = new System.Drawing.Size(245, 18);
            this.textBoxInputLabelColumn_BDR.TabIndex = 1;
            this.textBoxInputLabelColumn_BDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonOK_BDR
            // 
            this.buttonOK_BDR.Location = new System.Drawing.Point(174, 71);
            this.buttonOK_BDR.Name = "buttonOK_BDR";
            this.buttonOK_BDR.Size = new System.Drawing.Size(87, 27);
            this.buttonOK_BDR.TabIndex = 2;
            this.buttonOK_BDR.Text = "OK";
            this.buttonOK_BDR.UseVisualStyleBackColor = true;
            this.buttonOK_BDR.Click += new System.EventHandler(this.buttonOK_BDR_Click);
            // 
            // FormWriteText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 104);
            this.Controls.Add(this.buttonOK_BDR);
            this.Controls.Add(this.textBoxInputLabelColumn_BDR);
            this.Controls.Add(this.textBoxLabelColumn_BDR);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormWriteText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщение";
            this.Load += new System.EventHandler(this.FormWriteText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLabelColumn_BDR;
        private System.Windows.Forms.TextBox textBoxInputLabelColumn_BDR;
        private System.Windows.Forms.Button buttonOK_BDR;
    }
}