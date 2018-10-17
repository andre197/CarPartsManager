namespace CarPartsManager.App.Validations
{
    using Base;
    using System.Windows.Forms;

    public class StringNullOrEmptyValidationRule : IValidationRule
    {
        public string ErrorMessage { get; set; }

        public virtual bool Validate(Control control)
        {
            if (control == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(control.Text) || string.IsNullOrWhiteSpace(control.Text))
            {
                return false;
            }

            return true;
        }
    }
}
