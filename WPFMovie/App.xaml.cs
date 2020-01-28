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
using WPFMovie.ViewModels;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Création d'une collection de services.
            ServiceCollection serviceCollection = new ServiceCollection();
            
            //TODO: Appeler l'API.

            // Création du contexte de l'application
            serviceCollection.AddScoped<IViewModelMain, ViewModelMain>(sp => new ViewModelMain(sp));
            serviceCollection.AddScoped<IViewModelMovie, ViewModelMovie>(sp => new ViewModelMovie(sp.GetService<IDataContext>()));

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = serviceProvider.GetService<ViewModelMain>();
            mainWindow.Show();
        }
    }
}
