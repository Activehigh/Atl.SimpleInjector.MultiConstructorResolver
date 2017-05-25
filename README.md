# AtlSimpleInjectorMultiConstructorResolver
A constructor resolver needed to bypass Simple Injector exception for multiple constructurs

Install the package and override the consturctor resolver - 

    var container = new Container();
    container.Options.ConstructorResolutionBehavior = new MultiConstructorResolutionBehavior();
