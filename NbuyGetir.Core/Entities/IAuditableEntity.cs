using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entities
{
    /// <summary>
    /// Denetlenebilir entity, Kimin tarafından Updated,Created yapıldığı bilgisini tutacağız.
    /// </summary>
    public interface IAuditableEntity
    {
        // Bu entity ürün gibi bir nesne ise, bu alanları kesinlikle tutarız.

        /// <summary>
        /// Kim tarafından eklendi
        /// </summary>
        string CreadtedBy { get; set; }
        /// <summary>
        /// Kim update etti
        /// </summary>
        string UpdatedBy { get; set; }
        /// <summary>
        /// Entitynin eklenme tarihi
        /// </summary>
        DateTime CreatedDate { get; set; }
        /// <summary>
        /// Entity update tarihi
        /// </summary>
        DateTime? UpdatedDate { get; set; }

    }
}
