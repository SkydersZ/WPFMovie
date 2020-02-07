using Microsoft.Extensions.DependencyInjection;
using MovieMVVM.Interfaces;
using MovieMVVM.Models;
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
using WPFMovie.Views;
using WPFMovieManager.Models;
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
            serviceCollection.AddSingleton<IDataContext, MovieContext>(sp => new MovieContext("http://test.api"));

            // Création du vue-modèle principal.
            serviceCollection.AddScoped<IViewModelMain, ViewModelMain>(sp => new ViewModelMain(sp));
            serviceCollection.AddScoped<IViewModelMovies, ViewModelMovies>(sp => new ViewModelMovies(sp));

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = serviceProvider.GetService<IViewModelMain>();
            mainWindow.Show();
        }
    }
}
