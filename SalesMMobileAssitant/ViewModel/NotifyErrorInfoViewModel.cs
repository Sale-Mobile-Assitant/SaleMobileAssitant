using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesMMobileAssitant.ViewModel
{
    public class NotifyErrorInfoViewModel : BaseViewModel,INotifyDataErrorInfo
    {
        private string _Prioritize;
        public string Prioritize { get => _Prioritize; set { _Prioritize = value; OnPropertyChanged(); } }






        public NotifyErrorInfoViewModel()
        {
            Validate(nameof(Prioritize));
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            propertyName = "Prioritize";
            base.OnPropertyChanged(propertyName);
            Validate(propertyName);
        }

        private void Validate(string changedPropertyName)
        {
            //Do whatever validation is needed here
            //You can do validation accross multiple properties as well.
            int lol;
            switch (changedPropertyName)
            {
                
                case nameof(Prioritize):
                    if (string.IsNullOrWhiteSpace(Prioritize))
                    {
                        _ValidationErrorsByProperty[nameof(Prioritize)] = new List<object> { " A first name is required." };
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Prioritize)));
                    }
                    
                    else if (int.TryParse(Prioritize, out lol) == false)
                    {
                        _ValidationErrorsByProperty[nameof(Prioritize)] = new List<object> { "Must enter number." };
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Prioritize)));
                    }
                    else if (_ValidationErrorsByProperty.Remove(nameof(Prioritize)))
                    {
                        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(Prioritize)));
                    }
                    break;
               
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (_ValidationErrorsByProperty.TryGetValue(propertyName, out List<object> errors))
            {
                return errors;
            }
            return Array.Empty<object>();
        }


        private readonly Dictionary<string, List<object>> _ValidationErrorsByProperty =
           new Dictionary<string, List<object>>();

        public bool HasErrors => _ValidationErrorsByProperty.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;


    }
}
