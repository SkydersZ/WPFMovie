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
using WPFMovieManager.Interfaces;
using WPFMovieManager.Models;
using WPFMovieManager.ViewModels.Abstract;

namespace WPFMovie
{
    /// <summary>
    /// Regroupement de l'ensemble des ViewModel avec leurs IViewModels et distribution du contexte de l'application
    /// pour chacun des modèles.
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Création d'une collection de services.
            ServiceCollection serviceCollection = new ServiceCollection();

            //TODO: Mettre en place un contexte d'application valable (Remplacer le contexte de test.api).
            // Création du contexte de l'application
            serviceCollection.AddSingleton<IDataContext, MovieContext>(sp => new MovieContext("http://test.api"));

            // Création du vue-modèle principal.
            serviceCollection.AddScoped<IViewModelMain, ViewModelMain>(sp => new ViewModelMain(sp));
            serviceCollection.AddScoped<IViewModelMovies, ViewModelMovies>(sp => new ViewModelMovies(sp));
            serviceCollection.AddScoped<IViewModelMyMovies, ViewModelMyMovies>(sp => new ViewModelMyMovies(sp));
            serviceCollection.AddScoped<IViewModelSearch, ViewModelSearch>(sp => new ViewModelSearch());

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = serviceProvider.GetService<IViewModelMain>();
            mainWindow.Show();
        }
    }
}
