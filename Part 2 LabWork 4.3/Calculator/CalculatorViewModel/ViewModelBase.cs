using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Calculator.CalculatorViewModel
{
    public abstract class ViewModelBase<T>
        : INotifyPropertyChanged
    {
        private readonly IDictionary<object, string> _expressionDictionary = new Dictionary<object, string>();
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<TProperty>(ref TProperty field, TProperty value,
            Expression<Func<T, TProperty>> expression)
        {
            field = value;
            OnPropertyChanged(expression);
        }

        private void OnPropertyChanged<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            if (!_expressionDictionary.ContainsKey(expression))
            {
                var propertyName = TypeExtensions<T>.GetProperty(expression);
                _expressionDictionary.Add(expression, propertyName);
            }

            OnPropertyChanged(_expressionDictionary[expression]);
        }
    }
}