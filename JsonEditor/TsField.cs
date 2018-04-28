using System.ComponentModel.DataAnnotations;
using TestSuite.Base;

namespace JsonEditor
{
    public class TsField<T> : ValidatableBindableBase
    {
        private bool _IsActive = true;
        [Required]
        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                SetProperty(ref _IsActive, value);
            }
        }

        private string _name;
        [Required]
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                SetProperty(ref _value, value);
            }
        }

        //public override string ToString()
        //{
        //    if (typeof(T) == typeof(string))
        //    {
        //        return Value.ToString();
        //    }
        //    else
        //    {
        //        return Name;
        //    }
        //}
    }
}