# AtlSimpleInjectorMultiConstructorResolver
A constructor resolver needed to bypass Simple Injector exception for multiple constructurs

Install the package  -

    Install-Package Atl.SimpleInjector.MultiConstructorResolver 

and override the constructor resolver - 

    var container = new Container();
    container.Options.ConstructorResolutionBehavior = new MultiConstructorResolutionBehavior();
