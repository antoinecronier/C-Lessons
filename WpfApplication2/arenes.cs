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
    
    public partial class arenes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public arenes()
        {
            this.badges1 = new HashSet<badges>();
            this.positions1 = new HashSet<positions>();
        }
    
        public sbyte id_arene { get; set; }
        public string nom { get; set; }
        public sbyte id_badges { get; set; }
        public int id_positions { get; set; }
    
        public virtual badges badges { get; set; }
        public virtual positions positions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<badges> badges1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<positions> positions1 { get; set; }
    }
}
