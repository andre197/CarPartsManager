namespace CarPartsManager.App.Base
{
    using System.Windows.Forms;
    using System.Collections.Generic;

    public class Validator
    {
        private List<KeyValuePair<Control, IValidationRule>> toBeValidated = new List<KeyValuePair<Control, IValidationRule>>();

        public bool Validate()
        {
            var res = true;
            foreach (var item in toBeValidated)
            {
                ErrorProvider ep = new ErrorProvider();
                if (!item.Value.Validate(item.Key))
                {
                    ep.SetError(item.Key, item.Value.ErrorMessage);
                    res =  false;
                }
            }

            return res;
        }

        public void AddValidation(Control control, IValidationRule rule)
        {
            toBeValidated.Add(new KeyValuePair<Control, IValidationRule>(control, rule));
        }
    }
}
