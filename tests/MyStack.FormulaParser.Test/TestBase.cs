﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MyStack.FormulaParser.Test
{
    public abstract class TestBase
    {
        protected IServiceProvider ServiceProvider { get; private set; }
        [SetUp]
        public void GetServiceProvider()
        {
            var builder = new HostBuilder()
              .ConfigureHostConfiguration(configure =>
              {
                  configure.SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json");
              })
              .ConfigureServices((context, services) =>
              {
                  services.AddFormulaParser(context.Configuration, configure =>
                  {
                      configure.UseConfigurationIdValue();
                  });
              });

            var app = builder.Build();
            ServiceProvider = app.Services;
        }

    }
}
