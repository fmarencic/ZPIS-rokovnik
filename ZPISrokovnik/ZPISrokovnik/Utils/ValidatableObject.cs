using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZPISrokovnik.Utils
{
    public class ValidatableObject<T> : BaseViewModel
    {
        private readonly List<IValidationRule<T>> _validations;
        private List<string> _errors;
        private T _value;
        private bool _isValid;

        public List<IValidationRule<T>> Validations => _validations;

        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                SetValue(ref _errors, value);
                OnPropertyChanged(nameof(Errors));
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                SetValue(ref _value, value);
                OnPropertyChanged(nameof(Value));
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                SetValue(ref _isValid, value);
                OnPropertyChanged(nameof(IsValid));
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
    }
}
