namespace CarPartsManager.App
{
    using Controls;
    using Logic;
    using Logic.Helpers;
    using Logic.Implementations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Windows.Forms;

    public partial class MainView : Form
    {
        private List<CarPartsViewHelper> dataSource;
        private bool isAscending = false;
        private Dictionary<string, string> filter = new Dictionary<string, string>();

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
            CarPartsSchemeService.EntityService = EntityService;
            panelSearch.Visible = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ShowToolTip("Търсене", sender);
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

        private void buttonSearch_MouseLeave(object sender, EventArgs e)
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

                IEnumerable<CarPartsSchemeHelper> schemes = ConvertImagesToCarPartsSchemeHelperHelpers(viewControl.Images, carPart.PartId);
                CarPartsSchemeService.AddCarPartSchemes(schemes);
            }

            dataGridView1.Refresh();
        }

        private IEnumerable<CarPartsSchemeHelper> ConvertImagesToCarPartsSchemeHelperHelpers(IEnumerable<Image> images, int partId)
        {
            var res = new List<CarPartsSchemeHelper>();
            MemoryStream ms;

            foreach (var item in images)
            {
                using (ms = new MemoryStream())
                {
                    item.Save(ms, item.RawFormat);

                    res.Add(new CarPartsSchemeHelper()
                    {
                        PartId = partId,
                        Scheme = ms.ToArray()
                    });
                }
            }

            return res;
        }
        private IEnumerable<Image> ConvertCarPartsSchemeHelperHelpersToImages(IEnumerable<CarPartsSchemeHelper> images)
        {
            var res = new List<Image>();
            MemoryStream ms;

            foreach (var item in images)
            {
                using (ms = new MemoryStream(item.Scheme, 0, item.Scheme.Length))
                {
                    res.Add(Image.FromStream(ms));
                }
            }

            return res;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var partToEdit = bindingSource1.Current as CarPartsViewHelper;
            if (partToEdit == null)
            {
                MessageBox.Show("Няма избрана част за редакция. Моля изберете част и опитайте отново.", "Няма избрана част за редакция.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var schemes = CarPartsSchemeService.GetCarPartsSchemesByPartId(partToEdit.PartId);
            var images = ConvertCarPartsSchemeHelperHelpersToImages(schemes);

            var viewControl = new AddEditPartsControl();
            viewControl.CarPartsSchemeService = CarPartsSchemeService;
            viewControl.CarPartsService = CarPartsService;
            viewControl.EntityService = EntityService;
            viewControl.IsNew = false;
            viewControl.Dock = DockStyle.Fill;
            viewControl.CarPartsView = partToEdit;
            viewControl.Images = new LinkedList<Image>(images);

            var dialog = new GeneralForm();
            dialog.Text = "Редактиране на част";
            dialog.Size = viewControl.Size;

            dialog.Controls.Add(viewControl);
            viewControl.BringToFront();

            var res = dialog.ShowDialog();

            if (res == DialogResult.OK && viewControl.CarPartsView != null)
            {
                var carPart = CarPartsService.AddEditPart(viewControl.CarPartsView);

                CarPartsSchemeService.DeleteSchemesForPart(carPart.PartId);
                schemes = ConvertImagesToCarPartsSchemeHelperHelpers(viewControl.Images, carPart.PartId);
                CarPartsSchemeService.AddCarPartSchemes(schemes);
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var sortString = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            sortString += (isAscending ? " DESC" : " ASC");
            isAscending = !isAscending;

            var currentData = (List<CarPartsViewHelper>)bindingSource1.DataSource;
            bindingSource1.DataSource = currentData.OrderBy(sortString).ToList();

            dataGridView1.Refresh();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = !panelSearch.Visible;
        }

        private void textBoxUniqueNumber_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is TextBox tb))
            {
                return;
            }

            var propName = tb.Tag.ToString();
            if (!filter.ContainsKey(propName))
            {
                filter.Add(propName, "");
            }

            filter[propName] = tb.Text;

            Filter();
        }

        private void Filter()
        {
            var whereString = "";
            foreach (var item in filter)
            {
                if (string.IsNullOrEmpty(item.Value) || string.IsNullOrWhiteSpace(item.Value))
                {
                    continue;
                }

                whereString += item.Key + ".Contains(\"" + item.Value + "\") and ";
            }

            if (whereString.EndsWith(" and "))
            {
                var indexOfAnd = whereString.LastIndexOf(" and ");
                whereString = whereString.Substring(0, indexOfAnd);
            }

            var dataToShow = dataSource;
            if (whereString != "")
            {
                dataToShow = dataSource.AsEnumerable().Where(whereString).ToList();
            }

            bindingSource1.DataSource = dataToShow;
            dataGridView1.Refresh();
        }
    }
}
