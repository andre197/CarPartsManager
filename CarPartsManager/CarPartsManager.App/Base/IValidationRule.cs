namespace CarPartsManager.App.Base
{
    using System.Windows.Forms;

    public interface IValidationRule
    {
        string ErrorMessage { get; }

        bool Validate(Control control);
    }
}
