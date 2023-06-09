﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ssg.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {		

		protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

			// add new stuff
			var services = new ServiceCollection();
			services.AddTransient<MainWindow>();

			// Add DI for Configuration
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			IConfiguration config = builder.Build();
			services.AddSingleton(config);

			var serviceProvider = services.BuildServiceProvider();
			var mainWindow = serviceProvider.GetService<MainWindow>();

			mainWindow.Show();

		}
    }
}
