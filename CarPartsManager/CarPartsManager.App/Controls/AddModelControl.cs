namespace CarPartsManager.App.Controls
{
    using Base;
    using Validations;

    public partial class AddModelControl : BaseControl
    {
        public AddModelControl()
        {
            InitializeComponent();
        }

        public string CarModelName { get => textBoxModelName.Text; }
        public string CreationDate { get => textBoxCrationYear.Text; }

        private void AddModelControl_Load(object sender, System.EventArgs e)
        {
            var modelNameValidationRule = new StringNullOrEmptyValidationRule();
            modelNameValidationRule.ErrorMessage = "Полето не може да бъде празно!";
            Validator.AddValidation(textBoxModelName, modelNameValidationRule);

            var creationYearValidationRule = new CreationYearValidationRule();
            creationYearValidationRule.ErrorMessage = "Полето трябва да съдържа число между 1900 и 9999 и не трябва да бъде празно!";
            Validator.AddValidation(textBoxCrationYear, creationYearValidationRule);
        }
    }
}
