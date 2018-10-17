namespace CarPartsManager.App.Validations
{
    using Base;
    using System.Windows.Forms;

    public class CreationYearValidationRule : IValidationRule
    {
        public string ErrorMessage { get; set; }

        public bool Validate(Control control)
        {
            if (control == null)
            {
                return false;
            }

            if (control.Text == null)
            {
                return false;
            }

            if (!int.TryParse(control.Text, out int creationYear))
            {
                return false;
            }

            if (creationYear <= 1900 || creationYear > 9999)
            {
                return false;
            }

            return true;
        }
    }
}
