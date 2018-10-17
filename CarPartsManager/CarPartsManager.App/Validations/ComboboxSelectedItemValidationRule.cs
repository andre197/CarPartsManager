namespace CarPartsManager.App.Validations
{
    using Base;
    using System.Windows.Forms;

    public class ComboboxSelectedItemValidationRule : IValidationRule
    {
        public string ErrorMessage { get; set; }

        public bool Validate(Control control)
        {
            if (control == null)
            {
                return false;
            }

            if (control is ComboBox cb)
            {
                if (cb.SelectedItem == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
