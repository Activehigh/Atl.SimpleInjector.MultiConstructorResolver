using System;
using Atl.SimpleInjector.MultiConstructorResolver;
using Xunit;

namespace AtlSimpleInjectorMultiConstructorResolver.Test
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
            var result = _constructorResolutionBehavior.GetConstructor(typeof(A));
            Assert.NotNull(result);
        }
        
        [Fact]
        public void ResolveOneConstructor()
        {
            var result = _constructorResolutionBehavior.GetConstructor(typeof(B));
            Assert.NotNull(result);
        }

        [Fact]
        public void ResolveMulitpleConstructorWithUnEqualParamters()
        {
            var result = _constructorResolutionBehavior.GetConstructor(typeof(C));
            Assert.NotNull(result);
        }

        [Fact]
        public void ResolveMulitpleConstructorWithEqualParamters()
        {
            Assert.Throws<Exception>(() => _constructorResolutionBehavior.GetConstructor(typeof(D)));
        }
    }
}
