﻿namespace CWE
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using CWE.Data;
    using CWE.Data.Context;
    using CWE.Interactive;
    using CWE.Services;
    using Discord;
    using Discord.Addons.Hosting;
    using Discord.WebSocket;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Entry point of the CWE bot.
    /// </summary>
    internal class Program
    {
        private static async Task Main()
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration(x =>
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .Build();

                    x.AddConfiguration(configuration);
                })
                .ConfigureLogging(x =>
                {
                    x.AddConsole();
                    x.SetMinimumLevel(LogLevel.Debug);
                })
                .ConfigureDiscordHost<DiscordSocketClient>((context, config) =>
                {
                    config.SocketConfig = new DiscordSocketConfig
                    {
                        LogLevel = LogSeverity.Verbose,
                        AlwaysDownloadUsers = true,
                        MessageCacheSize = 200,
                    };

                    config.Token = context.Configuration["Token"];
                })
                .UseCommandService()
                .ConfigureServices((context, services) =>
                {
                    services
                    .AddHostedService<CommandHandler>()
                    .AddSingleton<InteractiveService>()
                    .AddDbContext<CWEDbContext>(x =>
                        x.UseMySql(
                            context.Configuration["Database"],
                            new MySqlServerVersion(new Version(8, 0, 23))))
                    .AddSingleton<DataAccessLayer>();
                })
                .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}