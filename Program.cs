using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using testC01.FileServices;
using testC01.FileServices.Implements;

namespace testC01
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IMain, Main>();
                    services.AddSingleton<IFileHandle, FileHandle>();
                    services.AddSingleton<IUtilHandle, UtilHandle>();
                })
                .Build();
            var main = ActivatorUtilities.CreateInstance<Main>(host.Services);
            main.Run();
        }
    }
}
