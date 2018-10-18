namespace CarPartsManager.App.Validations
{
    using Base;
    using System.Drawing;
    using System.Windows.Forms;

    public class SchemesValidationRule : IValidationRule
    {
        public string ErrorMessage { get; set; }

        public bool Validate(Control control)
        {
            if (control == null)
            {
                return false;
            }

            if (control is PictureBox pb)
            {
                return pb.Image != null;
            }
            return false;
        }
    }
}
