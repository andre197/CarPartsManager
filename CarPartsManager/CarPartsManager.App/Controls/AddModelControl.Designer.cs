namespace CarPartsManager.App.Controls
{
    partial class AddModelControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelModelName = new System.Windows.Forms.Label();
            this.textBoxModelName = new System.Windows.Forms.TextBox();
            this.textBoxCrationYear = new System.Windows.Forms.TextBox();
            this.labelCreationYear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelModelName
            // 
            this.labelModelName.AutoSize = true;
            this.labelModelName.Location = new System.Drawing.Point(3, 22);
            this.labelModelName.Name = "labelModelName";
            this.labelModelName.Size = new System.Drawing.Size(104, 17);
            this.labelModelName.TabIndex = 0;
            this.labelModelName.Text = "Име на модел:";
            // 
            // textBoxModelName
            // 
            this.textBoxModelName.Location = new System.Drawing.Point(184, 19);
            this.textBoxModelName.Name = "textBoxModelName";
            this.textBoxModelName.Size = new System.Drawing.Size(146, 22);
            this.textBoxModelName.TabIndex = 1;
            // 
            // textBoxCrationYear
            // 
            this.textBoxCrationYear.Location = new System.Drawing.Point(184, 45);
            this.textBoxCrationYear.Name = "textBoxCrationYear";
            this.textBoxCrationYear.Size = new System.Drawing.Size(146, 22);
            this.textBoxCrationYear.TabIndex = 3;
            // 
            // labelCreationYear
            // 
            this.labelCreationYear.AutoSize = true;
            this.labelCreationYear.Location = new System.Drawing.Point(3, 48);
            this.labelCreationYear.Name = "labelCreationYear";
            this.labelCreationYear.Size = new System.Drawing.Size(175, 17);
            this.labelCreationYear.TabIndex = 2;
            this.labelCreationYear.Text = "Година на производство:";
            // 
            // AddModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxCrationYear);
            this.Controls.Add(this.labelCreationYear);
            this.Controls.Add(this.textBoxModelName);
            this.Controls.Add(this.labelModelName);
            this.Name = "AddModelControl";
            this.Size = new System.Drawing.Size(410, 206);
            this.Load += new System.EventHandler(this.AddModelControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelModelName;
        private System.Windows.Forms.TextBox textBoxModelName;
        private System.Windows.Forms.TextBox textBoxCrationYear;
        private System.Windows.Forms.Label labelCreationYear;
    }
}
