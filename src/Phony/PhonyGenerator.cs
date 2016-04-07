using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Phony
{
    public class PhonyGenerator<TModel> where TModel : new()
    {
        private Dictionary<PropertyInfo, Func<object>> _configuration;

        protected PhonyGenerator()
        {
            _configuration = new Dictionary<PropertyInfo, Func<object>>();
        }

        public PhonyGenerator(Action<PhonyGenerator<TModel>> configuration) : this()
        {
            configuration(this);
        }

        public void Setup<TProp>(Expression<Func<TModel, TProp>> modelProperty, TProp constantValue)
        {
            Setup(modelProperty, () => constantValue);
        }

        public void Setup<TProp>(Expression<Func<TModel, TProp>> modelProperty, Func<TProp> someFunction)
        {
            // 1) Get the member info from expression
            Expression expressionToCheck = modelProperty.Body;
            var memberExpression = ((MemberExpression)expressionToCheck);

            // 2) save
            _configuration.Add((PropertyInfo)memberExpression.Member, () => someFunction());
        }

        public IEnumerable<TModel> Generate(int count)
        {
            if (count < 0)
            {
                throw new ArgumentException("Count must be zero or greater");
            }

            for (int i = 0; i < count; i++)
            {
                var x = new TModel();

                foreach (var kvp in _configuration)
                {
                    var propInfo = kvp.Key;

                    propInfo.SetValue(x, kvp.Value());
                }

                yield return x;
            }
        }
    }
}