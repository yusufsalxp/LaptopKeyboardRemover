using System.Reflection;
using Autofac;
using Services;
using Services.Contracts;

public static class ContainerService
{
    private static ContainerBuilder _builder = new ContainerBuilder();
    private static IContainer? _container;
    public static void Start()
    {
        var dataAccess = Assembly.GetExecutingAssembly();

        _builder.RegisterAssemblyTypes(dataAccess)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();

        _container = _builder.Build();
    }

    public static T Resolve<T>() where T : notnull
    {
        return _container!.Resolve<T>();
    }
}