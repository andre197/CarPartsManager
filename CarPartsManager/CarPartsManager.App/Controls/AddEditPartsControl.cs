namespace CarPartsManager.App.Controls
{
    using Base;
    using Logic;
    using Logic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Validations;

    public partial class AddEditPartsControl : BaseControl
    {
        public AddEditPartsControl()
        {
            InitializeComponent();
        }

        public bool IsNew { get; set; }
        public IEntityService EntityService { get; set; }
        public ICarPartsService CarPartsService { get; set; }
        public ICarPartsSchemesService CarPartsSchemeService { get; set; }
        public CarPartsViewHelper CarPartsView { get; set; }

        private void AddEditPartsControl_Load(object sender, EventArgs e)
        {
            SetMakerComboboxItems();

            if (!IsNew)
            {
                foreach (var item in comboBox1.Items)
                {
                    var carMaker = (CarMakerHelper)item;
                    if (carMaker.Name == CarPartsView.MakerName)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
                SetModelComboboxItems();

                foreach (var item in comboBoxModel.Items)
                {
                    var carMaker = (CarModelHelper)item;
                    if (carMaker.ModelName == CarPartsView.Model)
                    {
                        comboBoxModel.SelectedItem = item;
                        break;
                    }
                }

                comboBox1.Enabled = false;
                buttonAddMaker.Enabled = false;
                comboBoxModel.Enabled = false;
                buttonAddModel.Enabled = false;

                textBoxPartName.Text = CarPartsView.PartName;
                textBoxUniqueNumber.Text = CarPartsView.PartUniqueNumber;
                numericUpDown1.Value = CarPartsView.Quantity;

                var uniqueNumberValidationRule = new UniqueNumberValidationRule(EntityService.GetEntities(), CarPartsView.PartId, false);
                uniqueNumberValidationRule.ErrorMessage = "Вече съществува част със този уникален номер или полето е празно!";
                Validator.AddValidation(textBoxUniqueNumber, uniqueNumberValidationRule);
            }
            else
            {
                var uniqueNumberValidationRule = new UniqueNumberValidationRule(EntityService.GetEntities(), -1, true);
                uniqueNumberValidationRule.ErrorMessage = "Вече съществува част със този уникален номер или полето е празно!";
                Validator.AddValidation(textBoxUniqueNumber, uniqueNumberValidationRule);
            }

            var textBoxPartNameValidationRule = new StringNullOrEmptyValidationRule();
            textBoxPartNameValidationRule.ErrorMessage = "Полето име на частта не може да бъде празно!";
            Validator.AddValidation(textBoxPartName, textBoxPartNameValidationRule);

            var makerComboboxValidationRule = new ComboboxSelectedItemValidationRule();
            makerComboboxValidationRule.ErrorMessage = "Не е избрана марка!";
            Validator.AddValidation(comboBox1, makerComboboxValidationRule);

            var modelComboboxValidationRule = new ComboboxSelectedItemValidationRule();
            modelComboboxValidationRule.ErrorMessage = "Не е избран модел!";
            Validator.AddValidation(comboBoxModel, modelComboboxValidationRule);
        }

        private void SetModelComboboxItems()
        {
            CarMakerHelper maker = (CarMakerHelper)comboBox1.SelectedItem;
            comboBoxModel.Items.Clear();
            comboBoxModel.Items.AddRange(maker.Models.ToArray());
        }

        private void SetMakerComboboxItems()
        {
            comboBox1.Items.AddRange(CarPartsService.GetAllCarMakers().ToArray());
        }

        private void AddEditPartsControl_Leave(object sender, EventArgs e)
        {
            if (IsNew)
            {
                CarMakerHelper maker = (CarMakerHelper)comboBox1.SelectedItem;
                var selectedModel = (CarModelHelper)comboBoxModel.SelectedItem;

                CarPartsView = new CarPartsViewHelper()
                {
                    CreationDate = new DateTime(int.Parse(selectedModel.CreationDate), 1, 1),
                    Model = selectedModel.ModelName,
                    PartName = textBoxPartName.Text,
                    MakerName = maker.Name,
                    PartUniqueNumber = textBoxUniqueNumber.Text,
                    Quantity = (int)numericUpDown1.Value,
                    MakerId = maker.Id,
                    ModelId = selectedModel.Id
                };
            }
            else
            {
                CarPartsView.PartName = textBoxPartName.Text;
                CarPartsView.Quantity = (int)numericUpDown1.Value;
                CarPartsView.PartUniqueNumber = textBoxUniqueNumber.Text;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetModelComboboxItems();
        }

        private void buttonAddMaker_Click(object sender, EventArgs e)
        {
            var viewControl = new AddMakerControl();
            viewControl.Entity = EntityService.GetEntities();
            viewControl.Dock = DockStyle.Fill;
            var dialog = new GeneralForm();
            dialog.Text = "Добавяне на марка";
            dialog.Size = viewControl.Size;

            dialog.Controls.Add(viewControl);
            viewControl.BringToFront();

            var res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                var item = new CarMakerHelper
                {
                    Name = viewControl.CarMakerName,
                    Models = new List<CarModelHelper>()
                };

                comboBox1.Items.Add(item);
                comboBox1.SelectedItem = item;
            }
        }

        private void buttonAddModel_Click(object sender, EventArgs e)
        {
            var viewControl = new AddModelControl();
            viewControl.Dock = DockStyle.Fill;
            var dialog = new GeneralForm();
            dialog.Text = "Добавяне на модел";
            dialog.Size = viewControl.Size;

            dialog.Controls.Add(viewControl);
            viewControl.BringToFront();

            var res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                var item = new CarModelHelper
                {
                    ModelName = viewControl.CarModelName,
                    CreationDate = viewControl.CreationDate
                };

                comboBoxModel.Items.Add(item);
                comboBoxModel.SelectedItem = item;
            }
        }
    }
}
