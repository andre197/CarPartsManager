namespace CarPartsManager.App
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MakerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.toolTipAddButton = new System.Windows.Forms.ToolTip(this.components);
            this.panelSearch = new System.Windows.Forms.Panel();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.textBoxMaker = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPartType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUniqueNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.groupBoxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MakerName,
            this.PartName,
            this.quantityDataGridViewTextBoxColumn,
            this.CreationDate,
            this.Model,
            this.makerNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 164);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 286);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // MakerName
            // 
            this.MakerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MakerName.DataPropertyName = "PartUniqueNumber";
            this.MakerName.HeaderText = "Уникален номер на частта";
            this.MakerName.Name = "MakerName";
            this.MakerName.ReadOnly = true;
            // 
            // PartName
            // 
            this.PartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PartName.DataPropertyName = "PartName";
            this.PartName.HeaderText = "Тип част";
            this.PartName.Name = "PartName";
            this.PartName.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CreationDate
            // 
            this.CreationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreationDate.DataPropertyName = "CreationDate";
            this.CreationDate.HeaderText = "Дата на производство";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            // 
            // Model
            // 
            this.Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Model.DataPropertyName = "Model";
            this.Model.HeaderText = "Модел";
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            // 
            // makerNameDataGridViewTextBoxColumn
            // 
            this.makerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.makerNameDataGridViewTextBoxColumn.DataPropertyName = "MakerName";
            this.makerNameDataGridViewTextBoxColumn.HeaderText = "Марка";
            this.makerNameDataGridViewTextBoxColumn.Name = "makerNameDataGridViewTextBoxColumn";
            this.makerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CarPartsManager.Logic.Helpers.CarPartsViewHelper);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.buttonDetails);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::CarPartsManager.App.Properties.Resources.search_button;
            this.buttonSearch.Location = new System.Drawing.Point(144, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(27, 27);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            this.buttonSearch.MouseLeave += new System.EventHandler(this.buttonSearch_MouseLeave);
            this.buttonSearch.MouseHover += new System.EventHandler(this.button1_MouseHover);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Image = global::CarPartsManager.App.Properties.Resources.info_button;
            this.buttonDetails.Location = new System.Drawing.Point(111, 12);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(27, 27);
            this.buttonDetails.TabIndex = 3;
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            this.buttonDetails.MouseLeave += new System.EventHandler(this.buttonDetails_MouseLeave);
            this.buttonDetails.MouseHover += new System.EventHandler(this.buttonDetails_MouseHover);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::CarPartsManager.App.Properties.Resources.delete_button;
            this.buttonDelete.Location = new System.Drawing.Point(78, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(27, 27);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.MouseLeave += new System.EventHandler(this.buttonDelete_MouseLeave);
            this.buttonDelete.MouseHover += new System.EventHandler(this.buttonDelete_MouseHover);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Image = global::CarPartsManager.App.Properties.Resources.edit_button;
            this.buttonEdit.Location = new System.Drawing.Point(45, 12);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(27, 27);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            this.buttonEdit.MouseLeave += new System.EventHandler(this.buttonEdit_MouseLeave);
            this.buttonEdit.MouseHover += new System.EventHandler(this.buttonEdit_MouseHover);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.SystemColors.Control;
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonAdd.Image = global::CarPartsManager.App.Properties.Resources.add_button;
            this.buttonAdd.Location = new System.Drawing.Point(12, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(27, 27);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            this.buttonAdd.MouseLeave += new System.EventHandler(this.buttonAdd_MouseLeave);
            this.buttonAdd.MouseHover += new System.EventHandler(this.buttonAdd_MouseHover);
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.groupBoxFilter);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 50);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(800, 114);
            this.panelSearch.TabIndex = 2;
            this.panelSearch.Visible = false;
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.textBoxMaker);
            this.groupBoxFilter.Controls.Add(this.label5);
            this.groupBoxFilter.Controls.Add(this.textBoxModel);
            this.groupBoxFilter.Controls.Add(this.label4);
            this.groupBoxFilter.Controls.Add(this.textBoxPartType);
            this.groupBoxFilter.Controls.Add(this.label2);
            this.groupBoxFilter.Controls.Add(this.textBoxUniqueNumber);
            this.groupBoxFilter.Controls.Add(this.label1);
            this.groupBoxFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(800, 114);
            this.groupBoxFilter.TabIndex = 0;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Търсене:";
            // 
            // textBoxMaker
            // 
            this.textBoxMaker.Location = new System.Drawing.Point(424, 60);
            this.textBoxMaker.Name = "textBoxMaker";
            this.textBoxMaker.Size = new System.Drawing.Size(100, 22);
            this.textBoxMaker.TabIndex = 9;
            this.textBoxMaker.Tag = "MakerName";
            this.textBoxMaker.TextChanged += new System.EventHandler(this.textBoxUniqueNumber_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(421, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 38);
            this.label5.TabIndex = 8;
            this.label5.Text = "Марка:";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(303, 60);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(100, 22);
            this.textBoxModel.TabIndex = 7;
            this.textBoxModel.Tag = "Model";
            this.textBoxModel.TextChanged += new System.EventHandler(this.textBoxUniqueNumber_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(300, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 38);
            this.label4.TabIndex = 6;
            this.label4.Text = "Модел:";
            // 
            // textBoxPartType
            // 
            this.textBoxPartType.Location = new System.Drawing.Point(176, 60);
            this.textBoxPartType.Name = "textBoxPartType";
            this.textBoxPartType.Size = new System.Drawing.Size(100, 22);
            this.textBoxPartType.TabIndex = 3;
            this.textBoxPartType.Tag = "PartName";
            this.textBoxPartType.TextChanged += new System.EventHandler(this.textBoxUniqueNumber_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(173, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 38);
            this.label2.TabIndex = 2;
            this.label2.Text = "Тип част:";
            // 
            // textBoxUniqueNumber
            // 
            this.textBoxUniqueNumber.Location = new System.Drawing.Point(43, 60);
            this.textBoxUniqueNumber.Name = "textBoxUniqueNumber";
            this.textBoxUniqueNumber.Size = new System.Drawing.Size(100, 22);
            this.textBoxUniqueNumber.TabIndex = 1;
            this.textBoxUniqueNumber.Tag = "PartUniqueNumber";
            this.textBoxUniqueNumber.TextChanged += new System.EventHandler(this.textBoxUniqueNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Уникален номер:";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "Мениджър на части";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ToolTip toolTipAddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn MakerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn makerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPartType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUniqueNumber;
    }
}

