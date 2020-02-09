using MovieHelpers;
using MovieMVVM.Interfaces;
using MovieMVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using WPFMovieManager.Interfaces;
using WPFMovieManager.Models.DTO;

namespace WPFMovie.Services
{
    /// <summary>
    /// Service qui permet de manipuler l'API OMDb
    /// </summary>
    public class OMDbService : IOMDbService
    {

        #region Méthodes

        /// <summary>
        /// Récupère la liste des films par nom
        /// </summary>
        /// <param name="MovieName"></param>
        /// <returns></returns>
        public ObservableCollection<OMDbShortMovieObject> SearchMovieByName(string MovieName)
        {
            string URL = $"{Keys.OMDSearchUrl}{MovieName}{Keys.OMDbKeyParameter}{Keys.ApiKey}";

            ObservableCollection<OMDbShortMovieObject> DataList;

            using (WebClient wc = new WebClient())
            {
                string JsonResult = wc.DownloadString(URL);
                OMDbMovieSearchList dataListFromJson = JsonConvert.DeserializeObject<OMDbMovieSearchList>(JsonResult);
                DataList = dataListFromJson.OMDbMovieObjectList;
            }

            // On supprime l'ensemble des éléments qui ne sont pas des films de la liste.
            if (DataList != null)
            {
                ObservableCollection<OMDbShortMovieObject> SortMovieList = new ObservableCollection<OMDbShortMovieObject>();

                foreach (OMDbShortMovieObject MovieObject in DataList)
                {
                    if (MovieObject.Type == "movie")
                    {
                        SortMovieList.Add(MovieObject);

                    }
                }

                DataList = SortMovieList;

                return DataList;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
