using Microsoft.Extensions.DependencyInjection;
using MovieMVVM.Interfaces;
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
            ServiceCollection ServiceProvider = new ServiceCollection();

            //ServiceProvider.AddScoped<IOMDbManipulation, OMDbService>();
        }
    }
}
