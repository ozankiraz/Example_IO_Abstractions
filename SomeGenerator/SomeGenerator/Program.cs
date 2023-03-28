using Microsoft.Extensions.DependencyInjection;

namespace SomeGenerator;

public static class Program
{
    private static ServiceCollection _services;

    public static void Main(string[] args)
    {
        var inputFile = args[0];
        var templateFile = args[1];

        RegisterServices();

        var serviceProvider = _services.BuildServiceProvider();

        var generator = serviceProvider.GetRequiredService<IGenerator>();

        generator.Generate(inputFile, templateFile);
    }

    private static void RegisterServices()
    {
        _services = new ServiceCollection();
        _services.AddTransient<IGenerator, Generator>();
        _services.AddTransient<IInputReader, InputReader>();
    }
}