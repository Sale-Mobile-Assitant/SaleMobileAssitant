using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.ViewModel
{
    public class AnnotationValidationViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, PropertyInfo> _Properties;
        private readonly Dictionary<string, List<object>> _ValidationErrorsByProperty =
            new Dictionary<string, List<object>>();
        public bool HasErrors => _ValidationErrorsByProperty.Any();
        protected AnnotationValidationViewModel()
        {
            _Properties = GetType().GetProperties().ToDictionary(x => x.Name);
        }


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {

            if (_ValidationErrorsByProperty.TryGetValue(propertyName, out List<object> errors))
            {
                return errors;
            }
            return Array.Empty<object>();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            ValidateProperty(propertyName);
        }
        public bool ValidateModel()
        {
            bool rv = true;
            foreach (string propertyName in _Properties.Keys)
            {
                rv &= ValidateProperty(propertyName);
            }
            return rv;
        }

        public bool ValidateProperty(string propertyName)
        {
            if (_Properties.TryGetValue(propertyName, out PropertyInfo propInfo))
            {
                var errors = new List<object>();
                foreach (var attribute in propInfo.GetCustomAttributes<ValidationAttribute>())
                {
                    if (!attribute.IsValid(propInfo.GetValue(this)))
                    {
                        errors.Add(attribute.FormatErrorMessage(propertyName));
                    }
                }

                if (errors.Any())
                {
                    _ValidationErrorsByProperty[propertyName] = errors;
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                    return false;
                }
                if (_ValidationErrorsByProperty.Remove(propertyName))
                {
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }

            return true;
        }
    }
}
