namespace CarPartsManager.App.Controls
{
    partial class AddEditPartsControl
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
            this.components = new System.ComponentModel.Container();
            this.labelMaker = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonAddMaker = new System.Windows.Forms.Button();
            this.buttonAddModel = new System.Windows.Forms.Button();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.textBoxPartName = new System.Windows.Forms.TextBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBoxUniqueNumber = new System.Windows.Forms.TextBox();
            this.labelUniqueNumber = new System.Windows.Forms.Label();
            this.labelScheme = new System.Windows.Forms.Label();
            this.buttonSchemeSearch = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemRemoveImage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMaker
            // 
            this.labelMaker.AutoSize = true;
            this.labelMaker.Location = new System.Drawing.Point(3, 13);
            this.labelMaker.Name = "labelMaker";
            this.labelMaker.Size = new System.Drawing.Size(54, 17);
            this.labelMaker.TabIndex = 0;
            this.labelMaker.Text = "Марка:";
            this.labelMaker.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(173, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonAddMaker
            // 
            this.buttonAddMaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddMaker.Image = global::CarPartsManager.App.Properties.Resources.add_button;
            this.buttonAddMaker.Location = new System.Drawing.Point(388, 9);
            this.buttonAddMaker.Name = "buttonAddMaker";
            this.buttonAddMaker.Size = new System.Drawing.Size(25, 25);
            this.buttonAddMaker.TabIndex = 2;
            this.buttonAddMaker.UseVisualStyleBackColor = true;
            this.buttonAddMaker.Click += new System.EventHandler(this.buttonAddMaker_Click);
            // 
            // buttonAddModel
            // 
            this.buttonAddModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddModel.Image = global::CarPartsManager.App.Properties.Resources.add_button;
            this.buttonAddModel.Location = new System.Drawing.Point(388, 54);
            this.buttonAddModel.Name = "buttonAddModel";
            this.buttonAddModel.Size = new System.Drawing.Size(25, 25);
            this.buttonAddModel.TabIndex = 5;
            this.buttonAddModel.UseVisualStyleBackColor = true;
            this.buttonAddModel.Click += new System.EventHandler(this.buttonAddModel_Click);
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Location = new System.Drawing.Point(173, 55);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(184, 24);
            this.comboBoxModel.TabIndex = 4;
            // 
            // labelModel
            // 
            this.labelModel.AutoSize = true;
            this.labelModel.Location = new System.Drawing.Point(3, 58);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(55, 17);
            this.labelModel.TabIndex = 3;
            this.labelModel.Text = "Модел:";
            this.labelModel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(3, 98);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(93, 17);
            this.labelType.TabIndex = 9;
            this.labelType.Text = "Име на част:";
            // 
            // textBoxPartName
            // 
            this.textBoxPartName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPartName.Location = new System.Drawing.Point(173, 98);
            this.textBoxPartName.Name = "textBoxPartName";
            this.textBoxPartName.Size = new System.Drawing.Size(184, 22);
            this.textBoxPartName.TabIndex = 10;
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(3, 133);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(86, 17);
            this.labelQuantity.TabIndex = 11;
            this.labelQuantity.Text = "Количество";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(173, 133);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(184, 22);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxUniqueNumber
            // 
            this.textBoxUniqueNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUniqueNumber.Location = new System.Drawing.Point(173, 172);
            this.textBoxUniqueNumber.Name = "textBoxUniqueNumber";
            this.textBoxUniqueNumber.Size = new System.Drawing.Size(184, 22);
            this.textBoxUniqueNumber.TabIndex = 14;
            // 
            // labelUniqueNumber
            // 
            this.labelUniqueNumber.AutoSize = true;
            this.labelUniqueNumber.Location = new System.Drawing.Point(3, 172);
            this.labelUniqueNumber.Name = "labelUniqueNumber";
            this.labelUniqueNumber.Size = new System.Drawing.Size(121, 17);
            this.labelUniqueNumber.TabIndex = 13;
            this.labelUniqueNumber.Text = "Уникален номер:";
            // 
            // labelScheme
            // 
            this.labelScheme.AutoSize = true;
            this.labelScheme.Location = new System.Drawing.Point(3, 224);
            this.labelScheme.Name = "labelScheme";
            this.labelScheme.Size = new System.Drawing.Size(115, 17);
            this.labelScheme.TabIndex = 15;
            this.labelScheme.Text = "Избор на скици:";
            // 
            // buttonSchemeSearch
            // 
            this.buttonSchemeSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSchemeSearch.Location = new System.Drawing.Point(173, 224);
            this.buttonSchemeSearch.Name = "buttonSchemeSearch";
            this.buttonSchemeSearch.Size = new System.Drawing.Size(184, 23);
            this.buttonSchemeSearch.TabIndex = 16;
            this.buttonSchemeSearch.Text = "Търсене...";
            this.buttonSchemeSearch.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemRemoveImage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(242, 28);
            // 
            // toolStripMenuItemRemoveImage
            // 
            this.toolStripMenuItemRemoveImage.Name = "toolStripMenuItemRemoveImage";
            this.toolStripMenuItemRemoveImage.Size = new System.Drawing.Size(241, 24);
            this.toolStripMenuItemRemoveImage.Text = "Премахване на снимка";
            // 
            // AddEditPartsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSchemeSearch);
            this.Controls.Add(this.labelScheme);
            this.Controls.Add(this.textBoxUniqueNumber);
            this.Controls.Add(this.labelUniqueNumber);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.textBoxPartName);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.buttonAddModel);
            this.Controls.Add(this.comboBoxModel);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.buttonAddMaker);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelMaker);
            this.Name = "AddEditPartsControl";
            this.Size = new System.Drawing.Size(416, 387);
            this.Load += new System.EventHandler(this.AddEditPartsControl_Load);
            this.Leave += new System.EventHandler(this.AddEditPartsControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMaker;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonAddMaker;
        private System.Windows.Forms.Button buttonAddModel;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox textBoxPartName;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBoxUniqueNumber;
        private System.Windows.Forms.Label labelUniqueNumber;
        private System.Windows.Forms.Label labelScheme;
        private System.Windows.Forms.Button buttonSchemeSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveImage;
    }
}
