namespace CarPartsManager.App.Validations
{
    using Base;
    using DAL;
    using System.Linq;
    using System.Windows.Forms;

    public class UniqueNumberValidationRule : IValidationRule
    {
        private CarPartsManagerEntities _entity;
        private int _partId;
        private bool _isNew;

        public UniqueNumberValidationRule(CarPartsManagerEntities entity, int partId, bool isNew)
        {
            _entity = entity;
            _partId = partId;
            _isNew = isNew;
        }

        public string ErrorMessage { get; set; }

        public bool Validate(Control control)
        {
            if (control == null)
            {
                return false;
            }
            if (_entity == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(control.Text) || string.IsNullOrWhiteSpace(control.Text))
            {
                return false;
            }

            var carPart = _entity.CarParts.FirstOrDefault(cp => cp.UniqueNumber == control.Text);

            if (_isNew && carPart == null)
            {
                return true;
            }
            else if (!_isNew && carPart != null && carPart.Id == _partId)
            {
                return true;
            }

            return false;
        }
    }
}
