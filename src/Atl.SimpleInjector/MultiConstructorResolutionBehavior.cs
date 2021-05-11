using System;
using System.Linq;
using System.Reflection;
using SimpleInjector.Advanced;

namespace Atl.SimpleInjector
{
    /// <summary>
    /// Constructor resolver that return the constructor that has teh highest number of parameters
    /// </summary>
    /// <seealso cref="IConstructorResolutionBehavior" />
    public class MultiConstructorResolutionBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo TryGetConstructor(Type implementationType, out string errorMessage)
        {
	        errorMessage = "";
            var constructors = implementationType.GetConstructors().OrderByDescending(x => x.GetParameters().Length).ToList();
            var constructor = constructors.FirstOrDefault();
            var totalParameters = constructor?.GetParameters().Length;
            if (constructors.Count(x => x.GetParameters().Length == totalParameters) <= 1) return constructor;
            errorMessage =
	            $"Type {implementationType.FullName} has multiple constructors defined with same number of parameters.";
            return default;

        }
    }
}
