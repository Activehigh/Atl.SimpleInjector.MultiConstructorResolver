using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector.Advanced;

namespace Atl.SimpleInjector.MultiConstructorResolver
{
    /// <summary>
    /// Constructor resolver that return the constructor that has teh highest number of parameters
    /// </summary>
    /// <seealso cref="IConstructorResolutionBehavior" />
    public class MultiConstructorResolutionBehavior : IConstructorResolutionBehavior
    {
        /// <summary>
        /// Gets the constructor.
        /// </summary>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <returns></returns>
        public ConstructorInfo GetConstructor(Type implementationType)
        {
            var constructors = implementationType.GetConstructors().OrderByDescending(x => x.GetParameters().Length);
            var constructor = constructors.FirstOrDefault();
            var totalParameters = constructor?.GetParameters().Length;
            if (constructors.Count(x => x.GetParameters().Length == totalParameters) > 1)
                throw new Exception($"Type {implementationType.Namespace} has multiple constructors defined with same number of paramters.");
            return constructor;
        }
    }
}
