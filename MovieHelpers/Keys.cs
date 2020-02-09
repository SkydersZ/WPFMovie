using System;

namespace MovieHelpers
{
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
}
