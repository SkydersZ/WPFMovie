using Microsoft.Extensions.DependencyInjection;
using MovieMVVM.Interfaces;
using MovieMVVM.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFMovie.Services;

namespace WPFMovie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IDataContext, BankManagerContext>();

            //ServiceProvider.AddScoped<IOMDbManipulation, OMDbService>();
        }
    }
}
