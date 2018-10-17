namespace CarPartsManager.App.Controls
{
    using Base;
    using DAL;
    using Validations;

    public partial class AddMakerControl : BaseControl
    {
        public AddMakerControl()
        {
            InitializeComponent();
        }

        public CarPartsManagerEntities Entity { get; set; }
        public string CarMakerName { get => textBoxMaker.Text; }

        private void AddMakerControl_Load(object sender, System.EventArgs e)
        {
            var validationRule = new UniqueMakerNameValidationRule(Entity);
            validationRule.ErrorMessage = "Марка със същото име вече съществува или полето не може да бъде празно!";
            Validator.AddValidation(textBoxMaker, validationRule);
        }
    }
}
