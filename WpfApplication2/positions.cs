//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class positions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public positions()
        {
            this.arenes = new HashSet<arenes>();
        }
    
        public int id_positions { get; set; }
        public Nullable<int> x { get; set; }
        public Nullable<int> y { get; set; }
        public sbyte id_zones { get; set; }
        public Nullable<sbyte> id_arene { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<arenes> arenes { get; set; }
        public virtual arenes arenes1 { get; set; }
        public virtual zones zones { get; set; }
    }
}
