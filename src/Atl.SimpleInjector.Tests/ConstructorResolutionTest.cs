using System;
using Xunit;

namespace Atl.SimpleInjector.Tests
{
    public class ConstructorResolutionTest : IClassFixture<MultiConstructorResolutionBehavior>
    {
        private readonly MultiConstructorResolutionBehavior _constructorResolutionBehavior;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructorResolutionTest"/> class.
        /// </summary>
        /// <param name="constructorResolutionBehavior">The constructor resolution behavior.</param>
        public ConstructorResolutionTest(MultiConstructorResolutionBehavior constructorResolutionBehavior)
        {
            _constructorResolutionBehavior = constructorResolutionBehavior;
        }
        #region Referenced Classes
        public class A
        {
        }

        public class B
        {
            public B()
            {

            }
        }

        public class C
        {
            public C() : this(0)
            {

            }

            public C(int a) : this(0, 0)
            {

            }

            public C(int a, int b)
            {

            }
        }

        public class D
        {
            public D(int a)
            {

            }

            public D(string a)
            {

            }
        }
        #endregion

        [Fact]
        public void ResolveNoConstructor()
        {
            var result = _constructorResolutionBehavior.TryGetConstructor(typeof(A), out var error);
            Assert.Empty(error);
            Assert.NotNull(result);
        }
        
        [Fact]
        public void ResolveOneConstructor()
        {
            var result = _constructorResolutionBehavior.TryGetConstructor(typeof(B), out var error);
            Assert.Empty(error);
            Assert.NotNull(result);
        }

        [Fact]
        public void ResolveMultipleConstructorWithUnEqualParameters()
        {
            var result = _constructorResolutionBehavior.TryGetConstructor(typeof(C), out var error);
            Assert.Empty(error);
            Assert.NotNull(result);
        }

        [Fact]
        public void ResolveMultipleConstructorWithEqualParameters()
        {
	        _constructorResolutionBehavior.TryGetConstructor(typeof(D), out var error);
            Assert.Equal($"Type {typeof(D)} has multiple constructors defined with same number of parameters.", error);
        }
    }
}
