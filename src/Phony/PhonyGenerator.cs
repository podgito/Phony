using Phony.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Phony
{
    /// <summary>
    /// Generates test data for a given class
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class PhonyGenerator<TModel> where TModel : new()
    {
        private Dictionary<PropertyInfo, PropertyValueConfiguration> _configuration;

        private PhonyGenerator()
        {
            _configuration = new Dictionary<PropertyInfo, PropertyValueConfiguration>();
        }

        /// <summary>
        /// Creates an instance of the PhonyGenerator
        /// </summary>
        /// <param name="configuration">The confiuration for creating instances of TModel class</param>
        public PhonyGenerator(Action<PhonyGenerator<TModel>> configuration) : this()
        {
            configuration(this);
        }

        /// <summary>
        /// Setup how this property value will be set to a constant value.
        /// </summary>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="modelProperty"></param>
        /// <param name="constantValue"></param>
        public void Setup<TProp>(Expression<Func<TModel, TProp>> modelProperty, TProp constantValue)
        {
            Setup(modelProperty, () => constantValue);
        }

        /// <summary>
        /// Setup how this property value will be set to the result of a function
        /// </summary>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="modelProperty">The property to be assigned to.</param>
        /// <param name="someFunction">The function of which the result will be set to the value of the property</param>
        public void Setup<TProp>(Expression<Func<TModel, TProp>> modelProperty, Func<TProp> someFunction)
        {
            Setup(modelProperty, someFunction, nullPerentage: 0);
        }

        /// <summary>
        /// Setup how this property value will be set to the result of a function
        /// </summary>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="modelProperty">The property to be assigned to.</param>
        /// <param name="someFunction">The function of which the result will be set to the value of the property</param>
        /// <param name="nullPerentage">The percentage (0-100) of instances set to null (or default of TProp)</param>
        public void Setup<TProp>(Expression<Func<TModel, TProp>> modelProperty, Func<TProp> someFunction, int nullPerentage)
        {
            // 1) Get the member info from expression
            Expression expressionToCheck = modelProperty.Body;
            var memberExpression = ((MemberExpression)expressionToCheck);

            // 2) save
            _configuration.Add((PropertyInfo)memberExpression.Member, new PropertyValueConfiguration(() => someFunction(), nullPerentage));
        }

        /// <summary>
        /// Generates a number of instances of a class with the setup configuration
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
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

                    var step = CalculateNullStep(kvp.Value.NullPercentage);

                    //Set every step number properties to null
                    var value = (i + 1) % step == 0 ? GetDefault(propInfo.PropertyType) : kvp.Value.ValueFunction();
                    propInfo.SetValue(x, value);
                }

                yield return x;
            }
        }

        private object GetDefault(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        private int CalculateNullStep(int nullPercentage)
        {
            if (nullPercentage == 0) return int.MaxValue; //Avoid divide by zero exceptions
            return 100 / nullPercentage;
        }
    }
}