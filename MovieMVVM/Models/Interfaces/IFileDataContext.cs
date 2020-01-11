using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVVM.Models.Interfaces
{
    /// <summary>
    /// Interface de contexte de données dans un fichier
    /// </summary>
    interface IFileDataContext : IDataContext
    {
        #region Propriétés

        /// <summary>
        /// Obtient le chemin du fichier de données.
        /// </summary>
        string FilePath { get; }
        #endregion
    }
}
