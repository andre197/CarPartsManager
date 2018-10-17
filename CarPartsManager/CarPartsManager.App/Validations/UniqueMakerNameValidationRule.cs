namespace CarPartsManager.App.Validations
{
    using DAL;
    using System.Linq;
    using System.Windows.Forms;

    public class UniqueMakerNameValidationRule : StringNullOrEmptyValidationRule
    {
        private CarPartsManagerEntities _entity;

        public UniqueMakerNameValidationRule(CarPartsManagerEntities entity)
        {
            _entity = entity;
        }

        public override bool Validate(Control control)
        {
            if (base.Validate(control))
            {
                return !_entity.CarMakers.Any(cm => cm.CarMakerName == control.Text);
            }

            return false;
        }
    }
}
