namespace CarPartsManager.App.Controls
{
    partial class AddMakerControl
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
            this.labelMakerName = new System.Windows.Forms.Label();
            this.textBoxMaker = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelMakerName
            // 
            this.labelMakerName.AutoSize = true;
            this.labelMakerName.Location = new System.Drawing.Point(3, 22);
            this.labelMakerName.Name = "labelMakerName";
            this.labelMakerName.Size = new System.Drawing.Size(54, 17);
            this.labelMakerName.TabIndex = 0;
            this.labelMakerName.Text = "Марка:";
            // 
            // textBoxMaker
            // 
            this.textBoxMaker.Location = new System.Drawing.Point(63, 19);
            this.textBoxMaker.Name = "textBoxMaker";
            this.textBoxMaker.Size = new System.Drawing.Size(189, 22);
            this.textBoxMaker.TabIndex = 1;
            // 
            // AddMakerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxMaker);
            this.Controls.Add(this.labelMakerName);
            this.Name = "AddMakerControl";
            this.Size = new System.Drawing.Size(317, 184);
            this.Load += new System.EventHandler(this.AddMakerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMakerName;
        private System.Windows.Forms.TextBox textBoxMaker;
    }
}
