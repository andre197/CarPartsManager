namespace CarPartsManager.App
{
    using Controls;
    using Logic;
    using Logic.Helpers;
    using Logic.Implementations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class MainView : Form
    {
        private List<CarPartsViewHelper> dataSource;

        public IEntityService EntityService { get; set; }
        public ICarPartsService CarPartsService { get; set; }
        public ICarPartsSchemesService CarPartsSchemeService { get; set; }

        public MainView()
        {
            InitializeComponent();

            CarPartsService = new CarPartsService();
            EntityService = new EntityService();
            CarPartsSchemeService = new CarPartsSchemesService();
            CarPartsService.EntityService = EntityService;
        }

        private void buttonAdd_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip("Добавяне на нова част", sender);
        }

        private void buttonEdit_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip("Редактиране на част", sender);
        }

        private void buttonDelete_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip("Изтриване на запис", sender);
        }

        private void buttonDetails_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip("Показване на информация за част", sender);
        }

        private void ShowToolTip(string text, object control)
        {
            toolTipAddButton.Show(text, (Control)control, 0, 25);
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip(sender);
        }

        private void buttonEdit_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip(sender);
        }

        private void buttonDelete_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip(sender);
        }

        private void buttonDetails_MouseLeave(object sender, EventArgs e)
        {
            HideToolTip(sender);
        }

        private void HideToolTip(object sender)
        {
            toolTipAddButton.Hide((Control)sender);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            dataSource = CarPartsService.GetAllParts().ToList();
            bindingSource1.DataSource = dataSource;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var viewControl = new AddEditPartsControl();
            viewControl.CarPartsSchemeService = CarPartsSchemeService;
            viewControl.CarPartsService = CarPartsService;
            viewControl.EntityService = EntityService;
            viewControl.IsNew = true;
            viewControl.Dock = DockStyle.Fill;

            var dialog = new GeneralForm();
            dialog.Text = "Добавяне на част";
            dialog.Size = viewControl.Size;

            dialog.Controls.Add(viewControl);
            viewControl.BringToFront();

            var res = dialog.ShowDialog();

            if (res == DialogResult.OK && viewControl.CarPartsView != null)
            {
                var carPart = CarPartsService.AddEditPart(viewControl.CarPartsView);
                bindingSource1.Add(carPart);
            }

            dataGridView1.Refresh();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var partToEdit = bindingSource1.Current as CarPartsViewHelper;
            if (partToEdit == null)
            {
                MessageBox.Show("Няма избрана част за редакция. Моля изберете част и опитайте отново.", "Няма избрана част за редакция.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var viewControl = new AddEditPartsControl();
            viewControl.CarPartsSchemeService = CarPartsSchemeService;
            viewControl.CarPartsService = CarPartsService;
            viewControl.EntityService = EntityService;
            viewControl.IsNew = false;
            viewControl.Dock = DockStyle.Fill;
            viewControl.CarPartsView = partToEdit;
            var dialog = new GeneralForm();
            dialog.Text = "Редактиране на част";
            dialog.Size = viewControl.Size;

            dialog.Controls.Add(viewControl);
            viewControl.BringToFront();

            var res = dialog.ShowDialog();

            if (res == DialogResult.OK && viewControl.CarPartsView != null)
            {
                CarPartsService.AddEditPart(viewControl.CarPartsView);
            }

            dataGridView1.Refresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var toBeDeleted = bindingSource1.Current as CarPartsViewHelper;
            if (toBeDeleted == null)
            {
                return;
            }
            var partName = toBeDeleted.PartName;

            if (MessageBox.Show($"Наистина ли искате да изтриете част {partName}", "Изтриване на част", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CarPartsService.DeleteCarPartItem(toBeDeleted);
                bindingSource1.Remove(bindingSource1.Current);
                dataGridView1.Refresh();
                MessageBox.Show($"Част {partName} беше изтрита успешно.", "Изтриване на част", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
