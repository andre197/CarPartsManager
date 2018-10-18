namespace CarPartsManager.App.Controls
{
    using Base;
    using Logic;
    using Logic.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Validations;

    public partial class AddEditPartsControl : BaseControl
    {
        private LinkedListNode<Image> currentImage;

        public AddEditPartsControl()
        {
            InitializeComponent();
        }

        public bool IsNew { get; set; }
        public IEntityService EntityService { get; set; }
        public ICarPartsService CarPartsService { get; set; }
        public ICarPartsSchemesService CarPartsSchemeService { get; set; }
        public CarPartsViewHelper CarPartsView { get; set; }
        public LinkedList<Image> Images { get; set; } = new LinkedList<Image>();

        private void AddEditPartsControl_Load(object sender, EventArgs e)
        {
            EnableDisableBackwardsAndForwardButtons();
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
                currentImage = Images.First;
                pictureBox1.Image = currentImage.Value;
                EnableDisableBackwardsAndForwardButtons();
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

            var schemesValidationRule = new SchemesValidationRule();
            schemesValidationRule.ErrorMessage = "Моля изберете поне една схема за тази част";
            Validator.AddValidation(pictureBox1, schemesValidationRule);
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
            if (!Validator.Validate())
            {
                return;
            }
            
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
        
        private void buttonSchemeSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image|*.png;*.gif;*.jpg;*.jpeg" +
                         "|All files|*.*";

            ofd.CheckFileExists = true;
            var res = ofd.ShowDialog();

            if (res == DialogResult.OK)
            {
                var fileName = ofd.FileName;
                if (File.Exists(fileName))
                {
                    Image img = Image.FromFile(fileName);
                    currentImage = Images.AddLast(img);
                    pictureBox1.Image = currentImage.Value;

                    EnableDisableBackwardsAndForwardButtons();
                }
                else
                {
                    MessageBox.Show("Избрания файл не съществува! Моля опитайте отвново.", "Избор на файл", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonBackwards_Click(object sender, EventArgs e)
        {
            currentImage = currentImage.Previous;
            pictureBox1.Image = currentImage.Value;
            EnableDisableBackwardsAndForwardButtons();
        }

        private void EnableDisableBackwardsAndForwardButtons()
        {
            if (currentImage == null)
            {
                buttonBackwards.Enabled = false;
                buttonForward.Enabled = false;
                buttonDelete.Enabled = false;
                return;
            }
            else
            {
                buttonDelete.Enabled = true;
            }
            if (currentImage.Previous == null)
            {
                buttonBackwards.Enabled = false;
            }
            else
            {
                buttonBackwards.Enabled = true;
            }
            if (currentImage.Next == null)
            {
                buttonForward.Enabled = false;
            }
            else
            {
                buttonForward.Enabled = true;
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            currentImage = currentImage.Next;
            pictureBox1.Image = currentImage.Value;
            EnableDisableBackwardsAndForwardButtons();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentImage.Previous == null && currentImage.Next == null)
            {
                Images.Remove(currentImage);
                currentImage = null;
                pictureBox1.Image = Properties.Resources.Default_image;
                EnableDisableBackwardsAndForwardButtons();
                return;
            }
            else if (currentImage.Previous == null)
            {
                var imageToBeCurrent = currentImage.Next;
                Images.Remove(currentImage);
                currentImage = imageToBeCurrent;
            }
            else if (currentImage.Next == null)
            {
                var imageToBeCurrent = currentImage.Previous;
                Images.Remove(currentImage);
                currentImage = imageToBeCurrent;
            }

            pictureBox1.Image = currentImage.Value;
            EnableDisableBackwardsAndForwardButtons();
        }
    }
}
