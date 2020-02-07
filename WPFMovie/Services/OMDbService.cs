using MovieHelpers;
using MovieMVVM.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net;
using WPFMovieManager.Models.DTO;

namespace WPFMovie.Services
{
    public class OMDbService : IOMDbManipulation<OMDbMovieObject>
    {
        public ObservableCollection<OMDbMovieObject> SearchMovieByName(string Name)
        {
            string URL = $"{Keys.OMDSearchUrl}{Keys.OMDbKeyParameter}{Keys.ApiKey}";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(URL);
                ObservableCollection<OMDbMovieObject> obj = JsonConvert.DeserializeObject<ObservableCollection<OMDbMovieObject>>(json);

                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
