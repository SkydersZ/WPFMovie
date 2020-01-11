using System;
using System.Collections.Generic;
using System.Text;

namespace MovieMVVM.Models.Interfaces
{
    /// <summary>
    /// Interface d'une entité avec identifiant
    /// </summary>
    interface IEntity
    {
        #region Propriétés

        /// <summary>
        /// Obtient ou défini l'identifiant de l'élément
        /// </summary>
        long Identifier { get; set; }
        #endregion
    }
}
