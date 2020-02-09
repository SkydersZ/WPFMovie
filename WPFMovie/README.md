# Projet WPFMovie
Projet réalisé en C# (WPF) et avec Visual Studio.

## Somaire
1. [Outils utilisés](#outils-utilisés)

---

### Outils utilisés

Voici les outils utilisés pour réaliser l'application

#### Language utilisé et plateforme:

* C#
* .NET Core 3.1

#### IDE

* Visual Studio

#### Outil de versionning

* Git & Github

#### Dépendances
- [Mahapps.Metro](https://github.com/MahApps/MahApps.Metro) : Librairie graphique `WPF`.
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) : Librairie de sérialisation au format `JSON`.
- [Microsoft.Extensions.DependencyInjection](https://github.com/aspnet/Extensions) : Librairie d'injection de dépendance.
- CoursWPF.MVVM : Librairie `MVVM` pour `WPF` développée lors du cours. Je l'ai réécrit à la main.

---

## Spécificités

### Stucture du projet

Pour réaliser le projet, je me suis appuyé sur les projets existants que nous avions pu faire lors des heures de cours.

J'ai donc repris pour ma solution, une structure comportant 3 projets distincts:

* MovieHelper qui contient une classe key qui me permet de récupérer l'url de l'API.

* MovieMVVM qui contient la logique de mon application WPF en Model View View-Model

* MovieManager contient la logique métier de la solution, elle fait appel aux deux autres projets pour pouvoir fonctionner.

### Architecture
L'architecture du projet repose sur les principes du modèles `MVVM`.
Le modèle définit trois couches :
- **Modèle** : Logique métier et données de l'application développée en langage `C#`
- **Vue** : Interface utilisateur développée en langage `XAML` et `C#`
- **Vue-modèle** : Logique de présentation développée en langage `C#`

---

## Contenu

### Modèle de données de l'application
Le modèle de données utilisé par l'application est le suivant :

- **`Movie` : Représente un film (deprecated)**
- **`OMDbCompleteMovieObject` : Représente un film issu de l'API OMDb**
- **`OMDbShortMovieObject` : Représente un film issu de l'API OMdb, il possède moins de propriétés que le OMDbCompleteMovieObject**

### Styles
L'application se base principalement sur les styles graphiques définis par `Mahapps`.
Les styles de `Mahapps` sont fusionnés dans le fichier `.\App.xaml`.
L'application définie également sont propre dictionnaire de styles ainsi qu'un dictionnaire de `DataTemplate` (cf. ci-dessous).

``` xml
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml" />
                <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/Themes/Light.Crimson.xaml" />

                <!-- Styles locaux-->
                <ResourceDictionary Source="Resources/Styles.xaml"/>

                <!--Resources-->
                <ResourceDictionary Source="Resources/DataTemplates.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

### Fenêtre principale
La fenêtre principale de l'application n'est pas instanciée en définissant la propriété `App.StartupUri` dans le fichier `.\App.xaml`.
L'instanciation est réalisée dans l'événement `App.Startup` implémenté dans le fichier `.App.xaml.cs` :

``` csharp
public partial class App : Application
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
    }}
}
```

### Liaison entre les vues et les vues-modèles
Le choix du `DataTemplate` utilisé pour représenter chaque vue-modèle est réalisé dans le dictionnaire de ressource `.\Resources\DataTemplates.xaml` :
``` xml
    <DataTemplate DataType="{x:Type viewmodels:ViewModelMovies}">
        <views:MoviesView/>
    </DataTemplate>

    <DataTemplate DataType="{x:Type viewmodels:ViewModelMyMovies}">
        <views:MyMoviesView/>
    </DataTemplate>

    <DataTemplate DataType="{x:Type viewmodels:ViewModelSearch}">
        <views:SearchView/>
    </DataTemplate>
```

Chaque vue-modèle est représenté par un contrôle utilisateur définis dans le dossier `.\Views\`.

### Vue `MoviesView` (deprecated)

La vue `MoviesView` était à base la vue qui devait contenir l'ensemble des films récupérés depuis l'API.
Malheureusement il est n'est pas possible de récupérer l"ensemble des films sans un Nom ou un Id.
Elle est donc délaissé au profit de SearchView.

### Vue `MyMoviesView`

Cette vue devait contenir l'ensemble des films qui aurait été ajouté en favoris depuis la page de recherche de film.
Elle n'a pas été commencé mais existe tout de même dans la vue principale.

### Vue `SearchView`

C'est la vue la plus complète elle contient la recherche des films depuis l'API et dispose d'une vue très simple (Juste une DataGrid).

Cette vue est reliée au `ViewModelSearch.cs` qui permet d'assurer toute la logique de récupération de film et de recherche.

`SearchView.xaml`:
```xml
   <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TextBox Grid.Row="0" Style="{StaticResource placeHolder}" Text="{Binding SearchValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, Delay=1000}" Margin="10 10 10 10" Tag="Rechercher un film"/>
        <ScrollViewer Grid.Row="1" Name="ScrollViewerMovie">
            <Grid Name="GridMovie" ShowGridLines="True">
                <DataGrid ItemsSource="{Binding MovieCollection}" IsReadOnly="True"/>
            </Grid>
        </ScrollViewer>
    </Grid>
```

`ViewModelSearch.cs`:
```csharp
    public class ViewModelSearch : ObservableObject, IViewModelSearch
    {
        #region Champs

        /// <summary>
        /// Service permettant de manipuler l'API.
        /// </summary>
        private readonly OMDbService _OMDbService;

        /// <summary>
        /// Valeur du texte de la Textbox du ViewSearch.
        /// </summary>
        private string _SearchValue;

        #endregion

        #region Propriétés

        /// <summary>
        /// Titre de l'onglet
        /// </summary>
        public string Title => "Rechercher des films";

        /// <summary>
        /// Collection des films
        /// </summary>
        public ObservableCollection<OMDbShortMovieObject> MovieCollection { get; set; }

        /// <summary>
        /// Valeur du texte de la Textbox du ViewSearch 
        /// </summary>
        public string SearchValue
        {
            get { return this._SearchValue; }
            set
            {
                if (this._SearchValue != value)
                {
                    this._SearchValue = value;
                    this.NotifyPropertyChanged(nameof(SearchValue));
                    this.ResfreshDataGridMovie();
                }

            }

        }

        #endregion

        #region Constructeur

        public ViewModelSearch()
        {
            //TODO: Remplacer OMDbService par une injection de dépendance (via une interface).
            this._OMDbService = new OMDbService();

            //TODO: Changer d'API pour pouvoir avoir la liste des films par année.
            this.MovieCollection = this._OMDbService.SearchMovieByName("indiana");
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Rafraîchi la DataGrid en fonction de la recherche
        /// </summary>
        private void ResfreshDataGridMovie()
        {
            if (this.MovieCollection != null)
            {
                this.MovieCollection.Clear();
            }

            ObservableCollection<OMDbShortMovieObject> tempList = this._OMDbService.SearchMovieByName(SearchValue);
            if (tempList != null)
            {
                foreach (OMDbShortMovieObject MovieObject in tempList)
                {
                    this.MovieCollection.Add(MovieObject);
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Handler de l'évènement PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Evènement passé lors d'un changement dans la barre de recherche du film.
        /// </summary>
        /// <param name="propertyName"></param>
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
```

 ---

### DTO

Il existe trois objet **DTO** que j'ai réalisé, le premier est le `OMDbCompleteMovieObject`, il contient l'ensemble
des propriétés d'un film récupéré depuis l'API OMDbMovie.

Le `OMDbMovieSearchList` qui contient l'ensemble des éléments contenu dans la requêtes de recherche de film
depuis l'API. Pour être plus précis, il contient une liste `OMDbShortMovieObject` qui possède les propriétés réduites d'un film.


`OMDbCompleteMovieObject.cs` :
```csharp
    /// <summary>
    /// TODO: Pour l'instant elle n'est pas utilisé, au profil de l'objet "OMDbSearchList" qui est plus léger.
    /// Classe comportant toutes les propriétés d'un film récupéré depuis l'API OMDb.
    /// </summary>
   public class OMDbCompleteMovieObject : Entity
    {
        #region Propriétés
        [JsonProperty("Title")]
        public string Title 
        {
            get => this.Title;
            set => this.SetProperty(nameof(this.Title), () => this.Title, (v) => this.Title = v, value);
        }

        [JsonProperty("Year")]
        public string Year {
            get => this.Year;
            set => this.SetProperty(nameof(this.Year), () => this.Year, (v) => this.Year = v, value);
        }

        [JsonProperty("Rated")]
        public string Rated 
        { 
            get => this.Rated;
            set => this.SetProperty(nameof(this.Rated), () => this.Rated, (v) => this.Rated = v, value);
        }

        [JsonProperty("Released")]
        public string Released {
            get => this.Released; 
            set => this.SetProperty(nameof(this.Released), () => this.Released, (v) => this.Released = v, value);
        }

        [JsonProperty("Runtime")]
        public string Runtime 
        {
            get => this.Runtime;
            set => this.SetProperty(nameof(this.Runtime), () => this.Runtime, (v) => this.Runtime = v, value);
        }

        [JsonProperty("Genre")]
        public string Genre 
        {
            get => this.Genre;
            set => this.SetProperty(nameof(this.Genre), () => this.Genre, (v) => this.Genre = v, value);
        }

        [JsonProperty("Director")]
        public string Director 
        {
            get => this.Director; 
            set => this.SetProperty(nameof(this.Director), () => this.Director, (v) => this.Director = v, value);
        }

        [JsonProperty("Writer")]
        public string Writer 
        {
            get => this.Writer;
            set => this.SetProperty(nameof(this.Writer), () => this.Writer, (v) => this.Writer = v, value);
        }

        [JsonProperty("Actors")]
        public string Actors 
        {
            get => this.Actors;
            set => this.SetProperty(nameof(this.Actors), () => this.Actors, (v) => this.Actors = v, value);
        }

        [JsonProperty("Plot")]
        public string Plot 
        {
            get => this.Plot;
            set => this.SetProperty(nameof(this.Plot), () => this.Plot, (v) => this.Plot = v, value);
        }


        [JsonProperty("Language")]
        public string Language 
        {
            get => this.Language;
            set => this.SetProperty(nameof(this.Language), () => this.Language, (v) => this.Language = v, value);
        }

        [JsonProperty("Country")]
        public string Country 
        {
            get => this.Country;
            set => this.SetProperty(nameof(this.Country), () => this.Country, (v) => this.Country = v, value);
        }

        [JsonProperty("Awards")]
        public string Awards 
        {
            get => this.Awards;
            set => this.SetProperty(nameof(this.Awards), () => this.Awards, (v) => this.Awards = v, value);
        }

        [JsonProperty("Poster")]
        public string Poster 
        {
            get => this.Poster;
            set => this.SetProperty(nameof(this.Poster), () => this.Poster, (v) => this.Poster = v, value);
        }

        [JsonProperty("Metascore")]
        public string Metascore 
        {
            get => this.Metascore;
            set => this.SetProperty(nameof(this.Metascore), () => this.Metascore, (v) => this.Metascore = v, value);
        }

        [JsonProperty("imdbRating")]
        public string imdbRating 
        {
            get => this.imdbRating;
            set => this.SetProperty(nameof(this.imdbRating), () => this.imdbRating, (v) => this.imdbRating = v, value);
        }

        [JsonProperty("imdbVotes")]
        public string imdbVotes 
        {
            get => this.imdbVotes;
            set => this.SetProperty(nameof(this.imdbVotes), () => this.imdbVotes, (v) => this.imdbVotes = v, value);
        }

        [JsonProperty("imdbID")]
        public string imdbID 
        {
            get => this.imdbID;
            set => this.SetProperty(nameof(this.imdbID), () => this.imdbID, (v) => this.imdbID = v, value);
        }

        [JsonProperty("Type")]
        public string Type 
        {
            get => this.imdbID;
            set => this.SetProperty(nameof(this.Type), () => this.Type, (v) => this.Type = v, value);
        }

        [JsonProperty("Production")]
        public string Production
        {
            get => this.Production;
            set => this.SetProperty(nameof(this.Production), () => this.Production, (v) => this.Production = v, value);
        }

        [JsonProperty("Response")]
        public string Response
        {
            get => this.Response;
            set => this.SetProperty(nameof(this.Response), () => this.Response, (v) => this.Response = v, value);
        }

        [JsonProperty("Error")]
        public string Error
        {
            get => this.Error;
            set => this.SetProperty(nameof(this.Error), () => this.Error, (v) => this.Error = v, value);
        }
        #endregion
    }
```

`OMDbShortMovieObject.cs` :
```csharp
    /// <summary>
    /// Contient les propriétés réduite d'un film issu de OMDb
    /// </summary>
   public class OMDbShortMovieObject
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("imdbID")]
        public string imdbID { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

    }
```

`OMDbMovieSearchList.cs` :
```csharp
    /// <summary>
    /// Contient les résultats de recherche d'un film sur OMDb.
    /// </summary>
    public class OMDbMovieSearchList
    {
     [JsonProperty("Search")]
     public ObservableCollection<OMDbShortMovieObject> OMDbMovieObjectList { get; set; }
    
     [JsonProperty("Response")]
    public string Response { get; set; }

    [JsonProperty("Error")]
    public string Error { get; set; }

    } 

```

### Le projet `MovieHelpers`

Le projet `MovieHelpers` contient la classe `Keys.cs` qui contient de simples bouts de string permettant
en les mettants bout à bout de créer une requête URL.

`Keys.cs` :
```csharp
    /// <summary>
    /// Classe comportant toutes les clés de données pour l'API OMDb.
    /// </summary>
    public static class Keys
    {
        #region Propriétés
        public const string ApiKey = "5b1e6913";
        public const string OMDSearchUrl = "http://www.omdbapi.com/?s=";
        public const string OMDbKeyParameter = "&apikey=";
        #endregion
    }
```